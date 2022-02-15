using AutoMapper;
using MediatR;
using Site.Application.Contracts.Persistence.Repositories.Apartments;
using Site.Application.Models.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentQueryHandler : IRequestHandler<GetApartmentQuery, ApartmentModel>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public GetApartmentQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<ApartmentModel> Handle(GetApartmentQuery request, CancellationToken cancellationToken)
        {
            var apartment = await _apartmentRepository.GetByIdAsync(request.ID);

            if (apartment == null)
                throw new InvalidOperationException("There is no apartment with this id number.");

            var apartmentModel = _mapper.Map<ApartmentModel>(apartment);
            return apartmentModel;
        }
    }
}
