﻿using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.CompraReservaPasaje
{
    public partial class Form_CompraReserva : Form
    {
        private readonly CompraReservaPasajeViewModel _ViewModel;

        public Form_CompraReserva()
        {
            InitializeComponent();
            _ViewModel = new CompraReservaPasajeViewModel();
            BindControls();
            LoadDropDowns();
            PasajeDAO.ActualizarReservasVencidas();
        }

        private void BindControls()
        {
            datePickerDeparture.Input.DataBindings.Add("Value", _ViewModel, "FechaPartida", true, DataSourceUpdateMode.OnPropertyChanged);
            labelMonto.DataBindings.Add("Text", _ViewModel, "Monto", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownPuertoDesde.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdPuertoSalida", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownPuertoHasta.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdPuertoLlegada", true, DataSourceUpdateMode.OnPropertyChanged);

            listViewViajes.SetDataBinding(_ViewModel.Viajes, "Descripcion");

            listViewCabinas.SetDataBinding(_ViewModel.Cabinas, "Descripcion");

            //labelMonto.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Nombre", true, DataSourceUpdateMode.OnPropertyChanged);

            inputDni.Input.DataBindings.Add("Text", _ViewModel, "Cliente.DNI", true, DataSourceUpdateMode.OnPropertyChanged);
            inputNombre.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
            inputApellido.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Apellido", true, DataSourceUpdateMode.OnPropertyChanged);
            inputDireccion.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Direccion", true, DataSourceUpdateMode.OnPropertyChanged);
            inputTelefono.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Telefono", true, DataSourceUpdateMode.OnPropertyChanged);
            inputEmail.Input.DataBindings.Add("Text", _ViewModel, "Cliente.Mail", true, DataSourceUpdateMode.OnPropertyChanged);
            inputFechaNacimiento.Input.DataBindings.Add("Value", _ViewModel, "Cliente.FechaNacimiento", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadDropDowns()
        {
            dropdownPuertoDesde.Input.DataSource = PuertoDAO.GetAll();
            dropdownPuertoDesde.Input.DisplayMember = "Nombre";
            dropdownPuertoDesde.Input.ValueMember = "Cod_Puerto";

            dropdownPuertoHasta.Input.DataSource = PuertoDAO.GetAll();
            dropdownPuertoHasta.Input.DisplayMember = "Nombre";
            dropdownPuertoHasta.Input.ValueMember = "Cod_Puerto";
        }

        private void btnBuscarViajes_Click(object sender, EventArgs e)
        {
            _ViewModel.BuscarViajes();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ViewModel.IsValid())
                {
                    _ViewModel.CargarUsuario();
                    _ViewModel.ReservarPasaje();

                    string reservas = "";
                    foreach (Reserva reserva in _ViewModel.PasajesReservados)
                    {
                        reservas += Environment.NewLine + "Cod. Reserva: " + reserva.Cod_Reserva + " - Cabina Tipo: " + reserva.Cabina.Tipo_Cabina.Detalle + " / Piso: " + reserva.Cabina.Piso + " / Num: " + reserva.Cabina.Numero;
                    }

                    string reservado = _ViewModel.PasajesReservados.Count.ToString() + " cabinas reservadas. " + Environment.NewLine;

                    MessageBox.Show(reservado + reservas, "¡Reservas realizadas!", MessageBoxButtons.OK);
                    Program.Navigation.GoToPage(new UI.MenuPrincipal.Home(), cachePage: false);
                }
                else
                {
                    MessageBox.Show(_ViewModel.ErrorMessage, "Datos Incompletos", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ViewModel.IsValid())
                {

                    _ViewModel.CargarUsuario();

                    Program.Navigation.PopUpPage(new Form_Pago(
                        onSuccess: (pago) => _ViewModel.MedioDePago = pago));

                    _ViewModel.ComprarPasaje();

                    string compras = "";
                    foreach (Pasaje pasaje in _ViewModel.PasajesComprados)
                    {
                        compras += Environment.NewLine + "Voucher: " + pasaje.Cod_Pasaje + " - Tipo: " + pasaje.Cabina.Tipo_Cabina.Detalle + " / Piso: " + pasaje.Cabina.Piso + " / Num: " + pasaje.Cabina.Numero;
                    }

                    string compra = _ViewModel.PasajesComprados.Count.ToString() + " pasajes comprados. " + Environment.NewLine;

                    MessageBox.Show(compra + compras, "Pasajes comprados!", MessageBoxButtons.OK);
                    _ViewModel.IdsCabinasSeleccionadas.Clear();
                    _ViewModel.PasajesComprados.Clear();
                    Program.Navigation.GoToPage(new UI.MenuPrincipal.Home(), cachePage: false);
                }
                else
                {
                    MessageBox.Show(_ViewModel.ErrorMessage, "Datos Incompletos", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar procesar tu pago, por favor intenta nuevamente.", "Error Inesperado", MessageBoxButtons.OK);
            }
        }

        private void listViewViajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewViajes.SelectedItems == null || listViewViajes.SelectedItems.Count == 0)
            {
                _ViewModel.RutaDeViajeSeleccionada = (int?)null;
            }
            else
            {
                var rutaSeleccionada = _ViewModel.Viajes.FirstOrDefault(x => x.Descripcion == listViewViajes.SelectedItems[0].Text);
                _ViewModel.RutaDeViajeSeleccionada = rutaSeleccionada.IdRutaDeViaje;
            }
        }

        private void listViewCabinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCabinas.SelectedItems == null || listViewCabinas.SelectedItems.Count == 0)
            {
                _ViewModel.IdsCabinasSeleccionadas.Clear();
            }
            else
            {
                List<string> selectedValues = new List<string>();
                foreach (ListViewItem listItem in listViewCabinas.SelectedItems)
                {
                    selectedValues.Add(listItem.Text);
                }
                _ViewModel.SeleccionarCabinas(selectedValues);
            }
        }
    }
}
