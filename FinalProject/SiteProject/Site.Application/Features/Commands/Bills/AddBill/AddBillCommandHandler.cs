﻿using AutoMapper;
using MediatR;
using FluentValidation;
using Site.Application.Contracts.Persistence.Repositories.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Site.Domain.Entities;
using Site.Application.Contracts.Persistence.Repositories.Apartments;
using Site.Application.Contracts.Persistence.Repositories.BillPayments;

namespace Site.Application.Features.Commands.Bills.AddBill
{
    public class AddBillCommandHandler : IRequestHandler<AddBillCommand, int>
    {
        private readonly IBillRepository _billRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBillPaymentRepository _billPaymentRepository;
        private readonly IMapper _mapper;
        private readonly AddBillValidator _validator;
        public AddBillCommandHandler(IBillRepository billRepository, IApartmentRepository apartmentRepository, IBillPaymentRepository billPaymentRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _apartmentRepository = apartmentRepository;
            _billPaymentRepository = billPaymentRepository;
            _mapper = mapper;
            _validator = new AddBillValidator();
        }
        public async Task<int> Handle(AddBillCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var addedBill = _mapper.Map<Bill>(request);

            await _billRepository.AddAsync(addedBill);

            var billId = await _billRepository.GetByIdAsync(addedBill.ID);

            var apartments = await _apartmentRepository.GetAllAsync();
            var apartmentFirst = apartments[0];
            var apartmentLast = apartments[apartments.Count - 1];

            for (int i = apartmentFirst.ID; i <= apartmentLast.ID; i++)
            {
                var billPayment = new BillPayment();

                billPayment.Electric = addedBill.Electric / apartments.Count;
                billPayment.Water = addedBill.Water / apartments.Count;
                billPayment.NaturalGas = addedBill.NaturalGas / apartments.Count;
                billPayment.Dues = addedBill.Dues;
                billPayment.Month = addedBill.Month;
                var apartmentId = await _apartmentRepository.GetByIdAsync(i);
                billPayment.ApartmentId = apartmentId.ID;
                billPayment.BillId = billId.ID;

                await _billPaymentRepository.AddAsync(billPayment);
            }

            return 1;
        }
    }
}