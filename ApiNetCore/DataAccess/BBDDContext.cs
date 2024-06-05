using ApiNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNetCore.DataAccess
{
    public class BBDDContext: DbContext, IBBDDContext
    {
        public BBDDContext(DbContextOptions<BBDDContext> options): base(options)
        {
            
        }
        public DbSet<ModelItem> ModelItem { get; set; }
    }
}
