using Data.Entities;
using Microsoft.EntityFrameworkCore;
using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Category thức ăn nhanh và các bài viết
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = Guid.Parse("7C318165-4FD6-4FE2-A85C-069B08AE611F"),
                    CategoryName = "Thức ăn nhanh",
                    Description = "Bạn có dùng thức ăn nhanh? Có nhiều người phàn nàn về nó nhưng thức ăn nhanh đúng là những món ăn ngon! – nghĩa là khi bạn đến một trong những nhà hàng như McDonalds hay Kentucky. Tôi nghĩ trong thế giới ngày nay rất khó để tránh việc ăn nhanh trong nhà hàng. Bởi chúng rất thuận tiện và đáp ứng được ở mọi mọi. Tất nhiên chúng không giống như thức ăn trong các nhà hàng thực thụ khác. Tôi ngạc nhiên vì chúng là những nhà hàng mà không có cả người phục vụ. Ngoài ra, điều quan trọng nhất là thức ăn nhanh không có lợi cho sức khỏe. Những ai dùng nó hằng ngày sẽ gặp nhiều vấn đề về sức khỏe. Tôi không hiểu tại sao có một vài trường học lại dùng thức ăn nhanh cho thực đơn bữa trưa trong khi họ nên khuyến khích học sinh ăn uống đầy đủ để đảm bảo sức khỏe. Nếu các bạn có thời gian hãy quan tâm nhiều hơn đến những bữa ăn điều độ tại những trang mạng.",
                    Status = Status.Active
                }
            );
            #endregion
        }
    }
}
