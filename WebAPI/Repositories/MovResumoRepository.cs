using Infrastructure.DataBase;
using Microsoft.Extensions.Options;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class MovResumoRepository : BaseRepository<MovResumo>
    {
        public MovResumoRepository(IOptions<Settings> options) : base(options)
        {
        }
    }
}
