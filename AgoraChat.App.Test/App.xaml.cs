
using Microsoft.Extensions.Configuration;
using ObjCRuntime;
#if IOS
using HotCoffee.AgoraChat.iOS;
#endif
namespace AgoraChat.App.Test
{
    public partial class App : Application
    {  
        private bool isJoined = false;
        private bool isInitialized = false;
        private AgoraChatClient client;
        private IAgoraChatManager chatManager;
        private IConfiguration configuration;
        public App(IConfiguration configuration)
        {
            InitializeComponent();
            this.configuration = configuration;

#if ANDROID
#endif
#if IOS
            setupAgoraChatClient();
#endif


        }
#if IOS
        public bool setupAgoraChatClient()
        {
            try
            {
                var options = AgoraChatOptions.OptionsWithAppkey((string)configuration["appkey"]!);
                options.EnableConsoleLog = true;
                options.IsAutoLogin = true;
                options.LogLevel = AgoraChatLogLevel.Error;
                client = AgoraChatClient.SharedClient();
                Console.WriteLine("User Logged In -> " + client.IsLoggedIn);
                //  options.Add
                
                AgoraChatError? anyError = client.InitializeSDKWithOptions(options);
                
                setChatDelegates();
                if (anyError != null)
                {
                    if (anyError.Code == AgoraChatErrorCode.NoError)
                    {
                        
                    }
                    else
                    {
                        Console.WriteLine("Sorry Sdk not implemented");
                        
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
                
            }
            return true;
        }

        public void setChatDelegates()
        {   
            client.AddDelegate(new MyChatClientDelegate(), null);
            client.AddLogDelegate(new MyChatLogOutDelegate(), null); 
        }
#endif
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new ChatPage());
        }

        protected override void OnStart()
        {   
            base.OnStart();
            if (true)
            {   
                Console.WriteLine("----------- AgoraChat Initialized -----------");
                JoinLeave((string)configuration["username"]!, (string)configuration["token"]!);
            }
        }

        public void GetChatHistory()
        {
            client.ChatManager?.AsyncFetchHistoryMessagesFromServer("6",
                AgoraChatConversationType.Chat, null, 100, ((result, error) =>
                {   
                  //  Console.WriteLine(" History Messages Counts " + result);
                  
                    var  res = result as AgoraChatCursorResult<AgoraChatMessage>;
                    Console.WriteLine(" History Messages Counts " + res.List.Count());
                    foreach (var msg in res.List)
                    {
                    //    var chatMsg = (AgoraChatMessage)msg;
                     //   AgoraChatMessageBody body = chatMsg.Body;
                      //  Console.WriteLine(((AgoraChatTextMessageBody)body).Text);
                       
                        
                        AgoraChatMessageBody body = (AgoraChatMessageBody)msg.Body;
                        if (body != null && body.Type == AgoraChatMessageBodyType.Text)
                        {
                            Console.WriteLine(" Message: " + ((AgoraChatTextMessageBody)body).Text);
                        }
                        else if (body != null && body.Type == AgoraChatMessageBodyType.File)
                        {
                            Console.WriteLine(" File Name : " + ((AgoraChatFileMessageBody)body).DisplayName);
                        }
                        else if (body != null && body.Type == AgoraChatMessageBodyType.Image)
                        {
                            Console.WriteLine(" Image Name : " + ((AgoraChatImageMessageBody)body).DisplayName);
                            Console.WriteLine(" Image Thumbnail Name : " + ((AgoraChatImageMessageBody)body).ThumbnailDisplayName);
                        }
                        else
                        {
                            Console.WriteLine(" Not Supported ");
                        }
                    }
                }));
           // client.ChatManager.AsyncFetchHistoryMessagesFromServer(client.CurrentUsername, AgoraChatConversationType.Chat , null,);
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
                    AgoraChatManagerDelegate chatManagerDelegate = new MyAgoraChatManagerDelegate();
                    client.ChatManager?.AddDelegate(chatManagerDelegate, null);
                    
                    GetChatHistory();
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
                message.To = (string)configuration["toname"]!;
                message.ChatType = AgoraChatType.Chat;
                message.DeliverOnlineOnly = false;
                message.Direction = AgoraChatMessageDirection.Send;
             //   message.Body = new AgoraChatTextMessageBody(mesages);
                message.Ext = null;
                
                client.ChatManager?.SendMessage(message ,null , null);
                // client.ChatManager?.SendMessage(message , (message1) =>
                // {
                //     
                // }, ((chatMessage, error) =>
                // {
                //     Console.WriteLine("Error" + error.ToString());
                // } ));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               // throw;
            }
        }

    }
}