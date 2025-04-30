#if IOS
using HotCoffee.AgoraChat.iOS;
#endif
namespace AgoraChat.App.Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if ANDROID
               
#endif
#if IOS
            var options = AgoraChatOptions.OptionsWithAppkey("411294965#1491692");
            options.EnableConsoleLog = true;
            options.ApnsCertName = "AgoraChatDev";
            options.UsingHttpsOnly = true;
            var client = AgoraChatClient.SharedClient();
            
          //  options.Add
            
            client.InitializeSDKWithOptions(options);
            
           // Console.WriteLine(error.ErrorDescription);
            var accessUserToken = client.AccessUserToken;
            
            client.AddDelegate(new MyChatClientDelegate(), null);
            client.AddLogDelegate(new MyChatLogOutDelegate(), null);
           // client.ChatManager.AddDelegate(new MyAgoraChatManagerDelegate(), null);
           // client.ChatManager.

            Task.Delay(5000);
            Console.WriteLine("Agora IOS Connected "+ client.IsConnected +" Current User Name " + client.CurrentUsername);
            Console.WriteLine(" User Access Tokens  "+  accessUserToken);
#endif
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}