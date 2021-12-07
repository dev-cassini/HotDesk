using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.TestHelper.Builders
{
    public class DepartmentBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _name = "Department";
        private bool _enabled = true;

        public Department Build()
        {
            return new Department(
                _id,
                _name,
                _enabled,
                new List<IValidator<Department>>());
        }

        public DepartmentBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}
