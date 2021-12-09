using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.TestHelper.Builders
{
    public class LocationBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _name = "Location";
        private bool _enabled = true;

        public Location Build()
        {
            return new Location(
                _id,
                _name,
                _enabled,
                new List<IValidator<Location>>());
        }

        public LocationBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}
