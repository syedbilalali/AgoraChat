using Microsoft.Maui.LifecycleEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Chat.Maui
{
    public static class PlatformExtension
    {
        public static MauiAppBuilder UseAgora(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.ConfigureLifecycleEvents(config =>
            {
#if ANDROID
                config.AddAndroid(android =>
                {
                    android.OnCreate((del , bundle) => InitAgora());
                });
#endif 
            });
            return mauiAppBuilder;
        }

#if ANDROID
        private static void InitAgora()
        {
            global::Java.Lang.JavaSystem.LoadLibrary("agora-chat-sdk");
            global::Java.Lang.JavaSystem.LoadLibrary("cipherdb");
        }
#endif
    }
}
