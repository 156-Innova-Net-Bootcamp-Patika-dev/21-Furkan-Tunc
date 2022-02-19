using AutoMapper;
using MediatR;
using Site.Application.Contracts.Persistence.Repositories.Bills;
using Site.Application.Models.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Bills.GetAllBills
{
    public class GetAllBillsQueryHandler : IRequestHandler<GetAllBillsQuery, List<BillModel>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;
        public GetAllBillsQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }
        public async Task<List<BillModel>> Handle(GetAllBillsQuery request, CancellationToken cancellationToken)
        {
            var bills = await _billRepository.GetAllAsync();
            var result = _mapper.Map<List<BillModel>>(bills);
            return result;
        }
    }
}
