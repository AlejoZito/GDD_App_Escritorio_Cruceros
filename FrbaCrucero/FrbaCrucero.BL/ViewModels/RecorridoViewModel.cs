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
    public class RecorridoViewModel : ViewModel<Recorrido>
    {
        public RecorridoViewModel()
        {
            Tramos = new BindingList<TramoViewModel>();
        }

        public RecorridoViewModel(Recorrido r)
        {
            MapFromDomainObject(r);
        }

        [Listable(description: "Id")]
        public int IdRecorrido { get; set; }

        [Listable(description: "Activo")]
        public bool Activo { get; set; }

        [Listable(description: "Cantidad de tramos")]
        public int CantidadTramos { get { return Tramos.Count; } }

        public BindingList<TramoViewModel> Tramos { get; set; }

        [Listable(description: "Descripcion")]
        public string Descripcion
        {
            get
            {
                return "ID: " + IdRecorrido + " / Tramos: " + CantidadTramos;
            }
        }

        public string ErrorMessage { get; set; }

        public override void MapFromDomainObject(Recorrido o)
        {
            this.IdRecorrido = o.Cod_Recorrido;
            this.Activo = o.Activo;
            this.Tramos = new BindingList<TramoViewModel>();
            foreach (var t in o.Tramos)
            {
                this.Tramos.Add(new TramoViewModel(t));
            }
        }

        public override Recorrido MapToDomainObject()
        {
            return new Recorrido()
            {
                Cod_Recorrido = this.IdRecorrido,
                Activo = this.Activo,
                Tramos = this.Tramos.Select(t => t.MapToDomainObject()).ToList()
            };
        }

        public void SubirTramo(string tramoDescripcion)
        {
            var tramo = this.Tramos.FirstOrDefault(x => x.Descripcion == tramoDescripcion);
            if (tramo != null)
            {
                int posicion = Tramos.IndexOf(tramo);
                if (posicion != 0)
                {
                    Tramos.Remove(tramo);
                    Tramos.Insert(posicion - 1, tramo);
                }
            }
        }

        public void BajarTramo(string tramoDescripcion)
        {
            var tramo = this.Tramos.FirstOrDefault(x => x.Descripcion == tramoDescripcion);
            if (tramo != null)
            {
                int posicion = Tramos.IndexOf(tramo);
                if (posicion != Tramos.Count - 1)
                {
                    Tramos.Remove(tramo);
                    Tramos.Insert(posicion + 1, tramo);
                }
            }
        }

        public decimal CalcularCostoDeRecorrido()
        {
            if (Tramos != null && Tramos.Count > 0)
            {
                decimal costo = 0;
                foreach (var tramo in Tramos)
                    costo += tramo.Precio;
                return costo;
            }
            else
                return 0;
        }

        public bool IsValid()
        {
            ErrorMessage = "";

            if (CantidadTramos == 0)
                ErrorMessage += "Debe seleccionar por lo menos 1 tramo. " + System.Environment.NewLine;

            foreach (TramoViewModel tramo in Tramos)
            {
                if (tramo.PuertoDesde.IDPuerto == tramo.PuertoHasta.IDPuerto)
                {
                    int tramoIndex = Tramos.IndexOf(tramo);
                    ErrorMessage += "Tramo invalido [" + tramoIndex + "] El puerto desde no puede ser el mismo que el puerto hasta." + System.Environment.NewLine;
                }
            }

            //Validar coherencia de tramos (los puertos deben ser A->B, B->C, C->A)
            //Tramos de la forma A->B, C->A son invalidos)
            try
            {
                TramoViewModel tramoAnterior = null;
                foreach (TramoViewModel tramo in Tramos)
                {
                    //Validar
                    if (tramoAnterior != null)
                    {
                        if (tramoAnterior.PuertoHasta.IDPuerto != tramo.PuertoDesde.IDPuerto)
                        {
                            //El armado de tramos es invalido, el [destino] del anterior deberia coincidir con el [desde] del actual
                            //Con 1 tramo invalido ya mostrar el msj de error
                            throw new Exception("El armado de tramos es inválido. Cada nuevo tramo debe tener como orígen el puerto de destino del tramo anterior");
                        }
                    }
                    tramoAnterior = tramo;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message + System.Environment.NewLine;
            }            

            //If error message is empty, object is valid
            return string.IsNullOrEmpty(ErrorMessage);
        }

        public void Add()
        {
            RecorridoDAO.Add(this.MapToDomainObject());
        }


        public void Edit()
        {
            RecorridoDAO.Edit(this.MapToDomainObject());
        }
    }
}
