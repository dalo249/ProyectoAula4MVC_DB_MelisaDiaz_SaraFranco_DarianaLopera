using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProyectoAula4MVC.Models;
using ProyectoAula4MVC.Models.DB;
using ProyectoAula4MVC.Models.ViewModels;
using System.Net;

namespace ProyectoAula4MVC.Controllers
{
    public class IdeasDeNegocioController : Controller
    {
        IdeasDeNegocioDTO ideasDTO = new IdeasDeNegocioDTO();
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
                while(impacto == null)
                {
                    impacto = ideasDTO.crearImpacto(model.Impacto.ToLower());
                }

                Herramientas4RI herramienta = ideasDTO.buscarHerramientaByNombre(model.Herramienta4RI.ToLower());
                while(herramienta == null)
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

        //GET: Muesta toda la informacion de una idea.
        [HttpGet]
        public ActionResult DetallesIdea(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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
    }
}