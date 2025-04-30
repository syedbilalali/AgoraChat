using HotCoffee.AgoraChat.iOS;

namespace AgoraChat.App.Test;

public class MyChatClientDelegate : AgoraChatClientDelegate
{
    
    public override void ConnectionStateDidChange(AgoraChatConnectionState aConnectionState)
    {
       // base.ConnectionStateDidChange(aConnectionState);
        Console.WriteLine("OnConnected State : " + aConnectionState);
    }
}