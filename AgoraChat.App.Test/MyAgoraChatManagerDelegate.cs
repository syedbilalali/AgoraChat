#if IOS
using Foundation;
using HotCoffee.AgoraChat.iOS;
using ObjCRuntime;

namespace AgoraChat.App.Test;

public class MyAgoraChatManagerDelegate : AgoraChatManagerDelegate, IDisposable
{
    public MyAgoraChatManagerDelegate() : base()
    {
            
    }
    public override void MessagesDidReceive(AgoraChatMessage[] aMessages)
    {
       Console.WriteLine(" Messages Received " + aMessages.Length);

       foreach (var msg in aMessages)
       {   
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
    }
    public override void CmdMessagesDidReceive(AgoraChatMessage[] aCmdMessages)
    {
        Console.WriteLine(" Cmd Messages Received ");
    }
    public  void Dispose()
    {
       
    }
}
#endif