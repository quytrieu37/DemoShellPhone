using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.WebUI.Models
{
    public class AddToCartModel
    {
        [Required(ErrorMessage ="vui ong nhap product iD")] // custom lại nếu lỗi thì đưa ra tiếng việt chứ không phải tiếng anh
        [Range(1, int.MaxValue)] //nếu sử dụng model binding thì ta có thheer ràng buộc dữ liệu ở đây
        public int ProductId { get; set; }
        [Required]
        [Range(1,100)]
        public int Quantity { get; set; }
    }

}