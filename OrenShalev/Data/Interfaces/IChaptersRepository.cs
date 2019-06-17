using System.Collections.Generic;
using System.Threading.Tasks;
using OrenShalev.Models;

namespace OrenShalev.Data.Interfaces
{
    public interface IChaptersRepository
    {
        Task<List<Chapter>> GetAllChaptersAsync();
    }
}