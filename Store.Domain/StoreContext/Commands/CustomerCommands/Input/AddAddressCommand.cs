using System;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class AddAddressCommand
    {
        public Guid idCustomer { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }
    }
}