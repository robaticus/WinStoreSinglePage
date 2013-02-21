using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using UseCaseSample.UseCaseManager;

namespace UseCaseSample.ViewModel
{
    public class DoubleWideViewModel : ViewModelBase
    {
        private readonly IUseCaseManager _useCaseManager;


        public DoubleWideViewModel() : this(null)
        {
        }

        [PreferredConstructor]
        public DoubleWideViewModel(IUseCaseManager useCaseManager)
        {
            _useCaseManager = useCaseManager;

            SetupCommands();
        }

        public RelayCommand ActivateItemsUseCaseCommand { get; set; }
        public RelayCommand ActivatePopupUseCaseCommand { get; set; }

        private void SetupCommands()
        {
            ActivateItemsUseCaseCommand = new RelayCommand(() => _useCaseManager.ActivateUseCase(UseCases.ItemsPage));
            ActivatePopupUseCaseCommand = new RelayCommand(() => _useCaseManager.ActivateUseCase(UseCases.ShowPopup));
        }
    }
}