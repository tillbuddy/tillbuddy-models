using MediatR;

namespace TillBuddy.Models;

public interface IIntegrationEvent : INotification
{

}

public interface IDomainEvent : INotification
{

}