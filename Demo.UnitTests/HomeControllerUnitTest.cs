using Demo.Domain.Abstract;
using Demo.Domain.Concrete;
using Demo.Domain.Entities;
using Demo.WebUI.Controllers;
using Demo.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Demo.UnitTests
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        //mock data
        private IMainRepository mainRepository;
        public HomeControllerUnitTest()
        {
            //mainRepository = new MainRepositoryFake();
        }

        [TestMethod]
        public void TestIndex()
        {
            //target
            HomeController controller = new HomeController(mainRepository);

            //action
            var result = controller.Index();// as ViewResult;
            var model = result.Model as HomeIndexViewModel;

            //assert
            int total = 3;//mainRepository.Products.Count();
            int actual = model.Products.Count();

            Assert.AreEqual(total, actual);
        }
    }

    //init data
    public class MainRepositoryFake// : IMainRepository
    {
        private List<Product> products = new List<Product>();
        public MainRepositoryFake()
        {
            products.Add(new Product() { });
            products.Add(new Product() { });
            products.Add(new Product() { });
            products.Add(new Product() { });
        }

        public IQueryable<Product> Products => products.AsQueryable();

        public IQueryable<Category> Categories => throw new NotImplementedException();
    }
}
