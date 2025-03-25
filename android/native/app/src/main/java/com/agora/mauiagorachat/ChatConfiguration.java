package com.agora.mauiagorachat;

import android.content.Context;

import androidx.annotation.NonNull;

import io.agora.chat.ChatClient;
import io.agora.chat.ChatOptions;

public class ChatConfiguration {

    private ChatClient agoraChatClient;
    public void init(Context context,@NonNull ChatOptions option , String appKey, boolean debugMode){

          if(option !=  null)
              throw  new IllegalArgumentException("ChatOptions can't be null.");

          if(appKey.isBlank() &&  appKey.isEmpty())
              throw  new IllegalArgumentException("App Key can't be null.");

          agoraChatClient = ChatClient.getInstance();
          agoraChatClient.init(context , option);
          agoraChatClient.setDebugMode(debugMode);



    }
    public void init(Context context , @NonNull String appKey){

        if(appKey.isBlank() && appKey.isEmpty())
             throw  new IllegalArgumentException("App Key can't be null.");

        this.init(context , new ChatOptions(), appKey ,false);

    }
    public ChatClient getAgoraChatClient(){
        return agoraChatClient != null? agoraChatClient:null;
    }
}
