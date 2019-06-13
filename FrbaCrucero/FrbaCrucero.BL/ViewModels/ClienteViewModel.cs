﻿using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class ClienteViewModel : ViewModel<Cliente>
    {
        public ClienteViewModel(){}

        public ClienteViewModel(Cliente o)
        {
            MapFromDomainObject(o);
        }

        public string DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public override void MapFromDomainObject(Cliente o)
        {
            this.DNI = o.Dni;
            this.Nombre = o.Nombre;
            this.Apellido = o.Apellido;
            this.Direccion = o.Direccion;
            this.Telefono = o.Telefono;
            this.Mail = o.Mail;
            this.FechaNacimiento = o.Fecha_Nac;
        }

        public override Cliente MapToDomainObject()
        {
            return new Cliente()
            {
                Dni = this.DNI,
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Direccion = this.Direccion,
                Telefono = this.Telefono,
                Mail = this.Mail,
                Fecha_Nac = this.FechaNacimiento
            };
        }
    }
}
