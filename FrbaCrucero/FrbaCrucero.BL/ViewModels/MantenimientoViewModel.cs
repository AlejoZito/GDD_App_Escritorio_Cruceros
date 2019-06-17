using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class MantenimientoViewModel : ViewModel<Mantenimiento>
    {
        public MantenimientoViewModel(int idCrucero)
        {
            IDCrucero = idCrucero;
            FechaDesde = DateTime.Now;
            FechaHasta = DateTime.Now.AddDays(10);
            Mantenimientos = new BindingList<MantenimientoViewModel>();
        }

        public MantenimientoViewModel(Mantenimiento o)
        {
            MapFromDomainObject(o);
            Mantenimientos = new BindingList<MantenimientoViewModel>();
        }

        public int IdMantenimiento { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int IDCrucero { get; set; }

        public string Descripcion
        {
            get
            {
                return FechaDesde + " - " + FechaHasta;
            }
        }

        public BindingList<MantenimientoViewModel> Mantenimientos { get; set; }

        public void ActualizarMantenimientos()
        {
            Mantenimientos.Clear();

            List<Mantenimiento> mantemientos = MantenimientoDAO.GetAllByCruceroID(this.IDCrucero);
            foreach (var m in mantemientos)
            {
                Mantenimientos.Add(new MantenimientoViewModel(m));
            }
        }

        public void AgregarMantenimiento()
        {
            MantenimientoDAO.Add(MapToDomainObject());
            ActualizarMantenimientos();
        }

        public string ErrorMessage { get; set; }

        public bool IsValid()
        {
            string errorMessage = "";

            if(FechaDesde < DateTime.Now)
                errorMessage += "Debe ingresar una fecha desde superior a hoy" + Environment.NewLine;

            if (FechaHasta < FechaDesde)
                errorMessage += "La fecha HASTA debe ser superior a la fecha DESDE" + Environment.NewLine;

            return string.IsNullOrWhiteSpace(ErrorMessage);
        }

        public override void MapFromDomainObject(Mantenimiento o)
        {
            this.IdMantenimiento = o.Cod_Mantenimiento;
            this.FechaDesde = o.Fecha_Desde;
            this.FechaHasta = o.Fecha_Hasta;
            this.IDCrucero = o.Crucero.Cod_Crucero;
        }

        public override Mantenimiento MapToDomainObject()
        {
            return new Mantenimiento()
            {
                Fecha_Desde = this.FechaDesde,
                Fecha_Hasta = this.FechaHasta,
                Crucero = new Crucero()
                {
                    Cod_Crucero = this.IDCrucero
                }
            };
        }
    }
}
