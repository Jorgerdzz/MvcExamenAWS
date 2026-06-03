using Microsoft.EntityFrameworkCore;
using MvcExamenAWS.Data;
using MvcExamenAWS.Models;

namespace MvcExamenAWS.Repositories
{
    public class RepositoryZapatillas
    {
        private ZapatillasContext context;

        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }

        public async Task<List<Zapatilla>> GetZapatillasAsync()
        {
            return await this.context.Zapatillas.ToListAsync();
        }

        public async Task CreateZapatillaAsync(string nombre, string descripcion, string imagen)
        {
            Zapatilla z = new Zapatilla();
            z.IdProducto = await this.GetMaxIdZapatillaAsync() + 1;
            z.Nombre = nombre;
            z.Descripcion = descripcion;
            z.Imagen = imagen;

            await this.context.Zapatillas.AddAsync(z);
            await this.context.SaveChangesAsync();
        }

        private async Task<int> GetMaxIdZapatillaAsync()
        {
            return await this.context.Zapatillas.MaxAsync(z => z.IdProducto);
        }

    }
}
