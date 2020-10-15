using Microsoft.EntityFrameworkCore;
using WolfPack.Models;

namespace WolfPack.Data
{
    public class WolvesContext:DbContext
    {
        public WolvesContext(DbContextOptions<WolvesContext> opt):base(opt)
        {
            
        }

        public DbSet<Wolf> Wolves { get; set; }    
        public DbSet<Pack> Packs { get; set; }   
    
    }
}