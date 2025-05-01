/**
 *  
 *  @header IAgoraChatManager.h
 *  @abstract This protocol defines the operations of chat.
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>

#import "AgoraChatCommonDefs.h"
#import "AgoraChatManagerDelegate.h"
#import "AgoraChatConversation.h"

#import "AgoraChatMessage.h"
#import "AgoraChatTextMessageBody.h"
#import "AgoraChatLocationMessageBody.h"
#import "AgoraChatCmdMessageBody.h"
#import "AgoraChatFileMessageBody.h"
#import "AgoraChatImageMessageBody.h"
#import "AgoraChatVoiceMessageBody.h"
#import "AgoraChatVideoMessageBody.h"
#import "AgoraChatCustomMessageBody.h"
#import "AgoraChatCombineMessageBody.h"
#import "AgoraChatCursorResult.h"

#import "AgoraChatGroupMessageAck.h"
#import "AgoraChatTranslateLanguage.h"
#import "AgoraChatFetchServerMessagesOption.h"
#import "AgoraChatConversationFilter.h"

/**
 *  
 *  The directions in which historical messages are retrieved from the server.
 */
typedef NS_ENUM(NSUInteger, AgoraChatMessageFetchHistoryDirection) {
    AgoraChatMessageFetchHistoryDirectionUp  = 0,    /**  The SDK retrieves messages in the descending order of the timestamp included in them.*/
    AgoraChatMessageFetchHistoryDirectionDown        /**  The SDK retrieves messages in the ascending order of the timestamp included in them.
 **/
};


@class AgoraChatError;

/**
 *  
 *  This protocol that defines the operations of chat.
 *
 *  Messages are loaded from the local database, not from the server.
 */
@protocol IAgoraChatManager <NSObject>

@required

#pragma mark - Delegate

/**
 *  
 *  Adds a delegate.
 *
 *  @param aDelegate  The object that implements the protocol.
 *  @param aQueue     (optional) The queue of calling delegate methods. If you want to run the app on the main thread, set this parameter as nil.
 */
- (void)addDelegate:(id<AgoraChatManagerDelegate> _Nullable)aDelegate
      delegateQueue:(dispatch_queue_t _Nullable)aQueue;

/**
 *  
 *  Removes a delegate.
 *
 *  @param aDelegate  The delegate to be removed.
 */
- (void)removeDelegate:(id<AgoraChatManagerDelegate> _Nonnull)aDelegate;

#pragma mark - Conversation

/**
 *  
 *  Gets all local conversations.
 *
 * The SDK loads the conversations from the memory first. If no conversation is found in the memory, the SDK loads from the local database.
 *
 *  @result The conversation list of the NSArray<AgoraChatConversation *> * type.
 */
- (NSArray<AgoraChatConversation *> * _Nullable)getAllConversations;

/**
 *  
 *  Gets local conversations by filter.
 *
 *  The SDK loads conversations from the local database by the specified filter conditions.
 *
 *  Ensure that you call this method upon login success.
 *
 *  @param cleanMemoryCache Whether to clear cached conversations in memory.
 *  @param filter The filter. The return value `YES` indicates that the conversation is returned and `false` indicates that the conversation is not returned.
 *
 *  @result The conversation list of the NSArray<AgoraChatConversation *> * type.
 */
- (NSArray<AgoraChatConversation *> * _Nullable)filterConversationsFromDB:(BOOL)cleanMemoryCache filter:(BOOL(^_Nullable)(AgoraChatConversation * _Nonnull conversation))filter NS_SWIFT_NAME(filterConversationsFromDB(cleanMemoryCache:filter:));


/**
 *  
 *   Clear all conversations in memory to release memory.
 */
- (void)cleanConversationsMemoryCache;

/**
 *  
 *  Gets all local conversations.
 *
 *  The SDK loads the conversations from the memory first. If there is no conversation is in the memory, the SDK loads from the local database.
 *
 *  @param isSort Whether to sort the conversations.
 *          - YES: Yes. The SDK returns conversations in the descending order of the timestamp of the latest message in them, with the pinned ones at the top of the list and followed by the unpinned ones.
 *          - NO: No.
 *  @result The conversation list of the NSArray<AgoraChatConversation *> * type.
 */
- (NSArray<AgoraChatConversation *> * _Nullable)getAllConversations:(BOOL)isSort;

/**
 *  
 *  Gets all conversations from the server.
 *
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)getConversationsFromServer:(void (^_Nullable)(NSArray<AgoraChatConversation *> * _Nullable aConversations, AgoraChatError * _Nullable aError))aCompletionBlock EM_DEPRECATED_IOS(4_0_0, "Use -IAgoraChatManager getConversationsFromServerWithCursor:pageSize:completion");

/**
 *  
 *  Gets conversations from the server with pagination.
 *
 *  @param pageNumber The current page number, starting from 1.
 *  @param pageSize The number of conversations that you expect to get on each page.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)getConversationsFromServerByPage:(NSUInteger)pageNumber
                                pageSize:(NSUInteger)pageSize
                              completion:(void (^_Nullable)(NSArray<AgoraChatConversation *> * _Nullable aConversations, AgoraChatError * _Nullable aError))aCompletionBlock EM_DEPRECATED_IOS(4_0_0, "Use -IAgoraChatManager getConversationsFromServerWithCursor:pageSize:completion");
/**
 *  
 * Get the list of conversations from the server with pagination.
 *
 * The SDK retrieves the list of conversations in the reverse chronological order of their active time (the timestamp of the last message).
 *
 * If there is no message in the conversation, the SDK retrieves the list of conversations in the reverse chronological order of their creation time.
 *
 *  @param cursor The position from which to start getting data. If you pass in `nil` or `@""`, the SDK retrieves conversations from the latest active one.
 *  @param pageSize The number of conversations that you expect to get on each page. The value range is [1,50].
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)getConversationsFromServerWithCursor:(nullable NSString *)cursor pageSize:(UInt8)pageSize completion:(nonnull void (^)(AgoraChatCursorResult<AgoraChatConversation *> * _Nullable result, AgoraChatError * _Nullable error))completionBlock;

/**
 *  
 *  Gets the list of pinned conversations from the server with pagination.
 *
 *  The SDK returns the pinned conversations in the reverse chronological order of their pinning.
 *
 *  @param cursor The position from which to start getting data. If you pass in `nil` or `@""`, the SDK retrieves conversations from the latest pinned one.
 *  @param pageSize The number of conversations that you expect to get on each page. The value range is [1,50].
 *  @param completionBlock The completion block, which contains the error message if the method fails.
 */
- (void)getPinnedConversationsFromServerWithCursor:(nullable NSString *)cursor pageSize:(UInt8)limit completion:(nonnull void (^)(AgoraChatCursorResult<AgoraChatConversation *> * _Nullable result, AgoraChatError * _Nullable error))completionBlock;

/**
 *  
 *  Sets whether to pin a conversation.
 *
 *  @param conversationId  The conversation ID.
 *  @param isPinned Whether to pin a conversation:
     *                - `true`：Yes.
     *                  - `false`: No. The conversation is unpinned.
 *  @param completionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)pinConversation:(nonnull NSString *)conversationId isPinned:(BOOL)isPinned completionBlock:(nullable void(^)(AgoraChatError * _Nullable error))completionBlock;

/**
 *  
 *  Gets a conversation from the local database.
 *
 *  @param aConversationId  The conversation ID.
 *
 *  @result The conversation object.
 */
- (AgoraChatConversation *_Nullable)getConversationWithConvId:(NSString * _Nullable)aConversationId;

/**
 *  
 *  Gets a conversation from the local database.
 *
 *  @param aConversationId  The conversation ID.
 *  @param aType            The conversation type.
 *  @param aIfCreate        Whether to create the conversation if it does not exist:
 *                          - `YES`: Yes;
 *                          - `NO`: No.
 *
 *  @result The conversation object.
 */
- (AgoraChatConversation *_Nullable)getConversation:(NSString *_Nonnull)aConversationId
                               type:(AgoraChatConversationType)aType
                   createIfNotExist:(BOOL)aIfCreate;

/**
 *  
 *  Gets a conversation from the local database.
 *
 *  @param aConversationId  The conversation ID.
 *  @param aType            The conversation type.
 *  @param aIfCreate        Whether to create the conversation if it does not exist.
 *                          - `YES`: Yes;
 *                          - `NO`: No.
 *  @param isThread         Whether it is thread conversation. That is, whether the conversation is of the `threadChat` type.
 *  - `YES`: Yes;
 *  - `NO`: No.
 *  @result The conversation object.
 */
- (AgoraChatConversation *_Nullable)getConversation:(NSString *_Nonnull)aConversationId
                               type:(AgoraChatConversationType)aType
                   createIfNotExist:(BOOL)aIfCreate isThread:(BOOL)isThread;

/**
 *  
 *  Deletes a conversation from the local database.
 *
 *  @param aConversationId      The conversation ID.
 *  @param aIsDeleteMessages    Whether to delete the messages in the conversation.
 *  - `YES`: Yes;
 *  - `NO`: No.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method call fails.
 *
 */
- (void)deleteConversation:(NSString * _Nonnull)aConversationId
          isDeleteMessages:(BOOL)aIsDeleteMessages
                completion:(void (^_Nullable)(NSString * _Nullable aConversationId, AgoraChatError *_Nullable aError))aCompletionBlock;

/*!
  *  
  *  Deletes a conversation from the server.
  *
  *  @param aConversationId      The conversation ID.
  *  @param aConversationType    The conversation type.
  *  @param aIsDeleteMessages    Whether to delete the related messages with the conversation.
  *                          - `YES`: Yes;
  *                          - `NO`: No.
  *  @param aCompletionBlock     The completion block, which contains the error message if the method call fails.
  *
  */
 - (void)deleteServerConversation:(NSString * _Nonnull)aConversationId
                 conversationType:(AgoraChatConversationType)aConversationType
           isDeleteServerMessages:(BOOL)aIsDeleteServerMessages
                       completion:(void (^_Nullable)(NSString * _Nullable aConversationId, AgoraChatError * _Nullable aError))aCompletionBlock;

/*!
 *  
 *  Deletes multiple conversations.
 *
 *  @param aConversations       The conversation list.
 *  @param aIsDeleteMessages    Whether to delete the messages with the conversations.
 *  - `YES`: Yes;
 *  - `NO`: No.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)deleteConversations:(NSArray<AgoraChatConversation *> * _Nullable)aConversations
           isDeleteMessages:(BOOL)aIsDeleteMessages
                 completion:(void (^_Nullable)(AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 *  
 *  Imports multiple conversations to the local database.
 *
 *  @param aConversations       The conversation list.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)importConversations:(NSArray<AgoraChatConversation *> * _Nullable)aConversations
                 completion:(void (^ _Nullable)(AgoraChatError * _Nullable aError))aCompletionBlock;

#pragma mark - Message

/**
 *  
 *  Gets the specified message.
 *
 *  @param aMessageId    The message ID.
 *  @result AgoraChatMessage     The message content.
 */
- (AgoraChatMessage * _Nullable)getMessageWithMessageId:(NSString * _Nonnull)aMessageId;

/**
 *  
 *  Gets the local path of message attachments in a conversation.
 *
 *  When a conversation is deleted, the message attachments in the conversation will also be deleted.
 *
 *  @param aConversationId  The conversation ID.
 *
 *  @result The attachment path.
 */
- (NSString * _Nullable)getMessageAttachmentPath:(NSString * _Nonnull)aConversationId;

/**
 *  
 *  Imports multiple messages to the local database.
 *
 *  @param aMessages            The message list.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)importMessages:(NSArray<AgoraChatMessage *> * _Nonnull)aMessages
            completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Updates a message in the local database.
 *
 *  This method updates the message in both the memory and the local database at the same time.
 *
 *  The message ID cannot be updated.
 *
 *  @param aMessage             The message instance.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)updateMessage:(AgoraChatMessage *_Nonnull)aMessage
           completion:(void (^_Nullable)(AgoraChatMessage * _Nullable aMessage, AgoraChatError * _Nullable aError))aCompletionBlock;
/**
 *  
 *  Modifies a local message or a message at the server side.
 *
 * You can call this method to only modify a text message in one-to-one chats or group chats, but not in chat rooms.
 *
 *  @param message            The ID of the message to modify.
 *  @param body                   The modified message body(AgoraChatTextMessageBody).
 *  @param completionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)modifyMessage:(NSString *_Nonnull)messageId body:(AgoraChatMessageBody *_Nonnull)body completion:(void (^_Nonnull)(AgoraChatError * _Nullable error,AgoraChatMessage *_Nullable message))completionBlock;

/**
 *  
 *  Sends the read receipt for a message.
 *
 *  This is an asynchronous method.
 *
 *  @param aMessageId           The message ID.
 *  @param aUsername            The user ID of the recipient of the read receipt.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)sendMessageReadAck:(NSString * _Nonnull)aMessageId
                    toUser:(NSString * _Nonnull)aUsername
                completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;


/**
 *  
 *  Sends the read receipt for a group message.
 *
 *  This is an asynchronous method.
 *
 *  @param aMessageId           The message ID.
 *  @param aGroupId             The group ID.
 *  @param aContent             The message content.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)sendGroupMessageReadAck:(NSString * _Nonnull)aMessageId
                        toGroup:(NSString * _Nonnull)aGroupId
                        content:(NSString * _Nullable)aContent
                     completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Sends the conversation read receipt to the server.
 *
 *  This method applies to one-to-one chats only.
 *
 *  This method call notifies the server to set the number of unread messages of the specified conversation as 0, and triggers the onConversationRead callback on the recipient's client.
 *
 *  To reduce the number of method calls, we recommend that you call this method when the user enters a conversation with many unread messages, and call `sendMessageReadAck` during a conversation to send the message read receipts.
 *
 *  This is an asynchronous method.
 *
 *  @param conversationId          The conversation ID.
 *  @param aCompletionBlock        The completion block, which contains the error message if the method fails.
 *
 */
- (void)ackConversationRead:(NSString * _Nonnull)conversationId
                 completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Recalls a message.
 *
 *  This is an asynchronous method.
 *
 *  @param aMessageId           The message ID
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)recallMessageWithMessageId:(NSString *_Nonnull)aMessageId
                        completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Recalls a message.
 *
 *  This is an asynchronous method.
 *
 *  @param aMessageId           The ID of the message to recall.
 *  @param ext        The information to be transparently transmitted during message recall. The information can be a string or a JSONString.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)recallMessageWithMessageId:(NSString *_Nonnull)aMessageId ext:(NSString * _Nullable)ext completion:(void (^_Nonnull)(AgoraChatError * _Nullable))aCompletionBlock;
/**
 *  
 *  Sends a message.
 *
 *  This is an asynchronous method.
 *
 *  @param aMessage             The message instance.
 *  @param aProgressBlock       The callback block of attachment upload progress. The progress value range is [0,100].
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)sendMessage:(AgoraChatMessage *_Nonnull)aMessage
           progress:(void (^_Nullable)(int progress))aProgressBlock
         completion:(void (^_Nullable)(AgoraChatMessage *_Nullable message, AgoraChatError *_Nullable error))aCompletionBlock;

/**
 *  
 *  Resends a message.
 *
 *  @param aMessage             The message object.
 *  @param aProgressBlock       The callback block of attachment upload progress. The progress value range is [0,100].
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)resendMessage:(AgoraChatMessage *_Nonnull)aMessage
             progress:(void (^_Nullable)(int progress))aProgressBlock
           completion:(void (^_Nullable)(AgoraChatMessage *_Nullable message, AgoraChatError *_Nullable error))aCompletionBlock;

/**
 *  
 *  Downloads the message thumbnail (the thumbnail of an image or the first frame of a video).
 *
 *  The SDK automatically downloads the thumbnail. If the auto-download fails, you can call this method to manually download the thumbnail.
 *
 *  @param aMessage             The message object.
 *  @param aProgressBlock       The callback block of attachment download progress. The progress value range is [0,100].
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)downloadMessageThumbnail:(AgoraChatMessage *_Nonnull)aMessage
                        progress:(void (^_Nullable)(int progress))aProgressBlock
                      completion:(void (^_Nullable)(AgoraChatMessage *_Nullable message, AgoraChatError *_Nullable error))aCompletionBlock;

/**
 *  
 *  Downloads message attachment (voice, video, image or file).
 *
 *  The SDK automatically downloads voice messages. If the automatic download fails, you can call this method to download voice messages manually.
 *
 *  This is an asynchronous method.
 *
 *  @param aMessage             The message object.
 *  @param aProgressBlock       The callback block of attachment download progress. The progress value range is [0,100].
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)downloadMessageAttachment:(AgoraChatMessage *_Nonnull)aMessage
                         progress:(void (^_Nullable)(int progress))aProgressBlock
                       completion:(void (^_Nullable)(AgoraChatMessage *_Nullable message, AgoraChatError *_Nullable error))aCompletionBlock;

/**
 *  
 *  Download and parse the attachment in a combined message.
 *
 *  This is an asynchronous method.
 *
 *  @param aMessage            The combined message object.
 *  @param aCompletionBlock    The completion block, which contains the error message if the method fails.
 */
- (void)downloadAndParseCombineMessage:(AgoraChatMessage* _Nonnull)aMessage
                            completion:(void (^_Nullable)(NSArray<AgoraChatMessage *>*_Nullable messages, AgoraChatError *_Nullable error))aCompletionBlock;

/**
 *  
 *  Gets messages in a conversation from the server.
 
 *  @param aConversationId      The conversation ID.
 *  @param aConversationType    The conversation type.
 *  @param aStartMessageId      The starting message ID for query. If you set this parameter as `nil` or "", the SDK gets messages from the latest one.
 *  @param direction            The message search direction. See {@link AgoraChatMessageFetchHistoryDirection}.
 *  @param aPageSize            The number of messages that you expect to get on each page.
 *  @param pError               The error information if the method fails: Error.
 *
 *  @result    The list of retrieved messages.
 */
- (AgoraChatCursorResult<AgoraChatMessage*> *_Nullable)fetchHistoryMessagesFromServer:(NSString *_Nonnull)aConversationId
                                  conversationType:(AgoraChatConversationType)aConversationType
                                    startMessageId:(NSString *_Nullable)aStartMessageId
                                       fetchDirection:(AgoraChatMessageFetchHistoryDirection)direction
                                          pageSize:(int)aPageSize
                                             error:(AgoraChatError **_Nullable)pError __deprecated_msg("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead");
/**
 *  
 *  Gets messages in a conversation from the server.
 
 *  @param aConversationId      The conversation ID.
 *  @param aConversationType    The conversation type.
 *  @param aStartMessageId      The starting message ID for query. If you set this parameter as `nil` or "", the SDK gets messages from the latest one.
 *  @param aPageSize            The number of messages that you expect to get on each page.
 *  @param pError               The error information if the method fails: Error.
 *
 *  @result    The list of retrieved messages.
 */
- (AgoraChatCursorResult<AgoraChatMessage*> *_Nullable)fetchHistoryMessagesFromServer:(NSString *_Nonnull)aConversationId
                                  conversationType:(AgoraChatConversationType)aConversationType
                                    startMessageId:(NSString *_Nullable)aStartMessageId
                                          pageSize:(int)aPageSize
                                                                      error:(AgoraChatError **_Nullable)pError __deprecated_msg("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead");


/**
 *  
 *  Gets messages in a conversation from the server.
 *
 *  This is an asynchronous method.
 *
 *  @param aConversationId      The conversation ID.
 *  @param aConversationType    The conversation type.
 *  @param aStartMessageId      The starting message ID for query. If you set this parameter as `nil` or "", the SDK gets messages from the latest one.
 *  @param aPageSize            The number of messages that you expect to get on each page.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)asyncFetchHistoryMessagesFromServer:(NSString *_Nonnull)aConversationId
                           conversationType:(AgoraChatConversationType)aConversationType
                             startMessageId:(NSString *_Nullable)aStartMessageId
                                   pageSize:(int)aPageSize
                                 completion:(void (^_Nullable)(AgoraChatCursorResult<AgoraChatMessage*> *_Nullable aResult, AgoraChatError *_Nullable aError))aCompletionBlock __deprecated_msg("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead");
/**
 *  
 *  Fetches conversation messages from server.
 *
 *  This is an asynchronous method.
 *
 *  @param aConversationId      The conversation ID.
 *  @param aConversationType    The conversation type.
 *  @param aStartMessageId      The starting message ID for query. If you set this parameter as `nil` or "", the SDK gets messages from the latest one.
 *  @param direction            The message search direction. See {@link AgoraChatMessageFetchHistoryDirection}.
 *  @param aPageSize            The number of messages that you expect to get on each page. The value range is [1,50].
 *  @param aCompletionBlock     The callback block, which contains the error message if the method fails.
 */
- (void)asyncFetchHistoryMessagesFromServer:(NSString *_Nonnull)aConversationId
                           conversationType:(AgoraChatConversationType)aConversationType
                             startMessageId:(NSString *_Nullable)aStartMessageId
                             fetchDirection:(AgoraChatMessageFetchHistoryDirection)direction
                                   pageSize:(int)aPageSize
                                 completion:(void (^_Nullable)(AgoraChatCursorResult<AgoraChatMessage*> *_Nullable aResult, AgoraChatError *_Nullable aError))aCompletionBlock __deprecated_msg("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead");

 


/**
 *  
 *  Gets the read receipts of a specified group message from the server.
 *
 *  By getting the read receipts of a group message, you can see how many group members have read this message.
 *
 *  This is an asynchronous method.
 *
 *  @param  aMessageId           The message ID.
 *  @param  aGroupId             The group ID.
 *  @param  aGroupAckId          The ID of the read receipt to get from the server.
 *  @param  aPageSize            The number of read receipts that you expect to get on each page.
 *  @param  aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)asyncFetchGroupMessageAcksFromServer:(NSString *_Nonnull)aMessageId
                                     groupId:(NSString *_Nonnull)aGroupId
                             startGroupAckId:(NSString *_Nonnull)aGroupAckId
                                    pageSize:(int)aPageSize
                                  completion:(void (^_Nullable)(AgoraChatCursorResult<AgoraChatGroupMessageAck *> *_Nullable aResult, AgoraChatError *_Nullable error, int totalCount))aCompletionBlock;

/**
 *  
 *  Reports an inappropriate message.
 *
 *  This is an asynchronous method.
 
 *  @param  aMessageId              The ID of the inappropriate message.
 *  @param  aTag                   The tag of the illegal message. You need to type a custom tag, like `porn` or `ad`.  This parameter corresponds to the "Label" field on the message reporting history page of the console.
 *  @param  aReason                 he reporting reason. You need to type a specific reason. This parameter corresponds to the "Reason" field on the message reporting history page of the console.
 *  @param  aCompletion             The completion block, which contains the error message if the method fails.
 */
- (void)reportMessageWithId:(NSString *_Nonnull )aMessageId
                        tag:(NSString *_Nonnull)aTag
                     reason:(NSString *_Nonnull)aReason
                 completion:(void(^_Nullable)(AgoraChatError* _Nullable error))aCompletion;

/*!
 *  
 *  Deletes local historical messages with a Unix timestamp before a specified one.After setting the `autoLoadConversations` attribute in ``AgoraChatOptions`` to `false`, the filtered session pull messages will not be read accurately.
 *
 *  @param aTimestamp            The specified Unix timestamp in miliseconds. Messages with a Unix timestamp before the specified one will be deleted.
 *  @param aCompletion           The completion block, which contains the error message if the method fails.
 *
 */
- (void)deleteMessagesBefore:(NSUInteger)aTimestamp
                  completion:(void(^)(AgoraChatError*error))aCompletion;



/**
 *  
 *  Removes messages in a conversation (from both local storage and the server).
 *
 *  @param conversation The AgoraChatConversation object.
 *  @param messageIds   A string array of message IDs to delete.
 *  @param completion   The completion block, which contains the error message if the method fails.
 *
 */
- (void)removeMessagesFromServerWithConversation:(AgoraChatConversation *_Nonnull)conversation messageIds:(NSArray <__kindof NSString*>*_Nonnull)messageIds completion:(void (^ _Nullable)(AgoraChatError * _Nullable aError))aCompletionBlock;
/**
 *  
 *  Removes messages in a conversation (from both local storage and the server).
 *
 *  @param conversation The AgoraChatConversation object.
 *  @param beforeTimeStamp   The specified Unix timestamp in miliseconds. Messages with a timestamp before the specified one will be removed from the conversation.
 *  @param completion   The completion block, which contains the error message if the method fails.
 *
 */
- (void)removeMessagesFromServerWithConversation:(AgoraChatConversation *_Nonnull)conversation timeStamp:(NSTimeInterval)beforeTimeStamp completion:(void (^ _Nullable)(AgoraChatError * _Nullable aError))aCompletionBlock;


/*!
 *  
 *  Translates a message.
 *
 *  @param aMessage             The message object.
 *  @param aLanguages           The list of target language codes.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)translateMessage:(AgoraChatMessage * _Nonnull)aMessage
         targetLanguages:(NSArray<NSString*>* _Nonnull)aLanguages
              completion:(void (^_Nullable)(AgoraChatMessage * _Nullable message, AgoraChatError * _Nullable error))aCompletionBlock;

/*!
 *  
 *
 *  Gets all languages supported by the translation service.
 *
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 */
- (void)fetchSupportedLanguages:(void(^_Nullable)(NSArray<AgoraChatTranslateLanguage*>* _Nullable languages,AgoraChatError* _Nullable error))aCompletionBlock;

/**
 *  
 *  Loads messages with the specified keyword from the local database.
 *
 *  This method returns messages in chronological order.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aType            The message type to load.
 *  @param aTimestamp       The message timestamp threshold for loading. If you set this parameter as a negative value, the SDK loads messages from the latest one.
 *  @param aCount           The number of messages to load. If you set this parameter to a value less than 1, the SDK gets one message from the local database.
 *  @param aUsername        The message sender. It is optional. If you set this parameter as `nil`, the SDK gets messages while ignoring this parameter.
 *  @param aDirection       The message search direction. See {@link AgoraChatMessageSearchDirection}.
 *                          - `UP`: The SDK retrieves messages in the descending order of the timestamp included in them.
 *                          - `DOWN`：The SDK retrieves messages in the ascending order of the timestamp included in them.
 *
 *  @result The list of retrieved messages. The message list is of the array type. For elements in the array, see {@link AgoraChatMessage}.
 *
 */
- (NSArray<AgoraChatMessage *> * _Nullable)loadMessagesWithType:(AgoraChatMessageBodyType)aType
                                                   timestamp:(long long)aTimestamp
                                                       count:(int)aCount
                                                    fromUser:(NSString* _Nullable)aUsername
                                             searchDirection:(AgoraChatMessageSearchDirection)aDirection;

/**
 *  
 *  Loads messages with the specified keyword from the local database.
 *
 *  This method returns messages in chronological order.
 *
 *  @param aType            The message type to load.
 *  @param aTimestamp       The message timestamp threshold for loading. If you set this parameter as a negative value, the SDK loads messages from the latest one.
 *  @param aCount           The number of messages to load. If you set this parameter to a value less than 1, the SDK gets one message from the local database.
 *  @param aUsername        The message sender. It is optional. If you set this parameter as `nil`, the SDK ignores this parameter when retrieving messages.
 *  @param aDirection       The message search direction. See {@link AgoraChatMessageSearchDirection}.
 *                          - `UP`: The SDK retrieves messages in the descending order of the timestamp included in them.
 *                          - `DOWN`：The SDK retrieves messages in the ascending order of the timestamp included in them.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)loadMessagesWithType:(AgoraChatMessageBodyType)aType
                   timestamp:(long long)aTimestamp
                       count:(int)aCount
                    fromUser:(NSString*)aUsername
             searchDirection:(AgoraChatMessageSearchDirection)aDirection
                  completion:(void (^)(NSArray<AgoraChatMessage *> *aMessages, AgoraChatError *aError))aCompletionBlock;

/**
 *  
 *  Loads messages with the specified keyword from the local database.
 *
 *  This method returns messages in chronological order.
 *
 *  @param aTypes             The message types to load. Types include txt (text message), img (image message), loc (location message), audio (audio message), video (video message), file (file message), and cmd (command message). ``AgoraChatMessageBodyType``
 *  @param aTimestamp       The message timestamp threshold for loading. If you set this parameter as a negative value, the SDK loads messages from the latest one.
 *  @param aCount           The number of messages to load. If you set this parameter to a value less than 1, the SDK gets one message from the local database.
 *  @param aUsername        The message sender. It is optional. If you set this parameter as `nil`, the SDK ignores this parameter when retrieving messages.
 *  @param aDirection       The message search direction. See {@link AgoraChatMessageSearchDirection}.
 *                          - `UP`: The SDK retrieves messages in the descending order of the timestamp included in them.
 *                          - `DOWN`：The SDK retrieves messages in the ascending order of the timestamp included in them.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)searchMessagesWithTypes:(NSArray <NSNumber*>* _Nonnull)aTypes
                   timestamp:(long long)aTimestamp
                       count:(int)aCount
                    fromUser:(NSString* _Nullable)aUsername
             searchDirection:(AgoraChatMessageSearchDirection)aDirection
                   completion:(void (^_Nonnull)(NSArray<AgoraChatMessage *> * _Nullable aMessages, AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 *  
 *  Loads messages with the specified keyword from the local database.
 *
 *  This method returns messages in chronological order.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aKeyword         The keyword for message search. If you set this parameter as `nil`, the SDK ignores this parameter when retrieving messages.
 *  @param aTimestamp       The message timestamp threshold for loading. If you set this parameter as a negative value, the SDK loads messages from the latest.
 *  @param aCount           The number of messages to load. If you set this parameter less than 1, the SDK gets one message from the local database.
 *  @param aSender          The message sender. If you set this parameter as `nil`, the SDK ignores this parameter when retrieving messages.
 *  @param aDirection       The message search direction. See {@link AgoraChatMessageSearchDirection}.
 *                          - `UP`: The SDK retrieves messages in the descending order of the timestamp included in them.
 *                          - `DOWN`：The SDK retrieves messages in the ascending order of the timestamp included in them.
 *
 *  @result The list of retrieved messages. The message list is of the array type. For elements in the array, see {@link AgoraChatMessage}.
 *
 */
- (NSArray<AgoraChatMessage *> *)loadMessagesWithKeyword:(NSString*)aKeywords
                      timestamp:(long long)aTimestamp
                          count:(int)aCount
                       fromUser:(NSString*)aSender
                searchDirection:(AgoraChatMessageSearchDirection)aDirection;

/**
 *  
 *  Loads messages with the specified keyword from the local database.
 *
 *  This method returns messages in chronological order.
 *
 *  @param aKeyword         The keyword for message search. If you set this parameter as `nil`, the SDK ignores this parameter when retrieving messages.
 *  @param aTimestamp       The message timestamp threshold for loading. If you set this parameter as a negative value, the SDK loads messages from the latest.
 *  @param aCount           The number of messages to load. If you set this parameter less than 1, the SDK gets one message from the local database.
 *  @param aSender          The sender of the message. If you set this parameter as `nil`, the SDK ignores this parameter when retrieving messages.
 *  @param aDirection       The message search direction. See {@link AgoraChatMessageSearchDirection}.
 *                          - `UP`: The SDK retrieves messages in the descending order of the timestamp included in them.
 *                          - `DOWN`：The SDK retrieves messages in the ascending order of the timestamp included in them.
 *  @param aCompletionBlock  The completion block which contains the error code and error information if the method fails.
 */
- (void)loadMessagesWithKeyword:(NSString*)aKeywords
                      timestamp:(long long)aTimestamp
                          count:(int)aCount
                       fromUser:(NSString*)aSender
                searchDirection:(AgoraChatMessageSearchDirection)aDirection
                     completion:(void (^)(NSArray<AgoraChatMessage *> *aMessages, AgoraChatError *aError))aCompletionBlock;

/**
 *  
 *  Loads messages with the specified keyword from the local database.
 *
 *  The SDK returns messages in the chronological order.
 *
 *  @param aKeyword         The keyword for message search. If you set this parameter as `nil`, the SDK ignores this parameter when retrieving messages.
 *  @param aTimestamp       The Unix timestamp threshold for message search. The unit is millisecond. If you set this parameter as a negative value, the SDK loads messages from the latest one.
 *  @param aCount           The number of messages to load. If you set this parameter to 0 or less, the SDK gets one message from the local database.
 *  @param aSender          The sender of the message. If you set this parameter as `nil`, the SDK ignores this parameter when retrieving messages.
 *  @param aDirection       The message search direction. See {@link AgoraChatMessageSearchDirection}.
 *                          - `UP`: The SDK retrieves messages in the descending order of the timestamp included in them.
 *                          - `DOWN`：The SDK retrieves messages in the ascending order of the timestamp included in them.
 *  @param aScope       The message search scope. See {@link AgoraChatMessageSearchScope}.
 *  @param aCompletionBlock  The completion block which contains the error code and error information if the method fails.
 */
- (void)loadMessagesWithKeyword:(NSString*)aKeywords
                      timestamp:(long long)aTimestamp
                          count:(int)aCount
                       fromUser:(NSString*)aSender
                searchDirection:(AgoraChatMessageSearchDirection)aDirection
                          scope:(AgoraChatMessageSearchScope)aScope
                     completion:(void (^)(NSArray<AgoraChatMessage *> *aMessages, AgoraChatError *aError))aCompletionBlock;

NS_ASSUME_NONNULL_BEGIN
/*!
 *  
 *  Adds a Reaction.
 *
 *  @param reaction  The Reaction content.
 *  @param messageId  The message ID.
 *  @param completion  The completion block which contains the error code and error information if the method fails.
 */
- (void)addReaction:(NSString *)reaction toMessage:(NSString *)messageId completion:(nullable void(^)(AgoraChatError * _Nullable))completion;

/*!
 *  
 *  Removes a Reaction.
 *
 *  @param reaction  The Reaction content.
 *  @param messageId  The message ID.
 *  @param completion  The completion block which contains the error code and error information if the method fails.
 */
- (void)removeReaction:(NSString *)reaction fromMessage:(NSString *)messageId completion:(nullable void(^)(AgoraChatError * _Nullable))completion;

/*!
 *  
 *  Gets the Reaction list.
 *
 *  @param messageId  The message ID.
 *  @param groupId  The group ID. This parameter is invalid only for group chat.
 *  @param chatType  The chat type. Only one-to-one chat ({@link AgoraChatTypeChat} and group chat ({@link AgoraChatTypeGroupChat}) are allowed.
 *  @param completion The completion block which contains the error code and error information if the method fails.
 */
- (void)getReactionList:(NSArray <NSString *>*)messageIds
                groupId:(nullable NSString *)groupId
               chatType:(AgoraChatType)chatType
             completion:(void (^)(NSDictionary <NSString *, NSArray<AgoraChatMessageReaction *> *> *, AgoraChatError * _Nullable))completion;

/*!
 *  
 *  Uses the pagination to get the Reaction detail list of a chat group message.
 *
 *  @param messageId  The message ID.
 *  @param reaction  The Reaction content.
 *  @param cursor  The position from which to start getting data. If it is set to `nil` or `@""` at the first call, the SDK retrieves Reactions in the chronological order of their creation time.
 *  @param pageSize   The number of Reactions that you expect to get on each page. The value range is [1,100].
 *  @param completion  The completion block, which contains the Reaction list and the cursor for the next query. When the cursor is `nil`, all data is already fetched.
 */
- (void)getReactionDetail:(NSString *)messageId
                 reaction:(NSString *)reaction
                    cursor:(nullable NSString *)cursor
                 pageSize:(uint64_t)pageSize
               completion:(void (^)(AgoraChatMessageReaction *, NSString * _Nullable cursor, AgoraChatError * _Nullable))completion;

/**
 *  
 *  Get the historical messages of the specified session from the server page according to the message pull parameter configuration interface (`AgoraChatFetchServerMessagesOption`).
 *  When the number of returned messages is less than the expected number of messages, it means that the server has no more historical messages.
 *
 *  @param conversationId The conversation ID.
 *                        - One-to-one chat: The ID of the peer user;
 *                        - Group chat: The group ID;
 *                        - Chat room: The chat room ID.
 *  @param type The conversation type.
 *  @param cursor The cursor position from which to start querying data.
 *  @param pageSize The number of messages that you expect to get on each page. The value range is [1,50].
 *  @param option  The parameter configuration class for pulling historical messages from the server. See {@link AgoraChatFetchServerMessagesOption}.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)fetchMessagesFromServerBy:(NSString* )conversationId
                 conversationType:(AgoraChatConversationType)type
                           cursor:(NSString* _Nullable)cursor
                         pageSize:(NSUInteger)pageSize
                           option:(AgoraChatFetchServerMessagesOption* _Nullable)option
                       completion:(void (^_Nullable)(AgoraChatCursorResult<AgoraChatMessage*>* _Nullable result, AgoraChatError* _Nullable aError))aCompletionBlock;

/**
 *  
 *  Marks conversations.
 *
 *  This method marks conversations both locally and on the server.
 *
 *  @param conversationIds The list of conversation IDs.
 *  @param mark  The mark to add for the conversations.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)addConversationMark:(NSArray<NSString*>* _Nonnull)conversationIds mark:(AgoraChatMarkType)mark completion:(void (^_Nullable)(AgoraChatError* _Nullable aError))completion;

/**
 *  
 *
 *  Unmarks conversations.
 *
 *  This method unmarks conversations both locally and on the server.
 *
 *  @param conversationIds The list of conversation IDs.
 *  @param mark The conversation mark to remove.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)removeConversationMark:(NSArray<NSString*>* _Nonnull)conversationIds mark:(AgoraChatMarkType)mark completion:(void (^_Nullable)(AgoraChatError* _Nullable aError))completion;

/**
 *  
 *  Gets the conversations from the server with pagination according to the conversation filter class.
 *
 *  @param cursor The position from which to start getting data. If you pass in `nil` or `@""`, the SDK retrieves conversations from the latest marked one.
 *  @param filter The conversation filter options: conversation mark and the number of conversations to retrieve on each page.
 *  @param aCompletionBlock The completion block, which contains the conversation list and the cursor for the next query. When the cursor is empty, all data is already retrieved.
 *
 */
- (void)getConversationsFromServerWithCursor:(NSString * _Nullable)cursor filter:(AgoraChatConversationFilter* _Nonnull)filter completion:(nonnull void (^)(AgoraChatCursorResult<AgoraChatConversation *> * _Nullable result, AgoraChatError * _Nullable error))completionBlock;

/**
 * 
 * Clears all conversations and all messages in them.
 *
 * This is an asynchronous method.
 *
 * @param clearSeverData Whether to clear all conversations and all messages in them on the server.
 *  - YES：Yes. All conversations and all messages in them will be cleared on the server side.
           The current user cannot retrieve messages and conversations from the server, while this has no impact on other users.
 *  - (Default) NO：No. All local conversations and all messages in them will be cleared, while those on the server remain.
 * @param aCompletionBlock The completion callback, which contains the description of the cause to the failure.
 */
- (void)deleteAllMessagesAndConversations:(BOOL)clearServerData completion:(void (^_Nullable)(AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 * 
 * Pins a message.
 *
 * @param messageId The ID of the message to be pinned.
 * @param aCompletionBlock The completion block, which contains the pinned message object if the call succeeds, or contains the error message if the method fails.
 */
- (void)pinMessage:(NSString* _Nonnull)messageId completion:(void (^_Nullable)(AgoraChatMessage* _Nullable message,AgoraChatError * _Nullable aError))aCompletionBlock;
/**
 * 
 * Unpins a message.
 *
 * @param messageId The ID of the message to be unpinned.
 * @param aCompletionBlock The completion block, which contains the unpinned message object if the call succeeds, or contains the error message if the method fails.

 */
- (void)unpinMessage:(NSString* _Nonnull)messageId completion:(void (^_Nullable)(AgoraChatMessage* _Nullable message,AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 * 
 * Gets the list of pinned messages in a conversation.
 *
 * @param conversationId The conversation ID.
 * @param aCompletionBlock The completion block, which contains the list of pinned messages if the call succeeds, or contains the error message if the method fails.
 */
- (void)getPinnedMessagesFromServer:(NSString* _Nonnull)conversationId completion:(void (^_Nullable)(NSArray<AgoraChatMessage*>* _Nullable messages,AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 * 
 * Marks all conversations as read.
 *
 * This method works only for local conversations.
 */
- (AgoraChatError*)markAllConversationsAsRead;

/**
 *  
 *  Get the message count from db.
 *
 *  @param completion  The completion block, which contains the number of message count in db.
 */
- (void)getMessageCountWithCompletion:(void (^)(NSInteger count, AgoraChatError * _Nullable aError))completion;
    
NS_ASSUME_NONNULL_END

@end
