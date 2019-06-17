using System.Threading.Tasks;
using OrenShalev.Models;

namespace OrenShalev.Data.Interfaces
{
    public interface IRootsRepository
    {
        Task<Root> UpdateRootAsync(Root upRoot);
    }
}