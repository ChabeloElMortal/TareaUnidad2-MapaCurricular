using Microsoft.AspNetCore.Mvc;
using TareaUnidad2.Models;
using TareaUnidad2.Models.ViewModels;

namespace TareaUnidad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var carreras = context.Carreras.OrderBy(x => x.Nombre)
                .Select(x => new HomeViewModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Plan = x.Plan
                }).ToList();

            return View(carreras);
        }

        MapaCurricularContext context = new MapaCurricularContext();


        public IActionResult Info(int id)
        {
            var info = context.Carreras.FirstOrDefault(x => x.Id == id);
            if (info == null)
            {
                return RedirectToAction("Index");
            }
            return View(info);
        }

        public IActionResult Mapa(int id)
        {
            var carrera = context.Carreras.FirstOrDefault(x => x.Id == id);
            carrera.Materias=context.Materias.Where(x=>x.IdCarrera==id).ToList();
            if (carrera == null)
            {
                return RedirectToAction("Index");
            }
            var mapa = new HomeViewModel
            {
                Id = carrera.Id,
                Nombre = carrera.Nombre,
                Plan = carrera.Plan,
                Creditos = carrera.Materias.Sum(x => x.Creditos)

            };
            var semestres = new List<SemestreModel>();
            for (int i = 1; i <= 9; i++)
            {
                var semestre = new SemestreModel
                {
                    NumSemestre = i,
                    Semestre = $"{i} semestre",
                    Materias = new List<MateriasModel>()

                };
                semestre.Materias=carrera.Materias.Where(x => x.Semestre == i).
                    Select(x=> new MateriasModel
                    {
                        Clave = x.Clave,
                        Creditos = x.Creditos,
                        HorasPracticas = x.HorasPracticas,
                        HorasTeoricas = x.HorasTeoricas,
                        Nombre = x.Nombre
                    }).ToList();

                semestres.Add(semestre);

            }
            mapa.Semestres = semestres;
            return View(mapa);
        }
    }
}
