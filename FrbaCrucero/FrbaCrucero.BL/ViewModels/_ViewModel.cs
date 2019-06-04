using FrbaCrucero.BL.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class ViewModel
    {
        /// <summary>
        /// Returns a List of key value pairs with column name and cell value
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<string,string>> GetRow()
        {
            //Obtener columnas a partir del viewmodel pasado a este método
            var properties = this.GetType().GetProperties();
            List<KeyValuePair<string,string>> columnsAndValues = new List<KeyValuePair<string,string>>();

            foreach (var prop in properties)
            {
                var attributes = (ListableAttribute[])prop.GetCustomAttributes(typeof(ListableAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {
                    columnsAndValues.Add(new KeyValuePair<string,string>(attributes[0].Description, prop.GetValue(this).ToString()));
                }
            }

            return columnsAndValues;
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
