using ProyectoAula4MVC.Models.DB;
using ProyectoAula4MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ProyectoAula4MVC.Models
{
    public class IdeasDeNegocioDTO
    {
        private ProyectoAula4MVC_DBEntities db = new ProyectoAula4MVC_DBEntities();


        public Departamentos buscarDepartamentoByNombre(string nombreDepartamento)
        {
            Departamentos departamento = db.Departamentos.FirstOrDefault(i => i.Nombre == nombreDepartamento);
            return departamento;
        }

        public Departamentos crearDepartamento(string nombreDepartamento) 
        {
            Departamentos departamento = new Departamentos() 
            {
                Nombre = nombreDepartamento,
            };
            db.Departamentos.Add(departamento);
            db.SaveChanges();
            return departamento;
        }

        public Impactos buscarImpactoById(int id) 
        {
            Impactos impacto = db.Impactos.Find(id);
            return impacto;
        }
        public Impactos buscarImpactoByNombre(string nombreImpacto) 
        {
            Impactos impacto = db.Impactos.FirstOrDefault( i => i.Nombre == nombreImpacto );  
            return impacto;
        }

        public Impactos crearImpacto(string nombreImpacto) 
        {
            Impactos impacto = new Impactos()
            {
                Nombre = nombreImpacto
            };
            db.Impactos.Add(impacto);
            db.SaveChanges();
            return impacto;
            
        }

        public Herramientas4RI buscarHerramientaById(int id)
        {
            Herramientas4RI herramienta = db.Herramientas4RI.Find(id);
            return herramienta;
        }

        public Herramientas4RI buscarHerramientaByNombre(string nombreHerramienta)
        {
            Herramientas4RI herramienta = db.Herramientas4RI.FirstOrDefault(i => i.Nombre == nombreHerramienta);
            return herramienta;
        }

        public Herramientas4RI crearHerramienta(string nombreHerramienta) 
        {
            Herramientas4RI herramienta = new Herramientas4RI()
            {
                Nombre = nombreHerramienta
            };
            db.Herramientas4RI.Add(herramienta);
            db.SaveChanges();
            return herramienta;
        }

        public Ideas_De_Negocio buscarIdeaById(int? id) 
        {
            Ideas_De_Negocio idea = db.Ideas_De_Negocio.Find(id);
            return idea;
        }

        public Ideas_De_Negocio crearIdeaDeNegocio(RegistroIdeaViewModel model, Impactos impacto, Herramientas4RI herramienta) 
        {
            Ideas_De_Negocio idea = new Ideas_De_Negocio();
            idea.Nombre = model.Nombre;
            idea.ID_Impacto = impacto.ID_Impacto;
            idea.Valor_Inversion = model.ValorInversion;
            idea.Valor_Inversion_Infraestructura = model.ValorInversionInfraestructura;
            idea.Total_Ingresos = model.TotalIngresos;
            idea.ID_Herramienta = herramienta.ID_Herramienta;
            db.Ideas_De_Negocio.Add(idea);
            db.SaveChanges();

            return idea;
            
        }

        public void crearDepartamentosIdea(List<Departamentos> departamentos, Ideas_De_Negocio idea) 
        {
            foreach(Departamentos depto in departamentos) 
            {
                Departamentos_Idea deptoIdea = new Departamentos_Idea();
                deptoIdea.ID_Idea = idea.ID_Idea;
                deptoIdea.ID_Departamento = depto.ID_Departamento;
                db.Departamentos_Idea.Add(deptoIdea);
            }
            db.SaveChanges();
        }

        public List<Departamentos_Idea> buscarDepartamentosDeIdea(int idIdea) 
        {
            var deptosIdea = db.Departamentos_Idea
                .Where(i => i.ID_Idea == idIdea)
                .Include(i => i.Departamentos).ToList();

            return deptosIdea;
        }
    }
}