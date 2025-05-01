/**
 *  
 *  @header AgoraChatMessage.h
 *  @abstract Chat message
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>

#import "AgoraChatMessageBody.h"
#import "AgoraChatMessageReaction.h"

/**
 *  
 *  Chat types.
 */
typedef NS_ENUM(NSInteger, AgoraChatType) {
    AgoraChatTypeChat   = 0,   /**  One-to-one chat. */
    AgoraChatTypeGroupChat,    /**  Group chat. */
    AgoraChatTypeChatRoom,     /**  Chat room. */
};

/**
 *  
 *  The message delivery states.
 */
typedef NS_ENUM(NSInteger, AgoraChatMessageStatus) {
    AgoraChatMessageStatusPending  = 0,    /**  The message delivery is pending.*/
    AgoraChatMessageStatusDelivering,      /**  The message is being delivered.*/
    AgoraChatMessageStatusSucceed,         /**  The message is successfully delivered.*/
    AgoraChatMessageStatusFailed,          /**  The message fails to be delivered.*/
};

/**
 *  
 *  The message directions.
 */
typedef NS_ENUM(NSInteger, AgoraChatMessageDirection) {
    AgoraChatMessageDirectionSend = 0,    /**  This message is sent from the local client.*/
    AgoraChatMessageDirectionReceive,     /**  The message is received by the local client.*/
};

/**
 *  
 *  The chat room message priorities.
 */
typedef NS_ENUM(NSInteger, AgoraChatRoomMessagePriority)  {
    /**  High. */
    AgoraChatRoomMessagePriorityHigh = 0,
    /**  Normal. */
    AgoraChatRoomMessagePriorityNormal,
    /**  Low. */
    AgoraChatRoomMessagePriorityLow,
};

/**
 *  
 * The message pinning information.
 */
@interface AgoraChatMessagePinInfo: NSObject
/**  The user ID of the operator that pins the message. */
@property (strong,nonatomic) NSString* _Nonnull operatorId;
/**  When the message is pinned. The unit is millisecond. */
@property (nonatomic) NSInteger pinTime;

@end

/**
 *  
 * The message pinning and unpinning operations.
 */
typedef NS_ENUM(NSInteger, AgoraChatMessagePinOperation) {
    /**  Pin the message. */
    AgoraChatMessagePin = 0,
    
    /**  Unpin the message. */
    AgoraChatMessageUnpin
};

@class AgoraChatThread;
/**
 *  
 *  The chat message class.
 */
@interface AgoraChatMessage : NSObject

/**
 *  
 *  The message ID, which is the unique identifier of the message.
 */
@property (nonatomic, copy) NSString * _Nonnull messageId;

/**
 *  
 *  The conversation ID, which is the unique identifier of the conversation.
 */
@property (nonatomic, copy) NSString * _Nonnull conversationId;

/**
 *  
 *  The message delivery direction.
 */
@property (nonatomic) AgoraChatMessageDirection direction;

/**
 *  
 *  The user sending the message.
 */
@property (nonatomic, copy) NSString * _Nonnull from;

/**
 *  
 *  The user receiving the message.
 */
@property (nonatomic, copy) NSString * _Nonnull to;

/**
 *  
 *  The Unix timestamp for the chat server receiving the message. 
 * 
 *  The unit is second.
 */
@property (nonatomic) long long timestamp;

/**
 *  
 *  The Unix timestamp for the local client sending or receiving the message.
 * 
 * The unit is millisecond.
 */
@property (nonatomic) long long localTime;

/**
 *  
 *  The chat type.
 */
@property (nonatomic) AgoraChatType chatType;

/**
 *  
 *  The message delivery status. See {@link AgoraChatMessageStatus}.
 */
@property (nonatomic) AgoraChatMessageStatus status;

/*!
 *   
 * 
 *  Whether the message is an online message:
 *  - `YES`: online message. 
 *  - `NO`: offline message.
 * 
 * This message status is not stored in the local database. 
 * 
 * Messages read from the database or pulled from the server are regarded as online.
 * 
 * 
 */
@property (nonatomic, readonly) BOOL onlineState;

/**
 *  
 *  Whether the message read receipt is sent (from the message recipient) or received (by the message sender).
 *
 *  - `YES`: Yes;
 *  - `NO`: No.
 */
@property (nonatomic) BOOL isReadAcked;

/**
 *  
 *  Whether this message is sent within a thread:
 * 
 *  - `YES`: Yes;
 *  - `NO`: No.
 */
@property (nonatomic) BOOL isChatThreadMessage;

/**
 *  
 *  Whether read receipts are required for group messages.
 *
 *  - `YES`: Yes;
 *  - `NO`: No.
 */
@property (nonatomic) BOOL isNeedGroupAck;

/**
 *  
 *  The number of read receipts received for group messages.
 */
@property (nonatomic, readonly) int groupAckCount;

/**
 *  
 *  Whether the delivery receipt is sent or received:
 * 
 *  - `YES`: Yes;
 *  - `NO`: No.

 *  For the message sender, this attribute indicates whether the delivery receipt is received.
 * 
 *  For the message recipient, this attribute indicates whether the delivery receipt is sent.
 *
 *  If you set `enableDeliveryAck` in `AgoraChatOptions` as `YES`, the SDK automatically sends the delivery receipt after receiving a message.
 */
@property (nonatomic) BOOL isDeliverAcked;

/**
 *  
 *  Whether the message is read.
 *
 *  - `YES`: Yes;
 *  - `NO`: No.
 */
@property (nonatomic) BOOL isRead;

/**
 *  
 *  Whether the voice message is played.
 *
 *  - `YES`: Yes;
 *  - `NO`: No.
 */
@property (nonatomic) BOOL isListened;

/**
 *  
 *  The message body.
 */
@property (nonatomic, strong) AgoraChatMessageBody * _Nonnull body;

/**
 *  
 *  The Reaction list.
 */
@property (nonatomic, readonly) NSArray <AgoraChatMessageReaction *>* _Nullable reactionList;

/**
 *  
 *  Gets the Reaction content by the Reaction ID.
 *
 *  @param reaction   The Reaction ID.
 *
 *  @result    The Reaction content.
 */
- (AgoraChatMessageReaction *_Nullable)getReaction:(NSString * _Nonnull)reaction;

/**
 *  
 *  The custom message extension.
 *
 *  This data is in the key-value format, where the key is the extension field name of the NSString type, and the value must be of the NSString or NSNumber (Bool, Int, unsigned int, long long, double) type.
 */
@property (nonatomic, copy) NSDictionary * _Nullable ext;
/**
 *  
 *  Gets an overview of the thread in the message.
 * 
 *  Currently, this attribute is valid only for group messages.
 */

@property (readonly) AgoraChatThread * _Nullable chatThread;
/**
 *  
 *  Sets the priority of a chat room message. 
 * 
 *  Currently, this attribute is valid only for chat room messages.
 * 
 *  The default value is `normal`, indicating the normal priority.
 */
@property (nonatomic) AgoraChatRoomMessagePriority  priority;

/**
 *  
 *
 *  Whether it is a broadcast message
 */
@property (nonatomic,readonly) BOOL broadcast;

/**
 * 
 *
 * Whether the message is delivered only when the recipient(s) is/are online:
 * - `YES`：The message is delivered only when the recipient(s) is/are online. If the recipient is offline, the message is not delivered.
 * - (Default) `NO`：The message is delivered to the recipients regardless of whether they are online or offline.
 */
@property (nonatomic) BOOL deliverOnlineOnly;

/**
  * 
  *
  * The recipient list of a targeted message.
  *
  * This property is used only for messages in groups and chat rooms. If you pass in `nil`, the messages are sent to all members in the group or chat room.
  */
@property (nonatomic,strong) NSArray<NSString*>* _Nullable receiverList;

/**
  * 
  *
  * Whether the message content has been replaced by server.This property is used only when AgoraChatOptions#useReplacedMessageContent is true.
  *
  */
@property (nonatomic,readonly) BOOL isContentReplaced;

/**
 *  
 *
 *  The message pinning information.
 *
 *  For a message that is not pinned, nil is returned.
 */
@property (nonatomic,readonly)  AgoraChatMessagePinInfo* _Nullable  pinnedInfo;

/**
 *  
 *  Initializes a message instance.
 *
 *  @param aConversationId   The conversation ID.
 *  @param aFrom           The user that sends the message.
 *  @param aTo         The user that receives the message.
 *  @param aBody             The message body.
 *  @param aExt              The message extention.
 *
 *  @result    The message instance.
 */


- (instancetype _Nonnull)initWithConversationID:(NSString *_Nonnull)aConversationId
                                  from:(NSString *_Nonnull)aFrom
                                    to:(NSString *_Nonnull)aTo
                                  body:(AgoraChatMessageBody *_Nonnull)aBody
                                   ext:(NSDictionary *_Nullable)aExt;

/**
 *  
 *  Initializes a message instance.
 *
 *  @param aConversationId   The conversation ID.
 *  @param aBody             The message body.
 *  @param aExt              The message extention.
 *
 *  @result    The message instance.
 */


- (instancetype _Nonnull)initWithConversationID:(NSString *_Nonnull)aConversationId
                                  body:(AgoraChatMessageBody *_Nonnull)aBody
                                   ext:(NSDictionary *_Nullable)aExt;

@end
