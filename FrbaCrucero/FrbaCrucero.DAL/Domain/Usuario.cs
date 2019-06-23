using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.Domain
{
    public class Usuario : INotifyPropertyChanged
    {
        public int Cod_Usuario { get; set; }

        string _Username;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; InvokePropertyChanged(new PropertyChangedEventArgs("Username")); }
        }

        public string Password { get; set; }

        public int Logins_Fallidos { get; set; }

        public DateTime Fecha_Inhabilitacion { get; set; }

        public IList<Rol> Roles { get; set; }

        public void Desloguear()
        {
            this.Username = "";
            this.Cod_Usuario = 0;
            this.Password = "";
            this.Logins_Fallidos = 0;
            this.Roles = null;
        }

        #region Implementation of INotifyPropertyChanged

        /// <summary>
        /// Evento que se dispara cuando el valor de la propiedad cambia
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Llamar desde el setter de una propiedad para disparar el evento <see cref="PropertyChanged"/>
        /// </summary>
        /// <param name="e"></param>
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}
