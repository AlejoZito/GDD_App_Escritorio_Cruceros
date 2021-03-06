﻿using FrbaCrucero.DAL.Domain;
using FrbaCrucero.UI.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    static class Program
    {
        public static Form_Main Navigation;
        //public static MenuPrincipal.Form_MenuPrincipal MainMenu;
        public static Usuario UsuarioLoggeado;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                UsuarioLoggeado = new Usuario();
                Navigation = new Form_Main();
                Application.Run(Navigation);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
