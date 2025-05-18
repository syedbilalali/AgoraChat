/**
 *  
 *  @header AgoraChatMessageStatistics.h
 *  @abstract The message traffic statistics model.
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>
#import "AgoraChatMessage.h"

NS_ASSUME_NONNULL_BEGIN

/**
 *  
 *  The message traffic statistics.
 */
@interface AgoraChatMessageStatistics : NSObject

/**
 *  
 *  The message ID, which is the unique identifier of the message.
 */
@property (nonatomic,strong,readonly) NSString* messageId;

/**
 *  
 *  The user ID of the message recipient.
 */
@property (nonatomic,strong,readonly) NSString* to;

/**
 *  
 *  The user ID of the message sender.
 */
@property (nonatomic,strong,readonly) NSString* from;

/**
 *  
 *  The message body type.
 */
@property (nonatomic,readonly) AgoraChatMessageBodyType type;

/**
 *  
 *  The chat type.
 */
@property (nonatomic,readonly) AgoraChatType chatType;

/**
 *  
 *  The message direction:
 *  - `Send`: Messages sent by the current user;
 *  - `Receive`: Messages received by the current user.

 */
@property (nonatomic,readonly) AgoraChatMessageDirection direction;

/**
 *  
 *  The amount of traffic for the message body.
 * 
 *  The traffic is measured in bytes.
 */
@property (nonatomic,readonly) NSUInteger messageSize;

/**
 *  
 *  The amount of traffic for the message attachment.
 * 
 *  The traffic is measured in bytes.
 */
@property (nonatomic,readonly) NSUInteger attachmentSize;

/**
 *  
 *  The amount of traffic for the thumbnail.
 * 
 *  The traffic is measured in bytes.
 */
@property (nonatomic,readonly) NSUInteger thumbnailSize;

/**
 *  
 *  The Unix timestamp for the Chat server receiving the message. 
 * 
 *  The Unix timestamp is in the unit of millisecond.
 */
@property (nonatomic,readonly) NSUInteger timestamp;
@end

NS_ASSUME_NONNULL_END
