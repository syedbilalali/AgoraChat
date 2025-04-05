using Android.Runtime;

namespace Agora.Chat.Maui.Platforms.Android
{
    public class ChatClient : IO.Agora.Chat.ChatClient
    {
        protected ChatClient(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        { 
            
        }
    }
}
