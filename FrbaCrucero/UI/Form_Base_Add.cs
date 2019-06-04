using FrbaCrucero.BL.ViewModels;
using FrbaCrucero.UI.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI
{
    public partial class Form_Base_Add<T> : Form
    {
        CruceroViewModel _ViewModel;

        public Form_Base_Add()
        {
            InitializeComponent();
            _ViewModel = new CruceroViewModel(1, "t", "a", "b", true);
        }

        protected void AddControl(Control control)
        {
            if (flowLayoutPanel1.Controls != null) 
            {
                flowLayoutPanel1.Controls.Add(control);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inputIdCrucero = new InputTextControl(
                "IdCrucero",
                "Ingrese un ID");
            inputIdCrucero.TextBox.DataBindings.Add("Text", _ViewModel, "IdCrucero");

            AddControl(inputIdCrucero);

            var inputNombreCrucero = new InputTextControl(
                "Nombre Crucero",
                "Ingrese un valor");
            inputNombreCrucero.TextBox.DataBindings.Add("Text", _ViewModel, "NombreCrucero");

            AddControl(inputNombreCrucero);

            var inputABC = new InputTextControl(
                "ABC",
                "Ingrese un valor");
            inputABC.TextBox.DataBindings.Add("Text", _ViewModel, "Abc");

            AddControl(inputABC);
            //var bindingSource = new BindingSource();

            ////bindingSource.DataSource = viewModel;

            //if (flowLayoutPanel1.Controls != null)
            //{
            //    string textBoxInputName = "campo1";
            //    string textBoxDescription = "Ingrese un valor";
            //    string textBoxLabel = "Campo 1";
            //    string defaultValue = "";

                

            //    flowLayoutPanel1.Controls.Add(label);
            //    flowLayoutPanel1.Controls.Add(textBox);
            //    flowLayoutPanel1.Controls.Add(inputDescription);
            //}

            //foreach (Control c in flowLayoutPanel1.Controls)
            //{
            //    if(c is TextBox)
            //        Console.WriteLine(c.Name + " - " + c.Text);
            //}
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Prueba del bindeo del form
            label1.Text = _ViewModel.IdCrucero + " - " + _ViewModel.NombreCrucero + " - " + _ViewModel.Abc;
        }
    }
}
