using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI.Components
{
    public class InputTextControl : Control
    {
        public Label Label;
        public TextBox TextBox;
        public Label InputDescription;
        public Label ValidationMessage;

        public InputTextControl(string textBoxLabel, string inputDescriptionText)
        {
            Label = new Label()
            {
                Text = textBoxLabel,
                Width = 120,
                Height = 30,
                Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
            };

            TextBox = new TextBox()
            {
                Text = "",
                Width = 180,
                Height = 50,
                Font = new Font(FontFamily.GenericSansSerif, 12),
            };
            //textBox.DataBindings.Add("Text", _ViewModel, "NombreCrucero");

            InputDescription = new Label()
            {
                Name = textBoxLabel + "_label",
                Text = inputDescriptionText,
                Width = 426,
                Height = 30,
                Font = new Font(FontFamily.GenericSansSerif, 8),
                BackColor = Color.Yellow,
                Margin = new Padding(0, 0, 0, 4),
                //AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                //Dock = DockStyle.Fill
            };
        }
    }
}
