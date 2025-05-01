/**
 *  
 *  @header AgoraChatMessageBody.h
 *  @abstract Base class of message body
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>
#import <CoreGraphics/CGGeometry.h>

/**
 *  
 *  The enum of message body types.
 */
typedef NS_ENUM(NSInteger, AgoraChatMessageBodyType) {
    AgoraChatMessageBodyTypeText   = 1,    /**  A text message.*/
    AgoraChatMessageBodyTypeImage,         /**  An image message.*/
    AgoraChatMessageBodyTypeVideo,         /**  A video message.*/
    AgoraChatMessageBodyTypeLocation,      /**  A location message.*/
    AgoraChatMessageBodyTypeVoice,         /**  A voice message.*/
    AgoraChatMessageBodyTypeFile,          /**  A file message.*/
    AgoraChatMessageBodyTypeCmd,           /**  A command message.*/
    AgoraChatMessageBodyTypeCustom,        /**  A custom message.*/
    AgoraChatMessageBodyTypeCombine,       /**  A combine message.*/
};

/**
 *  
 *  The message body.
 */
@interface AgoraChatMessageBody : NSObject

/**
 *  
 *  The message body type.
 */
@property (nonatomic, readonly) AgoraChatMessageBodyType type;
/**
 *  
 *  Get the UNIX timestamp of the last message modification, in milliseconds.
 */
@property (nonatomic, assign,readonly) NSUInteger operationTime;
/**
 *  
 *  Get the user ID of the operator that modified the message last time.
 */
@property (nonatomic,nullable,readonly) NSString *operatorId;
/**
 *  
 *  Get the number of times a message is modified.
 */
@property (nonatomic, assign,readonly) NSUInteger operatorCount;

@end
