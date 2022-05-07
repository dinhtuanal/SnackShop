using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VSubCategory
    {
        public Guid SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public Status Status { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
