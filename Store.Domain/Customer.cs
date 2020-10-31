using System;

namespace Store.Domain
{
    public class Customer
    {
        // Propriedades
        public string Name { get; set; }
        public DateTime BirtDate { get; set; }
        public decimal Salary { get; set; }

        // Métodos
        public void Register() { }

        // Eventos
        public void AoRegistrar() { }
    }
}