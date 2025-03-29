using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgoraChatSDK.Additions
{
    public static class AgoraPlatform
    {
        public static void Init()
        {
#if ANDROID
            global::Java.Lang.JavaSystem.LoadLibrary("agora-chat-sdk");
#endif
        }
    }
}
