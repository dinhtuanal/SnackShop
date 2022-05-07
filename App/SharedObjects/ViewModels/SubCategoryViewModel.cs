using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class SubCategoryViewModel
    {
        public string SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public int Status { get; set; }
        public string CategoryId { get; set; }
    }
}
