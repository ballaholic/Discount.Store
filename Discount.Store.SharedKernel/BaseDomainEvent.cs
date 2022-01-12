using System;

using MediatR;

namespace Discount.Store.SharedKernel
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOcurred { get; protected set; } = DateTime.UtcNow;
    }
}
