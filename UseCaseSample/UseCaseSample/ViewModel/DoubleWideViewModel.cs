using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using UseCaseSample.UseCaseManager;

namespace UseCaseSample.ViewModel
{
    public class DoubleWideViewModel : ViewModelBase
    {
        private IUseCaseManager _useCaseManager;

        public RelayCommand ActivateItemsUseCaseCommand { get; set; }
        public RelayCommand ActivatePopupUseCaseCommand { get; set; }


        public DoubleWideViewModel() : this(null)
        {
            
        }

        [PreferredConstructor]
        public DoubleWideViewModel(IUseCaseManager useCaseManager)
        {
            _useCaseManager = useCaseManager;

            SetupCommands();
        }

        private void SetupCommands()
        {
            ActivateItemsUseCaseCommand = new RelayCommand(()=>_useCaseManager.ActivateUseCase(UseCases.ItemsPage));
            ActivatePopupUseCaseCommand = new RelayCommand(() => _useCaseManager.ActivateUseCase(UseCases.ShowPopup));
        }

        
    }
}
