using Demo.Domain.Abstract;
using Demo.Domain.Entities;
using Demo.WebUI.Models;
using Demo.WebUI.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Demo.WebUI.Controllers
{
    public class CartController : Controller
    {
        //khai báo repository
        private readonly IMainRepository _mainRepository;

        //inject
        public CartController(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }
        // GET: Cart
        public ViewResult Index()
        {
            var cart = GetCart();

            return View(cart);//show cart lên view
        }
        //[HttpPost]
        //public ActionResult AddToCart(AddToCartModel model) //model binding
        //{
        //    //kiem tra xem sản phẩm có tồn kho hay không tùy vào nghiệp vụ
        //    var product = _mainRepository
        //     .Products
        //     .FirstOrDefault(x => x.ProductId == model.ProductId);

        //    if (product != null)
        //    {
        //        //add to cart
        //        var cart = GetCart();
        //        cart.Add(product, model.Quantity);
        //    }
        //    return RedirectToAction("Index");
        //}
        //private Cart GetCart()
        //{
        //    //lấy giỏ hàng từ session
        //    var cart = Session["cart"] as Cart;
        //    //chưa có giỏ hàng
        //    if(cart == null)
        //    {
        //        //khởi tạo
        //        cart = new Cart();
        //        //lưu vào session
        //        Session["cart"] = cart;
        //    }
        //    return cart;
        //}

        //xử lí json
        [HttpPost]
        //public ActionResult AddToCart(int productId, int quantity) //nếu không sử dụng model binding thì sẽ như vầy 
        //public ActionResult AddToCart(AddToCartModel model)// model binding khai báo model ở đây và ràng buộc dữ liệu trong model
        public JsonResult AddToCartJson(AddToCartModel model)
        {
            
            if(ModelState.IsValid)// check model có hợp lệ hay không => tác dụng của model binding
            {
                var product = _mainRepository.Products.FirstOrDefault(x => x.ProductId == model.ProductId);
                if (product != null)
                {
                    var cart = GetCart();
                    cart.Add(product, model.Quantity);
                    return Json(new { state = true, msg = "thanh cong" });
                    
                }
            }

            var data = (new { state = false, msg = " khong thanh cong" });
            return Json(data);// ở đây không cần AllowGet vì mặc định của return Json là Post mà action này mình đã khai báo HttpPost rồi nên return Post mặc định là correct
            //return RedirectToAction(nameof(CartController.Index));
        }

        [HttpPost]
        public JsonResult RemoveFromCartJson(int productId)
        {
            
            var product = _mainRepository.Products.FirstOrDefault(x => x.ProductId == productId);
            if(product != null)
            {
                var cart = GetCart();
                cart.Remove(product);
                return Json(new { state = true, msg = "xoa thanh cong" });
                
            }

            var data1 = (new { state = false, msg = "xoa that bai" });
            return Json(data1);
        }

        [HttpPost]
        //public ActionResult AddToCart(int productId, int quantity) //nếu không sử dụng model binding thì sẽ như vầy 
        public JsonResult UpdateToCartJson(AddToCartModel model)// model binding khai báo model ở đây và ràng buộc dữ liệu trong model
        {
            
            if (ModelState.IsValid)// check model có hợp lệ hay không => tác dụng của model binding
            {
                var product = _mainRepository.Products.FirstOrDefault(x => x.ProductId == model.ProductId);
                if (product != null)
                {
                    var cart = GetCart();
                    cart.Update(product, model.Quantity);
                    return Json(new { state = true, msg = "update thanh cong" });
                    
                }
            }
            return Json(new { state = false, msg=""});
            
        }
        public PartialViewResult CartSummary()
        {
            var cart = GetCart();
            return PartialView(cart);
        }
        public PartialViewResult BodySummary()
        {
            var cart = GetCart();
            return PartialView(cart);
        }
        public ActionResult CheckOut()
        {
            //var cart = GetCart();
            //nếu giỏ hàng rỗng
            //if(cart.Lines.Count()==0)
            //{
            //    return RedirectToAction(nameof(CartController.Index));
            //}
            //ViewBag.Cart = cart;
            ViewBag.Payments = _mainRepository.Payments.ToList();// nhận giá trị là 1 list 
            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(CartCheckOutModel model)
        {
            //kiểm tra tính hợp lệ hay không
            if(ModelState.IsValid)
            {
                //gửi email: nội dung, chủ đề , người nhận
                //xây dựng nội dung
                StringBuilder sb = new StringBuilder();
                sb.Append("<table>");
                //full name
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("Khách hàng");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(model.FullName);
                sb.Append("</td>");
                sb.Append("</tr>");

                //email
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("Email");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(model.Email);
                sb.Append("</td>");
                sb.Append("</tr>");
                //điện thoại
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("ĐIện thoại");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(model.Phone);
                sb.Append("</td>");
                sb.Append("</tr>");
                ///địa chỉ
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("Khách hàng");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(model.FullName);
                sb.Append("</td>");
                sb.Append("</tr>");
                //thanh toán
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("Khách hàng");
                sb.Append("</td>");
                var payment = _mainRepository.Payments.FirstOrDefault(x => x.PaymentId== model.PaymentMethod);
                sb.Append("<td>");
                sb.Append(payment.PaymentName);// ở đây phải như vầy vì truyền lên client chỉ có Id nên phải xài như vầy
                sb.Append("</td>");
                sb.Append("</tr>");
                //ghi chú
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("ghi chú");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(model.Note);
                sb.Append("</td>");
                sb.Append("</tr>");
                
                //ship
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("Ship tajajn nhà");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(model.UseShipper ? "X" : "");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                var sender = new EmailSender();
                sender.Send("thong bao đạt hàng", sb.ToString(), model.Email);

            }    
            return Redirect("/"); // về trang chủ
        }

        #region Helper
        private Cart GetCart()
        {
            //lấy giỏ  hàng từ session
            var cart = Session["cart"] as Cart;
            //chưa có giỏ hàng
            if (cart == null)
            {
                //khởi tạo
                cart = new Cart();
                //lưu vào session
                Session["cart"] = cart;
            }
            return cart;
        }
        #endregion
    }
    //cookie chỉ nhận string lưu ở browser, section nhận object và lưu ở server => bảo mật hơn
}


