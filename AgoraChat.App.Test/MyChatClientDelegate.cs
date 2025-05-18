#if IOS
using HotCoffee.AgoraChat.iOS;
using Foundation;

namespace AgoraChat.App.Test;

public class MyChatClientDelegate : AgoraChatClientDelegate
{
    public MyChatClientDelegate() : base()
    {
            
    }
    public override void ConnectionStateDidChange(AgoraChatConnectionState aConnectionState)
    {
        Console.WriteLine("OnConnected State : " + aConnectionState);
        if (aConnectionState == AgoraChatConnectionState.Connected)
        {
            Console.WriteLine("OnConnected State : " + aConnectionState);
        }
        else
        {
            Console.WriteLine("OnDisconnected State : " + aConnectionState);
        }
    }
    public override void TokenDidExpire(AgoraChatErrorCode aErrorCode)
    {
        Console.WriteLine("Token expired (log in using new token) State : " + aErrorCode);   
    }

    public override void TokenWillExpire(AgoraChatErrorCode aErrorCode)
    {
        Console.WriteLine("Token will expire (log in using new token)\" State : ");
    }
}
#endif