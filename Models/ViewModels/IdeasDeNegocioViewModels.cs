using ProyectoAula4MVC.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProyectoAula4MVC.Models.ViewModels
{
    

    public class RegistroIdeaViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Impacto")]
        public string Impacto { get; set; }


        [Required]
        [Display(Name = "Valor de inversion")]
        [Range(0, 9999999999, ErrorMessage = "La cantidad no puede ser negativa.")]
        public decimal ValorInversion { get; set; }



        [Required]
        [Display(Name = "Total de ingresos")]
        [Range(0, 9999999999, ErrorMessage = "La cantidad no puede ser negativa.")]
        public decimal TotalIngresos { get; set; }



        [Required]
        [Display(Name = "Valor de inversion en infraestructura")]
        [Range(0, 9999999999, ErrorMessage = "La cantidad no puede ser negativa.")]
        public decimal ValorInversionInfraestructura { get; set; }



        [Required]
        [Display(Name = "Herramienta de la 4 R.I")]
        public string Herramienta4RI { get; set; }

        [Required]
        [Display(Name = "Departamentos beneficiados")]
        public List<string> Departamentos { get; set; }
    }

    public class DetallesIdeaViewModel
    {
        [Display(Name = "Idea de Negocio")]
        public Ideas_De_Negocio Idea { get; set; }


        [Display(Name = "Departamentos beneficiados")]
        public List<Departamentos_Idea> Departamentos { get; set; }


    }


}