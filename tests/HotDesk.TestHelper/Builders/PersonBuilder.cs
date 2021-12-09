using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.TestHelper.Builders
{
    public class PersonBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _firstName = "Test";
        private string _lastName = "Person";
        private bool _enabled = true;

        public Person Build()
        {
            return new Person(
                _id,
                _firstName,
                _lastName,
                _enabled,
                new List<IValidator<Person>>());
        }

        public PersonBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }
    }
}
