namespace ECommerce.Application.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>;
