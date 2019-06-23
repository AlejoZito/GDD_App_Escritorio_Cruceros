using FrbaCrucero.BL.Attributes;
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
    public class CruceroViewModel : ViewModel<Crucero>
    {
        public CruceroViewModel()
        {
            Cabinas = new BindingList<CabinaViewModel>();
        }

        public CruceroViewModel(Crucero c)
        {
            this.MapFromDomainObject(c);
        }


        [Listable(description: "ID")]
        public int IdCrucero { get; set; }

        public int IdModelo { get; set; }

        [Listable(description: "Modelo")]
        public string Modelo { get; set; }

        [Listable(description: "Identificador")]
        public string Identificador { get; set; }

        public int IdFabricante { get; set; }

        [Listable(description: "Fabricante")]
        public string Fabricante { get; set; }

        [Listable(description: "Activo")]
        public bool Activo { get; set; }

        public string ErrorMessage { get; set; }

        public BindingList<CabinaViewModel> Cabinas { get; set; }

        public string Descripcion
        {
            get { return "[" + Identificador + "] " + Modelo; }
        }

        public bool IsValid()
        {
            ErrorMessage = "";
            List<string> errors = new List<string>();
            if (string.IsNullOrWhiteSpace(this.Identificador))
            {
                errors.Add("El campo identificador debe ser completado");
            }

            if (!this.Cabinas.Any())
            {
                errors.Add("El crucero debe tener al menos una cabina");
            }

            if (CruceroDAO.ExisteCrucero(MapToDomainObject()))
            {
                errors.Add("Ya existe un crucero con ese identificador");
            }

            foreach (var error in errors)
                ErrorMessage += error + " / ";

            return errors.Count == 0;
        }

        public override Crucero MapToDomainObject()
        {
            return new Crucero()
            {
                Cod_Crucero = this.IdCrucero,
                Fabricante = new Fabricante() { Cod_Fabricante = this.IdFabricante },
                Modelo_Crucero = new ModeloCrucero() { Cod_Modelo = this.IdModelo },
                Identificador = this.IdCrucero.ToString(), //ToDo: revisar si identificador no es el cod crucero
                Activo = this.Activo,
                Cabinas = this.Cabinas.Select(x => (Cabina)x.MapToDomainObject()).ToList()
            };
        }
        public override void MapFromDomainObject(Crucero c)
        {
            this.IdCrucero = c.Cod_Crucero;
            this.IdFabricante = (c.Fabricante != null) ? c.Fabricante.Cod_Fabricante : 0;
            this.Fabricante = (c.Fabricante != null) ? c.Fabricante.Detalle : "";
            this.IdModelo = (c.Modelo_Crucero != null) ? c.Modelo_Crucero.Cod_Modelo : 0;
            this.Modelo = (c.Modelo_Crucero != null) ? c.Modelo_Crucero.Detalle : "";
            this.Activo = c.Activo;
            this.Identificador = c.Identificador;
            this.Cabinas = new BindingList<CabinaViewModel>();
            if (c.Cabinas != null)
            {
                foreach (var cab in c.Cabinas)
                {
                    CabinaViewModel cv = new CabinaViewModel();
                    cv.MapFromDomainObject(cab);
                    Cabinas.Add(cv);
                }
            }
        }

        public void Add()
        {
            try
            {
                CruceroDAO.Add(MapToDomainObject());
            }
            catch (Exception ex)
            {
                ErrorMessage = "EXCEPTION: " + ex.Message;
            }
        }

        public void Edit()
        {
            try
            {
                CruceroDAO.Edit(MapToDomainObject());
            }
            catch (Exception ex)
            {
                ErrorMessage = "EXCEPTION: " + ex.Message;
            }
        }

        public void Delete()
        {
            try
            {
                CruceroDAO.Delete(MapToDomainObject());
            }
            catch (Exception ex)
            {
                ErrorMessage = "EXCEPTION: " + ex.Message;
            }
        }
    }
}
