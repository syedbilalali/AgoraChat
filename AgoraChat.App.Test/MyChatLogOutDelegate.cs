#if IOS
using Foundation;
using HotCoffee.AgoraChat.iOS;

namespace AgoraChat.App.Test;

public class MyChatLogOutDelegate : AgoraChatLogDelegate
{   
    public override void LogDidOutput(string log)
    {   
        Console.WriteLine ($"{ DateTime.Now.ToShortTimeString() } Logs ----> " + log);
    }
}
#endif