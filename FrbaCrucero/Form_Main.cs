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

namespace FrbaCrucero
{
    public partial class Form_Main : Form
    {
        private readonly List<KeyValuePair<string, Form>> _PageCache;
        private readonly List<KeyValuePair<string, Form>> _NavigationStack;

        public Form_Main()
        {
            _PageCache = new List<KeyValuePair<string, Form>>();
            _NavigationStack = new List<KeyValuePair<string, Form>>();
            InitializeComponent();
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
            SetPageInContainer(newPage);
            
            //add item to navigation stack (used when going to previous page)
            _NavigationStack.Add(newPage);

            newPage.Value.Show();
        }

        public void GoToPreviousPage()
        {
            if(_NavigationStack.Count >= 2){            
                _NavigationStack.LastOrDefault().Value.Close();
                
                //Assign previous page to form;
                SetPageInContainer(_NavigationStack[_NavigationStack.Count - 2]);

                //Remove page from stack
                _NavigationStack.RemoveAt(_NavigationStack.Count - 1);
                
                //Remove from cache                
                //ToDo
            }
        }

        public void PopUpPage(Form page)
        {
            page.StartPosition = FormStartPosition.CenterParent;
            page.ShowDialog();
        }



        private void SetPageInContainer(KeyValuePair<string, Form> newPage)
        {
            Content.Controls.Clear();
            newPage.Value.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            newPage.Value.Dock = DockStyle.Fill;
            Content.Controls.Add(newPage.Value);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            LoginGeneral loginGeneral = new LoginGeneral();
            loginGeneral.TopLevel = false;
            Content.Controls.Add(loginGeneral);
            loginGeneral.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            loginGeneral.Dock = DockStyle.Fill;
            loginGeneral.Show();
        }
    }
}
