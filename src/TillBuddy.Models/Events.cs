using MediatR;

namespace TillBuddy.SDK.Model;

public interface IIntegrationEvent : INotification
{

}

public interface IDomainEvent : INotification
{

}