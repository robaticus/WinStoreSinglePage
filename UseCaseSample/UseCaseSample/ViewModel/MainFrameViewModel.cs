using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using UseCaseSample.UseCaseManager;

namespace UseCaseSample.ViewModel
{
    public class MainFrameViewModel : ViewModelBase
    {
        private readonly IUseCaseManager _useCaseManager;
        private bool _canGoBack;

        private string _pageTitle;

        [PreferredConstructor]
        public MainFrameViewModel(IUseCaseManager useCaseManager)
        {
            _useCaseManager = useCaseManager;

            PageTitle = "Single Page Apps with XAML/C#";

            MessengerInstance.Register<CanGoBackChangedMessage>(this, message => RaisePropertyChanged(() => CanGoBack));

            GoBackCommand = new RelayCommand(GoBack);
        }

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

        private void GoBack()
        {
            if (_useCaseManager != null)
            {
                _useCaseManager.GoBack();
            }
        }
    }
}