using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class FiltersViewModel : INotifyPropertyChanged
    {
        public FiltersViewModel(
            List<KeyValuePair<int, string>> dropdownOptions,
            string exactFilter = null,
            string likeFilter = null,
            string dropdownFilter = null,
            FilterButton filtro = null,
            FilterButton buttonA = null,
            FilterButton buttonB = null)
        {
            DropdownOptions = dropdownOptions;

            ExactFilterLabel = exactFilter ?? "Exact filter";
            LikeFilterLabel = likeFilter ?? "Like filter";
            DropdownFilterLabel = dropdownFilter ?? "Dropdown filter";

            Button_Filtro = filtro ?? new FilterButton();
            Button_A = buttonA ?? new FilterButton();
            Button_B = buttonB ?? new FilterButton();
        }

        public string ExactFilterLabel { get; set; }
        public string ExactFilter { get; set; }

        public string LikeFilterLabel { get; set; }
        public string LikeFilter { get; set; }

        public string DropdownFilterLabel { get; set; }
        public int DropdownFilterSelectedOption { get; set; }
        public List<KeyValuePair<int, string>> DropdownOptions { get; set; }

        /// <summary>
        /// Objeto que se selecciono en el pop up. Si era una fecha desde y hasta, podria ser un diccionario o una lista con estos valores.
        /// </summary>
        public object Button_Filtro_Seleccion { get; set; }

        string _Button_Filtro_Seleccion_Descripcion;
        /// <summary>
        /// Descripcion de la seleccion, para mostrar a la izquierda del boton
        /// </summary>
        public string Button_Filtro_Seleccion_Descripcion
        {
            get { return _Button_Filtro_Seleccion_Descripcion; }
            set { _Button_Filtro_Seleccion_Descripcion = value; InvokePropertyChanged(new PropertyChangedEventArgs("Button_Filtro_Seleccion_Descripcion")); }
        }

        /// <summary>
        /// Metodo que recibe la seleccion del pop up y guarda el/los valores en una propiedad
        /// </summary>
        /// <param name="o"></param>
        public void Button_Filtro_Seleccionar(object o, string descripcionSeleccion)
        {
            Button_Filtro_Seleccion = o;
            Button_Filtro_Seleccion_Descripcion = descripcionSeleccion;
        }
        /// <summary>
        /// Boton para el "filtro extraño". La accion de este boton deberia abrir un form nuevo donde se selecciona la subconsulta.
        /// </summary>
        public FilterButton Button_Filtro { get; set; }

        public FilterButton Button_A { get; set; }
        public FilterButton Button_B { get; set; }

        //ToDo
        public DateTime? DateTimeFilter { get; set; }

        public void ResetFilter()
        {
            ExactFilter = "";
            LikeFilter = "";
            DropdownFilterSelectedOption = 0;
            DateTimeFilter = null;
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

    public class FilterButton
    {
        /// <summary>
        /// Disabled button
        /// </summary>
        public FilterButton()
        {
            Text = "";
            Visible = false;
            Action = () => { };
        }

        public FilterButton(string text, ButtonActionDelegate action, string color = "")
        {
            Text = text;
            Action = action;
            //Color = color;
            Visible = true;
        }

        public string Text { get; set; }
        public ButtonActionDelegate Action { get; set; }
        public bool Visible { get; set; }
        //public string Color { get; set; }
    }

    public delegate void ButtonActionDelegate();

    public delegate void FiltroComodinSeleccionarDelegate(object o, string description);
}
