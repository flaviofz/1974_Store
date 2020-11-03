using System;
using System.Collections.Generic;
using System.Linq;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Domain.StoreContext.Entities
{
    public class Customer
    {
        private readonly IList<Address> _address;

        public Customer
        (
            Name name,
            Document document,
            Email email,
            string phone
        )
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _address = new List<Address>();
        }

        // Propriedades
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _address.ToArray();

        public void AddAddress(Address address)
        {
            // Adicionar o endereço
            _address.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}