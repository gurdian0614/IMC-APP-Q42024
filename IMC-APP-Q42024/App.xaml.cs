using IMC_APP_Q42024.Views;

namespace IMC_APP_Q42024
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new ImcView());
        }
    }
}