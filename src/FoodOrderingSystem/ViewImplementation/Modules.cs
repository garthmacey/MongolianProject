using Prism.Ioc;
using Prism.Modularity;
using ViewImplementation.Views;
using System.Diagnostics.CodeAnalysis;

namespace ViewImplementation
{
    [ExcludeFromCodeCoverage]
    public class Modules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CustomerMenuView>();
            containerRegistry.RegisterForNavigation<OrderProgressView>();
            containerRegistry.RegisterForNavigation<AdminView>();
            containerRegistry.RegisterForNavigation<ChefStatusView>();
            containerRegistry.RegisterForNavigation<ChefFoodItemView>();
            containerRegistry.RegisterForNavigation<CustomerPaymentView>();
        }
    }
}