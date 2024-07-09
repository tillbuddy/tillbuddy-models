namespace TillBuddy.SDK.Model;

public interface INotification { }


public interface IIntegrationEvent : INotification
{

}

public interface IDomainEvent : INotification
{

}