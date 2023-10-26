using ProyectoAula4MVC.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProyectoAula4MVC.Models.ViewModels;
using ProyectoAula4MVC.Models;

namespace ProyectoAula4MVC.Controllers
{
    public class EstadisticasController : Controller
    {
        private AnalizadorEstadisticasDTO analizadorDTO = new AnalizadorEstadisticasDTO();

        // GET: Estadisticas Obtiene datos proveniente de base de datos desde el modelo
        public ActionResult Index()
        {
            List<DetallesIdeaViewModel> ideasMas3Deptos = analizadorDTO.ideasMas3Departamentos();
            List<Ideas_De_Negocio> ideasMayorRentabilidad = analizadorDTO.ideasMayorRentabilidad();
            List<Ideas_De_Negocio> ideasUsanDesarrolloSostenible = analizadorDTO.ideasUsanDesarrolloSostenible();
            List<Ideas_De_Negocio> ideasRentabilidadMayorPromedio = analizadorDTO.ideasRentabilidadMayorPromedio();
            List<Ideas_De_Negocio> ideasUsanTerritoriosOTransicion = analizadorDTO.ideasUsanTerritoriosOTransicion();
            DetallesIdeaViewModel ideaMayorDeptos = analizadorDTO.ideaMayorDepartamentos();
            Ideas_De_Negocio ideaMayorTotalIngresos = analizadorDTO.ideaMayorTotalIngresos();
            Ideas_De_Negocio ideaMayorInversionInfraestructura = analizadorDTO.ideaMayorInversionInfraestructura();
            decimal sumaTotalInversiones = analizadorDTO.sumarValorInversiones();
            decimal sumaTotalIngresos = analizadorDTO.sumarTotalIngresos();
            int totalIdeasUsanIA = analizadorDTO.ContarIdeasUsanIA();

            EstadisticasViewModel estadisticas = new EstadisticasViewModel(ideasMas3Deptos, ideasMayorRentabilidad, ideasUsanDesarrolloSostenible,
               ideasRentabilidadMayorPromedio, ideasUsanTerritoriosOTransicion, ideaMayorDeptos, ideaMayorTotalIngresos, ideaMayorInversionInfraestructura,
               sumaTotalInversiones, sumaTotalIngresos, totalIdeasUsanIA);

            return View(estadisticas);





        }
        

        
    }
}