using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.BL.ViewModels
{
    public class FiltersViewModel
    {
        public FiltersViewModel(List<KeyValuePair<int, string>> dropdownOptions, string exactFilterTooltip = "", string likeFilterToolTip = "", string dropdownFilterTooltip = "")
        {
            DropdownOptions = dropdownOptions;
            ExactFilterToolTip = exactFilterTooltip;
            LikeFilterTooltip = likeFilterToolTip;
            DropdownFilterTooltip = dropdownFilterTooltip;
        }

        public string ExactFilter { get; set; }
        public string ExactFilterToolTip { get; set; }
        public string LikeFilter { get; set; }
        public string LikeFilterTooltip { get; set; }
        public int DropdownFilterSelectedOption { get; set; }
        public string DropdownFilterTooltip { get; set; }
        public List<KeyValuePair<int, string>> DropdownOptions { get; set; }

        //ToDo
        public DateTime? DateTimeFilter { get; set; }

        public void ResetFilter()
        {
            ExactFilter = "";
            LikeFilter = "";
            DropdownFilterSelectedOption = 0;
            DateTimeFilter = null;
        }
    }
}
