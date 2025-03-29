namespace AgoraChat.App.Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if ANDROID
            AgoraChatSDK.Additions.AgoraPlatform.Init();

#endif
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }


    }
}