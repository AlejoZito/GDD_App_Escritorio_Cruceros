using FrbaCrucero.BL;
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
    public partial class Form_Recorrido_Add : Form
    {
        OnAddSuccessDelegate<RecorridoViewModel> _OnAddSuccess;
        RecorridoViewModel _ViewModel;

        public Form_Recorrido_Add(OnAddSuccessDelegate<RecorridoViewModel> onAddSuccess)
        {
            InitializeComponent();

            _OnAddSuccess = onAddSuccess;
            _ViewModel = new RecorridoViewModel();
            BindViewModel();
        }

        private void BindViewModel()
        {
            listTramos.SetDataBinding(_ViewModel.Tramos, "Descripcion");
        }

        private void btn_tramoAdd_Click(object sender, EventArgs e)
        {
            Program.Navigation.PopUpPage(new Form_Tramo_Add(
                onAddSuccess: (tramo) => _ViewModel.Tramos.Add(tramo)));
        }

        private void btn_TramoDelete_Click(object sender, EventArgs e)
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

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (listTramos.SelectedItems == null || listTramos.SelectedItems.Count == 0)
            {
            }
            else
            {
                foreach (ListViewItem listItem in listTramos.SelectedItems)
                {
                    _ViewModel.SubirTramo(listItem.Text);
                }
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (listTramos.SelectedItems == null || listTramos.SelectedItems.Count == 0)
            {
            }
            else
            {
                foreach (ListViewItem listItem in listTramos.SelectedItems)
                {
                    _ViewModel.BajarTramo(listItem.Text);
                }
            }
        }

        private void btnRecorridoAdd_Click(object sender, EventArgs e)
        {
            if (_ViewModel.IsValid())
            {
                try
                {
                    _ViewModel.Add();
                    _OnAddSuccess(_ViewModel);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(_ViewModel.ErrorMessage);
            }
        }
    }
}
