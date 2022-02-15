using Site.Application.Contracts.Persistence.Repositories.Apartments;
using Site.Domain.Entities;
using Site.Infrastructure.Contracts.Persistence.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Infrastructure.Contracts.Persistence.Concrete
{
    public class ApartmentRepository:RepositoryBase<Apartment>,IApartmentRepository
    {
        public ApartmentRepository(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
