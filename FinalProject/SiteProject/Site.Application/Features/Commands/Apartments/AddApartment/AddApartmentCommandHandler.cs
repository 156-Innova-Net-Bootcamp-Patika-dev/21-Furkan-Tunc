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

namespace Site.Application.Features.Commands.Apartments.AddApartment
{
    public class AddApartmentCommandHandler : IRequestHandler<AddApartmentCommand, Apartment>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly AddApartmentValidator _validator;

        public AddApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _validator = new AddApartmentValidator();
        }
        public async Task<Apartment> Handle(AddApartmentCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var apartment = _mapper.Map<Apartment>(request);

            await _apartmentRepository.AddAsync(apartment);

            return apartment;
        }
    }
}
