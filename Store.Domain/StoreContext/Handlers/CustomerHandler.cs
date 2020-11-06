using System;
using FluentValidator;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            #region Validacao No Banco
            // Verificar se CPF existe na base
            // Verificar se E-mail existe na base
            #endregion

            #region Criando VOs e Entidades
            // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar entidades
            var customer = new Customer(name, document, email, command.Phone);
            #endregion

            #region Validando VOs e Entidades - Adiciona notificações
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);
            #endregion

            // Persistir o cliente
            // Enviar e-mail de boas vindas

            // Retornar resultado para a tela
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}