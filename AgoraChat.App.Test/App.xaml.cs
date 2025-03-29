namespace AgoraChat.App.Test
{
    public partial class App : Application
    {
        public App()
        {
           
            InitializeComponent();

#if ANDROID
            global::Java.Lang.JavaSystem.LoadLibrary("agora-chat-sdk");
            //    ChatConfiguration chatConfiguration = new ChatConfiguration();
            //    chatConfiguration.Init(Platform.AppContext, "fsjfjhf");

            //    var chatClient = IO.Agora.Chat.ChatClient.Instance;
            //chatClient.Init(Platform.AppContext, new IO.Agora.Chat.ChatOptions
            //    ()
            //{ });
#endif
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}