using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.OrderCommands.Input
{
    public class CreateOrderCommand : Notifiable, ICommand
    {
        public CreateOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid IdCustomer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasLen(IdCustomer.ToString(), 36, "Customer", "Identificador do cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum ítem do pedido foi encontrado")
            );

            return Valid();
        }
    }

    public class OrderItemCommand
    {
        public Guid idProduct { get; set; }
        public decimal Quantity { get; set; }
    }
}