using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Apartments.DeleteApartment
{
    public class DeleteApartmentCommand:IRequest
    {
        public DeleteApartmentCommand(int Id)
        {
            ID = Id;
        }
        public int ID { get; set; }
    }
}
