using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class ClienteViewModel : ViewModel<Cliente>
    {
        public ClienteViewModel() { }

        public ClienteViewModel(Cliente o)
        {
            MapFromDomainObject(o);
        }

        string _DNI;
        public string DNI
        {
            get { return _DNI; }
            set
            {
                //Only update if value is new (to avoid recursion)
                if (_DNI != value)
                {
                    _DNI = value;
                    //Actualizar cliente cuando se ingresa dni
                    if (!string.IsNullOrEmpty(_DNI))
                    {
                        try
                        {
                            MapFromDomainObject(ClienteDAO.GetByDNI(_DNI));
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        DateTime _FechaNacimiento;
        public DateTime FechaNacimiento { get; set; }

        public override void MapFromDomainObject(Cliente o)
        {
            this.DNI = o.Dni.ToString();
            this.Nombre = o.Nombre;
            this.Apellido = o.Apellido;
            this.Direccion = o.Direccion;
            this.Telefono = o.Telefono.ToString();
            this.Mail = o.Mail;
            this.FechaNacimiento = o.Fecha_Nac;
        }

        public override Cliente MapToDomainObject()
        {
            return new Cliente()
            {
                Dni = int.Parse(this.DNI),
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Direccion = this.Direccion,
                Telefono = int.Parse(this.Telefono),
                Mail = this.Mail,
                Fecha_Nac = DateTime.Equals(this.FechaNacimiento, new DateTime()) ? DateTime.Now : this.FechaNacimiento
            };
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(DNI) &&
                    !string.IsNullOrWhiteSpace(Nombre) &&
                    !string.IsNullOrWhiteSpace(Apellido) &&
                    !string.IsNullOrWhiteSpace(Direccion) &&
                    !string.IsNullOrWhiteSpace(Telefono) &&
                    !string.IsNullOrWhiteSpace(Mail);
        }
    }
}
