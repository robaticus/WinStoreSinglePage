using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UseCaseSample.UseCaseManager;

namespace UseCaseSample.ViewModel
{
    public class ItemsViewModel : ViewModelBase
    {
        private readonly IUseCaseManager _useCaseManager;

        public ItemsViewModel(IUseCaseManager useCaseManager)
        {
            _useCaseManager = useCaseManager;
            SetupCommands();
        }


        public RelayCommand ShowDogCommand { get; private set; }
        public RelayCommand ShowKidCommand { get; private set; }


        private void SetupCommands()
        {
            ShowDogCommand = new RelayCommand(() => _useCaseManager.ActivateUseCase(UseCases.ShowDog));
            ShowKidCommand = new RelayCommand(() => _useCaseManager.ActivateUseCase(UseCases.ShowKid));
        }
    }
}