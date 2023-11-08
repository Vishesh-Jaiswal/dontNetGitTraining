using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System.Diagnostics;
using System.Xml.Linq;

namespace BLTest
{
    public class ProductServiceTest
    {

        IProductService repository1;
        [SetUp]
        public void Setup()
        {
            repository1 = new ProductService();
        }

        [Test]
        public void AddProductTestBL()
        {
            //Arrange

            //Action
            var result = repository1.AddProduct(new Product { Name = "Nissan" });

            //Assert
            Assert.IsNotNull(result);
        }


        [TestCase(1, "Maruti")]
        [TestCase(2, "Alto")]
        public void GetProductTest(int id, string name)
        {
            //Arrange

            var prod1 = repository1.AddProduct(new Product { Name = "Maruti" });
            var prod2 = repository1.AddProduct(new Product { Name = "Alto" });

            //Action
            var result = repository1.GetProduct(id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo(name));
        }

        [TestCase(1,"New Price")]
        public void UpdateProductPriceTestBL(int id, string name)
        {
            //Arrange
            var prod2 = repository1.AddProduct(new Product { Name = "Alto", Price = 500 });
            var prod1 = repository1.UpdateProductPrice(1, 700 );
            
            //Action
            var result = repository1.GetProduct(id);
       
            //Assert
            Assert.That(result.Id, Is.EqualTo(id));
            //Assert.That(result.Name, Is.EqualTo(name));
            Assert.That(result.Price, Is.EqualTo(700));
        }
    }
}