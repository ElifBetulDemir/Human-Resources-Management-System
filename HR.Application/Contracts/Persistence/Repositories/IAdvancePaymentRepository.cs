﻿using HR.Application.Contracts.Persistence.Repositories.Base;
using HR.Domain.Concrete;

namespace HR.Application.Contracts.Persistence.Repositories;

public interface IAdvancePaymentRepository : IBaseRepository<AdvancePayment>
{
    Task<IEnumerable<AdvancePayment>> GetAllByPersonIdAsync(Guid id, CancellationToken token);
}