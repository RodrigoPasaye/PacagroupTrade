using Grpc.Core;
using Grpc.Core.Interceptors;
using Pacagroup.Trade.Application.UseCases.Commons.Exceptions;
using Pacagroup.Trade.Services.gRPC.Protos;

namespace Pacagroup.Trade.Services.gRPC.Commons.GlobalException
{
    public class GlobalExceptionHandler : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await base.UnaryServerHandler(request, context, continuation);
            }
            catch(ValidationExceptionCustom ex)
            {
                var serverResponse = new ServerResponse()
                {
                    Errors = string.Join(" | ", ex.Errors),
                    IsSuccess = false,
                    Message = "Validation Error",
                };
                return MapResponse<TRequest, TResponse>(serverResponse);
            }
            catch (Exception ex)
            {
                var serverResponse = new ServerResponse()
                {
                    Errors = ex.Message,
                    IsSuccess = false,
                    Message = "Error during the execution",
                };
                return MapResponse<TRequest, TResponse>(serverResponse);
            }
        }

        private TResponse MapResponse<TRequest, TResponse>(ServerResponse serverResponse)
        {
            var response = Activator.CreateInstance<TResponse>();
            SetNestedPropertyValue(response, "ServerResponse.IsSuccess", serverResponse.IsSuccess);
            SetNestedPropertyValue(response, "ServerResponse.Message", serverResponse.Message);
            SetNestedPropertyValue(response, "ServerResponse.Errors", serverResponse.Errors);
            return response;
        }

        private static void SetNestedPropertyValue<T>(T obj, string propertyPath, object value)
        {
            if (obj == null || string.IsNullOrEmpty(propertyPath))
                throw new ArgumentNullException(nameof(obj), "The object cannot be null or the property path cannot be empty.");

            var properties = propertyPath.Split('.');
            var currentObject = (object)obj;

            for (int i = 0; i < properties.Length; i++)
            {
                var propertyInfo = currentObject.GetType().GetProperty(properties[i]);
                if (propertyInfo == null)
                    throw new ArgumentException($"The property '{properties[i]}' was not found in the object of type '{currentObject.GetType().FullName}'.");

                if (i == properties.Length - 1)
                {
                    propertyInfo.SetValue(currentObject, value);
                }
                else
                {
                    var nextObject = propertyInfo.GetValue(currentObject);
                    if (nextObject == null)
                    {
                        nextObject = Activator.CreateInstance(propertyInfo.PropertyType);
                        propertyInfo.SetValue(currentObject, nextObject);
                    }
                    currentObject = nextObject;
                }
            }
        }
    }
}
