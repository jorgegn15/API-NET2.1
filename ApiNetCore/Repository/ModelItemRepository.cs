using ApiNetCore.DataAccess;
using ApiNetCore.Models;
using System.Threading.Tasks;

namespace ApiNetCore.Repository
{
    public class ModelItemRepository: IModelItemRepository
    {
        private readonly IBBDDContext _context;
        public ModelItemRepository(IBBDDContext context)
        {
            _context = context;
        }

        public async Task AddModelItem(ModelItem model)
        {
            await _context.ModelItem.AddAsync(model);
            await _context.SaveChangesAsync();
        }
    }
}
