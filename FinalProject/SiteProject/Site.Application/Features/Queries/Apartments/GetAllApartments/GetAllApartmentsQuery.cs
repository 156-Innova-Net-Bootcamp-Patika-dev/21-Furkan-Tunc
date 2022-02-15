using MediatR;
using Site.Application.Models.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Apartments.GetAllApartments
{
    public class GetAllApartmentsQuery : IRequest<List<ApartmentModel>>
    {
    }
}
