#if IOS
using HotCoffee.AgoraChat.iOS;
#endif
namespace AgoraChat.App.Test
{
    public partial class App : Application
    {  
        private bool isJoined = false;
        private AgoraChatClient client;
        public App()
        {
            InitializeComponent();

#if ANDROID
               
#endif
#if IOS
            var options = AgoraChatOptions.OptionsWithAppkey("411294965#1491692");
            options.EnableConsoleLog = true;
            options.LogLevel = AgoraChatLogLevel.Debug;
            options.ApnsCertName = "AgoraChatDev";
            options.UsingHttpsOnly = true;
           client = AgoraChatClient.SharedClient();
            
          //  options.Add
          client.InitializeSDKWithOptions(options);
            
           // Console.WriteLine(error.ErrorDescription);
          var accessUserToken = client.AccessUserToken;
          Console.WriteLine(accessUserToken);
            
            client.AddDelegate(new MyChatClientDelegate(), null);
          //  client.AddLogDelegate(new MyChatLogOutDelegate(), null); 
            client.ChatManager?.AddDelegate(new MyAgoraChatManagerDelegate(), null);
             
           

            //Task.Delay(5000);
           Console.WriteLine("Agora IOS Connected "+ client.IsConnected +" Current User Name " + client.CurrentUsername);
          //  Console.WriteLine(" User Access Tokens  "+  accessUserToken);
           
           JoinLeave("sdssds" , "007eJxTYFi8r6vZu3/a2x6PG/s//Pyw38VyrfCOKU3bIpe26WycWfBIgSHN0NzUIM3ENCnVLMnE0Dw5ycQsMSkpMdXS3NTUzDjN7Mcd6YyGQEaGqZe2sDIysDIwAiGIr8JgaJqcbGBuZKBraG5homtomGaga2ECZCUlWZgbGaeZGiUaWAIAH4Uq1Q==");
#endif
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        public void JoinLeave(string username , string token)
        {
            if (client != null)
            {   
                //var result = client.LoginWithUsername("", "");
                var result = client.LoginWithUsernameAndToken(username, token);
                if (result != null)
                {
                    if (result.Code == AgoraChatErrorCode.ChatroomAlreadyJoined)
                    {
                        Console.WriteLine("You are already joined to " + client.CurrentUsername);
                    }
                }
            }
        }
    }
}