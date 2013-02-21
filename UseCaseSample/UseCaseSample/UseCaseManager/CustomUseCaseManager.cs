using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GalaSoft.MvvmLight.Messaging;
using UseCaseSample.Utility;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UseCaseSample.UseCaseManager
{
    public class CustomUseCaseManager : IUseCaseManager
    {
        private readonly List<Frame> _frames = new List<Frame>();

        private readonly Stack<UseCases> _useCaseStack = new Stack<UseCases>();

        private UseCases _currentUseCase = UseCases.None;
        private Frame _opacityFrame;

        public void ActivateUseCase(UseCases useCase)
        {
            _useCaseStack.Push(useCase);
            Messenger.Default.Send(new CanGoBackChangedMessage());

            switch (useCase)
            {
                case UseCases.FrontPage:
                    HideAllContent();
                    DisplayContent(typeof (DoubleWidePage));
                    break;

                case UseCases.ItemsPage:
                    HideAllContent();
                    DisplayContent(typeof (ItemsPage));
                    break;

                case UseCases.ShowDog:
                    DisplayContent(typeof (DogPage));
                    break;

                case UseCases.ShowKid:
                    DisplayContent(typeof (KidPage));
                    break;

                case UseCases.ShowPopup:
                    DisplayContent(typeof (PopupPage));
                    break;
            }
        }

        public void RegisterRegion(Frame frame)
        {
            if (frame.Name == "OpacityFrame")
            {
                _opacityFrame = frame;
            }

            if (!_frames.Contains(frame))
            {
                _frames.Add(frame);
            }
        }

        public bool CanGoBack
        {
            get { return _useCaseStack.Count > 1; }
        }

        public void GoBack()
        {
            if (_useCaseStack.Count > 1)
            {
                _useCaseStack.Pop(); //get the current page off the stack.
                UseCases backCase = _useCaseStack.Pop(); //get the previous page off the stack.
                ActivateUseCase(backCase); // navigate to the previous page
            }
        }

        private void DisplayContent(Type type)
        {
            string region;
            bool disableOtherContent = false;

            TypeInfo t = type.GetTypeInfo();

            var attrib = t.GetCustomAttribute<DisplayRegionAttribute>();
            if (attrib == null)
            {
                region = "FullFrame";
            }
            else
            {
                region = attrib.RegionName;
                disableOtherContent = attrib.DisableContent;
            }

            if (disableOtherContent && _opacityFrame != null)
            {
                _opacityFrame.Visibility = Visibility.Visible;
            }
            else if (_opacityFrame != null)
            {
                _opacityFrame.Visibility = Visibility.Collapsed;
            }

            Frame frame = _frames.FirstOrDefault(f => f.Name == region);
            if (frame != null)
            {
                frame.Navigate(type);
            }
            else
            {
                throw new Exception(string.Format("Couldn't find frame named {0}", region));
            }
        }

        private void HideAllContent()
        {
            foreach (Frame f in _frames)
            {
                f.Content = null;
            }
        }
    }

    public class CanGoBackChangedMessage
    {
    }
}