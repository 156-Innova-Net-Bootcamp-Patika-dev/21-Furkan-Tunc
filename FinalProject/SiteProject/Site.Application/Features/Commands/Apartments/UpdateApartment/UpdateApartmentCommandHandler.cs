using AutoMapper;
using FluentValidation;
using MediatR;
using Site.Application.Contracts.Persistence.Repositories.Apartments;
using Site.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Apartments.UpdateApartment
{
    public class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommand, int>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly UpdateApartmentValidator _validator;

        public UpdateApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _validator = new UpdateApartmentValidator();
        }

        public async Task<int> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var apartment = await _apartmentRepository.GetByIdAsync(request.Id);

            if (apartment == null)
                throw new InvalidOperationException("There is no apartment with this id number.");

            apartment.ApartmentNumber = request.ApartmentNumber != default ? request.ApartmentNumber : apartment.ApartmentNumber;
            apartment.Blok = request.Blok != default ? request.Blok : apartment.Blok;
            apartment.Floor = request.Floor != default ? request.Floor : apartment.Floor;
            apartment.Owner = request.Owner != default ? request.Owner : apartment.Owner;
            apartment.Status = request.Status != default ? request.Status : apartment.Status;
            apartment.Type = request.Type != default ? request.Type : apartment.Type;

            await _apartmentRepository.UpdateAsync(apartment);
            return 1;
        }
    }
}
