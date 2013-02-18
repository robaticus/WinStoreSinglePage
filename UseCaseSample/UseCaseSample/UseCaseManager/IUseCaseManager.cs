using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UseCaseSample.UseCaseManager
{
    public interface IUseCaseManager
    {
        void ActivateUseCase(UseCases useCase);
        void RegisterRegion(Frame frame);

        bool CanGoBack { get; }

        void GoBack();

    }
}
