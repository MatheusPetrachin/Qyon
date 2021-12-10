using Microsoft.EntityFrameworkCore;

namespace QyonAdventureWorks.Api.Model
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        { }

        public virtual DbSet<PistaCorrida> PistaCorridas { get; set; }
        public virtual DbSet<HistoricoCorrida> HistoricoCorridas { get; set; }
        public virtual DbSet<Competidor> Competidores { get; set; }
    }
}
