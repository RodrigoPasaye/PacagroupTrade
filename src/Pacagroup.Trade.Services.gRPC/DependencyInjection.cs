using Pacagroup.Trade.Services.gRPC.Commons.GlobalException;
using Pacagroup.Trade.Services.gRPC.Commons.Mappings;

namespace Pacagroup.Trade.Services.gRPC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(MappingProfile));
            services.AddGrpc(options =>
            {
                options.Interceptors.Add<GlobalExceptionHandler>();
            });
            return services;
        }
    }
}
