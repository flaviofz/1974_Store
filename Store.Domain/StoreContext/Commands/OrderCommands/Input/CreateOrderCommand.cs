using System;
using System.Collections.Generic;

namespace Store.Domain.StoreContext.Commands.OrderCommands.Input
{
    public class CreateOrderCommand
    {
        public Guid IdCustomer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }
    }

    public class OrderItemCommand
    {
        public Guid idProduct { get; set; }
        public decimal Quantity { get; set; }
    }
}