using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WSConvertisseur.Controllers;
using WSConvertisseur.Models;
namespace WSConvertisseurUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public DeviseController Controller { get; set; }
        [TestInitialize]
        public void InitialisationDesTests()
        {
            // Arrange             
            Controller = new DeviseController();
        }

        [TestMethod]
        public async void GetById_ExistingIdPassed_ReturnsOkObjectResult()
        {            
                      // Act             
            var result = await Controller.GetById(1); 
                      // Assert 
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public async void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            
            // Act             
            var result = await Controller.GetById(1) as OkObjectResult;
            // Assert             
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise");
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise)result.Value, "Devises pas identiques");
        }

        [TestMethod]
        public async void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act             
            var result = await Controller.GetById(20);
            // Assert             
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }

        [TestMethod]
        public async void GetAll_IsDevisesArrayFull()
        {
            List<Devise> _devises = new List<Devise>();
             _devises.AddRange(await Controller.GetAll());
            CollectionAssert.Contains(_devises, new Devise(1, "Dollar", 1.08));
            CollectionAssert.Contains(_devises, new Devise(2, "Franc Suisse", 1.07));
            CollectionAssert.Contains(_devises, new Devise(3, "Yen", 120));
        }

        [TestMethod]
        public async void Post_IsDeviseAdd()
        {
            List<Devise> _devises = new List<Devise>();
            await Controller.Post(new Devise(4, "Couronne", 300));
            _devises.AddRange(await Controller.GetAll());
            CollectionAssert.Contains(_devises, new Devise(4, "Couronne", 300));

        }

        [TestMethod]
        public async void Put_IsDeviseModified()
        {
            List<Devise> _devises = new List<Devise>();
            await Controller.Put(2, new Devise(2, "Couronne", 300));
            _devises.AddRange(await Controller.GetAll());
            CollectionAssert.Contains(_devises, new Devise(2, "Couronne", 300));
        }

        [TestMethod]
        public async void Delete_IsDeviseModified()
        {
            List<Devise> _devises = new List<Devise>();
            await Controller.Delete(2);
            _devises.AddRange(await Controller.GetAll());
            CollectionAssert.DoesNotContain(_devises, new Devise(2, "Couronne", 300));
        }

        [TestCleanup]
        public void NettoyageDesTests()
        {
            Controller = null;     
        } 

    }
}
