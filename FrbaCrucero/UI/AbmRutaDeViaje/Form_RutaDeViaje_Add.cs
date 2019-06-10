﻿using FrbaCrucero.BL;
using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.AbmRutaDeViaje
{
    public partial class Form_RutaDeViaje_Add : Form
    {
        OnAddSuccessDelegate<RutaDeViajeViewModel> _OnAddSuccess;
        RutaDeViajeViewModel _ViewModel;

        public Form_RutaDeViaje_Add(OnAddSuccessDelegate<RutaDeViajeViewModel> onAddSuccess)
        {
            InitializeComponent();
            LoadDropdowns();

            _OnAddSuccess = onAddSuccess;
            _ViewModel = new RutaDeViajeViewModel();
            BindViewModel();
        }

        private void BindViewModel()
        {
            dropdownCrucero.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdCrucero", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownRecorrido.Input.DataBindings.Add("SelectedValue", _ViewModel, "IdRecorrido", true, DataSourceUpdateMode.OnPropertyChanged);
            datepickerDesde.Input.DataBindings.Add("Value", _ViewModel, "Fecha_Inicio", true, DataSourceUpdateMode.OnPropertyChanged);
            datepickerHasta.Input.DataBindings.Add("Value", _ViewModel, "Fecha_Fin", true, DataSourceUpdateMode.OnPropertyChanged);
            datepickerEstimada.Input.DataBindings.Add("Value", _ViewModel, "Fecha_Fin_Estimada", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadDropdowns()
        {
            dropdownCrucero.Input.DataSource = (new CruceroDAO()).GetAll();
            dropdownCrucero.Input.DisplayMember = "Detalle";
            dropdownCrucero.Input.ValueMember = "Cod_Crucero";

            dropdownRecorrido.Input.DataSource = (new RecorridoDAO()).GetAll().Select(x=>new RecorridoViewModel(x)).ToList();
            dropdownRecorrido.Input.DisplayMember = "Descripcion";
            dropdownRecorrido.Input.ValueMember = "IdRecorrido";
        }

        private void btnRecorridoAdd_Click(object sender, EventArgs e)
        {
            (new RutaDeViajeDAO()).Add(_ViewModel.MapToDomainObject());
            _OnAddSuccess(_ViewModel);
            this.Close();
        }
    }
}
