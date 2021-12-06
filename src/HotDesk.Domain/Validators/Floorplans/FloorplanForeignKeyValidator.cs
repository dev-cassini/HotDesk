using FluentValidation;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using System.Linq;

namespace HotDesk.Domain.Validators.Floorplans
{
    public class FloorplanForeignKeyValidator : AbstractValidator<Floorplan>
    {
        public FloorplanForeignKeyValidator(IReadOnlyRepository readOnlyRepository)
        {
            RuleFor(floorplan => floorplan.LocationId)
                .Must(locationId =>
                {
                    var location = readOnlyRepository.Query<Location>()
                        .SingleOrDefault(l => l.Id == locationId);

                    return location is not null;
                })
                .WithMessage(floorplan => $"Location {floorplan.LocationId} does not exist.");
        }
    }
}
