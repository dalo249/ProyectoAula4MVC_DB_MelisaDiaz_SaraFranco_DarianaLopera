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

    public class EstadisticasViewModel 
    {
        public List<DetallesIdeaViewModel> ideasMas3Deptos { get; set; }
        public List<Ideas_De_Negocio> ideasMayorRentabilidad { get; set; }
        public List<Ideas_De_Negocio> ideasUsanDesarrolloSostenible { get; set; }
        public List<Ideas_De_Negocio> ideasRentabilidadMayorPromedio { get; set; }
        public List<Ideas_De_Negocio> ideasUsanTerritoriosOTransicion { get; set; }
        public DetallesIdeaViewModel ideaMayorDeptos { get; set; } 
        public Ideas_De_Negocio ideaMayorTotalIngresos { get; set; }
        public Ideas_De_Negocio ideaMayorInversionInfraestructura { get; set; }
        public decimal sumaTotalInversiones { get; set; }
        public decimal sumaTotalIngresos { get; set; }
        public int totalIdeasUsanIA { get; set; }

        public EstadisticasViewModel(List<DetallesIdeaViewModel> ideasMas3Deptos, List<Ideas_De_Negocio> ideasMayorRentabilidad, List<Ideas_De_Negocio> ideasUsanDesarrolloSostenible,
            List<Ideas_De_Negocio> ideasRentabilidadMayorPromedio, List<Ideas_De_Negocio> ideasUsanTerritoriosOTransicion, DetallesIdeaViewModel ideaMayorDeptos,
            Ideas_De_Negocio ideaMayorTotalIngresos, Ideas_De_Negocio ideaMayorInversionInfraestructura, decimal sumaTotalInversiones, decimal sumaTotalIngresos,
            int totalIdeasUsanIA)
        {
            this.ideasMas3Deptos = ideasMas3Deptos;
            this.ideasMayorRentabilidad = ideasMayorRentabilidad;
            this.ideasUsanDesarrolloSostenible = ideasUsanDesarrolloSostenible;
            this.ideasRentabilidadMayorPromedio = ideasRentabilidadMayorPromedio;
            this.ideasUsanTerritoriosOTransicion = ideasUsanTerritoriosOTransicion;
            this.ideaMayorDeptos = ideaMayorDeptos;
            this.ideaMayorTotalIngresos = ideaMayorTotalIngresos;
            this.ideaMayorInversionInfraestructura = ideaMayorInversionInfraestructura;                 
            this.sumaTotalInversiones = sumaTotalInversiones;
            this.sumaTotalIngresos = sumaTotalIngresos;
            this.totalIdeasUsanIA = totalIdeasUsanIA;
        }


    }


}