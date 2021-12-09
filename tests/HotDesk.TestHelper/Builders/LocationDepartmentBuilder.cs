using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.TestHelper.Builders
{
    public class LocationDepartmentBuilder
    {
        private Guid _id = Guid.NewGuid();
        private Guid _locationId = Guid.NewGuid();
        private Guid _departmentId = Guid.NewGuid();
        private bool _enabled = true;

        public LocationDepartment Build()
        {
            return new LocationDepartment(
                _id,
                _locationId,
                _departmentId,
                _enabled,
                new List<IValidator<LocationDepartment>>());
        }

        public LocationDepartmentBuilder WithLocationId(Guid locationId)
        {
            _locationId = locationId;
            return this;
        }

        public LocationDepartmentBuilder WithDepartmentId(Guid departmentId)
        {
            _departmentId = departmentId;
            return this;
        }
    }
}
