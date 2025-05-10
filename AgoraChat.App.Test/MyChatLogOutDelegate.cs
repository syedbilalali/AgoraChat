#if IOS
using Foundation;
using HotCoffee.AgoraChat.iOS;

namespace AgoraChat.App.Test;

public class MyChatLogOutDelegate : AgoraChatLogDelegate
{   
    public override void LogDidOutput(string log)
    {   
       // var lastColor = Console.ForegroundColor;
     //   Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine ($"{ DateTime.Now.ToShortTimeString() } Logs ----> " + log);
       // Console.ForegroundColor = lastColor;
    }
}
#endif