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
    public partial class Form_Tramo_Add : Form
    {
        TramoViewModel _ViewModel;
        OnAddSuccessDelegate<TramoViewModel> _OnAddSuccess;
        public Form_Tramo_Add(OnAddSuccessDelegate<TramoViewModel> onAddSuccess)
        {
            InitializeComponent();
            _OnAddSuccess = onAddSuccess;
            LoadDropdowns();

            _ViewModel = new TramoViewModel();
            BindViewModel();
        }

        private void BindViewModel()
        {
            inputPrecio.Input.DataBindings.Add("Text", _ViewModel, "Precio", true, DataSourceUpdateMode.OnPropertyChanged);
            
            //ToDo: Revisar este tema, si bindeo ID y Texto, se rompe el binding.
            //Convendria hacerlo por ID para persistencia, pero sin bindear el nombre no puedo mostrar los nombres de puertos
            //en la pantalla de creacion de recorrido

            dropdownPuertoDesde.Input.DataBindings.Add("SelectedValue", _ViewModel, "PuertoDesde.IdPuerto", true, DataSourceUpdateMode.OnPropertyChanged);
            //dropdownPuertoDesde.Input.DataBindings.Add("Text", _ViewModel, "PuertoDesde.Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
            dropdownPuertoHasta.Input.DataBindings.Add("SelectedValue", _ViewModel, "PuertoHasta.IdPuerto", true, DataSourceUpdateMode.OnPropertyChanged);
            //dropdownPuertoHasta.Input.DataBindings.Add("Text", _ViewModel, "PuertoHasta.Nombre", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void LoadDropdowns()
        {
            dropdownPuertoDesde.Input.DataSource = PuertoDAO.GetAll();
            dropdownPuertoDesde.Input.DisplayMember = "Nombre";
            dropdownPuertoDesde.Input.ValueMember = "Cod_Puerto";

            dropdownPuertoHasta.Input.DataSource = PuertoDAO.GetAll();
            dropdownPuertoHasta.Input.DisplayMember = "Nombre";
            dropdownPuertoHasta.Input.ValueMember = "Cod_Puerto";
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_ViewModel.IsValid())
            {
                _ViewModel.CargarPuertos();//Este metodo es necesario porque no puedo bindear doblemente los dropdowns de puertos.
                _OnAddSuccess(_ViewModel);
                this.Close();
            }
            else
            {
                MessageBox.Show(_ViewModel.ErrorMessage, "Datos Incorrectos");
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Console.WriteLine("");
        }
    }
}
