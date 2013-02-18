using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UseCaseSample.UseCaseManager;

namespace UseCaseSample.ViewModel
{
    public class ItemsViewModel : ViewModelBase
    {
        private IUseCaseManager _useCaseManager;


        public RelayCommand ShowDogCommand { get; private set; }
        public RelayCommand ShowKidCommand { get; private set; }


        public ItemsViewModel(IUseCaseManager useCaseManager)
        {
            _useCaseManager = useCaseManager;
            SetupCommands();
        }

        private void SetupCommands()
        {
            ShowDogCommand = new RelayCommand(()=>_useCaseManager.ActivateUseCase(UseCases.ShowDog));
            ShowKidCommand = new RelayCommand(()=>_useCaseManager.ActivateUseCase(UseCases.ShowKid));
        }
    }
}
