using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.TestHelper.Builders
{
    public class DeskBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _name = "Desk";
        private Guid _floorplanId = Guid.NewGuid();
        private Guid _departmentId = Guid.NewGuid();
        private int _xCoordinate = 100;
        private int _yCoordinate = 100;
        private int _width = 50;
        private int _height = 50;
        private bool _enabled = true;

        public Desk Build()
        {
            return new Desk(
                _id,
                _name,
                _floorplanId,
                _departmentId,
                _xCoordinate,
                _yCoordinate,
                _width,
                _height,
                _enabled,
                new List<IValidator<Desk>>());
        }
    }
}
