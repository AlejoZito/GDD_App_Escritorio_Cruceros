using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL
{
    public delegate void OnButtonClickDelegate();
    public delegate void OnButtonClickWithIDDelegate(int ID);
    public delegate void OnAddSuccessDelegate<T>(T t);
    public delegate void OnEditSuccessDelegate<T>(T t);
    public delegate void OnDeleteSuccessDelegate<T>(T t);
}
