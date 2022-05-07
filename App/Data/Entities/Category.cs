using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Category
    {
        public Category()
        {
            SubCategories = new List<SubCategory>();        }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public ICollection<SubCategory> SubCategories{ get; set; }
    }
}
