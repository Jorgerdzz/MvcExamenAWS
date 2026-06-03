using Microsoft.AspNetCore.Mvc;
using MvcExamenAWS.Models;
using MvcExamenAWS.Repositories;
using MvcExamenAWS.Services;

namespace MvcExamenAWS.Controllers
{
    public class ZapatillasController : Controller
    {
        private RepositoryZapatillas repo;
        private ServiceBucketS3 service;

        public ZapatillasController(RepositoryZapatillas repo, ServiceBucketS3 service)
        {
            this.repo = repo;
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Zapatilla> zapatillas = await this.repo.GetZapatillasAsync();
            return View(zapatillas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Zapatilla zapa, IFormFile file)
        {
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(file.FileName, stream);
            }
            zapa.Imagen = file.FileName;
            await this.repo.CreateZapatillaAsync(zapa.Nombre, zapa.Descripcion, zapa.Imagen);
            return RedirectToAction("Index");
        }
    }
}
