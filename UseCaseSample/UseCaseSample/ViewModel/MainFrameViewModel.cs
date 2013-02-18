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
    public class MainFrameViewModel : ViewModelBase
    {
        private bool _canGoBack;

        public bool CanGoBack
        {
            get
            {
                if (_useCaseManager != null)
                {
                    return _useCaseManager.CanGoBack;
                }
                else
                {
                    return false;
                }
            }

        }

        private string _pageTitle;

        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                if (_pageTitle != value)
                {
                    _pageTitle = value;
                    RaisePropertyChanged(() => PageTitle);
                }

            }

        }

        

        public RelayCommand GoBackCommand { get; private set; }

        private IUseCaseManager _useCaseManager;

        [PreferredConstructor]
        public MainFrameViewModel(IUseCaseManager useCaseManager)
        {
            _useCaseManager = useCaseManager;

            this.PageTitle = "Single Page Apps with XAML/C#";

            MessengerInstance.Register<CanGoBackChangedMessage>(this, message => RaisePropertyChanged(() => CanGoBack));

            GoBackCommand = new RelayCommand(GoBack);
        }

        private void GoBack()
        {
            if (_useCaseManager != null)
            {
                _useCaseManager.GoBack();
            }
        }
    }
}
