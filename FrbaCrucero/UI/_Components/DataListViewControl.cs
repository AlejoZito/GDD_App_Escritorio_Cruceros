using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.UI._Components
{
    public class DataListViewControl : ListView
    {
        public DataListViewControl()
        {
            View = View.Details;
            this.HeaderStyle = ColumnHeaderStyle.None;
        }
        public void SetDataBinding(object dataSource, string dataMember = null)
        {
            var cm = BindingContext[dataSource] as CurrencyManager;
            RefreshList(cm, dataMember);
            if (cm.List != null)
                cm.ListChanged += (s, e) =>
                    RefreshList(cm, dataMember);       // note: e.ListChangedType
        }
        private void RefreshList(CurrencyManager cm, string dataMember)
        {
            this.Clear();
            var props = cm.GetItemProperties();

            if (dataMember == null)
            {
                foreach (PropertyDescriptor pd in props)
                    this.Columns.Add(new ColumnHeader
                    {
                        Text = pd.Name,
                        Width = 100,
                        TextAlign = HorizontalAlignment.Left
                    });
                foreach (object itm in cm.List)
                {
                    var items = new string[props.Count];
                    for (int i = 0; i < props.Count; i++)
                        items[i] = Convert.ToString(props[i].GetValue(itm));
                    this.Items.Add(new ListViewItem(items));
                }
            }
            else
            {
                PropertyDescriptor foundProp = props.Find(dataMember, true);
                this.Columns.Add(new ColumnHeader{
                    Text = "",
                    TextAlign = HorizontalAlignment.Left,
                    Width = this.Width - 10
                });                   

                if (foundProp != null)
                {
                    foreach (object itm in cm.List)
                    {
                        this.Items.Add(new ListViewItem(Convert.ToString(foundProp.GetValue(itm))));
                    }
                }
            }
        }
    }
}
