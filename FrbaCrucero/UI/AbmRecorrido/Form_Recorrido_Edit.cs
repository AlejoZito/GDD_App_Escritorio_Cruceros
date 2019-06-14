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

namespace FrbaCrucero.UI.AbmRecorrido
{
    public partial class Form_Recorrido_Edit : Form
    {
        OnEditSuccessDelegate<RecorridoViewModel> _OnEditSuccess;
        RecorridoViewModel _ViewModel;

        public Form_Recorrido_Edit(OnEditSuccessDelegate<RecorridoViewModel> onEditSuccess, int idRecorrido)
        {
            InitializeComponent();

            _OnEditSuccess = onEditSuccess;
            
            //obtengo el recorrido de la base y lo mapeo a un viewmodel
            _ViewModel = new RecorridoViewModel((new RecorridoDAO()).GetByID(idRecorrido));

            //bindeo las propiedades del viewmodel a los controles
            BindViewModel();
        }
        private void BindViewModel()
        {
            checkbox_activo.DataBindings.Add("Checked", _ViewModel, "Activo", true, DataSourceUpdateMode.OnPropertyChanged);
            listTramos.SetDataBinding(_ViewModel.Tramos, "Descripcion");
        }

        private void btn_TramoDelete_Click_1(object sender, EventArgs e)
        {
            if (listTramos.SelectedItems == null || listTramos.SelectedItems.Count == 0)
            {
            }
            else
            {
                foreach (ListViewItem listItem in listTramos.SelectedItems)
                {
                    var tramoToRemove = _ViewModel.Tramos.FirstOrDefault(x => x.Descripcion == listItem.Text);
                    _ViewModel.Tramos.Remove(tramoToRemove);
                }
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            (new RecorridoDAO()).Edit(_ViewModel.MapToDomainObject());
            _OnEditSuccess(_ViewModel);
            this.Close();
        }

        private void btn_tramoAdd_Click_1(object sender, EventArgs e)
        {
            Program.Navigation.PopUpPage(new Form_Tramo_Add(
                onAddSuccess: (tramo) => _ViewModel.Tramos.Add(tramo)));
        }
    }
}