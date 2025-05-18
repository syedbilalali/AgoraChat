//
//  Demo.swift
//  AgoraChats
//
//  Created by Medina Travel on 30/04/25.
//
import AgoraChat

func setupChatClient() {
    if (appKey.isEmpty) {
        showLog("You need to set your AppKey")
        return
    }
    let options = AgoraChatOptions(appkey: appKey)  // Create AgoraChatOptions with your app key
    agoraChatClient = AgoraChatClient.shared()
    options.enableConsoleLog = true  // Enable printing logs on console
    agoraChatClient.initializeSDK(with: options)  // Initialize the AgoraChatClient
    agoraChatClient.chatManager?.add(self, delegateQueue: nil)  // Adds the chat delegate to receive messages
}
// Add message event callbacks
extension ViewController: AgoraChatManagerDelegate {
    func messagesDidReceive(_ aMessages: [AgoraChatMessage]) {
        for message in aMessages {
            let msgBody = message.body as! AgoraChatTextMessageBody

            DispatchQueue.main.async {
                self.displayMessage(messageText: msgBody.text, isSentMessage: false)
            }

            showLog("Received a message from \(message.from)")
        }
    }
}

// Add connection event callbacks
extension ViewController: AgoraChatClientDelegate {
    func connectionStateDidChange(_ aConnectionState: AgoraChatConnectionState) {
        if aConnectionState == .connected {
            showLog("Connected to the chat server.")
        } else {
            if isJoined {
                showLog("Disconnected from the chat server.")
                isJoined = false
            }
        }
    }

    func tokenWillExpire(_ aErrorCode: AgoraChatErrorCode) {
        showLog("Token will expire (log in using new token)")
    }

    func tokenDidExpire(_ aErrorCode: AgoraChatErrorCode) {
        showLog("Token expired (log in using new token)")
    }
}


