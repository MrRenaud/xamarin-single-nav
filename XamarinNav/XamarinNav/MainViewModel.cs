using System.Windows.Input;

namespace XamarinNav
{
    public class MainViewModel
    {
        public ICommand GoToPage1 { get; set; } 
        public ICommand GoToPage2 { get; set; }
        public ICommand GoToPage3 { get; set; }

        public MainViewModel()
        {
            GoToPage1 = new SingleNavigationCommand(OnGoToPage1);
            GoToPage2 = new SingleNavigationCommand(OnGoToPage2);
            GoToPage3 = new SingleNavigationCommand(OnGoToPage3);
        }

        private void OnGoToPage3(object obj)
        {
            App.Navigation.PushAsync(new Page3());
        }

        private void OnGoToPage2(object obj)
        {
            App.Navigation.PushAsync(new Page2());
        }


        private void OnGoToPage1(object param)
        {
            App.Navigation.PushAsync(new Page1());
        }
    }
}
