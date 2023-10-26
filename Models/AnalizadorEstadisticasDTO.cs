using ProyectoAula4MVC.Models.DB;
using ProyectoAula4MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoAula4MVC.Models
{
    public class AnalizadorEstadisticasDTO
    {

        private ProyectoAula4MVC_DBEntities db = new ProyectoAula4MVC_DBEntities();
        private IdeasDeNegocioDTO ideasDTO = new IdeasDeNegocioDTO();
       

        public DetallesIdeaViewModel ideaMayorDepartamentos()
        {
            var idIdea = db.Departamentos_Idea
                .GroupBy(i => i.ID_Idea)
                .OrderByDescending(grupo => grupo.Count())
                .Select(grupo => grupo.Key)
                .FirstOrDefault();

            Ideas_De_Negocio idea = db.Ideas_De_Negocio.Find(idIdea);
            List<Departamentos_Idea> deptosIdea = ideasDTO.buscarDepartamentosDeIdea(idea.ID_Idea);
            DetallesIdeaViewModel ideaConDeptos = new DetallesIdeaViewModel()
            {
                Idea = idea,
                Departamentos = deptosIdea,
            };
            return ideaConDeptos;
        }

        public List<DetallesIdeaViewModel> ideasMas3Departamentos()
        {
            var idIdeas = db.Departamentos_Idea
                .GroupBy(i => i.ID_Idea)
                .Where(grupo => grupo.Count() > 3)
                .Select(grupo => grupo.Key)
                .ToList();

            List<DetallesIdeaViewModel> listIdeasConDeptos = new List<DetallesIdeaViewModel>();
            foreach (var id in idIdeas)
            {
                Ideas_De_Negocio idea = db.Ideas_De_Negocio.Find(id);
                List<Departamentos_Idea> deptosIdea = ideasDTO.buscarDepartamentosDeIdea(idea.ID_Idea);
                DetallesIdeaViewModel ideaConDeptos = new DetallesIdeaViewModel()
                {
                    Idea = idea,
                    Departamentos = deptosIdea,
                };
                listIdeasConDeptos.Add(ideaConDeptos);
            }
            return listIdeasConDeptos;
        }

        public Ideas_De_Negocio ideaMayorTotalIngresos() 
        {
            var idea = db.Ideas_De_Negocio
                .OrderByDescending(i => i.Total_Ingresos)
                .FirstOrDefault();

            return idea;
        }

        public List<Ideas_De_Negocio> ideasMayorRentabilidad()
        {
            var listIdeas = db.Ideas_De_Negocio
                .OrderByDescending(i => i.Total_Ingresos)
                .Take(3)
                .ToList();

            return listIdeas;
        }

        public int ContarIdeasUsanIA() 
        {
            int ideasUsanIA = db.Ideas_De_Negocio
                .Where(i => i.Herramientas4RI.Nombre.Contains("inteligencia artificial"))
                .Count();

            return ideasUsanIA;
        }

        public List<Ideas_De_Negocio> ideasUsanDesarrolloSostenible() 
        {
            var listIdeas = db.Ideas_De_Negocio
                .Where(i => i.Impactos.Nombre.Contains("desarrollo sostenible"))
                .ToList();
            return listIdeas;
        }

        public List<Ideas_De_Negocio> ideasRentabilidadMayorPromedio() 
        {
            decimal promedio = db.Ideas_De_Negocio.Average(i => i.Total_Ingresos);
            var listIdeas = db.Ideas_De_Negocio
                .Where(i => i.Total_Ingresos > promedio)
                .ToList();

            return listIdeas;
        }

        public Ideas_De_Negocio ideaMayorInversionInfraestructura() 
        {
            var idea = db.Ideas_De_Negocio
                .OrderByDescending(i => i.Valor_Inversion_Infraestructura)
                .FirstOrDefault();
            return idea;
        }

        public List<Ideas_De_Negocio> ideasUsanTerritoriosOTransicion() 
        {
            var listIdeas = db.Ideas_De_Negocio
                .Where(i => i.Impactos.Nombre.Contains("transicion energetica") || i.Impactos.Nombre.Contains("territorios inteligentes"))
                .ToList();
            return listIdeas;
        }

        public decimal sumarValorInversiones()
        {
            var totalInversiones = db.Ideas_De_Negocio
                .Sum(i => i.Valor_Inversion);

            return totalInversiones;
        }

        public decimal sumarTotalIngresos()
        {
            var totalIngresos = db.Ideas_De_Negocio
                .Sum(i => i.Total_Ingresos);

            return totalIngresos;
        }
    }
}