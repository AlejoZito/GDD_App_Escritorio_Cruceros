﻿using FrbaCrucero.DAL.Domain;
using FrbaCrucero.DAL.Enums;
using FrbaCrucero.UI.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.MenuPrincipal
{
    public partial class Form_MenuPrincipal : Form
    {
        private readonly List<KeyValuePair<string, Form>> _PageCache;

        public Form_MenuPrincipal()
        {
            _PageCache = new List<KeyValuePair<string, Form>>();
            InitializeComponent();
            GoToPage(new UI.MenuPrincipal.Home(), cachePage: false);
        }

        public void GoToPage(Form page, bool cachePage = true)
        {
            KeyValuePair<string, Form> newPage = new KeyValuePair<string, Form>(page.GetType().Name, page);

            //Si cachePage == true, revisar las paginas abiertas y usarla si existe.
            //Si no existe en el cache, almacenarla.
            if (cachePage == true)
            {
                if (_PageCache.Any(x => x.Key == newPage.Key))
                {
                    //La página ya fue abierta, utilizar la que ya está en memoria
                    newPage = _PageCache.FirstOrDefault(x => x.Key == newPage.Key);
                }
                else
                {
                    _PageCache.Add(newPage);
                }
            }

            newPage.Value.TopLevel = false;
            Content.Controls.Clear();
            Content.Controls.Add(newPage.Value);
            newPage.Value.Show();
        }

        public void PopUpPage(Form page)
        {
            page.ShowDialog();
        }

        private void MenuPrincipal_Shown(object sender, EventArgs e)
        {
            //this.UsernameLabel.Text = String.IsNullOrEmpty(Program.UsuarioLoggeado.Username) ? "Cliente" : Program.UsuarioLoggeado.Username;
        }

        private void button_CerrarSesion_Click(object sender, EventArgs e)
        {
            Program.UsuarioLoggeado = new DAL.Domain.Usuario();
            Program.Navigation.GoToPage(new LoginGeneral());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GoToPage(new UI.MenuPrincipal.Home(), cachePage: false);
        }

    }
}
