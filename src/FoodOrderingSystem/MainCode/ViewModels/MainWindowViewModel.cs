using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace MainCode.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
            Navigate("ChefStatusView");
            Navigate("AdminView");
            Navigate("OrderProgressView");
            Navigate("CustomerView");
            Navigate("CustomerMenuView");
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }
    }
}
