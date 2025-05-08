#if IOS
using HotCoffee.AgoraChat.iOS;

namespace AgoraChat.App.Test;

public class MyAgoraChatManagerDelegate : AgoraChatManagerDelegate
{
    public override void MessagesDidReceive(AgoraChatMessage[] aMessages)
    {
       Console.WriteLine("OnMessage Received : ");
       base.MessagesDidReceive(aMessages);
    }
}
#endif