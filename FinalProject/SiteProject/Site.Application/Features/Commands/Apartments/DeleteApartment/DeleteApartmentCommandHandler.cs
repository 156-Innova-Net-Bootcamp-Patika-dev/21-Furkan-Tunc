using FluentValidation;
using MediatR;
using Site.Application.Contracts.Persistence.Repositories.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Apartments.DeleteApartment
{
    public class DeleteApartmentCommandHandler : IRequestHandler<DeleteApartmentCommand, int>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly DeleteApartmentValidator _validator;

        public DeleteApartmentCommandHandler(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
            _validator = new DeleteApartmentValidator();
        }

        public async Task<int> Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            var apartment = await _apartmentRepository.GetByIdAsync(request.ID);

            if (apartment==null)
                throw new InvalidOperationException("There is no apartment with this id number.");

            await _apartmentRepository.RemoveAsync(apartment);
            return 1;
        }
    }
}
