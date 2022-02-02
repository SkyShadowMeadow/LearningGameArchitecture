
namespace Assets.Scripts.Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices _instance;

        public static AllServices Container =>
            _instance ?? (_instance = new AllServices());

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;
        
        public TService GetSingle<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;
        
        public static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}
