using Concactly.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Concactly.Data
{
    public class ContactlyDbContext:DbContext
    {
        public ContactlyDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
