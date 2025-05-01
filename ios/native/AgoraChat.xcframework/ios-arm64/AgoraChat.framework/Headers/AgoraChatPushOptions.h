/**
 *  
 *  @header AgoraChatPushOptions.h
 *  @abstract The setting options of Apple Push Notification.
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>
#import "AgoraChatCommonDefs.h"

#define kPushNickname @"nickname"
#define kPushDisplayStyle @"notification_display_style"
#define kPushNoDisturbing @"notification_no_disturbing"
#define kPushNoDisturbingStartH @"notification_no_disturbing_start"
#define kPushNoDisturbingStartM @"notification_no_disturbing_startM"
#define kPushNoDisturbingEndH @"notification_no_disturbing_end"
#define kPushNoDisturbingEndM @"notification_no_disturbing_endM"

/**
 *   
 *  The display style of push message.
 */
typedef NS_ENUM(NSInteger, AgoraChatPushDisplayStyle) {
    AgoraChatPushDisplayStyleSimpleBanner = 0, /**
                                         *  
                                         *  A simple banner that displays "You have a new message".
                                         */
    AgoraChatPushDisplayStyleMessageSummary,   /**
                                         *   
                                         *  Displays the message's content.
                                         */
};

/**
 *   
 *  The options for Apple Push Notification service (APNs).
 */
@interface AgoraChatPushOptions : NSObject

/**
 *   
 *  The user's nickname to be displayed in the notification.
 */
@property (nonatomic, strong, readonly) NSString * _Nullable displayName;

/**
 *   
 *  The display style of the notification.
 */
@property (nonatomic, readonly) AgoraChatPushDisplayStyle displayStyle;


/**
 *   
 *  The no-disturbing mode start time (in hour).
 *  Deprecated. Please use AgoraChatSilentModeResult property silentModeStartTime instead.
 */
@property (nonatomic, readonly) NSInteger silentModeStart
EM_DEPRECATED_IOS(3_8_8, 3_9_1, "Use AgoraChatSilentModeResult property silentModeStartTime instead");

/**
 *   
 *  The no-disturbing mode end time (in hour).
 *  Deprecated. Please use AgoraChatSilentModeResult property silentModeEndTime instead.
 */
@property (nonatomic, readonly) NSInteger silentModeEnd
EM_DEPRECATED_IOS(3_8_8, 3_9_1, "Use AgoraChatSilentModeResult property silentModeEndTime instead");

/**
 *  
 *  Whether to enable the Do Not Disturb mode. expireTimestamp
 *  Deprecated. Please use AgoraChatSilentModeResult property expireTimestamp and silentModeTime determine whether to enable
 */

@property (nonatomic, readonly) BOOL silentModeEnabled
EM_DEPRECATED_IOS(3_8_8, 3_9_1, "Use AgoraChatSilentModeResult property expireTimestamp and silentModeTime determine whether to enable");


#pragma mark - EM_DEPRECATED_IOS 3.8.8
/**
 *  
 *  No disturbing mode start time (in hour)
 */
@property (nonatomic, readonly) NSInteger noDisturbingStartH
__deprecated_msg("Use silentModeStart instead");

/**
 *  
 *  No disturbing mode end time (in hour)
 */
@property (nonatomic, readonly) NSInteger noDisturbingEndH
__deprecated_msg("Use silentModeEnd instead");

/**
 *  
 *  Whether enable messages do not disturb
 */

@property (nonatomic, readonly) BOOL isNoDisturbEnable
__deprecated_msg("Use silentModeEnabled instead");




@end
