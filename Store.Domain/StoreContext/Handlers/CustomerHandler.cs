using System;
using FluentValidator;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(
            ICustomerRepository repository,
            IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            #region Validacao No Banco
            // Verificar se CPF existe na base
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPf já está em uso");

            // Verificar se E-mail existe na base
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Este email já está em uso");
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

            if (Invalid)
                return null;
            #endregion

            #region Repositórios
            // Persistir o cliente
            _repository.Save(customer);

            // Enviar e-mail de boas vindas
            _emailService.Send(email.Address, "hello@balta.io", "Bem vindo", "Seja bem vindo ao app Store");
            #endregion

            // Retornar resultado para a tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}