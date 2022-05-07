using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class FoodViewModel
    {
        public string FoodId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; } // miêu tả
        public string Content { get; set; } // nội dung sản phẩm
        public int Status { get; set; } //Trạng thái còn hay hết
        public DateTime? DateCreated { get; set; }
        public string SubCategoryId { get; set; } // Mã thể loại
    }
}
