namespace KTIGSETS2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //PARA COMENZAR LA NAVEGACION: new NavigationPage
            return new Window(new NavigationPage(new Views.login()));
        }
    }
}
