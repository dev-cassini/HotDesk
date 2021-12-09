using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.TestHelper.Builders
{
    public class FloorplanBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _name = "Floorplan";
        private Guid _locationId = Guid.NewGuid();
        private bool _enabled = true;

        public Floorplan Build()
        {
            return new Floorplan(
                _id,
                _name,
                _locationId,
                _enabled,
                new List<IValidator<Floorplan>>());
        }

        public FloorplanBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public FloorplanBuilder WithLocationId(Guid locationId)
        {
            _locationId = locationId;
            return this;
        }
    }
}
