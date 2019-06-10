using FrbaCrucero.BL.Attributes;
using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class CruceroViewModel : ViewModel <Crucero>
    {
        public CruceroViewModel()
        {
            Cabinas = new BindingList<CabinaViewModel>();
        }

        public CruceroViewModel(Crucero c)
        {
            this.MapFromDomainObject(c);
        }

        private int _IdCrucero;

        [Listable(description: "ID")]
        public int IdCrucero
        {
            get { return _IdCrucero; }
            set
            {
                _IdCrucero = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("IdCrucero"));
            }
        }

        private int _IdModelo;
        public int IdModelo
        {
            get { return _IdModelo; }
            set
            {
                _IdModelo = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("IdModelo"));
            }
        }

        [Listable(description: "Modelo")]
        public string Modelo { get; set; }

        private int _IdFabricante;
        public int IdFabricante
        {
            get { return _IdFabricante; }
            set
            {
                _IdFabricante = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("IdFabricante"));
            }
        }

        [Listable(description: "Fabricante")]
        public string Fabricante { get; set; }

        [Listable(description: "Activo")]
        public bool Activo { get; set; }

        public BindingList<CabinaViewModel> Cabinas { get; set; }

        public override Crucero MapToDomainObject()
        {
            return new Crucero()
            {
                Cod_Crucero = this.IdCrucero,
                Fabricante = new Fabricante() { Cod_Fabricante = this.IdFabricante },
                Modelo_Crucero = new ModeloCrucero() { Cod_Modelo = this.IdModelo },
                Identificador = this.IdCrucero.ToString(), //ToDo: revisar si identificador no es el cod crucero
                Activo = this.Activo,
                Cabinas = this.Cabinas.Select(x=>(Cabina)x.MapToDomainObject()).ToList()
            };
        }
        public override void MapFromDomainObject(Crucero c)
        {
            this.IdCrucero = c.Cod_Crucero;
            this.IdFabricante = c.Fabricante.Cod_Fabricante;
            this.Fabricante = c.Fabricante.Detalle;
            this.IdModelo = c.Modelo_Crucero.Cod_Modelo;
            this.Modelo = c.Modelo_Crucero.Detalle;
            this.Activo = c.Activo;
            this.Cabinas = new BindingList<CabinaViewModel>();
            foreach (var cab in c.Cabinas)
            {
                CabinaViewModel cv = new CabinaViewModel();
                cv.MapFromDomainObject(cab);
                Cabinas.Add(cv);
            }
        }
    }
}
