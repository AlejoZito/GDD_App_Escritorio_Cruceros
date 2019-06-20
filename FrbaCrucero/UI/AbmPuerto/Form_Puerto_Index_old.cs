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

namespace FrbaCrucero.UI.AbmPuerto
{
    public partial class Form_Puerto_Index_old : Form
    {
        public Form_Puerto_Index_old()
        {
            InitializeComponent();
        }

        private void CrearButton_Click(object sender, EventArgs e)
        {
            //Program.Navigation.PopUpPage(new AltaPuerto());
        }

        private void Form_Puerto_Index_Load(object sender, EventArgs e)
        {
            IList<Puerto> puertos = this.GetData();
        }

        private IList<Puerto> GetData()
        {
            return PuertoDAO.GetAll();
        }
    }
}
