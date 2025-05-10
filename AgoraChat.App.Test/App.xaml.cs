
using ObjCRuntime;
#if IOS
using HotCoffee.AgoraChat.iOS;
#endif
namespace AgoraChat.App.Test
{
    public partial class App : Application
    {  
        private bool isJoined = false;
        private AgoraChatClient client;
        private IAgoraChatManager chatManager;
        public App()
        {
            InitializeComponent();

#if ANDROID
               
#endif
#if IOS
            var options = AgoraChatOptions.OptionsWithAppkey("411294965#1491692");
            options.EnableConsoleLog = true;
            options.LogLevel = AgoraChatLogLevel.Debug;
            options.ApnsCertName = "a27e00c5235a40f5971d367530e4e2a7";
            options.UsingHttpsOnly = false;
           client = AgoraChatClient.SharedClient();
            
          //  options.Add
          client.InitializeSDKWithOptions(options);
            
           // Console.WriteLine(error.ErrorDescription);
          var accessUserToken = client.AccessUserToken;
          Console.WriteLine(accessUserToken);
            
            client.AddDelegate(new MyChatClientDelegate(), null);
           client.AddLogDelegate(new MyChatLogOutDelegate(), null); 
          chatManager = (IAgoraChatManager)client.ChatManager.Self;
    
       
         chatManager.AddDelegate(new MyAgoraChatManagerDelegate(), null);
             
           

            //Task.Delay(5000);
           Console.WriteLine("Agora IOS Connected "+ client.IsConnected +" Current User Name " + client.CurrentUsername);
          //  Console.WriteLine(" User Access Tokens  "+  accessUserToken);
           
           JoinLeave("36" , "007eJxTYHj54fHzjpjI9dcPTpRdwn/txd/ZVvveerNt3b9Jb+2B/XxsCgxphuamBmkmpkmpZkkmhubJSSZmiUlJiamW5qamZsZpZhpz5DIaAhkZzMRTGRgZWIGYkQHEV2FINDZLNDQ0MNA1NDNM0zU0TDPQtTSzNNNNS0q0TDIwT7NIMjYCAJlzKLA=");
#endif
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new ChatPage());
        }

        public void JoinLeave(string username , string token)
        {
            if (client != null)
            {   
                //var result = client.LoginWithUsername("", "");
                client.ServiceCheckWithUsername("36","Chetu@123",(stype,serror)=>
                {
                    Console.WriteLine("Error" + serror);
                });
                var result = client.LoginWithUsernameAndToken(username, token);
                if (result != null)
                {
                    if (result.Code == AgoraChatErrorCode.ChatroomAlreadyJoined)
                    {
                        Console.WriteLine("You are already joined to " + client.CurrentUsername);
                       
                    }
                   SendMeesages("Hello Agora! From iOS");
                }
            }
        }
        public void SendMeesages(string mesages)
        {
            try
            {   
                Console.WriteLine(" Current Name --> " + client.CurrentUsername);
                AgoraChatMessage message = new AgoraChatMessage("6",new AgoraChatTextMessageBody(mesages) ,null);
                message.From = client.CurrentUsername;
             //   message.ConversationId = "36";
                message.To = "6";
                message.ChatType = AgoraChatType.Chat;
             //   message.Body = new AgoraChatTextMessageBody(mesages);
                message.Ext = null;
                client.ChatManager?.SendMessage(message, null, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               // throw;
            }
        }

    }
}