using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VCategory
    {
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
