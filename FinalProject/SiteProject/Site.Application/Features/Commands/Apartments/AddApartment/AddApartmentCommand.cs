using MediatR;
using Site.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Apartments.AddApartment
{
    public class AddApartmentCommand:IRequest<Apartment>
    {
        public byte Blok { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public byte Floor { get; set; }
        public byte ApartmentNumber { get; set; }
        public string Owner { get; set; }
        public int UserId { get; set; }
    }
}
