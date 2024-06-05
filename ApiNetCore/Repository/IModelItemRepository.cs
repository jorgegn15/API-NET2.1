using ApiNetCore.Models;
using System.Threading.Tasks;

namespace ApiNetCore.Repository
{
    public interface IModelItemRepository
    {
        Task AddModelItem(ModelItem model);
    }
}
