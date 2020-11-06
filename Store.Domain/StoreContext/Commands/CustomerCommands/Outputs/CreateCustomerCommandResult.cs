using System;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult() { }
        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            this.id = id;
            Name = name;
            Email = email;
        }

        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}