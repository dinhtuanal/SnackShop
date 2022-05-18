using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class CategoryViewModel
    {
        public string CategoryId { get; set; }
        [Required(ErrorMessage ="Không thể để trống tên thể loại")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
