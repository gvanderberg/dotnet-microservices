using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo.Common;
using Demo.Common.Repository;

using Microsoft.Extensions.Logging;

using StackExchange.Redis;

namespace Demo.RedisDb
{
    public class RedisRepository<T> : IRepository<T> where T : class
    {
        private readonly IDatabase _database;

        private readonly ILogger<RedisRepository<T>> _logger;

        public RedisRepository(IDatabase database, ILogger<RedisRepository<T>> logger)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private static string InstanceName()
        {
            var type = typeof(T);

            return $"{type.FullName}:";
        }

        private static string Key(Guid id)
        {
            return $"{InstanceName()}{id:N}";
        }

        private static string SetName()
        {
            return $"{InstanceName()}Set";
        }

        public async Task CreateAsync(T aggregate)
        {
            var key = Key(Guid.Empty);
            var serialised = ModelManager.ModelToJson(aggregate);
            var transaction = _database.CreateTransaction();

            await transaction.StringSetAsync(key, serialised).ConfigureAwait(false);
            //await transaction.SetAddAsync(SetName(), t.Id.ToString("N"));

            var committed = await transaction.ExecuteAsync().ConfigureAwait(false);

            if (!committed)
            {
                throw new ApplicationException("transaction failed. Now what?");
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var query = new RedisValue[] { InstanceName() + "*" };
            var result = await _database.SortAsync(SetName(), sortType: SortType.Alphabetic, by: "nosort", get: query).ConfigureAwait(false);
            var readObjects = result.Select(v => ModelManager.JsonToModel<T>(v)).ToList();

            return readObjects.AsReadOnly();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var key = Key(id);
            var value = await _database.StringGetAsync(key).ConfigureAwait(false);

            if (value.HasValue)
            {
                return ModelManager.JsonToModel<T>(value);
            }

            return default;
        }

        public async Task UpdateAsync(Guid id, T aggregate)
        {
            var key = Key(id);
            var serialised = ModelManager.ModelToJson(aggregate);

            await _database.StringSetAsync(key, serialised, when: When.Exists).ConfigureAwait(false);
        }
    }
}