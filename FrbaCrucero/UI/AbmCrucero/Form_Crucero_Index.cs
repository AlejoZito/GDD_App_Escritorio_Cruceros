using FrbaCrucero.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.UI.AbmCrucero
{
    public class Form_Crucero_Index : FrbaCrucero.UI.Form_Base_Index<CruceroViewModel>
    {
        protected override List<CruceroViewModel> GetData()
        {
            return new List<CruceroViewModel>(){
                new CruceroViewModel(1, "29", "Revolution 9", "Beatles", true),
                new CruceroViewModel(2, "6", "Fools Rush In", "Frank Sinatra", true),
                new CruceroViewModel(3, "1", "One of These Days", "Pink Floyd", true),
                new CruceroViewModel(4, "7", "Where Is My Mind?", "Pixies", true),
                new CruceroViewModel(5, "9", "Can't Find My Mind", "Cramps", false),
                new CruceroViewModel(6, "13", "Scatterbrain. (As Dead As Leaves.)", "Radiohead", true),
                new CruceroViewModel(7, "3", "Dress", "P J Harvey", true)
            };
        }
    }
}
