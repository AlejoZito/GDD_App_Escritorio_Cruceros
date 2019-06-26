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
        public string Numero { get; set; }
        public string Piso { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public int IdCrucero { get; set; }

        /// <summary>
        /// Porcentaje traido desde el "tipo de cabina"
        /// </summary>
        public decimal PorcentajeRecargo { get; set; }

        public string Descripcion
        {
            get
            {
                return "Tipo: " + Tipo + " / Piso: " + Piso + " / Num: " + Numero  ;
            }
        }

        public string ErrorMessage { get; set; }

        public override Cabina MapToDomainObject()
        {
            return new Cabina()
            {
                Cod_Cabina = this.IdCabina,
                Numero = int.Parse(this.Numero),
                Piso = int.Parse(this.Piso),
                Tipo_Cabina = new TipoCabina() { Cod_Tipo = this.IdTipo },
                IdCrucero = 2,
            };
        }

        public override void MapFromDomainObject(Cabina c)
        {
            this.IdCabina = c.Cod_Cabina;
            this.Numero = c.Numero.ToString();
            this.Piso = c.Piso.ToString();
            this.IdTipo = c.Tipo_Cabina.Cod_Tipo;
            this.Tipo = c.Tipo_Cabina.Detalle;
            this.PorcentajeRecargo = c.Tipo_Cabina.Porc_Recargo;
            //this.IdCrucero = c.Crucero.Cod_Crucero;
        }

        public bool IsValid()
        {
            ErrorMessage = "";
            int validarNumero;

            if (string.IsNullOrWhiteSpace(this.Numero))
                ErrorMessage += "Debe ingresar un número de cabina" + System.Environment.NewLine;
            else
            {
                if (!int.TryParse(this.Numero, out validarNumero))
                {
                    ErrorMessage += "No se pueden ingresar letras en el campo número de la cabina" + System.Environment.NewLine;
                }
            }

            if (string.IsNullOrWhiteSpace(this.Piso))
                ErrorMessage += "Debe ingresar un número de piso" + System.Environment.NewLine;
            else
            {
                if (!int.TryParse(this.Piso, out validarNumero))
                {
                    ErrorMessage += "No se pueden ingresar letras en el campo piso de la cabina" + System.Environment.NewLine;
                }
            }

            if (this.IdTipo == null || this.IdTipo == 0)
                ErrorMessage += "Debe ingresar un tipo de cabina" + System.Environment.NewLine;
            return string.IsNullOrEmpty(ErrorMessage);
        }
    }
}
