using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Demo.WebUI.Models
{
    public class CartCheckOutModel
    {
        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage ="vui lòng nhập họ tên")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "vui lòng nhập Email")]
        //[DataType(DataType.EmailAddress, ErrorMessage ="email không đúng định dạng")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng")]
        public string Email { get; set; }


        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "vui lòng nhập điện thoại")]
        [StringLength(20, MinimumLength =10, ErrorMessage ="phone không hợp lệ")]
        public string Phone { get; set; }



        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "vui lòng nhập Địa chỉ")]
        [StringLength(500, ErrorMessage ="địa chỉ sai phông")]
        public string Address { get; set; }


        [Display(Name = "Phương thức thanh toán")]
        public int PaymentMethod { get; set; }


        [Display(Name = "Ghi chú")]
        public string Note { get; set; }


        [Display(Name = "Ship hàng tận nhà?")]
        public bool UseShipper { get; set; }
    }
}