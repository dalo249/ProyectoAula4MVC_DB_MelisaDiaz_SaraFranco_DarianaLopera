using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProyectoAula4MVC.Models;
using ProyectoAula4MVC.Models.DB;
using ProyectoAula4MVC.Models.ViewModels;
using System.Net;
using System.Web.UI.WebControls;

namespace ProyectoAula4MVC.Controllers
{
    public class IdeasDeNegocioController : Controller
    {
        private IdeasDeNegocioDTO ideasDTO = new IdeasDeNegocioDTO();
        private ProyectoAula4MVC_DBEntities db = new ProyectoAula4MVC_DBEntities();

        // GET: Muestra lista global de ideas de negocio
        public ActionResult Index()
        {
            var ideas_De_Negocio = db.Ideas_De_Negocio.Include(i => i.Herramientas4RI).Include(i => i.Impactos);
            return View(ideas_De_Negocio.ToList());

        }

        //GET: formulario registrar idea
        [HttpGet]
        public ActionResult RegistrarIdea()
        {
            return View();
        }

        //POST: Registra y agrega idea a base de datos
        [HttpPost]
        public ActionResult RegistrarIdea(RegistroIdeaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (model.Departamentos.Count == 0)
                {
                    return View(model);
                }

                List<Departamentos> departamentos = new List<Departamentos>();
                foreach (var depto in model.Departamentos)
                {
                    Departamentos departamento = ideasDTO.buscarDepartamentoByNombre(depto.ToLower());
                    while (departamento == null)
                    {
                        departamento = ideasDTO.crearDepartamento(depto.ToLower());
                    }
                    departamentos.Add(departamento);
                }

                Impactos impacto = ideasDTO.buscarImpactoByNombre(model.Impacto.ToLower());
                while (impacto == null)
                {
                    impacto = ideasDTO.crearImpacto(model.Impacto.ToLower());
                }

                Herramientas4RI herramienta = ideasDTO.buscarHerramientaByNombre(model.Herramienta4RI.ToLower());
                while (herramienta == null)
                {
                    herramienta = ideasDTO.crearHerramienta(model.Herramienta4RI.ToLower());
                }

                Ideas_De_Negocio idea = ideasDTO.crearIdeaDeNegocio(model, impacto, herramienta);
                ideasDTO.crearDepartamentosIdea(departamentos, idea);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }

        }

        //GET: Muestra toda la informacion de una idea.
        [HttpGet]
        public ActionResult DetallesIdea(int? id)
        {

            Ideas_De_Negocio idea = ideasDTO.buscarIdeaById(id);
            if (idea == null)
            {
                return HttpNotFound();
            }

            List<Departamentos_Idea> deptosIdea = ideasDTO.buscarDepartamentosDeIdea(idea.ID_Idea);
            DetallesIdeaViewModel ideaConDeptos = new DetallesIdeaViewModel()
            {
                Idea = idea,
                Departamentos = deptosIdea,
            };
            return View(ideaConDeptos);
        }

        //GET: Muestra formulario para editar una idea.
        [HttpGet]
        public ActionResult EditarIdea(int Id)
        {

            Ideas_De_Negocio idea = ideasDTO.buscarIdeaById(Id);
            if (idea == null)
            {
                return HttpNotFound();
            }

            EditarIdeaViewModel model = new EditarIdeaViewModel();
            model.IdIdea = idea.ID_Idea;
            model.ValorInversion = idea.Valor_Inversion;
            model.TotalIngresos = idea.Total_Ingresos;
            model.Integrantes = new List<IntegranteViewModel>();


            return View(model);
        }

        //POST: Cambia los valores editados de la idea.
        [HttpPost]
        public ActionResult EditarIdea(EditarIdeaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Ideas_De_Negocio idea = ideasDTO.buscarIdeaById(model.IdIdea);
            if (idea == null)
            {
                return HttpNotFound();
            }

            ideasDTO.editarIdea(model, idea);

            if (model.Integrantes.Count == 0)
            {
                return RedirectToAction("DetallesIdea", new { id = model.IdIdea });
            }

            foreach (var integrante in model.Integrantes)
            {
                ideasDTO.crearIntegrante(model.IdIdea, integrante);
            }

            return RedirectToAction("DetallesIdea", new { id = model.IdIdea });
        }

        [HttpGet]
        public ActionResult EliminarIntegrante(int idIntegrante) 
        {
            Integrantes integrante = ideasDTO.buscarIntegranteaById(idIntegrante);
            if (integrante == null)
            {
                return HttpNotFound();
            }

            ideasDTO.eliminarIntegrante(integrante);

            return RedirectToAction("DetallesIdea", new { id = integrante.ID_Idea });
        }
    }
}