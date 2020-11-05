using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;
using Store.Domain.StoreContext.Enums;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Product _mouse;
        private Product _monitor;
        private Product _chair;
        private Product _keyboard;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Flavio", "Zavarise");
            var document = new Document("12345678977");
            var email = new Email("flaviofz@gmail.com");
            _customer = new Customer(name, document, email, "12345648");

            _mouse = new Product("Mouse", "Mouse sem fio", "imagem.png", 20.50M, 15);
            _keyboard = new Product("Teclado", "Teclado sem fio", "imagem.png", 45.60M, 10);
            _chair = new Product("Cadeira", "Cadeira gamer", "imagem.png", 500.00M, 5);
            _monitor = new Product("Monitor", "Monitor", "imagem.png", 355.99M, 3);

            _order = new Order(_customer);
        }

        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 2);
            _order.AddItem(_keyboard, 1);

            Assert.AreEqual(2, _order.Items.Count);
        }

        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 10);

            Assert.AreEqual(5, _mouse.QuantityOnHand);
        }

        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_monitor, 2);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_monitor, 2);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_monitor, 2);
            _order.AddItem(_keyboard, 1);

            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, item.Status);
            }
        }
    }
}
