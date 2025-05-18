/**
 *  
 *  @header AgoraChatClientDelegate.h
 *  @abstract The protocol provides callbacks related to account login status
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>
#import "AgoraChatErrorCode.h"
#import "AgoraChatCommonDefs.h"
#import "AgoraChatLoginExtensionInfo.h"

/**
 *   
 *  The connection state.
 */
typedef NS_ENUM(NSInteger, AgoraChatConnectionState) {
    AgoraChatConnectionConnected = 0,  /**
                                 *  The SDK is connected to the chat server.
                                 */
    AgoraChatConnectionDisconnected,   /**
                                 *  The SDK is disconnected from the chat server.
                                 */
};

@class AgoraChatError;

/**
 *   
 *  @abstract This protocol provides a number of utility classes callback
 */
@protocol AgoraChatClientDelegate <NSObject>

@optional

/**
 *  
 *  Occurs when the connection state between the SDK and the server changes.
 * 
 *  The SDK triggers this callback in any of the following situations:
 *   - After login, the device is disconnected from the internet.
 *   - After login, the network status changes.
 *
 *  @param aConnectionState  The current connection state.
 */
- (void)connectionStateDidChange:(AgoraChatConnectionState)aConnectionState;

/**
 *  
 *  Occurs when the auto login is completed.
 *
 *  @param aError Error   A description of the issue that caused this call to fail.
 */
- (void)autoLoginDidCompleteWithError:(AgoraChatError * _Nullable)aError;

/**
 *  
 *  Occurs when the current user account is logged in to another device.

 *  @param aDeviceName The name of the new login device.
 */
- (void)userAccountDidLoginFromOtherDevice:(NSString* _Nullable)aDeviceName EM_DEPRECATED_IOS(4_1_0, 4_7_0, "Use userAccountDidLoginFromOtherDeviceWithInfo: instead");


/**
 *  
 *  Occurs when the current user account is logged in to another device.

 *  @param info The device name and extended information of the login device ``AgoraChatLoginInfo``.
 */
- (void)userAccountDidLoginFromOtherDeviceWithInfo:(AgoraChatLoginExtensionInfo* _Nullable)info;

/**
 *  
 *  Occurs when the current chat user is removed from the server.
 */
- (void)userAccountDidRemoveFromServer;

/**
 *  
 *  The delegate method will be invoked when the User account is forbidden.
 */
- (void)userDidForbidByServer;

/**
 *  
 *  The delegate method will be invoked when current IM account is forced to logout with the following reasons:
 *    1. The password is modified;
 *    2. Logged in too many devices;
 *    3. User for forbidden;
 *    4. Forced offline.
 */
- (void)userAccountDidForcedToLogout:(AgoraChatError *_Nullable)aError;

/**
 *  
 *  token will expire (log in using agoraToken)
 */
- (void)tokenWillExpire:(AgoraChatErrorCode)aErrorCode;

/**
 *  
 *  token did expire (log in using agoraToken)
 */
- (void)tokenDidExpire:(AgoraChatErrorCode)aErrorCode;

/**
 *  
 *  Occurs when the SDK starts pulling offline messages from the server.
 */
- (void)onOfflineMessageSyncStart;

/**
 *  
 *  Occurs when the SDK finishes pulling offline messages from the server.
 */
- (void)onOfflineMessageSyncFinish;

#pragma mark - EM_DEPRECATED_IOS 4.1.0
/**
 *  
 *  Occurs when the current user account is logged in to another device.
 */
- (void)userAccountDidLoginFromOtherDevice EM_DEPRECATED_IOS(3_1_0, 4_1_0, "Use userAccountDidLoginFromOtherDevice: instead");

@end
