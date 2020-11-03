using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Flavio", "Zavarise");
            var document = new Document("12345678911");
            var email = new Email("flaviofz@gmail.com");
            var customer = new Customer(name, document, email, "123456789");

            var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "image.png", 159.90M, 10);
            var impressora = new Product("Impressora", "impressora", "image.png", 359.90M, 10);
            var cadeira = new Product("Cadeira", "cadeira", "image.png", 559.90M, 10);

            var order = new Order(customer);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(cadeira, 5));
            order.AddItem(new OrderItem(impressora, 5));

            // Realizando o pedido
            order.Place();

            // Pagamento
            order.Pay();

            // Simular envio
            order.Ship();

            // Simular cancelamento
            order.Cancel();
        }
    }
}
