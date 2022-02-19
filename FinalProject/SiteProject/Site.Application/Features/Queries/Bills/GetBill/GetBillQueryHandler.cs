using AutoMapper;
using MediatR;
using FluentValidation;
using Site.Application.Contracts.Persistence.Repositories.Bills;
using Site.Application.Models.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Site.Application.Contracts.Persistence.Repositories.BillPayments;

namespace Site.Application.Features.Queries.Bills.GetBill
{
    public class GetBillQueryHandler:IRequestHandler<GetBillQuery, List<BillModel>>
    {
        private readonly IBillPaymentRepository _billPaymentRepository;
        private readonly IMapper _mapper;
        private readonly GetBillValidator _validator;

        public GetBillQueryHandler(IBillPaymentRepository billPaymentRepository, IMapper mapper)
        {
            _billPaymentRepository = billPaymentRepository;
            _mapper = mapper;
            _validator = new GetBillValidator();
        }

        public async Task<List<BillModel>> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var bills =  await _billPaymentRepository.GetBillByUserId(request.UserId);

            if (bills == null)
                throw new InvalidOperationException("There is no bill.");

            var result = _mapper.Map<List<BillModel>>(bills);

            return result;

        }
    }
}
