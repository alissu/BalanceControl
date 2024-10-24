using Infrastructure.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Infrastructure.DataBase
{
    public class BaseRepository<TModel> where TModel : BaseModel
    {
        public BaseRepository(IOptions<Settings> options)
        {
            var dataBase = new MongoClient(options.Value.ConnectionString)
                .GetDatabase(options.Value.DatabaseName);

            var collectionName = nameof(TModel);
            _collection = dataBase.GetCollection<TModel>(collectionName);
            Query = _collection.AsQueryable();
        }

        protected readonly IQueryable<TModel> Query;
        private readonly IMongoCollection<TModel> _collection;

        public async Task<TModel> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Query.Where(w => w.Id == id).SingleAsync(cancellationToken);
        }

        public async Task<List<TModel>> GetAsync(CancellationToken cancellationToken)
        {
            return await Query.ToListAsync(cancellationToken);
        }

        public async Task InsertAsync(TModel model, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(model, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(TModel model, CancellationToken cancellationToken)
        {
            await _collection.ReplaceOneAsync(w => w.Id == model.Id, model, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _collection.DeleteOneAsync(w => w.Id == id, cancellationToken: cancellationToken);
        }
    }
}
