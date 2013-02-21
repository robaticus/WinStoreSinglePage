using Windows.UI.Xaml.Controls;

namespace UseCaseSample.UseCaseManager
{
    public interface IUseCaseManager
    {
        bool CanGoBack { get; }
        void ActivateUseCase(UseCases useCase);
        void RegisterRegion(Frame frame);

        void GoBack();
    }
}