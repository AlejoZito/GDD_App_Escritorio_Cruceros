using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class CabinaViewModel : ViewModel <Cabina>
    {
        public CabinaViewModel() { }

        public CabinaViewModel(Cabina o)
        {
            MapFromDomainObject(o);
        }

        public int IdCabina { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public int IdTipo { get; set; }
        public int IdCrucero { get; set; }

        public string Descripcion
        {
            get
            {
                return "Num: " + Numero + " / Piso: " + Piso + " / IDTipo: " + IdTipo;
            }
        }

        public override Cabina MapToDomainObject()
        {
            return new Cabina()
            {
                Cod_Cabina = this.IdCabina,
                Numero = this.Numero,
                Piso = this.Piso,
                Tipo_Cabina = new TipoCabina() { Cod_Tipo = this.IdTipo },
                Crucero = null
            };
        }

        public override void MapFromDomainObject(Cabina c)
        {
            this.IdCabina = c.Cod_Cabina;
            this.Numero = c.Numero;
            this.Piso = c.Piso;
            this.IdTipo = c.Tipo_Cabina.Cod_Tipo;
            //this.IdCrucero = c.Crucero.Cod_Crucero;
        }
    }
}
