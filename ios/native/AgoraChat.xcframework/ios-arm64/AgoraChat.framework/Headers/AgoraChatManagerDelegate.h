/**
 *  
 *  @header AgoraChatManagerDelegate.h
 *  @abstract This protocol defines chat related callbacks.
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>
#import "AgoraChatRecallMessageInfo.h"

@class AgoraChatMessage;
@class AgoraChatError;
@class AgoraChatMessageReactionChange;
@class AgoraChatGroupMessageAck;
@class AgoraChatConversation;

/**
 *  
 *  The chat related callbacks.
 */
@protocol AgoraChatManagerDelegate <NSObject>

@optional

#pragma mark - Conversation

/**
 *  
 *  Occurs when the conversation list changes.
 *
 *  @param aConversationList  The conversation NSArray. <AgoraChatConversation>
 */
- (void)conversationListDidUpdate:(NSArray<AgoraChatConversation *> * _Nonnull)aConversationList;

#pragma mark - Message

/**
 *  
 *  Occurs when the SDK receives new messages.
 *
 *  @param aMessages  The received messages. An NSArray of the <AgoraChatMessage> objects.
 */
- (void)messagesDidReceive:(NSArray<AgoraChatMessage *> * _Nonnull)aMessages;

/**
 *  
 *  Occurs when receiving command messages.
 *
 *  @param aCmdMessages  The command message NSArray.
 */
- (void)cmdMessagesDidReceive:(NSArray<AgoraChatMessage *> * _Nonnull)aCmdMessages;

/**
 *  
 *  Occurs when receiving read acknowledgement in message list.
 *
 *  @param aMessages  The read messages.
 */
- (void)messagesDidRead:(NSArray<AgoraChatMessage *> * _Nonnull)aMessages;

/**
 *  
 *  Occurs when the SDK receives read receipts for group messages.
 *
 *  @param aMessage  The acknowledged message.
 *  @param aGroupAcks The read acks of the message.
 *
 */
- (void)groupMessageDidRead:(AgoraChatMessage * _Nonnull)aMessage
                  groupAcks:(NSArray<AgoraChatGroupMessageAck *> * _Nonnull)aGroupAcks;

/**
 *  
 *  Occurs when the current group read messages count changed.
 *
 */
- (void)groupMessageAckHasChanged;

/**
 * 
 * Occurs when a conversation read receipt is received.
 * @param from  The username who send channel_ack.
 * @param to    The username who receive channel_ack.
 *
 *  If the conversaion readack is from the current login ID's multiple devices:
 *       The value of the "FROM" parameter is current login ID, and the value of the "to" parameter is the conversation ID. All the messages sent by the conversation are set to read： "isRead" is set to YES.
 *  If the send conversation readack is from the conversation ID's device:
 *       The value of the "FROM" parameter is the conversation ID, and the value of the "to" parameter is current login ID. The "isReaAck" of messages sent by login ID in this session will all be set to YES.
 *  Note: This conversation is the conversation represented by the conversation ID.
 *
 *
 */
- (void)onConversationRead:(NSString * _Nonnull)from to:(NSString * _Nonnull)to;

/**
 *  
 *  Occurs when receiving delivered acknowledgement in message list.
 *
 *  @param aMessages  The acknowledged message NSArray.
 */
- (void)messagesDidDeliver:(NSArray<AgoraChatMessage *> * _Nonnull)aMessages;

/**
 *  
 *  Occurs when a message is recalled. If the recalled message is offline, the ``AgoraChatRecallMessageInfo`` object will be an empty object.
 *
 *  @param aRecallMessagesInfo  The list of recalled messages.
 */
- (void)messagesInfoDidRecall:(NSArray<AgoraChatRecallMessageInfo *> * _Nonnull)aRecallMessagesInfo;

/**
 *  
 *  Occurs when message status has changed. You need to set the parameter as nil.
 *
 *  @param aMessage  The message whose status has changed.
 *  @param aError    The error information.
 */
- (void)messageStatusDidChange:(AgoraChatMessage * _Nonnull)aMessage
                         error:(AgoraChatError * _Nullable)aError;

/**
 *  
 *  Occurs when the message attachment status changed.
 *
 *  @param aMessage  The message whose attachment status has changed.
 *  @param aError    The error information.
 */
- (void)messageAttachmentStatusDidChange:(AgoraChatMessage * _Nonnull)aMessage
                                   error:(AgoraChatError * _Nullable)aError;
/**
 *  
 *  Occurs when the message content is modified.
 *
 *  @param message  The modified message object, where the message body contains the information such as the number of message modifications, the operator of the last modification, and the last modification time.Also, you can get the operator of the last message modification and the last modification time via the `onMessageContentChanged` method.
 *  @param operatorId    The user ID of the operator that modified the message last time.
 *  @param operationTime   The last message modification time. It is a UNIX timestamp in milliseconds.
 */
- (void)onMessageContentChanged:(AgoraChatMessage *_Nonnull)message operatorId:(NSString *_Nonnull)operatorId operationTime:(NSUInteger)operationTime;

/**
 * 
 * Occurs when the message pinning status changed.
 *
 * @param messageId The ID of the message with the changed pinning status.
 * @param conversationId The ID of the conversation that contains the message.
 * @param pinOperation The message pinning or unpinning operation.
 * @param pinInfo The information about message pinning or unpinning, including the operation time and the user ID of the operater.
 */
- (void)onMessagePinChanged:(NSString* _Nonnull)messageId conversationId:(NSString* _Nonnull)conversationId operation:(AgoraChatMessagePinOperation)pinOperation pinInfo:(AgoraChatMessagePinInfo* _Nonnull)pinInfo;

#pragma mark - Deprecated methods

/**
 *  
 *  Occurs when a received message is recalled.
 *
 *  @param aMessages  The list of recalled messages.
 *
 *  Deprecated. Please use {@link messagesInfoDidRecall:} instead.
 */
- (void)messagesDidRecall:(NSArray *)aMessages __deprecated_msg("Use -messagesInfoDidRecall: instead");

/*!
 *  
 *  Occurs when the Reaction data changes.
 *
 *  @param changes The Reaction which is changed.
 */
- (void)messageReactionDidChange:(NSArray<AgoraChatMessageReactionChange *>* _Nonnull)changes;
@end
