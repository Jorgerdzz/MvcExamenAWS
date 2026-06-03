using Microsoft.EntityFrameworkCore;
using MvcExamenAWS.Models;

namespace MvcExamenAWS.Data
{
    public class ZapatillasContext : DbContext
    {
        public ZapatillasContext(DbContextOptions options) : base(options) { }

        public DbSet<Zapatilla> Zapatillas { get; set; }
    }
}
