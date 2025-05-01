/**
 *  @header AgoraChatClient.h
 *  @abstract SDK Client
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>

#import "AgoraChatClientDelegate.h"
#import "AgoraChatError.h"
#import "AgoraChatMultiDevicesDelegate.h"
#import "AgoraChatOptions.h"
#import "AgoraChatPushOptions.h"

#import "IAgoraChatManager.h"
#import "IAgoraChatroomManager.h"
#import "IAgoraChatContactManager.h"
#import "IAgoraChatGroupManager.h"
#import "IAgoraChatThreadManager.h"
#import "IAgoraChatPushManager.h"
#import "IAgoraChatUserInfoManager.h"
#import "IAgoraChatTranslateManager.h"
#import "IAgoraChatPresenceManager.h"
#import "IAgoraChatStatisticsManager.h"

#import "AgoraChatDeviceConfig.h"
#import "AgoraChatLocalNotificationManager.h"
#import "AgoraChatTranslationResult.h"
#import "AgoraChatLogDelegate.h"

/**
 *  
 *  This enum lists the server diagnostic tests which are run for the current user when you call AgoraChatClient::serviceCheckWithUsername.
 * 
 *  This is an asynchronous method. 
 * 
 * If there is an error, check the error code for the error information.
 */
typedef NS_ENUM(NSInteger, AgoraChatServerCheckType) {
  AgoraChatServerCheckAccountValidation = 0, /**  The check of the account validity. */
  AgoraChatServerCheckGetDNSListFromServer,  /**  The check for DNS list retrieval from the server. */
  AgoraChatServerCheckGetTokenFromServer,    /**  The check for token retrieval from the server. */
  AgoraChatServerCheckDoLogin,               /**  The login check. */
  AgoraChatServerCheckDoLogout,              /**  The logout check. */
};

/**
 * 
 *  This class is the entry of the Chat SDK, which is responsible for management of modules like login, logout, and connection. 
 * 
 * With this class, you can access other modules such as group [AgoraChatClient sharedClient].groupManager.
 *
 */
@interface AgoraChatClient : NSObject
{
  AgoraChatPushOptions *_pushOptions;
}

/**
 *  
 *  The SDK version number.
 */
@property(nonatomic, strong, readonly) NSString * _Nonnull version;

/**
 *  
 *  The ID of the user currently logged in to your chat app.
 */
@property(nonatomic, strong, readonly) NSString * _Nullable currentUsername;

/**
 *  
 *  The SDK setting options. For example, whether to use HTTPs by default.
 */
@property(nonatomic, strong, readonly) AgoraChatOptions * _Nonnull options;

/**
 *  
 *  The chat manager module.
 */
@property(nonatomic, strong, readonly) id<IAgoraChatManager> _Nullable chatManager;

/**
 *  
 *  The contact manager module.
 */
@property(nonatomic, strong, readonly) id<IAgoraChatContactManager> _Nullable contactManager;

/**
 *  
 *  The group manager module.
 */
@property(nonatomic, strong, readonly) id<IAgoraChatGroupManager> _Nullable groupManager;

/**
 *  
 *  The thread manager module.
 */
@property (nonatomic, strong, readonly) id<IAgoraChatThreadManager> _Nullable threadManager;

/*!
 *  
 *  The chat room manager module.
 */
@property(nonatomic, strong, readonly) id<IAgoraChatroomManager> _Nullable roomManager;

/**
 *  
 *   The push manager module.
 */
@property (nonatomic, strong, readonly) id<IAgoraChatPushManager> _Nullable pushManager;

/**
 *  
 *  Whether to allow a user to automatically log in to the chat server with the user ID used last time.
 * 
 * - `YES`：Yes.
 * - `NO`：No.
 * 
 *  If the login fails, for example, because of an incorrect password or a deactivated user account, this parameter will be reset to `NO`. In this case, you need to set it back to `YES` to allow automatic login.
 * 
 */
@property(nonatomic, readonly) BOOL isAutoLogin;

/**
 *  
 * 
 * Whether the current user is already logged in to the chat server.
 *  
 * - `YES`：The current user is already logged in.
 * - `NO`：The current user is not logged in.
 */
@property(nonatomic, readonly) BOOL isLoggedIn;

/**
 *  
 *  Whether the SDK is connected to the chat server.
 * 
 * - `YES`：Yes.
 * - `NO`：No.
 */
@property(nonatomic, readonly) BOOL isConnected;

/**
 *  
 *  The token used by the current user to access the chat server.
 * 
 * The user needs to use the user ID and password for the first login. If the login succeeds, a token is returned and the user can use it for subsequent logins.
 */
@property(nonatomic, readonly) NSString * _Nullable accessUserToken;

/**
 *  
 *  The user attribute manager module.
 */
@property(nonatomic, strong, readonly) id<IAgoraChatUserInfoManager> _Nullable userInfoManager;

/**
 *  
 *  The presence manager module.
 */
@property (nonatomic, strong, readonly) id<IAgoraChatPresenceManager> _Nullable presenceManager;

/**
 *  
 *  The message statistics manager module.
 */
@property (nonatomic, strong, readonly) id<IAgoraChatStatisticsManager> _Nullable statisticsManager;

-(instancetype _Nonnull ) init __attribute__((unavailable("call sharedClient instead")));
-(instancetype _Nonnull ) copy __attribute__((unavailable("call sharedClient instead")));
-(instancetype _Nonnull ) mutableCopy __attribute__((unavailable("call sharedClient instead")));
/**
 *  
 *  Creates a Client instance. The Client class is the entry to the Chat SDK. You need to call this method to create a Client instance before calling any other methods.
 */
+ (instancetype _Nonnull )sharedClient;


/**
 *  
 *  The SDK version number.
 */
- (NSString *)version;

#pragma mark - Delegate  

/**
 *  
 *  Adds a delegate. 
 *
 *  @param aDelegate  The delegate that you want to add.
 *  @param aQueue     (optional) The queue of calling delegate methods. If you want to run the app on the main thread, set this parameter as `nil`. */
- (void)addDelegate:(id<AgoraChatClientDelegate>_Nonnull)aDelegate
      delegateQueue:(dispatch_queue_t _Nullable )aQueue;

/**
 *  
 *  Removes a delegate.
 *
 *  @param aDelegate  The delegate that you want to remove.
 */
- (void)removeDelegate:(id _Nonnull )aDelegate;

/**
 *  
 *  Adds the multi-device delegate.
 *
 *  @param aDelegate  The delegate that you want to add. 
 *  @param aQueue     The queue of calling delegate methods.
 */
- (void)addMultiDevicesDelegate:(id<AgoraChatMultiDevicesDelegate>_Nonnull)aDelegate
                  delegateQueue:(dispatch_queue_t _Nullable )aQueue NS_SWIFT_NAME(addMultiDevices(delegate:queue:));

/**
 *  
 *  Removes the multi-device delegate.
 *
 *  @param aDelegate  The multi-device delegate that you want to delete.
 */
- (void)removeMultiDevicesDelegate:(id<AgoraChatMultiDevicesDelegate>_Nonnull)aDelegate;

#pragma mark - Initialize SDK

/**
 *  
 *  Initializes the SDK.
 *
 *  @param aOptions   The SDK options.
 *
 *  @Result A description of the issue that caused this call to fail.
 */
- (AgoraChatError *_Nullable)initializeSDKWithOptions:(AgoraChatOptions * _Nonnull )aOptions;

#pragma mark - Change AppKey

/**
 *  
 *  Updates the the App Key, the unique identifier used to access the chat server.
 *
 * You can only update the App Key when you are logged out. 
 *
 *  @param aAppkey  The new App Key. 
 *
 *  @Result A description of the issue that caused this call to fail.
 */
- (AgoraChatError *_Nullable)changeAppkey:(NSString * _Nonnull)aAppkey;

#pragma mark - User Registration 
/**
 *  
 *  Registers a new user.
 *
 *  This method is not recommended and you are advised to call the RESTful API to register a new user.
 * 
 *
 *  After you call `initializeSDKWithOptions` and register your app in the console, the app has access to all the features registered inside your chat network. You add and remove users inside your chat network; depending on how you implement your app, you control the people each user can see inside your network.
 *
 *  This is a synchronous method and blocks the current thread. To ensure the registration reliability, we recommend using the RESTful API to register new chat users.
 *
 *  @param aUsername  The user ID. The maximum length is 64 characters. Ensure that you set this parameter. Supported characters include the 26 English letters (a-z), the ten numbers (0-9), the underscore (_), the hyphen (-), and the English period (.). This parameter is case insensitive, and upper-case letters are automatically changed to low-case ones. If you want to set this parameter as a regular expression, set it as ^[a-zA-Z0-9_-]+$.
 *  @param aPassword   The password. The maximum length is 64 characters. Ensure that you set this parameter.
 *
 *  @result A description of the issue that caused this call to fail.
 */
- (AgoraChatError *_Nullable)registerWithUsername:(NSString * _Nonnull)aUsername
                                  password:(NSString * _Nonnull)aPassword;

/**
 *  
 *  Registers a new user.
 *
 *  This is an asynchronous method. This method is not recommended and you are advised to call the RESTful API to register a user.
 *
 *  To ensure registration reliability, we recommend using the RESTful API to register new chat users.
 *
 *  @param aUsername        The user ID. The maximum length is 64 characters. Ensure that you set this parameter. Supported characters include the 26 English letters (a-z), the ten numbers (0-9), the underscore (_), the hyphen (-), and the English period (.). This parameter is case insensitive, and upper-case letters are automatically changed to low-case ones. If you want to set this parameter as a regular expression, set it as ^[a-zA-Z0-9_-]+$.
 *  @param aPassword        The password. The maximum length is 64 characters. Ensure that you set this parameter.
 *  @param aCompletionBlock The completion block, which contains the username and the error message if the method fails.
 *
 */
- (void)registerWithUsername:(NSString *_Nonnull)aUsername
                    password:(NSString *_Nonnull)aPassword
                  completion:(void (^_Nullable)(NSString * _Nonnull aUsername, AgoraChatError * _Nullable aError))aCompletionBlock;

#pragma mark - Login

/**
 *  
 *  Fetches the token from the server.
 *
 *  This is an asynchronous method.
 *
 *  @param aUsername     The user ID.
 *  @param aPassword     The password.
 *  @param aCompletionBlock The completion block, which contains the token and the error message if the method fails.
 *
 */
- (void)fetchTokenWithUsername:(NSString *_Nonnull)aUsername
                      password:(NSString *_Nonnull)aPassword
                    completion:(void (^_Nullable)(NSString * _Nullable aToken, AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 *  
 *  Logs in to the chat server with a password.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  It is recommended that you log in to the chat service with a token.
 *
 *  @param aUsername  The user ID. The maximum length is 64 characters. Ensure that you set this parameter. Supported characters include the 26 English letters (a-z), the ten numbers (0-9), the underscore (_), the hyphen (-), and the English period (.). This parameter is case insensitive, and upper-case letters are automatically changed to low-case ones. If you want to set this parameter as a regular expression, set it as ^[a-zA-Z0-9_-]+$.
 *  @param aPassword  The password. The maximum length is 64 characters. Ensure that you set this parameter.
 *
 *  @result If the login succeeds, the SDK returns `nil`; otherwise, the SDK returns the description of the issue that causes the call to fail. 
 */
- (AgoraChatError *_Nullable)loginWithUsername:(NSString *_Nonnull)aUsername
                               password:(NSString *_Nonnull)aPassword EM_DEPRECATED_IOS(3_0_0, 4_5_0,"Use -AgoraChatClient loginWithUsername:token:completion instead");

/**
 *  
 *  Logs in to the chat server with a password.
 *
 *  This is an asynchronous method.
 *
 *  It is recommended that you log in to the chat service with a token.
 *
 *  @param aUsername        The user ID. The maximum length is 64 characters. Ensure that you set this parameter. Supported characters include the 26 English letters (a-z), the ten numbers (0-9), the underscore (_), the hyphen (-), and the English period (.). This parameter is case insensitive, and upper-case letters are automatically changed to low-case ones. If you want to set this parameter as a regular expression, set it as ^[a-zA-Z0-9_-]+$.
 *  @param aPassword        The password. The maximum length is 64 characters. Ensure that you set this parameter.
 *  @param aCompletionBlock The completion block, which contains the username and the error message if the method fails.
 *
 */
- (void)loginWithUsername:(NSString *_Nonnull)aUsername
                 password:(NSString *_Nonnull)aPassword
               completion:(void (^_Nullable)(NSString * _Nonnull aUsername, AgoraChatError *_Nullable aError))aCompletionBlock EM_DEPRECATED_IOS(3_0_0, 4_5_0,"Use -AgoraChatClient loginWithUsername:token:completion instead");

/**
 *  
 *  Logs in to the chat server with a token.
 * 
 *  This method does not support automatic login.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aUsername  The user ID. The maximum length is 64 characters. Ensure that you set this parameter. Supported characters include the 26 English letters (a-z), the ten numbers (0-9), the underscore (_), the hyphen (-), and the English period (.). This parameter is case insensitive, and upper-case letters are automatically changed to low-case ones. If you want to set this parameter as a regular expression, set it as ^[a-zA-Z0-9_-]+$.
 *  @param aToken     The token for login to the chat server.
 *
 *  @result If the login succeeds, the SDK returns `nil`; otherwise, the SDK returns the description of the issue that causes the call to fail. 
 */
- (AgoraChatError *_Nullable)loginWithUsername:(NSString *_Nonnull)aUsername
                                  token:(NSString *_Nonnull)aToken;

/**
 *  
 * Logs in to the chat server with a token.  
 * 
 * This is an asynchronous method. This method supports automatic login.
 *
 *  @param aUsername        The user ID. The maximum length is 64 characters. Ensure that you set this parameter. Supported characters include the 26 English letters (a-z), the ten numbers (0-9), the underscore (_), the hyphen (-), and the English period (.). This parameter is case insensitive, and upper-case letters are automatically changed to low-case ones. If you want to set this parameter as a regular expression, set it as ^[a-zA-Z0-9_-]+$.
 *  @param aToken           The token for login to the chat server.
 *  @param aCompletionBlock The completion block, which contains the user ID and the error message if the method fails.
 *
 */
- (void)loginWithUsername:(NSString *_Nonnull)aUsername
                    token:(NSString *_Nonnull)aToken
               completion:(void (^_Nullable)(NSString * _Nonnull aUsername, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Logs in to the chat server with an Agora Chat user token. 
 * 
 *  This is a synchronous method and blocks the current thread. This method supports automatic login.
 *
 *  @param aUsername    The user ID.
 *  @param aAgoraToken  The Agora Chat user token.
 *
 *  @result If the login succeeds, the SDK returns `nil`; otherwise, the SDK returns the description of the issue that causes the call to fail. 
 */
- (AgoraChatError *_Nullable)loginWithUsername:(NSString *_Nonnull)aUsername
                             agoraToken:(NSString *_Nonnull)aAgoraToken EM_DEPRECATED_IOS(3_8_9, 4_2_0,"Use -AgoraChatClient loginWithUsername:token instead");

/**
 *  
 *  Logs in to the chat server with Agora Chat user token. 
 * 
 *  This is an asynchronous method. It supports automatic login.
 *
 *
 *  @param aUsername        The user ID.
 *  @param aAgoraToken      The Agora Chat user token.
 *  @param aCompletionBlock The callback of completion block, which contains the description of the cause to the issue if the method fails.
 *
 */
- (void)loginWithUsername:(NSString *_Nonnull)aUsername
               agoraToken:(NSString *_Nonnull)aAgoraToken
               completion:(void (^_Nullable)(NSString * _Nonnull aUsername, AgoraChatError *_Nullable aError))aCompletionBlock EM_DEPRECATED_IOS(3_8_9, 4_2_0,"Use -AgoraChatClient loginWithUsername:token:completion instead");

/**
 *  
 *  Renews the user token when the current token expires.
 *
 *  If you are logged in with an Chat user token and you are notified via the ClientDelegate callback that the token is about to expire, you can call this method to renew the token to prevent unknown issues caused by an invalid token.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param newToken The new Chat token。
 *
 *  @result The result which contains the description of the cause to the failure if call fails.
 */
- (AgoraChatError *_Nullable)renewToken:(NSString *_Nonnull)newToken;

/**
 *  
 *  Renews the user token when the current token expires.
 *
 *  If you are logged in with an Chat user token and you are notified via the ClientDelegate callback that the token is about to expire, you can call this method to renew the token to prevent unknown issues caused by an invalid token.
 *
 *  This is an asynchronous method.
 *
 *  @param newToken The new Chat token。
 *
 *  @result The result which contains the description of the cause to the failure if call fails.
 */
- (void)renewToken:(NSString *_Nonnull)newToken completion:(void (^_Nullable)(AgoraChatError* _Nullable aError))aCompletionBlock;

#pragma mark - Logout

/**
 *  
 *  Logs out of the chat server.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aIsUnbindDeviceToken Whether to unbind the user ID from the device.
 *  - `Yes`：Yes. Once the user ID is unbound from the device, the user device stops receiving push notifications from the Apple Push Notifications service.
 *    If the unbinding fails, the SDK returns an error that includes the reason for the failure.
 *  - `NO`：No.
 *
 *  @result A description of the issue that caused this call to fail.
 */
- (AgoraChatError *_Nullable)logout:(BOOL)aIsUnbindDeviceToken;

/**
 *  
 *  Logs out of the chat server.
 *
 *  This is an asynchronous method.
 *
 *  @param aIsUnbindDeviceToken   Whether to unbind the user ID from the device.
 *  - `Yes`：Yes. Once the user ID is unbound from the device, the user device stops receiving push notifications from the Apple Push Notifications service.
 *    If the unbinding fails, the SDK returns an error that includes the reason for the failure.
 *  - `NO`：No.
 *  @param aCompletionBlock  The completion block, which contains the token and the error message if the method fails.
 *
 */
- (void)logout:(BOOL)aIsUnbindDeviceToken
    completion:(void (^_Nullable)(AgoraChatError * _Nullable aError))aCompletionBlock;

#pragma mark - PushKit

/**
 *  
 *  Uses the PushKit token to bind the user and the device, which is required to enable Apple PushKit Service. 
 * 
 *  The Apple PushKit service is used to implement VoIP push notifications.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aPushToken      The PushKit token to bind.
 *
 *  @result A description of the issue that caused this call to fail.
 */
- (AgoraChatError *_Nullable)bindPushKitToken:(NSData *_Nullable)aPushToken;

/**
 *  
 *  Registers a PushKit token.
 * 
 *  The Apple PushKit service is used to implement VoIP push notifications.
 *
 *  This is an asynchronous method.
 *
 *  @param aPushToken           The PushKit token to register.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)registerPushKitToken:(NSData *_Nullable)aPushToken
                  completion:(void (^_Nullable)(AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 *  
 *  Unbinds the Apple PushKit token from the device.
 * 
 *  This method plays the same role as the `unRegisterPushKitTokenWithCompletion` method.
 * 
 *  The Apple PushKit service is used to implement VoIP push notifications.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @result A description of the issue that caused this call to fail.
 */
- (AgoraChatError *_Nullable)unBindPushKitToken;

/**
 *  
 *  Unregisters the Apple PushKit token.
 * 
 *  This method plays the same role as the `unBindPushKitToken` method.
 * 
 *  This is an asynchronous method.
 * 
 *  The Apple PushKit service is used to implement VoIP push notifications.
 *
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)unRegisterPushKitTokenWithCompletion:(void (^_Nullable)(AgoraChatError * _Nullable aError))aCompletionBlock;

#pragma mark - APNs

/**
 *  
 *  Binds the device token.
 * 
 *  Device token binding is required to enable Apple Push Notification Service.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aDeviceToken  The device token to bind.
 *
 *  @Result If the binding succeeds, the SDK returns `nil`; otherwise, the SDK returns the description of the issue that causes the call to fail. 
 */
- (AgoraChatError *_Nullable)bindDeviceToken:(NSData *_Nonnull)aDeviceToken;

/**
 *  
 *  Registers the device token.
 * 
 *  Device token binding is required to enable Apple push notification service.
 * 
 *  This is an asynchronous method.
 *
 *  @param aDeviceToken         The device token to bind.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)registerForRemoteNotificationsWithDeviceToken:(NSData *_Nonnull)aDeviceToken
                                           completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Registers the device token.
 *
 *  Device token binding is required to enable Apple push notification service.
 *
 *  This is an asynchronous method.
 *
 *  @param aCertName               The certification name to bind.
 *  @param aDeviceToken         The device token to bind.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 */
- (void)registerForRemoteNotificationsWithCertName:(NSString *_Nonnull)aCertName
                                       deviceToken:(NSData *_Nonnull)aDeviceToken
                                        completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Binds the FCM token, call this API when integrated FCM Notification
 *
 *  This is an asynchronous method.
 *
 *  @param aFCMToken  The device token generated by FCM SDK.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 *  @Result If the binding succeeds, the SDK returns `nil`; otherwise, the SDK returns the description of the issue that causes the call to fail.
 */
- (void)bindFCMToken:(NSString* _Nonnull)aFCMToken
          completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

#pragma mark - Log

/**
 *  
 *  Uploads the log to the chat server.
 * 
 *  The information in the debug log is used by our engineers to fix errors and improve system performance.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @result If the upload succeeds, the SDK returns `nil`; otherwise, the SDK returns the description of the issue that causes the call to fail. 
 */
- (AgoraChatError *_Nullable)uploadLogToServer;

/**
 *  
 *  Uploads the debug log to the chat server.
 *
 *  @param aCompletionBlock     The completion block, which contains the token and the error message if the method fails.
 */
- (void)uploadDebugLogToServerWithCompletion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Compresses the debug logs into a gzip archive (.gz).
 * 
 *  You are strongly advised to delete this debug archive once it is no longer used.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param pError  A description of the issue that caused this call to fail.
 *
 *  @result NSString The full file path of the debug archive.
 */
- (NSString *_Nullable)getLogFilesPath:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Compresses the debug logs into a gzip archive (.gz).
 * 
 *  You are strongly advised to delete this debug archive once it is no longer used.
 *
 *  This is an asynchronous method.
 *
 *  @param aCompletionBlock     The completion block, which contains the token and the error message if the method fails.
 */
- (void)getLogFilesPathWithCompletion:(void (^_Nullable)(NSString *_Nullable aPath, AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 *  
 *  Outputs logs to a log file. 
 * 
 *  You can call this method after the SDK is initialized.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aLog The log information to output.
 */
- (void)log:(NSString *_Nonnull)aLog;

/**
 *  
 *  Adds the log callback delegate.
 *
 *  @param aDelegate  The delegate that you want to add.
 *  @param aQueue     The queue of calling delegate methods.
 */
- (void)addLogDelegate:(id<AgoraChatLogDelegate>_Nonnull)aDelegate
         delegateQueue:(dispatch_queue_t _Nullable )aQueue NS_SWIFT_NAME(addLog(delegate:queue:));

/**
 *  
 *  Removes the log callback delegate.
 *
 *  @param aDelegate  The log callback delegate that you want to delete.
 */
- (void)removeLogDelegate:(id<AgoraChatLogDelegate>_Nonnull)aDelegate NS_SWIFT_NAME(removeLog(delegate:));

#pragma mark - Multi Devices

/**
 *  
 *  Retrieves all devices a specified user is currently logged in to.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aUsername      The user ID used by the user to log in to the devices.
 *  @param aPassword      The password.
 *  @param pError         A description of the issue that caused this call to fail.
 *
 *  @result  The information of the login devices, an array of <AgoraChatDeviceConfig> objects.
 */
- (NSArray<AgoraChatDeviceConfig*> *_Nullable)getLoggedInDevicesFromServerWithUsername:(NSString * _Nonnull)aUsername
                                                                       password:(NSString * _Nonnull)aPassword
                                                                          error:(AgoraChatError ** _Nullable)pError;

/**
 *  
 *  Gets information of all login devices from the server. 
 *
 *  This is an asynchronous method.
 *
 *  @param aUsername     The user ID.
 *  @param aPassword     The password.
 *  @param aCompletionBlock     The completion block, which contains the list and the error message if the method fails.
 *
 */
- (void)getLoggedInDevicesFromServerWithUsername:(NSString *_Nonnull)aUsername
                                        password:(NSString *_Nonnull)aPassword
                                      completion:(void (^_Nullable)(NSArray<AgoraChatDeviceConfig*> * _Nullable aList, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets information of all login devices <AgoraChatDeviceConfig> from the server. 
 *
 *  This is an asynchronous method.
 *
 *  @param aUserID     The user ID.
 *  @param aToken        The token.
 *  @param aCompletionBlock     The completion block, which contains the list and the error message if the method fails.
 *
 */
- (void)getLoggedInDevicesFromServerWithUserId:(NSString *_Nonnull)aUserID
                                         token:(NSString *_Nonnull)aToken
                                    completion:(void (^_Nullable)(NSArray<AgoraChatDeviceConfig*> * _Nullable aList, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Kicks a user out of the app on a specific device.
 *
 *  This is a synchronous method and blocks the current thread.
 * 
 *  You can call `getLoggedInDevicesFromServerWithUsername` to retrieve the list of devices that a user is currently logged in to.
 *
 *  @param aUsername     The user ID of the user to be kicked out of the app.
 *  @param aPassword     The password.
 *  @param aResource     The device to log the user out from. 
 *
 *  @result If the user is successfully kicked out of the app, the SDK returns `nil`; otherwise, the SDK returns the description of the issue that causes the call to fail. 
 */
- (AgoraChatError *_Nullable)kickDeviceWithUsername:(NSString *_Nonnull)aUsername
                                    password:(NSString *_Nonnull)aPassword
                                    resource:(NSString *_Nonnull)aResource;


/**
 *  
 *  Kicks a user out of the app on a specific device.
 * 
 *  You can call `getLoggedInDevicesFromServerWithUsername` to retrieve the list of devices that a user is currently logged in to.
 *
 *  This is an asynchronous method.
 *
 *  @param aUsername     The user ID of the user to be kicked out of the app.
 *  @param aPassword     The password.
 *  @param aResource     The device to log `aUsername` out from. 
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 */
- (void)kickDeviceWithUsername:(NSString *_Nonnull)aUsername
                      password:(NSString *_Nonnull)aPassword
                      resource:(NSString *_Nonnull)aResource
                    completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Kicks a user out of the app on a specific device.
 *
 *  You can call `getLoggedInDevicesFromServerWithUserId` to retrieve the list of devices that a user is currently logged in to.
 *
 *  This is an asynchronous method.
 *
 *  @param aUserID     The user ID of the user to be kicked out of the app.
 *  @param aToken        The token.
 *  @param aResource     The device to log `aUsername` out from. Call `getLoggedInDevicesFromServerWithUserId` to retrieve the list of devices `aUsername` is currently logged into.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 */
- (void)kickDeviceWithUserId:(NSString *_Nonnull)aUserID
                       token:(NSString *_Nonnull)aToken
                    resource:(NSString *_Nonnull)aResource
                  completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Kicks a user out of the app on all devices.
 *
 *  This is an asynchronous method.
 *
 *  @param aUserID     The user ID.
 *  @param aToken            The token.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 */
- (void)kickAllDevicesWithUserId:(NSString *_Nonnull)aUserID
                           token:(NSString *_Nonnull)aToken
                      completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Kicks a user out of the app on all devices.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aUsername     The user ID of the user forced to log out of the app on all login devices.
 *  @param aPassword     The app login password of the user forced to log out of the app.
 *
 *  @result  Returns nil on success, and the description of the issue that cause the call to fail.
 */
- (AgoraChatError *_Nullable)kickAllDevicesWithUsername:(NSString *_Nonnull)aUsername
                                        password:(NSString *_Nonnull)aPassword;

/**
 *  
 *  Kicks a user out of the app on all devices.
 *
 *  This is an asynchronous method.
 *
 *  @param aUsername      The user ID of the user to be forced to log out of the app on all login devices.
 *  @param aPassword      The app login password of the user to be forced to log out of the app.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 */
- (void)kickAllDevicesWithUsername:(NSString *_Nonnull)aUsername
                          password:(NSString *_Nonnull)aPassword
                        completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets information of the current login device.
 *
 *  @result Information of the current login device.
 */
- (AgoraChatDeviceConfig *)getDeviceConfig:(AgoraChatError **)pError;

#pragma mark - iOS


/**
 *  
 *  Disconnects from the chat server when the app is switched to the background.
 * 
 *  This method is specific to the iOS platform.
 *
 *  @param aApplication  The current application instance.
 */
- (void)applicationDidEnterBackground:(id _Nonnull )aApplication;

/**
 *  
 *  Reconnects to the server when your app returns to the foreground.
 * 
 *  This method is specific to the iOS platform.
 *
 *  @param aApplication  The current application instance.
 */
- (void)applicationWillEnterForeground:(id _Nonnull )aApplication;

/**
 *  
 *  Occurs when the device receives an APNs notification when your app is running in the foreground.
 * 
 *  This event is specific to the iOS platform.
 *
 *  @param application  The current application instance.
 *  @param userInfo     The push content.
 */
- (void)application:(id _Nonnull)application didReceiveRemoteNotification:(NSDictionary * _Nullable)userInfo;

#pragma mark - Service Check

/**
 *  
 *  Runs the server diagnostic test for a specific user.  
 * 
 *  These tests are run in the order defined by AgoraChatServerCheckType.
 * 
 *  If the user is logged in, the login account is used by default.
 *
 *  This is an asynchronous method.
 *
 *  @param aUsername    The user ID.
 *  @param aPassword    The password.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 */
- (void)serviceCheckWithUsername:(NSString *_Nonnull)aUsername
                        password:(NSString *_Nonnull)aPassword
                      completion:(void (^_Nullable)(AgoraChatServerCheckType aType, AgoraChatError *_Nullable aError))aCompletionBlock __deprecated_msg("This method is deprecated");

@property (nonatomic, strong, readonly) id<IAgoraChatTranslateManager> _Nonnull translateManager EM_DEPRECATED_IOS(3_8_9, 3_9_5,"Use -IAgoraChatManager translateMessage: instead");
@end
