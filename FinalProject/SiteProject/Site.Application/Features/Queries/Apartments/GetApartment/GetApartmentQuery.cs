using MediatR;
using Site.Application.Models.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentQuery:IRequest<ApartmentModel>
    {
        public GetApartmentQuery(int Id)
        {
            ID = Id;
        }

        public int ID { get; set; }
    }
}
