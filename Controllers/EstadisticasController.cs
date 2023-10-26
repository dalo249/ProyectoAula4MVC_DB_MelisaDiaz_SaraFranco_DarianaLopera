using ProyectoAula4MVC.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ProyectoAula4MVC.Controllers
{
    public class EstadisticasController : Controller
    {
        private ProyectoAula4MVC_DBEntities db = new ProyectoAula4MVC_DBEntities();

        // GET: Estadisticas Obtiene datos proveniente de base de datos desde el modelo
        public ActionResult Index()
        {
            var ideas_De_Negocio = db.Ideas_De_Negocio.Include(i => i.Herramientas4RI).Include(i => i.Impactos);
            return View();
        }
    }
}