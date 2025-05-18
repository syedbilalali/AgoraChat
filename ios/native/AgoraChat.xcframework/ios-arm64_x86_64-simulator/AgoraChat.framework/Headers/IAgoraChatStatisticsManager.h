/**
 *  
 *  @header IAgoraChatStatisticsManager.h
 *  @abstract This protocol defines the message statistics operations. 
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>
#import "AgoraChatMessageStatistics.h"

/**
 *  
 *  The message direction types for querying.
 */
typedef NS_ENUM(NSUInteger, AgoraChatMessageStatisticsDirection) {
    AgoraChatMessageStatisticsDirectionSend = 0, /**  This message is sent from the local client.*/
    AgoraChatMessageStatisticsDirectionReceive, /**  The message is received by the local client.*/
    AgoraChatMessageStatisticsDirectionAll = 100, /**   The message is sent from or received by the local client.*/
};

/**
 *  
 *  The message body types for querying.
 */
typedef NS_ENUM(NSUInteger, AgoraChatMessageStatisticsType) {
    AgoraChatMessageStatisticsTypeText = 0, /**  A text message.*/
    AgoraChatMessageStatisticsTypeImage,  /**  An image message.*/
    AgoraChatMessageStatisticsTypeVideo,  /**  A video message.*/
    AgoraChatMessageStatisticsTypeLocation, /**  A location message.*/
    AgoraChatMessageStatisticsTypeVoice, /**  A voice message.*/
    AgoraChatMessageStatisticsTypeFile, /**  A file message.*/
    AgoraChatMessageStatisticsTypeCmd, /**  A command message.*/
    AgoraChatMessageStatisticsTypeCustom, /**  A custom message.*/
    AgoraChatMessageStatisticsTypeAll = 100, /**  All message types.*/
};


@class AgoraChatError;

/**
 *  
 * The protocol that defines statistical operations of message traffic.
 * 
 * This protocol contains methods that are used to calculate the number of local messages of certain types sent and/or received in a specified period, as well as their traffic.
 * 
 * This traffic statistics function is disabled by default. To use this function, you need to enable it by setting {@link AgoraChatOptions#enableStatistics} prior to the SDK initialization. The SDK can collect statistics of messages that are sent and received after this function is enabled.
 *  
 * The SDK only calculates the traffic of messages that are sent and received within the last 30 days after the traffic statistics function is enabled. 
 * 
 *  The message traffic is calculated as follows:
 *  - For a text, command, location or custom message, the message traffic is the traffic of the message body.
 *  - For an image or video message, the message traffic is the traffic sum of the message body, the image or video file, and the thumbnail.
 *  - For a file or voice message, the message traffic is the traffic sum of the message body and the attachment.
 * 
 * @note
 * 1. For messages with attachments, the traffic will be calculated only if the download is successful.
 *    If an attachment is downloaded multiple times, its download traffic will be accumulated.
 * 2. For roaming messages pulled from the server, if they already exist in the local database, the SDK ignores them during traffic calculation.
 * 
 * The SDK only measures the traffic of local messages, but not the actual message traffic. Generally, the calculated traffic volume is smaller than the actual traffic because of the following:
 *   - The traffic of the common protocol data generated during message sending is not considered;
 *   - For the received messages, the server aggregates them and adds common fields. During traffic statistics, the SDK only calculates the traffic of individual messages, but ignoring the traffic of common fields. 
 * 
 */
@protocol IAgoraChatStatisticsManager <NSObject>

@required


/**
 *  
 *  Gets the message traffic statistics by message ID.
 * 
 *  @param messageId The message ID.
 *  @return The message traffic statistics. 
 */
- (AgoraChatMessageStatistics* _Nullable)getMessageStatisticsById:(NSString* _Nonnull)messageId;

/**
 *  
 *  Gets the count of messages of certain types that are sent and/or received in a specified period.
 * 
 *  @param startTimestamp  The starting timestamp for statistics. The unit is millisecond.
 *  @param endTimestamp The ending timestamp for statistics. The unit is millisecond.
 *  @param direction  The message direction.
 *  @param type  The message type.
 *  @return The count of messages that meet the statistical conditions. `0` is returned in the case of a call failure.
 */
- (NSInteger)getMessageCountWithStart:(NSInteger)startTimestamp
                                  end:(NSInteger)endTimestamp
                            direction:(AgoraChatMessageStatisticsDirection)direction
                                 type:(AgoraChatMessageStatisticsType)type;


/**
 *  
 *  Gets the total traffic amount of messages that meet the statistical conditions.
 * 
 *  The traffic is measured in bytes.
 * 
 *  @param startTimestamp  The starting timestamp for statistics. The unit is millisecond.
 *  @param endTimestamp The ending timestamp for statistics. The unit is millisecond.
 *  @param direction  The message direction.
 *  @param type  The message type.
 *  @return The total traffic amount of messages that meet the statistical conditions. `0` is returned in the case of a call failure.
 */
- (NSInteger)getMessageStatisticsSizeWithStart:(NSInteger)startTimestamp
                                           end:(NSInteger)endTimestamp
                                     direction:(AgoraChatMessageStatisticsDirection)direction
                                          type:(AgoraChatMessageStatisticsType)type;

@end
