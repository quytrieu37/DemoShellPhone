using Demo.Domain.Abstract;
using Demo.Domain.Concrete;
using Demo.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //khai báo repository
        private readonly IMainRepository _mainRepository;

        //inject
        public HomeController(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        //abcs zuxux
        public ViewResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();

            model.Products = _mainRepository.Products
                .OrderByDescending(x => x.ProductId)
                .Take(3)
                .ToList();

            return View(model);
        }
        public ViewResult ListProduct(int page=1, int pageSize=10, int category=-1)
        {
            HomeListProductViewModel model = new HomeListProductViewModel();
            model.Products = _mainRepository.Products
                .Where(x=>category==-1 || x.CategoryId== category)
                .OrderByDescending(x=>x.ProductId)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToList();
            model.PagingInfo = new PagingInfo()
            {
                CurentPage = page,
                PageSize = pageSize,
                TotalItems = _mainRepository.Products
                .Where(x=>category==-1 || x.CategoryId== category)
                .Count()
            };
            model.Categories = _mainRepository.Categories.ToList();
            model.CurrentCategory = category;
            return View(model);
        }
        public ViewResult ListCustomer(int page=1,int pageSize=3, int province=-1)
        {
            HomeListCustomerViewModel model = new HomeListCustomerViewModel();
            model.Customers = _mainRepository.Customers
                .Where(x => province == -1 || x.ProvinceId == province)
                .OrderBy(x=>x.ProvinceId)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToList();
            model.PagingInfo = new PagingInfo()
            {
                CurentPage = page,
                PageSize = pageSize,
                TotalItems = _mainRepository.Customers
                .Where(x=>province==-1||x.ProvinceId==province)
                .Count()
            };
            model.Provinces = _mainRepository.Provinces.ToList();
            model.CurrentProvince = province;
            return View(model);
        }
        //commit test
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //demo josn
        public JsonResult GetProduct(int id)
        {
            var product = _mainRepository.Products
                .Select(x => new { x.ProductId, x.Price, x.ProductName, x.Amount }) // vì product có tạo khóa ngoại nên nếu không select sẽ tạo ra vòng lặp vô hạn ở đây
                .FirstOrDefault(x => x.ProductId == id);
            return Json(product, JsonRequestBehavior.AllowGet);// allowget ở đây để đánh dấu là get vì Json mặc định là post nên muốn đánh dấu ở đây là get thì phải alowget
        }
        public JsonResult GetListProduct()
        {
            var products = _mainRepository.Products
                .Select(x=> new { x.ProductId, x.Price, x.ProductName, x.Amount})
                .Take(5).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

    }
}