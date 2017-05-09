# xamarin-single-nav

If you want to prevent multiple navigations firing when clicking on buttons, you can handle it by providing your own implementation of an ICommand adding a small delay and preventing the execution of another command at the same time.

See [SingleNavigationCommand](/XamarinNav/XamarinNav/SingleNavigationCommand.cs) for the implementation.
