using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
//using AgoraChat; just to ressolving the issues, TODO: Check it later for native linking.
using CoreFoundation;
using CoreGraphics;
using Foundation;
using Microsoft.VisualBasic.CompilerServices;
using ObjCRuntime;
using UserNotifications;

namespace HotCoffee.AgoraChat.iOS
{   
	// @interface AgoraChatLoginExtensionInfo : NSObject
	[BaseType (typeof(NSObject), Name ="AgoraChatLoginExtensionInfo")]
	interface AgoraChatLoginExtensionInfo
	{
		// @property (copy, nonatomic) NSString * _Nonnull deviceName;
		[Export ("deviceName")]
		string DeviceName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull extensionInfo;
		[Export ("extensionInfo")]
		string ExtensionInfo { get; set; }
	}
    // @interface AgoraChatOptions : NSObject
	[BaseType (typeof(NSObject), Name = "AgoraChatOptions")] 
	interface AgoraChatOptions
	{
		// @property (readonly, copy, nonatomic) NSString * appkey;
		[Export ("appkey")]
		string Appkey { get; }

		// @property (assign, nonatomic) BOOL enableConsoleLog;
		[Export ("enableConsoleLog")]
		bool EnableConsoleLog { get; set; }

		// @property (assign, nonatomic) AgoraChatLogLevel logLevel;
		[Export ("logLevel", ArgumentSemantic.Assign)]
		AgoraChatLogLevel LogLevel { get; set; }

		// @property (assign, nonatomic) BOOL usingHttpsOnly;
		[Export ("usingHttpsOnly")]
		bool UsingHttpsOnly { get; set; }

		// @property (assign, nonatomic) BOOL isAutoLogin;
		[Export ("isAutoLogin")]
		bool IsAutoLogin { get; set; }

		// @property (assign, nonatomic) BOOL deleteMessagesOnLeaveGroup;
		[Export ("deleteMessagesOnLeaveGroup")]
		bool DeleteMessagesOnLeaveGroup { get; set; }

		// @property (assign, nonatomic) BOOL deleteMessagesOnLeaveChatroom;
		[Export ("deleteMessagesOnLeaveChatroom")]
		bool DeleteMessagesOnLeaveChatroom { get; set; }

		// @property (assign, nonatomic) BOOL canChatroomOwnerLeave;
		[Export ("canChatroomOwnerLeave")]
		bool CanChatroomOwnerLeave { get; set; }

		// @property (assign, nonatomic) BOOL autoAcceptGroupInvitation;
		[Export ("autoAcceptGroupInvitation")]
		bool AutoAcceptGroupInvitation { get; set; }

		// @property (assign, nonatomic) BOOL autoAcceptFriendInvitation;
		[Export ("autoAcceptFriendInvitation")]
		bool AutoAcceptFriendInvitation { get; set; }

		// @property (assign, nonatomic) BOOL autoDownloadThumbnail;
		[Export ("autoDownloadThumbnail")]
		bool AutoDownloadThumbnail { get; set; }

		// @property (assign, nonatomic) BOOL enableRequireReadAck;
		[Export ("enableRequireReadAck")]
		bool EnableRequireReadAck { get; set; }

		// @property (assign, nonatomic) BOOL enableDeliveryAck;
		[Export ("enableDeliveryAck")]
		bool EnableDeliveryAck { get; set; }

		// @property (assign, nonatomic) BOOL sortMessageByServerTime;
		[Export ("sortMessageByServerTime")]
		bool SortMessageByServerTime { get; set; }

		// @property (assign, nonatomic) BOOL isAutoTransferMessageAttachments;
		[Export ("isAutoTransferMessageAttachments")]
		bool IsAutoTransferMessageAttachments { get; set; }

		// @property (copy, nonatomic) NSString * apnsCertName;
		[Export ("apnsCertName")]
		string ApnsCertName { get; set; }

		// @property (copy, nonatomic) NSString * pushKitCertName;
		[Export ("pushKitCertName")]
		string PushKitCertName { get; set; }

		// @property (nonatomic) AreaCode area;
		[Export ("area", ArgumentSemantic.Assign)]
		AreaCode Area { get; set; }

		// @property (nonatomic) BOOL enableStatistics;
		[Export ("enableStatistics")]
		bool EnableStatistics { get; set; }

		// @property (nonatomic) BOOL loadEmptyConversations;
		[Export ("loadEmptyConversations")]
		bool LoadEmptyConversations { get; set; }

		// @property (nonatomic) NSInteger customOSType;
		[Export ("customOSType")]
		nint CustomOSType { get; set; }

		// @property (strong) NSString * customDeviceName;
		[Export ("customDeviceName", ArgumentSemantic.Strong)]
		string CustomDeviceName { get; set; }

		// @property (nonatomic) BOOL useReplacedMessageContents;
		[Export ("useReplacedMessageContents")]
		bool UseReplacedMessageContents { get; set; }

		// @property (nonatomic) BOOL includeSendMessageInMessageListener;
		[Export ("includeSendMessageInMessageListener")]
		bool IncludeSendMessageInMessageListener { get; set; }

		// @property (nonatomic) BOOL regardImportMessagesAsRead;
		[Export ("regardImportMessagesAsRead")]
		bool RegardImportMessagesAsRead { get; set; }

		// @property (nonatomic) BOOL autoLoadConversations;
		[Export ("autoLoadConversations")]
		bool AutoLoadConversations { get; set; }

		// @property (nonatomic) NSString * loginExtensionInfo;
		[Export ("loginExtensionInfo")]
		string LoginExtensionInfo { get; set; }

		// @property (nonatomic) BOOL workPathCopiable;
		[Export ("workPathCopiable")]
		bool WorkPathCopiable { get; set; }

		// +(instancetype _Nonnull)optionsWithAppkey:(NSString * _Nonnull)aAppkey;
		[Static]
		[Export ("optionsWithAppkey:")]
		AgoraChatOptions OptionsWithAppkey (string aAppkey);

		// @property (assign, nonatomic) BOOL isDeleteMessagesWhenExitGroup __attribute__((deprecated("Use deleteMessagesOnLeaveGroup instead")));
		[Export ("isDeleteMessagesWhenExitGroup")]
		bool IsDeleteMessagesWhenExitGroup { get; set; }

		// @property (assign, nonatomic) BOOL isDeleteMessagesWhenExitChatRoom __attribute__((deprecated("Use deleteMessagesOnLeaveChatroom instead")));
		[Export ("isDeleteMessagesWhenExitChatRoom")]
		bool IsDeleteMessagesWhenExitChatRoom { get; set; }

		// @property (assign, nonatomic) BOOL isChatroomOwnerLeaveAllowed __attribute__((deprecated("Use canChatroomOwnerLeave instead")));
		[Export ("isChatroomOwnerLeaveAllowed")]
		bool IsChatroomOwnerLeaveAllowed { get; set; }

		// @property (assign, nonatomic) BOOL isAutoAcceptGroupInvitation __attribute__((deprecated("Use autoAcceptGroupInvitation instead")));
		[Export ("isAutoAcceptGroupInvitation")]
		bool IsAutoAcceptGroupInvitation { get; set; }

		// @property (assign, nonatomic) BOOL isAutoAcceptFriendInvitation __attribute__((deprecated("Use autoAcceptFriendInvitation instead")));
		[Export ("isAutoAcceptFriendInvitation")]
		bool IsAutoAcceptFriendInvitation { get; set; }

		// @property (assign, nonatomic) BOOL isAutoDownloadThumbnail __attribute__((deprecated("Use autoDownloadThumbnail instead")));
		[Export ("isAutoDownloadThumbnail")]
		bool IsAutoDownloadThumbnail { get; set; }
	}
	// @protocol AgoraChatClientDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "AgoraChatClientDelegate")]
	interface AgoraChatClientDelegate
	{
		// @optional -(void)connectionStateDidChange:(AgoraChatConnectionState)aConnectionState;
		[Export ("connectionStateDidChange:")]
		void ConnectionStateDidChange (AgoraChatConnectionState aConnectionState);

		// @optional -(void)autoLoginDidCompleteWithError:(AgoraChatError * _Nullable)aError;
		[Export ("autoLoginDidCompleteWithError:")]
		void AutoLoginDidCompleteWithError ([NullAllowed] AgoraChatError aError);

		// @optional -(void)userAccountDidLoginFromOtherDevice:(NSString * _Nullable)aDeviceName __attribute__((deprecated("")));
		[Export ("userAccountDidLoginFromOtherDevice:")]
		void UserAccountDidLoginFromOtherDevice ([NullAllowed] string aDeviceName);

		// @optional -(void)userAccountDidLoginFromOtherDeviceWithInfo:(AgoraChatLoginExtensionInfo * _Nullable)info;
		[Export ("userAccountDidLoginFromOtherDeviceWithInfo:")]
		void UserAccountDidLoginFromOtherDeviceWithInfo ([NullAllowed] AgoraChatLoginExtensionInfo info);

		// @optional -(void)userAccountDidRemoveFromServer;
		[Export ("userAccountDidRemoveFromServer")]
		void UserAccountDidRemoveFromServer ();

		// @optional -(void)userDidForbidByServer;
		[Export ("userDidForbidByServer")]
		void UserDidForbidByServer ();

		// @optional -(void)userAccountDidForcedToLogout:(AgoraChatError * _Nullable)aError;
		[Export ("userAccountDidForcedToLogout:")]
		void UserAccountDidForcedToLogout ([NullAllowed] AgoraChatError aError);

		// @optional -(void)tokenWillExpire:(AgoraChatErrorCode)aErrorCode;
		[Export ("tokenWillExpire:")]
		void TokenWillExpire (AgoraChatErrorCode aErrorCode);

		// @optional -(void)tokenDidExpire:(AgoraChatErrorCode)aErrorCode;
		[Export ("tokenDidExpire:")]
		void TokenDidExpire (AgoraChatErrorCode aErrorCode);

		// @optional -(void)onOfflineMessageSyncStart;
		[Export ("onOfflineMessageSyncStart")]
		void OnOfflineMessageSyncStart ();

		// @optional -(void)onOfflineMessageSyncFinish;
		[Export ("onOfflineMessageSyncFinish")]
		void OnOfflineMessageSyncFinish ();

		// @optional -(void)userAccountDidLoginFromOtherDevice __attribute__((deprecated("")));
		[Export ("userAccountDidLoginFromOtherDevice")]
		void UserAccountDidLoginFromOtherDevice ();
	}
	// @interface AgoraChatError : NSObject
	[BaseType (typeof(NSObject),Name ="AgoraChatError")]
	interface AgoraChatError 
	{
		// @property (nonatomic) AgoraChatErrorCode code;
		[Export ("code", ArgumentSemantic.Assign)]
		AgoraChatErrorCode Code { get; set; }

		// @property (copy, nonatomic) NSString * errorDescription;
		[Export ("errorDescription")]
		string ErrorDescription { get; set; }

		// -(instancetype)initWithDescription:(NSString *)aDescription code:(AgoraChatErrorCode)aCode;
		//[Export ("initWithDescription:code:")]
		//NativeHandle Constructor (string aDescription, AgoraChatErrorCode aCode);

		// +(instancetype _Nonnull)errorWithDescription:(NSString * _Nullable)aDescription code:(AgoraChatErrorCode)aCode;
		[Static]
		[Export ("errorWithDescription:code:")]
		AgoraChatError ErrorWithDescription ([NullAllowed] string aDescription, AgoraChatErrorCode aCode);
	}
	
	// @interface AgoraChatClient : NSObject
	[BaseType (typeof(NSObject), Name = "AgoraChatClient")]
	//[DisableDefaultCtor]
	interface AgoraChatClient
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull version;
		[Export ("version", ArgumentSemantic.Strong)]
		string Version { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable currentUsername;
		[NullAllowed, Export ("currentUsername", ArgumentSemantic.Strong)]
		string CurrentUsername { get; }

		// @property (readonly, nonatomic, strong) AgoraChatOptions * _Nonnull options;
		[Export ("options", ArgumentSemantic.Strong)]
		AgoraChatOptions Options { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatManager> _Nullable chatManager;
		[NullAllowed, Export ("chatManager", ArgumentSemantic.Strong)]
		IAgoraChatManager ChatManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatContactManager> _Nullable contactManager;
		//[NullAllowed, Export ("contactManager", ArgumentSemantic.Strong)]
		//IAgoraChatContactManager ContactManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatGroupManager> _Nullable groupManager;
		//[NullAllowed, Export ("groupManager", ArgumentSemantic.Strong)]
		//IAgoraChatGroupManager GroupManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatThreadManager> _Nullable threadManager;
		//[NullAllowed, Export ("threadManager", ArgumentSemantic.Strong)]
		//IAgoraChatThreadManager ThreadManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatroomManager> _Nullable roomManager;
		//[NullAllowed, Export ("roomManager", ArgumentSemantic.Strong)]
		//IAgoraChatroomManager RoomManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatPushManager> _Nullable pushManager;
		//[NullAllowed, Export ("pushManager", ArgumentSemantic.Strong)]
		//IAgoraChatPushManager PushManager { get; }

		// @property (readonly, nonatomic) BOOL isAutoLogin;
		[Export ("isAutoLogin")]
		bool IsAutoLogin { get; }

		// @property (readonly, nonatomic) BOOL isLoggedIn;
		[Export ("isLoggedIn")]
		bool IsLoggedIn { get; }

		// @property (readonly, nonatomic) BOOL isConnected;
		[Export ("isConnected")]
		bool IsConnected { get; }

		// @property (readonly, nonatomic) NSString * _Nullable accessUserToken;
		[NullAllowed, Export ("accessUserToken")]
		string AccessUserToken { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatUserInfoManager> _Nullable userInfoManager;
		[NullAllowed, Export ("userInfoManager", ArgumentSemantic.Strong)]
		IAgoraChatUserInfoManager UserInfoManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatPresenceManager> _Nullable presenceManager;
		//[NullAllowed, Export ("presenceManager", ArgumentSemantic.Strong)]
		//IAgoraChatPresenceManager PresenceManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatStatisticsManager> _Nullable statisticsManager;
		//[NullAllowed, Export ("statisticsManager", ArgumentSemantic.Strong)]
		//IAgoraChatStatisticsManager StatisticsManager { get; }

		// +(instancetype _Nonnull)sharedClient;
		[Static]
		[Export ("sharedClient")]
		AgoraChatClient SharedClient ();

		// -(void)addDelegate:(id<AgoraChatClientDelegate> _Nonnull)aDelegate delegateQueue:(dispatch_queue_t _Nullable)aQueue;
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (AgoraChatClientDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// -(void)removeDelegate:(id _Nonnull)aDelegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (NSObject aDelegate);

		// -(void)addMultiDevicesDelegate:(id<AgoraChatMultiDevicesDelegate> _Nonnull)aDelegate delegateQueue:(dispatch_queue_t _Nullable)aQueue __attribute__((swift_name("addMultiDevices(delegate:queue:)")));
		//[Export ("addMultiDevicesDelegate:delegateQueue:")]
		//void AddMultiDevicesDelegate (AgoraChatMultiDevicesDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// -(void)removeMultiDevicesDelegate:(id<AgoraChatMultiDevicesDelegate> _Nonnull)aDelegate;
		//[Export ("removeMultiDevicesDelegate:")]
		//void RemoveMultiDevicesDelegate (AgoraChatMultiDevicesDelegate aDelegate);

		// -(AgoraChatError * _Nullable)initializeSDKWithOptions:(AgoraChatOptions * _Nonnull)aOptions;
		[Export ("initializeSDKWithOptions:")]
		[return: NullAllowed]
		AgoraChatError InitializeSDKWithOptions (AgoraChatOptions aOptions);

		// -(AgoraChatError * _Nullable)changeAppkey:(NSString * _Nonnull)aAppkey;
		[Export ("changeAppkey:")]
		[return: NullAllowed]
		AgoraChatError ChangeAppkey (string aAppkey);

		// -(AgoraChatError * _Nullable)registerWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword;
		[Export ("registerWithUsername:password:")]
		[return: NullAllowed]
		AgoraChatError RegisterWithUsername (string aUsername, string aPassword);

		// -(void)registerWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword completion:(void (^ _Nullable)(NSString * _Nonnull, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("registerWithUsername:password:completion:")]
		void RegisterWithUsername (string aUsername, string aPassword, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// -(void)fetchTokenWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("fetchTokenWithUsername:password:completion:")]
		void FetchTokenWithUsername (string aUsername, string aPassword, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)loginWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword __attribute__((deprecated("")));
		[Export ("loginWithUsername:password:")]
		[return: NullAllowed]
		AgoraChatError LoginWithUsername (string aUsername, string aPassword);

		// -(void)loginWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword completion:(void (^ _Nullable)(NSString * _Nonnull, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("")));
		[Export ("loginWithUsername:password:completion:")]
		void LoginWithUsername (string aUsername, string aPassword, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)loginWithUsername:(NSString * _Nonnull)aUsername token:(NSString * _Nonnull)aToken;
		[Export ("loginWithUsername:token:")]
		[return: NullAllowed]
		AgoraChatError LoginWithUsernameAndToken (string aUsername, string aToken);

		// -(void)loginWithUsername:(NSString * _Nonnull)aUsername token:(NSString * _Nonnull)aToken completion:(void (^ _Nullable)(NSString * _Nonnull, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("loginWithUsername:token:completion:")]
		void LoginWithUsernameAndToken (string aUsername, string aToken, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)loginWithUsername:(NSString * _Nonnull)aUsername agoraToken:(NSString * _Nonnull)aAgoraToken __attribute__((deprecated("")));
		[Export ("loginWithUsername:agoraToken:")]
		[return: NullAllowed]
		AgoraChatError LoginWithUsernameWithAgoraToken(string aUsername, string aAgoraToken);

		// -(void)loginWithUsername:(NSString * _Nonnull)aUsername agoraToken:(NSString * _Nonnull)aAgoraToken completion:(void (^ _Nullable)(NSString * _Nonnull, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("")));
		[Export ("loginWithUsername:agoraToken:completion:")]
		void LoginWithUsernameWithAgoraToken (string aUsername, string aAgoraToken, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)renewToken:(NSString * _Nonnull)newToken;
		[Export ("renewToken:")]
		[return: NullAllowed]
		AgoraChatError RenewToken (string newToken);

		// -(void)renewToken:(NSString * _Nonnull)newToken completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("renewToken:completion:")]
		void RenewToken (string newToken, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)logout:(BOOL)aIsUnbindDeviceToken;
		[Export ("logout:")]
		[return: NullAllowed]
		AgoraChatError Logout (bool aIsUnbindDeviceToken);

		// -(void)logout:(BOOL)aIsUnbindDeviceToken completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("logout:completion:")]
		void Logout (bool aIsUnbindDeviceToken, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)bindPushKitToken:(NSData * _Nullable)aPushToken;
		[Export ("bindPushKitToken:")]
		[return: NullAllowed]
		AgoraChatError BindPushKitToken ([NullAllowed] NSData aPushToken);

		// -(void)registerPushKitToken:(NSData * _Nullable)aPushToken completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("registerPushKitToken:completion:")]
		void RegisterPushKitToken ([NullAllowed] NSData aPushToken, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)unBindPushKitToken;
		[NullAllowed, Export ("unBindPushKitToken")]
		//[Verify (MethodToProperty)]
		AgoraChatError UnBindPushKitToken { get; }

		// -(void)unRegisterPushKitTokenWithCompletion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("unRegisterPushKitTokenWithCompletion:")]
		void UnRegisterPushKitTokenWithCompletion ([NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)bindDeviceToken:(NSData * _Nonnull)aDeviceToken;
		[Export ("bindDeviceToken:")]
		[return: NullAllowed]
		AgoraChatError BindDeviceToken (NSData aDeviceToken);

		// -(void)registerForRemoteNotificationsWithDeviceToken:(NSData * _Nonnull)aDeviceToken completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("registerForRemoteNotificationsWithDeviceToken:completion:")]
		void RegisterForRemoteNotificationsWithDeviceToken (NSData aDeviceToken, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(void)registerForRemoteNotificationsWithCertName:(NSString * _Nonnull)aCertName deviceToken:(NSData * _Nonnull)aDeviceToken completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("registerForRemoteNotificationsWithCertName:deviceToken:completion:")]
		void RegisterForRemoteNotificationsWithCertName (string aCertName, NSData aDeviceToken, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(void)bindFCMToken:(NSString * _Nonnull)aFCMToken completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("bindFCMToken:completion:")]
		void BindFCMToken (string aFCMToken, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)uploadLogToServer;
		[NullAllowed, Export ("uploadLogToServer")]
		//[Verify (MethodToProperty)]
		AgoraChatError UploadLogToServer { get; }

		// -(void)uploadDebugLogToServerWithCompletion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("uploadDebugLogToServerWithCompletion:")]
		void UploadDebugLogToServerWithCompletion ([NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(NSString * _Nullable)getLogFilesPath:(AgoraChatError ** _Nullable)pError;
		[Export ("getLogFilesPath:")]
		[return: NullAllowed]
		string GetLogFilesPath (out AgoraChatError pError);

		// -(void)getLogFilesPathWithCompletion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("getLogFilesPathWithCompletion:")]
		void GetLogFilesPathWithCompletion ([NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// -(void)log:(NSString * _Nonnull)aLog;
		[Export ("log:")]
		void Log (string aLog);

		// -(void)addLogDelegate:(id<AgoraChatLogDelegate> _Nonnull)aDelegate delegateQueue:(dispatch_queue_t _Nullable)aQueue __attribute__((swift_name("addLog(delegate:queue:)")));
		[Export ("addLogDelegate:delegateQueue:")]
		void AddLogDelegate (AgoraChatLogDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// -(void)removeLogDelegate:(id<AgoraChatLogDelegate> _Nonnull)aDelegate __attribute__((swift_name("removeLog(delegate:)")));
	    [Export ("removeLogDelegate:")]
	    void RemoveLogDelegate (AgoraChatLogDelegate aDelegate);

		// -(NSArray<AgoraChatDeviceConfig *> * _Nullable)getLoggedInDevicesFromServerWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword error:(AgoraChatError ** _Nullable)pError;
		//[Export ("getLoggedInDevicesFromServerWithUsername:password:error:")]
		//[return: NullAllowed]
		//AgoraChatDeviceConfig[] GetLoggedInDevicesFromServerWithUsername (string aUsername, string aPassword, out AgoraChatError pError);

		// -(void)getLoggedInDevicesFromServerWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword completion:(void (^ _Nullable)(NSArray<AgoraChatDeviceConfig *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		//[Export ("getLoggedInDevicesFromServerWithUsername:password:completion:")]
		//void GetLoggedInDevicesFromServerWithUsername (string aUsername, string aPassword, [NullAllowed] Action<NSArray<AgoraChatDeviceConfig>, AgoraChatError> aCompletionBlock);

		// -(void)getLoggedInDevicesFromServerWithUserId:(NSString * _Nonnull)aUserID token:(NSString * _Nonnull)aToken completion:(void (^ _Nullable)(NSArray<AgoraChatDeviceConfig *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		//[Export ("getLoggedInDevicesFromServerWithUserId:token:completion:")]
		//void GetLoggedInDevicesFromServerWithUserId (string aUserID, string aToken, [NullAllowed] Action<NSArray<AgoraChatDeviceConfig>, AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)kickDeviceWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword resource:(NSString * _Nonnull)aResource;
		[Export ("kickDeviceWithUsername:password:resource:")]
		[return: NullAllowed]
		AgoraChatError KickDeviceWithUsername (string aUsername, string aPassword, string aResource);

		// -(void)kickDeviceWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword resource:(NSString * _Nonnull)aResource completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("kickDeviceWithUsername:password:resource:completion:")]
		void KickDeviceWithUsername (string aUsername, string aPassword, string aResource, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(void)kickDeviceWithUserId:(NSString * _Nonnull)aUserID token:(NSString * _Nonnull)aToken resource:(NSString * _Nonnull)aResource completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("kickDeviceWithUserId:token:resource:completion:")]
		void KickDeviceWithUserId (string aUserID, string aToken, string aResource, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(void)kickAllDevicesWithUserId:(NSString * _Nonnull)aUserID token:(NSString * _Nonnull)aToken completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("kickAllDevicesWithUserId:token:completion:")]
		void KickAllDevicesWithUserId (string aUserID, string aToken, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)kickAllDevicesWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword;
		[Export ("kickAllDevicesWithUsername:password:")]
		[return: NullAllowed]
		AgoraChatError KickAllDevicesWithUsername (string aUsername, string aPassword);

		// -(void)kickAllDevicesWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("kickAllDevicesWithUsername:password:completion:")]
		void KickAllDevicesWithUsername (string aUsername, string aPassword, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(AgoraChatDeviceConfig *)getDeviceConfig:(AgoraChatError **)pError;
		//[Export ("getDeviceConfig:")]
		//AgoraChatDeviceConfig GetDeviceConfig (out AgoraChatError pError);

		// -(void)applicationDidEnterBackground:(id _Nonnull)aApplication;
		[Export ("applicationDidEnterBackground:")]
		void ApplicationDidEnterBackground (NSObject aApplication);

		// -(void)applicationWillEnterForeground:(id _Nonnull)aApplication;
		[Export ("applicationWillEnterForeground:")]
		void ApplicationWillEnterForeground (NSObject aApplication);

		// -(void)application:(id _Nonnull)application didReceiveRemoteNotification:(NSDictionary * _Nullable)userInfo;
		[Export ("application:didReceiveRemoteNotification:")]
		void Application (NSObject application, [NullAllowed] NSDictionary userInfo);

		// -(void)serviceCheckWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword completion:(void (^ _Nullable)(AgoraChatServerCheckType, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("This method is deprecated")));
		[Export ("serviceCheckWithUsername:password:completion:")]
		void ServiceCheckWithUsername (string aUsername, string aPassword, [NullAllowed] Action<AgoraChatServerCheckType, AgoraChatError> aCompletionBlock);

		// @property (readonly, nonatomic, strong) EM_DEPRECATED_IOS(3_8_9, 3_9_5,"Use -IAgoraChatManager translateMessage: instead") id<IAgoraChatTranslateManager> translateManager __attribute__((deprecated("")));
		//[Export ("translateManager", ArgumentSemantic.Strong)]
		//IAgoraChatTranslateManager TranslateManager { get; }
	}
	// @protocol IAgoraChatUserInfoManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/  [Model]
	[BaseType (typeof(NSObject), Name = "IAgoraChatUserInfoManager")]
	interface IAgoraChatUserInfoManager
	{
		// @required -(void)updateOwnUserInfo:(AgoraChatUserInfo * _Nonnull)aUserData completion:(void (^ _Nullable)(AgoraChatUserInfo * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateOwnUserInfo:completion:")]
		void UpdateOwnUserInfo (AgoraChatUserInfo aUserData, [NullAllowed] Action<AgoraChatUserInfo, AgoraChatError> aCompletionBlock);

		// @required -(void)updateOwnUserInfo:(NSString * _Nullable)aValue withType:(AgoraChatUserInfoType)aType completion:(void (^ _Nullable)(AgoraChatUserInfo * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateOwnUserInfo:withType:completion:")]
		void UpdateOwnUserInfo ([NullAllowed] string aValue, AgoraChatUserInfoType aType, [NullAllowed] Action<AgoraChatUserInfo, AgoraChatError> aCompletionBlock);

		// @required -(void)fetchUserInfoById:(NSArray<NSString *> * _Nonnull)aUserIds completion:(void (^ _Nullable)(NSDictionary<NSString *,AgoraChatUserInfo *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("fetchUserInfoById:completion:")]
		void FetchUserInfoById (string[] aUserIds, [NullAllowed] Action<NSDictionary<NSString, AgoraChatUserInfo>, AgoraChatError> aCompletionBlock);

		// @required -(void)fetchUserInfoById:(NSArray<NSString *> * _Nonnull)aUserIds type:(NSArray<NSNumber *> * _Nonnull)aType completion:(void (^ _Nullable)(NSDictionary<NSString *,AgoraChatUserInfo *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("fetchUserInfoById:type:completion:")]
		void FetchUserInfoById (string[] aUserIds, NSNumber[] aType, [NullAllowed] Action<NSDictionary<NSString, AgoraChatUserInfo>, AgoraChatError> aCompletionBlock);
	}
	// @interface AgoraChatUserInfo : NSObject <NSCopying>
	[BaseType (typeof(NSObject), Name = "AgoraChatUserInfo")]
	interface AgoraChatUserInfo : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nullable userId;
		[NullAllowed, Export ("userId")]
		string UserId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable nickname;
		[NullAllowed, Export ("nickname")]
		string Nickname { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable avatarUrl;
		[NullAllowed, Export ("avatarUrl")]
		string AvatarUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable mail;
		[NullAllowed, Export ("mail")]
		string Mail { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export ("phone")]
		string Phone { get; set; }

		// @property (nonatomic) NSInteger gender;
		[Export ("gender")]
		nint Gender { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable sign;
		[NullAllowed, Export ("sign")]
		string Sign { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable birth;
		[NullAllowed, Export ("birth")]
		string Birth { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ext;
		[NullAllowed, Export ("ext")]
		string Ext { get; set; }

		// @property (copy, nonatomic) NSString * nickName __attribute__((deprecated("Use nickname instead")));
		[Export ("nickName")]
		string NickName { get; set; }
	}
	
	// @protocol AgoraChatManagerDelegate <NSObject>
	//[Protocol, Model]
	[Protocol][Model]
	[BaseType (typeof(NSObject), Name = "AgoraChatManagerDelegate")]
	interface AgoraChatManagerDelegate
	{
		// @optional -(void)conversationListDidUpdate:(NSArray<AgoraChatConversation *> * _Nonnull)aConversationList;
		//[Export ("conversationListDidUpdate:")]
		//void ConversationListDidUpdate (AgoraChatConversation[] aConversationList);

		// @optional -(void)messagesDidReceive:(NSArray<AgoraChatMessage *> * _Nonnull)aMessages;
		[Export ("messagesDidReceive:")]
		void MessagesDidReceive (AgoraChatMessage[] aMessages);

		// @optional -(void)cmdMessagesDidReceive:(NSArray<AgoraChatMessage *> * _Nonnull)aCmdMessages;
		[Export ("cmdMessagesDidReceive:")]
		void CmdMessagesDidReceive (AgoraChatMessage[] aCmdMessages);

		// @optional -(void)messagesDidRead:(NSArray<AgoraChatMessage *> * _Nonnull)aMessages;
		[Export ("messagesDidRead:")]
		void MessagesDidRead (AgoraChatMessage[] aMessages);

		// @optional -(void)groupMessageDidRead:(AgoraChatMessage * _Nonnull)aMessage groupAcks:(NSArray<AgoraChatGroupMessageAck *> * _Nonnull)aGroupAcks;
		//[Export ("groupMessageDidRead:groupAcks:")]
		//void GroupMessageDidRead (AgoraChatMessage aMessage, AgoraChatGroupMessageAck[] aGroupAcks);

		// @optional -(void)groupMessageAckHasChanged;
		[Export ("groupMessageAckHasChanged")]
		void GroupMessageAckHasChanged ();

		// @optional -(void)onConversationRead:(NSString * _Nonnull)from to:(NSString * _Nonnull)to;
		[Export ("onConversationRead:to:")]
		void OnConversationRead (string from, string to);

		// @optional -(void)messagesDidDeliver:(NSArray<AgoraChatMessage *> * _Nonnull)aMessages;
		[Export ("messagesDidDeliver:")]
		void MessagesDidDeliver (AgoraChatMessage[] aMessages);

		// @optional -(void)messagesInfoDidRecall:(NSArray<AgoraChatRecallMessageInfo *> * _Nonnull)aRecallMessagesInfo;
		//[Export ("messagesInfoDidRecall:")]
		//void MessagesInfoDidRecall (AgoraChatRecallMessageInfo[] aRecallMessagesInfo);

		// @optional -(void)messageStatusDidChange:(AgoraChatMessage * _Nonnull)aMessage error:(AgoraChatError * _Nullable)aError;
		[Export ("messageStatusDidChange:error:")]
		void MessageStatusDidChange (AgoraChatMessage aMessage, [NullAllowed] AgoraChatError aError);

		// @optional -(void)messageAttachmentStatusDidChange:(AgoraChatMessage * _Nonnull)aMessage error:(AgoraChatError * _Nullable)aError;
		[Export ("messageAttachmentStatusDidChange:error:")]
		void MessageAttachmentStatusDidChange (AgoraChatMessage aMessage, [NullAllowed] AgoraChatError aError);

		// @optional -(void)onMessageContentChanged:(AgoraChatMessage * _Nonnull)message operatorId:(NSString * _Nonnull)operatorId operationTime:(NSUInteger)operationTime;
		[Export ("onMessageContentChanged:operatorId:operationTime:")]
		void OnMessageContentChanged (AgoraChatMessage message, string operatorId, nuint operationTime);

		// @optional -(void)onMessagePinChanged:(NSString * _Nonnull)messageId conversationId:(NSString * _Nonnull)conversationId operation:(AgoraChatMessagePinOperation)pinOperation pinInfo:(AgoraChatMessagePinInfo * _Nonnull)pinInfo;
		//[Export ("onMessagePinChanged:conversationId:operation:pinInfo:")]
		//void OnMessagePinChanged (string messageId, string conversationId, AgoraChatMessagePinOperation pinOperation, AgoraChatMessagePinInfo pinInfo);

		// @optional -(void)messagesDidRecall:(NSArray *)aMessages __attribute__((deprecated("Use -messagesInfoDidRecall: instead")));
		//[Export ("messagesDidRecall:")]
		//[Verify (StronglyTypedNSArray)]
		//void MessagesDidRecall (NSObject[] aMessages);

		// @optional -(void)messageReactionDidChange:(NSArray<AgoraChatMessageReactionChange *> * _Nonnull)changes;
		//[Export ("messageReactionDidChange:")]
		//void MessageReactionDidChange (AgoraChatMessageReactionChange[] changes);
	}
	// @interface AgoraChatMessage : NSObject
	[Protocol]
	[BaseType (typeof(NSObject), Name = "AgoraChatMessage")]
	interface AgoraChatMessage : INativeObject 
	{
		// @property (copy, nonatomic) NSString * _Nonnull messageId;
		[Export ("messageId")]
		string MessageId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull conversationId;
		[Export ("conversationId")]
		string ConversationId { get; set; }

		// @property (nonatomic) AgoraChatMessageDirection direction;
		[Export ("direction", ArgumentSemantic.Assign)]
		AgoraChatMessageDirection Direction { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull from;
		[Export ("from")]
		string From { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull to;
		[Export ("to")]
		string To { get; set; }

		// @property (nonatomic) long long timestamp;
		[Export ("timestamp")]
		long Timestamp { get; set; }

		// @property (nonatomic) long long localTime;
		[Export ("localTime")]
		long LocalTime { get; set; }

		// @property (nonatomic) AgoraChatType chatType;
		[Export ("chatType", ArgumentSemantic.Assign)]
		AgoraChatType ChatType { get; set; }

		// @property (nonatomic) AgoraChatMessageStatus status;
		[Export ("status", ArgumentSemantic.Assign)]
		AgoraChatMessageStatus Status { get; set; }

		// @property (readonly, nonatomic) BOOL onlineState;
		[Export ("onlineState")]
		bool OnlineState { get; }

		// @property (nonatomic) BOOL isReadAcked;
		[Export ("isReadAcked")]
		bool IsReadAcked { get; set; }

		// @property (nonatomic) BOOL isChatThreadMessage;
		[Export ("isChatThreadMessage")]
		bool IsChatThreadMessage { get; set; }

		// @property (nonatomic) BOOL isNeedGroupAck;
		[Export ("isNeedGroupAck")]
		bool IsNeedGroupAck { get; set; }

		// @property (readonly, nonatomic) int groupAckCount;
		[Export ("groupAckCount")]
		int GroupAckCount { get; }

		// @property (nonatomic) BOOL isDeliverAcked;
		[Export ("isDeliverAcked")]
		bool IsDeliverAcked { get; set; }

		// @property (nonatomic) BOOL isRead;
		[Export ("isRead")]
		bool IsRead { get; set; }

		// @property (nonatomic) BOOL isListened;
		[Export ("isListened")]
		bool IsListened { get; set; }

		// @property (nonatomic, strong) AgoraChatMessageBody * _Nonnull body;
		[Export ("body", ArgumentSemantic.Strong)]
		AgoraChatMessageBody Body { get; set; }

		// @property (readonly, nonatomic) NSArray<AgoraChatMessageReaction *> * _Nullable reactionList;
		//[NullAllowed, Export ("reactionList")]
		//AgoraChatMessageReaction[] ReactionList { get; }

		// -(AgoraChatMessageReaction * _Nullable)getReaction:(NSString * _Nonnull)reaction;
		//[Export ("getReaction:")]
		//[return: NullAllowed]
		//AgoraChatMessageReaction GetReaction (string reaction);

		// @property (copy, nonatomic) NSDictionary * _Nullable ext;
		[NullAllowed, Export ("ext", ArgumentSemantic.Copy)]
		NSDictionary Ext { get; set; }

		// @property (readonly) AgoraChatThread * _Nullable chatThread;
		[NullAllowed, Export ("chatThread")]
		AgoraChatThread ChatThread { get; }

		// @property (nonatomic) AgoraChatRoomMessagePriority priority;
		[Export ("priority", ArgumentSemantic.Assign)]
		AgoraChatRoomMessagePriority Priority { get; set; }

		// @property (readonly, nonatomic) BOOL broadcast;
		[Export ("broadcast")]
		bool Broadcast { get; }

		// @property (nonatomic) BOOL deliverOnlineOnly;
		[Export ("deliverOnlineOnly")]
		bool DeliverOnlineOnly { get; set; }

		// @property (nonatomic, strong) NSArray<NSString *> * _Nullable receiverList;
		[NullAllowed, Export ("receiverList", ArgumentSemantic.Strong)]
		string[] ReceiverList { get; set; }

		// @property (readonly, nonatomic) BOOL isContentReplaced;
		[Export ("isContentReplaced")]
		bool IsContentReplaced { get; }

		// @property (readonly, nonatomic) AgoraChatMessagePinInfo * _Nullable pinnedInfo;
		[NullAllowed, Export ("pinnedInfo")]
		AgoraChatMessagePinInfo PinnedInfo { get; }

		// -(instancetype _Nonnull)initWithConversationID:(NSString * _Nonnull)aConversationId from:(NSString * _Nonnull)aFrom to:(NSString * _Nonnull)aTo body:(AgoraChatMessageBody * _Nonnull)aBody ext:(NSDictionary * _Nullable)aExt;
		[Export ("initWithConversationID:from:to:body:ext:")]
	    NativeHandle Constructor (string aConversationId, string aFrom, string aTo, AgoraChatMessageBody aBody, [NullAllowed] NSDictionary aExt);

		// -(instancetype _Nonnull)initWithConversationID:(NSString * _Nonnull)aConversationId body:(AgoraChatMessageBody * _Nonnull)aBody ext:(NSDictionary * _Nullable)aExt;
		[Export ("initWithConversationID:body:ext:")]
		NativeHandle Constructor (string aConversationId, AgoraChatMessageBody aBody, [NullAllowed] NSDictionary aExt);
	}
	// @interface AgoraChatMessagePinInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatMessagePinInfo
	{
		// @property (nonatomic, strong) NSString * _Nonnull operatorId;
		[Export ("operatorId", ArgumentSemantic.Strong)]
		string OperatorId { get; set; }

		// @property (nonatomic) NSInteger pinTime;
		[Export ("pinTime")]
		nint PinTime { get; set; }
	}
	// @interface AgoraChatMessageReaction : NSObject
	[BaseType (typeof(NSObject), Name = "AgoraChatMessageReaction")]
	interface AgoraChatMessageReaction : INativeObject
	{
		// @property (readonly) NSString * _Nullable reaction;
		[NullAllowed, Export ("reaction")]
		string Reaction { get; }

		// @property (readonly) NSUInteger count;
		[Export ("count")]
		nuint Count { get; }

		// @property (readonly) BOOL isAddedBySelf;
		[Export ("isAddedBySelf")]
		bool IsAddedBySelf { get; }

		// @property (readonly) NSArray<NSString *> * _Nullable userList;
		[NullAllowed, Export ("userList")]
		string[] UserList { get; }
	}
	// @interface AgoraChatMessageBody : NSObject
	[BaseType (typeof(NSObject), Name = "AgoraChatMessageBody")]
	interface AgoraChatMessageBody
	{
		// @property (readonly, nonatomic) AgoraChatMessageBodyType type;
		[Export ("type")]
		AgoraChatMessageBodyType Type { get; }

		// @property (readonly, assign, nonatomic) NSUInteger operationTime;
		[Export ("operationTime")]
		nuint OperationTime { get; }

		// @property (readonly, nonatomic) NSString * _Nullable operatorId;
		[NullAllowed, Export ("operatorId")]
		string OperatorId { get; }

		// @property (readonly, assign, nonatomic) NSUInteger operatorCount;
		[Export ("operatorCount")]
		nuint OperatorCount { get; }
	}
	// @interface AgoraChatThread : NSObject
	[BaseType (typeof(NSObject), Name = "AgoraChatThread")]
	interface AgoraChatThread
	{
		// @property (readonly) NSString * threadId;
		[Export ("threadId")]
		string ThreadId { get; }

		// @property (nonatomic, strong) NSString * threadName;
		[Export ("threadName", ArgumentSemantic.Strong)]
		string ThreadName { get; set; }

		// @property (readonly) NSString * owner;
		[Export ("owner")]
		string Owner { get; }

		// @property (readonly) NSString * messageId;
		[Export ("messageId")]
		string MessageId { get; }

		// @property (readonly) NSString * parentId;
		[Export ("parentId")]
		string ParentId { get; }

		// @property (readonly) int membersCount;
		[Export ("membersCount")]
		int MembersCount { get; }

		// @property (readonly) int messageCount;
		[Export ("messageCount")]
		int MessageCount { get; }

		// @property (readonly) NSInteger createAt;
		[Export ("createAt")]
		nint CreateAt { get; }

		// @property (readonly) AgoraChatMessage * lastMessage;
		[Export ("lastMessage")]
		AgoraChatMessage LastMessage { get; }
	}
	// @protocol IAgoraChatManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/ // [Protocol]
	
  //  [Model, Protocol]
    
   // [Protocol(),Model]
   
   
   
    [Protocol]
   // [Model()][Protocol (Name = "AgoraChatManager")]
	[BaseType (typeof(NSObject))]
	//[Export ("chatManager", ArgumentSemantic.Strong)]
	interface IAgoraChatManager
	{   
		// -(instancetype _Nonnull)init:();
	//	[Export ("init")]
	//	NativeHandle Constructor ();

		// @required -(void)addDelegate:(id<AgoraChatManagerDelegate> _Nullable)aDelegate delegateQueue:(dispatch_queue_t _Nullable)aQueue;
		//[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate ([NullAllowed] AgoraChatManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);
	
		// @required -(void)removeDelegate:(id<AgoraChatManagerDelegate> _Nonnull)aDelegate;
		//[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (AgoraChatManagerDelegate aDelegate);
		
		// @required -(NSArray<AgoraChatConversation *> * _Nullable)getAllConversations;
		[Abstract]
		[NullAllowed, Export ("getAllConversations")]
		//[Verify (MethodToProperty)]
		AgoraChatConversation[] AllConversations { get; }
		
		//3 // @required -(NSArray<AgoraChatConversation *> * _Nullable)filterConversationsFromDB:(BOOL)cleanMemoryCache filter:(BOOL (^ _Nullable)(AgoraChatConversation * _Nonnull))filter __attribute__((swift_name("filterConversationsFromDB(cleanMemoryCache:filter:)")));
		[Abstract]
		[Export ("filterConversationsFromDB:filter:")]
		[return: NullAllowed]
		AgoraChatConversation[] FilterConversationsFromDB (bool cleanMemoryCache, [NullAllowed] Func<AgoraChatConversation, bool> filter);
		
		// @required -(void)cleanConversationsMemoryCache;
		[Abstract]
		[Export ("cleanConversationsMemoryCache")]
		void CleanConversationsMemoryCache ();
		
		// @required -(NSArray<AgoraChatConversation *> * _Nullable)getAllConversations:(BOOL)isSort;
		[Abstract]
		[Export ("getAllConversations:")]
		[return: NullAllowed]
		AgoraChatConversation[] GetAllConversations (bool isSort);
		
		// 4// @required -(void)getConversationsFromServer:(void (^ _Nullable)(NSArray<AgoraChatConversation *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("getConversationsFromServer:")]
		void GetConversationsFromServer ([NullAllowed] Action<NSArray<AgoraChatConversation>, AgoraChatError> aCompletionBlock);
		
		// @required -(void)getConversationsFromServerByPage:(NSUInteger)pageNumber pageSize:(NSUInteger)pageSize completion:(void (^ _Nullable)(NSArray<AgoraChatConversation *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("getConversationsFromServerByPage:pageSize:completion:")]
		void GetConversationsFromServerByPage (nuint pageNumber, nuint pageSize, [NullAllowed] Action<NSArray<AgoraChatConversation>, AgoraChatError> aCompletionBlock);
		
		// @required -(void)getConversationsFromServerWithCursor:(NSString * _Nullable)cursor pageSize:(UInt8)pageSize completion:(void (^ _Nonnull)(AgoraChatCursorResult<AgoraChatConversation *> * _Nullable, AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("getConversationsFromServerWithCursor:pageSize:completion:")]
		void GetConversationsFromServerWithCursor ([NullAllowed] string cursor, byte pageSize, Action<AgoraChatCursorResult<AgoraChatConversation>, AgoraChatError> completionBlock);
		
		// 5// @required -(void)getPinnedConversationsFromServerWithCursor:(NSString * _Nullable)cursor pageSize:(UInt8)limit completion:(void (^ _Nonnull)(AgoraChatCursorResult<AgoraChatConversation *> * _Nullable, AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("getPinnedConversationsFromServerWithCursor:pageSize:completion:")]
		void GetPinnedConversationsFromServerWithCursor ([NullAllowed] string cursor, byte limit, Action<AgoraChatCursorResult<AgoraChatConversation>, AgoraChatError> completionBlock);
		
		// @required -(void)pinConversation:(NSString * _Nonnull)conversationId isPinned:(BOOL)isPinned completionBlock:(void (^ _Nullable)(AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("pinConversation:isPinned:completionBlock:")]
		void PinConversation (string conversationId, bool isPinned, [NullAllowed] Action<AgoraChatError> completionBlock);
		
		// @required -(AgoraChatConversation * _Nullable)getConversationWithConvId:(NSString * _Nullable)aConversationId;
		[Abstract]
		[Export ("getConversationWithConvId:")]
		[return: NullAllowed]
		AgoraChatConversation GetConversationWithConvId ([NullAllowed] string aConversationId);
		
		// @required -(AgoraChatConversation * _Nullable)getConversation:(NSString * _Nonnull)aConversationId type:(AgoraChatConversationType)aType createIfNotExist:(BOOL)aIfCreate;
		[Abstract]
		[Export ("getConversation:type:createIfNotExist:")]
		[return: NullAllowed]
		AgoraChatConversation GetConversation (string aConversationId, AgoraChatConversationType aType, bool aIfCreate);
		
		// @required -(AgoraChatConversation * _Nullable)getConversation:(NSString * _Nonnull)aConversationId type:(AgoraChatConversationType)aType createIfNotExist:(BOOL)aIfCreate isThread:(BOOL)isThread;
		[Abstract]
		[Export ("getConversation:type:createIfNotExist:isThread:")]
		[return: NullAllowed]
		AgoraChatConversation GetConversation (string aConversationId, AgoraChatConversationType aType, bool aIfCreate, bool isThread);
		
		// 6// @required -(void)deleteConversation:(NSString * _Nonnull)aConversationId isDeleteMessages:(BOOL)aIsDeleteMessages completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("deleteConversation:isDeleteMessages:completion:")]
		void DeleteConversation (string aConversationId, bool aIsDeleteMessages, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);
		
		// @required -(void)deleteServerConversation:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType isDeleteServerMessages:(BOOL)aIsDeleteServerMessages completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("deleteServerConversation:conversationType:isDeleteServerMessages:completion:")]
		void DeleteServerConversation (string aConversationId, AgoraChatConversationType aConversationType, bool aIsDeleteServerMessages, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);
		
		// @required -(void)deleteConversations:(NSArray<AgoraChatConversation *> * _Nullable)aConversations isDeleteMessages:(BOOL)aIsDeleteMessages completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("deleteConversations:isDeleteMessages:completion:")]
		void DeleteConversations ([NullAllowed] AgoraChatConversation[] aConversations, bool aIsDeleteMessages, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
		
		// @required -(void)importConversations:(NSArray<AgoraChatConversation *> * _Nullable)aConversations completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("importConversations:completion:")]
		void ImportConversations ([NullAllowed] AgoraChatConversation[] aConversations, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
		
		// @required -(AgoraChatMessage * _Nullable)getMessageWithMessageId:(NSString * _Nonnull)aMessageId;
		[Abstract]
		[Export ("getMessageWithMessageId:")]
		[return: NullAllowed]
		AgoraChatMessage GetMessageWithMessageId (string aMessageId);
		
		// 7// @required -(NSString * _Nullable)getMessageAttachmentPath:(NSString * _Nonnull)aConversationId;
		[Abstract]
		[Export ("getMessageAttachmentPath:")]
		[return: NullAllowed]
		string GetMessageAttachmentPath (string aConversationId);
		
		// @required -(void)importMessages:(NSArray<AgoraChatMessage *> * _Nonnull)aMessages completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("importMessages:completion:")]
		void ImportMessages (AgoraChatMessage[] aMessages, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
		
		// @required -(void)updateMessage:(AgoraChatMessage * _Nonnull)aMessage completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateMessage:completion:")]
		void UpdateMessage (AgoraChatMessage aMessage, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);
		
		// @required -(void)modifyMessage:(NSString * _Nonnull)messageId body:(AgoraChatMessageBody * _Nonnull)body completion:(void (^ _Nonnull)(AgoraChatError * _Nullable, AgoraChatMessage * _Nullable))completionBlock;
		[Abstract]
		[Export ("modifyMessage:body:completion:")]
		void ModifyMessage (string messageId, AgoraChatMessageBody body, Action<AgoraChatError, AgoraChatMessage> completionBlock);
		
		// @required -(void)sendMessageReadAck:(NSString * _Nonnull)aMessageId toUser:(NSString * _Nonnull)aUsername completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("sendMessageReadAck:toUser:completion:")]
		void SendMessageReadAck (string aMessageId, string aUsername, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
		
		// 8// @required -(void)sendGroupMessageReadAck:(NSString * _Nonnull)aMessageId toGroup:(NSString * _Nonnull)aGroupId content:(NSString * _Nullable)aContent completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
          		[Export ("sendGroupMessageReadAck:toGroup:content:completion:")]
          		void SendGroupMessageReadAck (string aMessageId, string aGroupId, [NullAllowed] string aContent, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
          		
          		// @required -(void)ackConversationRead:(NSString * _Nonnull)conversationId completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
          		[Abstract]
          		[Export ("ackConversationRead:completion:")]
          		void AckConversationRead (string conversationId, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
          		
          		// @required -(void)recallMessageWithMessageId:(NSString * _Nonnull)aMessageId completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
          		[Abstract]
          		[Export ("recallMessageWithMessageId:completion:")]
          		void RecallMessageWithMessageId (string aMessageId, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
          		
          		// @required -(void)recallMessageWithMessageId:(NSString * _Nonnull)aMessageId ext:(NSString * _Nullable)ext completion:(void (^ _Nonnull)(AgoraChatError * _Nullable))aCompletionBlock;
          		[Abstract]
          		[Export ("recallMessageWithMessageId:ext:completion:")]
          		void RecallMessageWithMessageId (string aMessageId, [NullAllowed] string ext, Action<AgoraChatError> aCompletionBlock);
          		
          		// @required -(void)sendMessage:(AgoraChatMessage * _Nonnull)aMessage progress:(void (^ _Nullable)(int))aProgressBlock completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
          		//[Abstract]
          		[Export ("sendMessage:progress:completion:")]
          		void SendMessage (AgoraChatMessage aMessage, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);
          		
          		// @required -(void)resendMessage:(AgoraChatMessage * _Nonnull)aMessage progress:(void (^ _Nullable)(int))aProgressBlock completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
          		[Abstract]
          		[Export ("resendMessage:progress:completion:")]
          		void ResendMessage (AgoraChatMessage aMessage, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);
          		
		// 9// @required -(void)downloadMessageThumbnail:(AgoraChatMessage * _Nonnull)aMessage progress:(void (^ _Nullable)(int))aProgressBlock completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		 [Abstract]
		 [Export ("downloadMessageThumbnail:progress:completion:")]
		 void DownloadMessageThumbnail (AgoraChatMessage aMessage, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);
		//
		 // @required -(void)downloadMessageAttachment:(AgoraChatMessage * _Nonnull)aMessage progress:(void (^ _Nullable)(int))aProgressBlock completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		 [Abstract]
		 [Export ("downloadMessageAttachment:progress:completion:")]
		 void DownloadMessageAttachment (AgoraChatMessage aMessage, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);
		
		// // @required -(void)downloadAndParseCombineMessage:(AgoraChatMessage * _Nonnull)aMessage completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		 [Abstract]
		 [Export ("downloadAndParseCombineMessage:completion:")]
		void DownloadAndParseCombineMessage (AgoraChatMessage aMessage, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);
		
		////@required -(AgoraChatCursorResult<AgoraChatMessage *> * _Nullable)fetchHistoryMessagesFromServer:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType startMessageId:(NSString * _Nullable)aStartMessageId fetchDirection:(AgoraChatMessageFetchHistoryDirection)direction pageSize:(int)aPageSize error:(AgoraChatError ** _Nullable)pError __attribute__((deprecated("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead")));
		// [Abstract]
		// [Export ("fetchHistoryMessagesFromServer:conversationType:startMessageId:fetchDirection:pageSize:error:")]
		// [return: NullAllowed]
		// AgoraChatCursorResult<AgoraChatMessage> FetchHistoryMessagesFromServer (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] string aStartMessageId, AgoraChatMessageFetchHistoryDirection direction, int aPageSize, out AgoraChatError pError);
		//
		
		// @required -(AgoraChatCursorResult<AgoraChatMessage *> * _Nullable)fetchHistoryMessagesFromServer:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType startMessageId:(NSString * _Nullable)aStartMessageId pageSize:(int)aPageSize error:(AgoraChatError ** _Nullable)pError __attribute__((deprecated("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead")));
		//[Abstract]
		//[Export ("fetchHistoryMessagesFromServer:conversationType:startMessageId:pageSize:error:")]
	//	[return: NullAllowed]
		//AgoraChatCursorResult<AgoraChatMessage> FetchHistoryMessagesFromServer (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] string aStartMessageId, int aPageSize, out AgoraChatError pError);
		
		// @required -(void)asyncFetchHistoryMessagesFromServer:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType startMessageId:(NSString * _Nullable)aStartMessageId pageSize:(int)aPageSize completion:(void (^ _Nullable)(AgoraChatCursorResult<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead")));
		[Abstract]
		[Export ("asyncFetchHistoryMessagesFromServer:conversationType:startMessageId:pageSize:completion:")]
		void AsyncFetchHistoryMessagesFromServer (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] string aStartMessageId, int aPageSize, [NullAllowed] Action<AgoraChatCursorResult<AgoraChatMessage>, AgoraChatError> aCompletionBlock);
		
		//10 // @required -(void)asyncFetchHistoryMessagesFromServer:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType startMessageId:(NSString * _Nullable)aStartMessageId fetchDirection:(AgoraChatMessageFetchHistoryDirection)direction pageSize:(int)aPageSize completion:(void (^ _Nullable)(AgoraChatCursorResult<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead")));
		[Abstract]
		[Export ("asyncFetchHistoryMessagesFromServer:conversationType:startMessageId:fetchDirection:pageSize:completion:")]
		void AsyncFetchHistoryMessagesFromServer (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] string aStartMessageId, AgoraChatMessageFetchHistoryDirection direction, int aPageSize, [NullAllowed] Action<AgoraChatCursorResult<AgoraChatMessage>, AgoraChatError> aCompletionBlock);
		
		// @required -(void)asyncFetchGroupMessageAcksFromServer:(NSString * _Nonnull)aMessageId groupId:(NSString * _Nonnull)aGroupId startGroupAckId:(NSString * _Nonnull)aGroupAckId pageSize:(int)aPageSize completion:(void (^ _Nullable)(AgoraChatCursorResult<AgoraChatGroupMessageAck *> * _Nullable, AgoraChatError * _Nullable, int))aCompletionBlock;
		//[Abstract]
		//[Export ("asyncFetchGroupMessageAcksFromServer:groupId:startGroupAckId:pageSize:completion:")]
		//void AsyncFetchGroupMessageAcksFromServer (string aMessageId, string aGroupId, string aGroupAckId, int aPageSize, [NullAllowed] Action<AgoraChatCursorResult<AgoraChatGroupMessageAck>, AgoraChatError, int> aCompletionBlock);
		
		// @required -(void)reportMessageWithId:(NSString * _Nonnull)aMessageId tag:(NSString * _Nonnull)aTag reason:(NSString * _Nonnull)aReason completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletion;
		[Abstract]
		[Export ("reportMessageWithId:tag:reason:completion:")]
		void ReportMessageWithId (string aMessageId, string aTag, string aReason, [NullAllowed] Action<AgoraChatError> aCompletion);
		
		// @required -(void)deleteMessagesBefore:(NSUInteger)aTimestamp completion:(void (^)(AgoraChatError *))aCompletion;
		[Abstract]
		[Export ("deleteMessagesBefore:completion:")]
		void DeleteMessagesBefore (nuint aTimestamp, Action<AgoraChatError> aCompletion);
		
		// @required -(void)removeMessagesFromServerWithConversation:(AgoraChatConversation * _Nonnull)conversation messageIds:(NSArray<__kindof NSString *> * _Nonnull)messageIds completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeMessagesFromServerWithConversation:messageIds:completion:")]
		void RemoveMessagesFromServerWithConversation (AgoraChatConversation conversation, string[] messageIds, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
		
		// @required -(void)removeMessagesFromServerWithConversation:(AgoraChatConversation * _Nonnull)conversation timeStamp:(NSTimeInterval)beforeTimeStamp completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeMessagesFromServerWithConversation:timeStamp:completion:")]
		void RemoveMessagesFromServerWithConversation (AgoraChatConversation conversation, double beforeTimeStamp, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
		
		// @required -(void)translateMessage:(AgoraChatMessage * _Nonnull)aMessage targetLanguages:(NSArray<NSString *> * _Nonnull)aLanguages completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("translateMessage:targetLanguages:completion:")]
		void TranslateMessage (AgoraChatMessage aMessage, string[] aLanguages, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);
		
		// @required -(void)fetchSupportedLanguages:(void (^ _Nullable)(NSArray<AgoraChatTranslateLanguage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		//[Abstract]
		//[Export ("fetchSupportedLanguages:")]
		//void FetchSupportedLanguages ([NullAllowed] Action<NSArray<AgoraChatTranslateLanguage>, AgoraChatError> aCompletionBlock);
		
		// @required -(NSArray<AgoraChatMessage *> * _Nullable)loadMessagesWithType:(AgoraChatMessageBodyType)aType timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aUsername searchDirection:(AgoraChatMessageSearchDirection)aDirection;
		[Abstract]
		[Export ("loadMessagesWithType:timestamp:count:fromUser:searchDirection:")]
		[return: NullAllowed]
		AgoraChatMessage[] LoadMessagesWithType (AgoraChatMessageBodyType aType, long aTimestamp, int aCount, [NullAllowed] string aUsername, AgoraChatMessageSearchDirection aDirection);
		
		// @required -(void)loadMessagesWithType:(AgoraChatMessageBodyType)aType timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString *)aUsername searchDirection:(AgoraChatMessageSearchDirection)aDirection completion:(void (^)(NSArray<AgoraChatMessage *> *, AgoraChatError *))aCompletionBlock;
		[Abstract]
		[Export ("loadMessagesWithType:timestamp:count:fromUser:searchDirection:completion:")]
		void LoadMessagesWithType (AgoraChatMessageBodyType aType, long aTimestamp, int aCount, string aUsername, AgoraChatMessageSearchDirection aDirection, Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);
		
		// @required -(void)searchMessagesWithTypes:(NSArray<NSNumber *> * _Nonnull)aTypes timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aUsername searchDirection:(AgoraChatMessageSearchDirection)aDirection completion:(void (^ _Nonnull)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("searchMessagesWithTypes:timestamp:count:fromUser:searchDirection:completion:")]
		void SearchMessagesWithTypes (NSNumber[] aTypes, long aTimestamp, int aCount, [NullAllowed] string aUsername, AgoraChatMessageSearchDirection aDirection, Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);
		
		// @required -(NSArray<AgoraChatMessage *> *)loadMessagesWithKeyword:(NSString *)aKeywords timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString *)aSender searchDirection:(AgoraChatMessageSearchDirection)aDirection;
		[Abstract]
		[Export ("loadMessagesWithKeyword:timestamp:count:fromUser:searchDirection:")]
		AgoraChatMessage[] LoadMessagesWithKeyword (string aKeywords, long aTimestamp, int aCount, string aSender, AgoraChatMessageSearchDirection aDirection);
		
		// @required -(void)loadMessagesWithKeyword:(NSString *)aKeywords timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString *)aSender searchDirection:(AgoraChatMessageSearchDirection)aDirection completion:(void (^)(NSArray<AgoraChatMessage *> *, AgoraChatError *))aCompletionBlock;
		[Abstract]
		[Export ("loadMessagesWithKeyword:timestamp:count:fromUser:searchDirection:completion:")]
		void LoadMessagesWithKeyword (string aKeywords, long aTimestamp, int aCount, string aSender, AgoraChatMessageSearchDirection aDirection, Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);
		
		// @required -(void)loadMessagesWithKeyword:(NSString *)aKeywords timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString *)aSender searchDirection:(AgoraChatMessageSearchDirection)aDirection scope:(AgoraChatMessageSearchScope)aScope completion:(void (^)(NSArray<AgoraChatMessage *> *, AgoraChatError *))aCompletionBlock;
		[Abstract]
		[Export ("loadMessagesWithKeyword:timestamp:count:fromUser:searchDirection:scope:completion:")]
		void LoadMessagesWithKeyword (string aKeywords, long aTimestamp, int aCount, string aSender, AgoraChatMessageSearchDirection aDirection, AgoraChatMessageSearchScope aScope, Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);
		
		// @required -(void)addReaction:(NSString * _Nonnull)reaction toMessage:(NSString * _Nonnull)messageId completion:(void (^ _Nullable)(AgoraChatError * _Nullable))completion;
		[Abstract]
		[Export ("addReaction:toMessage:completion:")]
		void AddReaction (string reaction, string messageId, [NullAllowed] Action<AgoraChatError> completion);
		
		// @required -(void)removeReaction:(NSString * _Nonnull)reaction fromMessage:(NSString * _Nonnull)messageId completion:(void (^ _Nullable)(AgoraChatError * _Nullable))completion;
		[Abstract]
		[Export ("removeReaction:fromMessage:completion:")]
		void RemoveReaction (string reaction, string messageId, [NullAllowed] Action<AgoraChatError> completion);
		
		// @required -(void)getReactionList:(NSArray<NSString *> * _Nonnull)messageIds groupId:(NSString * _Nullable)groupId chatType:(AgoraChatType)chatType completion:(void (^ _Nonnull)(NSDictionary<NSString *,NSArray<AgoraChatMessageReaction *> *> * _Nonnull, AgoraChatError * _Nullable))completion;
		[Abstract]
		[Export ("getReactionList:groupId:chatType:completion:")]
		void GetReactionList (string[] messageIds, [NullAllowed] string groupId, AgoraChatType chatType, Action<NSDictionary<NSString, NSArray<AgoraChatMessageReaction>>, AgoraChatError> completion);
		
		// @required -(void)getReactionDetail:(NSString * _Nonnull)messageId reaction:(NSString * _Nonnull)reaction cursor:(NSString * _Nullable)cursor pageSize:(uint64_t)pageSize completion:(void (^ _Nonnull)(AgoraChatMessageReaction * _Nonnull, NSString * _Nullable, AgoraChatError * _Nullable))completion;
		[Abstract]
		[Export ("getReactionDetail:reaction:cursor:pageSize:completion:")]
		void GetReactionDetail (string messageId, string reaction, [NullAllowed] string cursor, ulong pageSize, Action<AgoraChatMessageReaction, NSString, AgoraChatError> completion);
		
		// @required -(void)fetchMessagesFromServerBy:(NSString * _Nonnull)conversationId conversationType:(AgoraChatConversationType)type cursor:(NSString * _Nullable)cursor pageSize:(NSUInteger)pageSize option:(AgoraChatFetchServerMessagesOption * _Nullable)option completion:(void (^ _Nullable)(AgoraChatCursorResult<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		//[Abstract]
		//[Export ("fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion:")]
		//void FetchMessagesFromServerBy (string conversationId, AgoraChatConversationType type, [NullAllowed] string cursor, nuint pageSize, [NullAllowed] AgoraChatFetchServerMessagesOption option, [NullAllowed] Action<AgoraChatCursorResult<AgoraChatMessage>, AgoraChatError> aCompletionBlock);
		
		// @required -(void)addConversationMark:(NSArray<NSString *> * _Nonnull)conversationIds mark:(AgoraChatMarkType)mark completion:(void (^ _Nullable)(AgoraChatError * _Nullable))completion;
		[Abstract]
		[Export ("addConversationMark:mark:completion:")]
		void AddConversationMark (string[] conversationIds, AgoraChatMarkType mark, [NullAllowed] Action<AgoraChatError> completion);
		
		// @required -(void)removeConversationMark:(NSArray<NSString *> * _Nonnull)conversationIds mark:(AgoraChatMarkType)mark completion:(void (^ _Nullable)(AgoraChatError * _Nullable))completion;
		[Abstract]
		[Export ("removeConversationMark:mark:completion:")]
		void RemoveConversationMark (string[] conversationIds, AgoraChatMarkType mark, [NullAllowed] Action<AgoraChatError> completion);
		
		// @required -(void)getConversationsFromServerWithCursor:(NSString * _Nullable)cursor filter:(AgoraChatConversationFilter * _Nonnull)filter completion:(void (^ _Nonnull)(AgoraChatCursorResult<AgoraChatConversation *> * _Nullable, AgoraChatError * _Nullable))completionBlock;
		//[Abstract]
		//[Export ("getConversationsFromServerWithCursor:filter:completion:")]
		//void GetConversationsFromServerWithCursor ([NullAllowed] string cursor, AgoraChatConversationFilter filter, Action<AgoraChatCursorResult<AgoraChatConversation>, AgoraChatError> completionBlock);
		
		// @required -(void)deleteAllMessagesAndConversations:(BOOL)clearServerData completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("deleteAllMessagesAndConversations:completion:")]
		void DeleteAllMessagesAndConversations (bool clearServerData, [NullAllowed] Action<AgoraChatError> aCompletionBlock);
		
		// @required -(void)pinMessage:(NSString * _Nonnull)messageId completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("pinMessage:completion:")]
		void PinMessage (string messageId, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);
		
		// @required -(void)unpinMessage:(NSString * _Nonnull)messageId completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("unpinMessage:completion:")]
		void UnpinMessage (string messageId, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);
		
		// @required -(void)getPinnedMessagesFromServer:(NSString * _Nonnull)conversationId completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getPinnedMessagesFromServer:completion:")]
		void GetPinnedMessagesFromServer (string conversationId, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);
		
		// @required -(AgoraChatError * _Nonnull)markAllConversationsAsRead;
		[Abstract]
		[Export ("markAllConversationsAsRead")]
		//[Verify (MethodToProperty)]
		AgoraChatError MarkAllConversationsAsRead { get; }
		
		// @required -(void)getMessageCountWithCompletion:(void (^ _Nonnull)(NSInteger, AgoraChatError * _Nullable))completion;
		[Abstract]
		[Export ("getMessageCountWithCompletion:")]
		void GetMessageCountWithCompletion (Action<int, AgoraChatError> completion);
	}
	// @interface AgoraChatConversation : NSObject
	[BaseType (typeof(NSObject), Name = "AgoraChatConversation")]
	interface AgoraChatConversation : INativeObject
	{
		// @property (readonly, copy, nonatomic) NSString * conversationId;
		[Export ("conversationId")]
		string ConversationId { get; }

		// @property (readonly, assign, nonatomic) AgoraChatConversationType type;
		[Export ("type", ArgumentSemantic.Assign)]
		AgoraChatConversationType Type { get; }

		// @property (readonly, assign, nonatomic) int unreadMessagesCount;
		[Export ("unreadMessagesCount")]
		int UnreadMessagesCount { get; }

		// @property (readonly, assign, nonatomic) int messagesCount;
		[Export ("messagesCount")]
		int MessagesCount { get; }

		// @property (copy, nonatomic) NSDictionary * ext;
		[Export ("ext", ArgumentSemantic.Copy)]
		NSDictionary Ext { get; set; }

		// @property (assign, nonatomic) BOOL isChatThread;
		[Export ("isChatThread")]
		bool IsChatThread { get; set; }

		// @property (readonly) BOOL isPinned;
		[Export ("isPinned")]
		bool IsPinned { get; }

		// @property (readonly) int64_t pinnedTime;
		[Export ("pinnedTime")]
		long PinnedTime { get; }

		// @property (readonly, nonatomic, strong) AgoraChatMessage * latestMessage;
		[Export ("latestMessage", ArgumentSemantic.Strong)]
		AgoraChatMessage LatestMessage { get; }

		// @property (readonly, nonatomic) NSArray<NSNumber *> * marks;
		[Export ("marks")]
		NSNumber[] Marks { get; }

		// @property (readonly, nonatomic) AgoraChatPushRemindType disturbType;
		[Export ("disturbType")]
		AgoraChatPushRemindType DisturbType { get; }

		// -(AgoraChatMessage * _Nullable)lastReceivedMessage;
		[NullAllowed, Export ("lastReceivedMessage")]
		AgoraChatMessage LastReceivedMessage { get; }

		// -(void)insertMessage:(AgoraChatMessage * _Nonnull)aMessage error:(AgoraChatError ** _Nullable)pError;
		[Export ("insertMessage:error:")]
		void InsertMessage (AgoraChatMessage aMessage, out AgoraChatError pError);

		// -(void)appendMessage:(AgoraChatMessage * _Nonnull)aMessage error:(AgoraChatError ** _Nullable)pError;
		[Export ("appendMessage:error:")]
		void AppendMessage (AgoraChatMessage aMessage, out AgoraChatError pError);

		// -(void)deleteMessageWithId:(NSString * _Nonnull)aMessageId error:(AgoraChatError ** _Nullable)pError;
		[Export ("deleteMessageWithId:error:")]
		void DeleteMessageWithId (string aMessageId, out AgoraChatError pError);

		// -(void)deleteAllMessages:(AgoraChatError ** _Nullable)pError;
		[Export ("deleteAllMessages:")]
		void DeleteAllMessages (out AgoraChatError pError);

		// -(void)removeMessagesFromServerMessageIds:(NSArray<__kindof NSString *> * _Nonnull)messageIds completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("removeMessagesFromServerMessageIds:completion:")]
		void RemoveMessagesFromServerMessageIds (string[] messageIds, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(void)removeMessagesFromServerWithTimeStamp:(NSTimeInterval)beforeTimeStamp completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("removeMessagesFromServerWithTimeStamp:completion:")]
		void RemoveMessagesFromServerWithTimeStamp (double beforeTimeStamp, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// -(void)updateMessageChange:(AgoraChatMessage * _Nonnull)aMessage error:(AgoraChatError ** _Nullable)pError;
		[Export ("updateMessageChange:error:")]
		void UpdateMessageChange (AgoraChatMessage aMessage, out AgoraChatError pError);

		// -(void)markMessageAsReadWithId:(NSString * _Nonnull)aMessageId error:(AgoraChatError ** _Nullable)pError;
		[Export ("markMessageAsReadWithId:error:")]
		void MarkMessageAsReadWithId (string aMessageId, out AgoraChatError pError);

		// -(void)markAllMessagesAsRead:(AgoraChatError ** _Nullable)pError;
		[Export ("markAllMessagesAsRead:")]
		void MarkAllMessagesAsRead (out AgoraChatError pError);

		// -(NSArray<AgoraChatMessage *> * _Nullable)pinnedMessages;
		[NullAllowed, Export ("pinnedMessages")]
		AgoraChatMessage[] PinnedMessages { get; }

		// -(AgoraChatMessage * _Nullable)loadMessageWithId:(NSString * _Nonnull)aMessageId error:(AgoraChatError ** _Nullable)pError;
		[Export ("loadMessageWithId:error:")]
		[return: NullAllowed]
		AgoraChatMessage LoadMessageWithId (string aMessageId, out AgoraChatError pError);

		// -(NSArray<AgoraChatMessage *> * _Nullable)loadMessagesStartFromId:(NSString * _Nullable)aMessageId count:(int)aCount searchDirection:(AgoraChatMessageSearchDirection)aDirection;
		[Export ("loadMessagesStartFromId:count:searchDirection:")]
		[return: NullAllowed]
		AgoraChatMessage[] LoadMessagesStartFromId ([NullAllowed] string aMessageId, int aCount, AgoraChatMessageSearchDirection aDirection);

		// -(void)loadMessagesStartFromId:(NSString * _Nullable)aMessageId count:(int)aCount searchDirection:(AgoraChatMessageSearchDirection)aDirection completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("loadMessagesStartFromId:count:searchDirection:completion:")]
		void LoadMessagesStartFromId ([NullAllowed] string aMessageId, int aCount, AgoraChatMessageSearchDirection aDirection, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// -(NSArray<AgoraChatMessage *> * _Nullable)loadMessagesWithType:(AgoraChatMessageBodyType)aType timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aUsername searchDirection:(AgoraChatMessageSearchDirection)aDirection;
		[Export ("loadMessagesWithType:timestamp:count:fromUser:searchDirection:")]
		[return: NullAllowed]
		AgoraChatMessage[] LoadMessagesWithType (AgoraChatMessageBodyType aType, long aTimestamp, int aCount, [NullAllowed] string aUsername, AgoraChatMessageSearchDirection aDirection);

		// -(void)loadMessagesWithType:(AgoraChatMessageBodyType)aType timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aUsername searchDirection:(AgoraChatMessageSearchDirection)aDirection completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("loadMessagesWithType:timestamp:count:fromUser:searchDirection:completion:")]
		void LoadMessagesWithType (AgoraChatMessageBodyType aType, long aTimestamp, int aCount, [NullAllowed] string aUsername, AgoraChatMessageSearchDirection aDirection, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// -(void)searchMessagesWithTypes:(NSArray<NSNumber *> * _Nonnull)aTypes timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aUsername searchDirection:(AgoraChatMessageSearchDirection)aDirection completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("searchMessagesWithTypes:timestamp:count:fromUser:searchDirection:completion:")]
		void SearchMessagesWithTypes (NSNumber[] aTypes, long aTimestamp, int aCount, [NullAllowed] string aUsername, AgoraChatMessageSearchDirection aDirection, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// -(NSArray<AgoraChatMessage *> * _Nullable)loadMessagesWithKeyword:(NSString * _Nullable)aKeyword timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aSender searchDirection:(AgoraChatMessageSearchDirection)aDirection;
		[Export ("loadMessagesWithKeyword:timestamp:count:fromUser:searchDirection:")]
		[return: NullAllowed]
		AgoraChatMessage[] LoadMessagesWithKeyword ([NullAllowed] string aKeyword, long aTimestamp, int aCount, [NullAllowed] string aSender, AgoraChatMessageSearchDirection aDirection);

		// -(void)loadMessagesWithKeyword:(NSString * _Nullable)aKeyword timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aSender searchDirection:(AgoraChatMessageSearchDirection)aDirection completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("loadMessagesWithKeyword:timestamp:count:fromUser:searchDirection:completion:")]
		void LoadMessagesWithKeyword ([NullAllowed] string aKeyword, long aTimestamp, int aCount, [NullAllowed] string aSender, AgoraChatMessageSearchDirection aDirection, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// -(void)loadMessagesWithKeyword:(NSString * _Nullable)aKeyword timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aSender searchDirection:(AgoraChatMessageSearchDirection)aDirection scope:(AgoraChatMessageSearchScope)aScope completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("loadMessagesWithKeyword:timestamp:count:fromUser:searchDirection:scope:completion:")]
		void LoadMessagesWithKeyword ([NullAllowed] string aKeyword, long aTimestamp, int aCount, [NullAllowed] string aSender, AgoraChatMessageSearchDirection aDirection, AgoraChatMessageSearchScope aScope, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// -(NSArray<AgoraChatMessage *> * _Nullable)loadCustomMsgWithKeyword:(NSString *)aKeyword timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aSender searchDirection:(AgoraChatMessageSearchDirection)aDirection;
		[Export ("loadCustomMsgWithKeyword:timestamp:count:fromUser:searchDirection:")]
		[return: NullAllowed]
		AgoraChatMessage[] LoadCustomMsgWithKeyword (string aKeyword, long aTimestamp, int aCount, [NullAllowed] string aSender, AgoraChatMessageSearchDirection aDirection);

		// -(void)loadCustomMsgWithKeyword:(NSString * _Nullable)aKeyword timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString * _Nullable)aSender searchDirection:(AgoraChatMessageSearchDirection)aDirection completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("loadCustomMsgWithKeyword:timestamp:count:fromUser:searchDirection:completion:")]
		void LoadCustomMsgWithKeyword ([NullAllowed] string aKeyword, long aTimestamp, int aCount, [NullAllowed] string aSender, AgoraChatMessageSearchDirection aDirection, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// -(NSArray<AgoraChatMessage *> * _Nullable)loadMessagesFrom:(long long)aStartTimestamp to:(long long)aEndTimestamp count:(int)aCount;
		[Export ("loadMessagesFrom:to:count:")]
		[return: NullAllowed]
		AgoraChatMessage[] LoadMessagesFrom (long aStartTimestamp, long aEndTimestamp, int aCount);

		// -(void)loadMessagesFrom:(long long)aStartTimestamp to:(long long)aEndTimestamp count:(int)aCount completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("loadMessagesFrom:to:count:completion:")]
		void LoadMessagesFrom (long aStartTimestamp, long aEndTimestamp, int aCount, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)removeMessagesStart:(NSInteger)aStartTimestamp to:(NSInteger)aEndTimestamp;
		[Export ("removeMessagesStart:to:")]
		[return: NullAllowed]
		AgoraChatError RemoveMessagesStart (nint aStartTimestamp, nint aEndTimestamp);

		// -(NSInteger)getMessageCountStart:(NSInteger)aStartTimestamp to:(NSInteger)aEndTimestamp;
		[Export ("getMessageCountStart:to:")]
		nint GetMessageCountStart (nint aStartTimestamp, nint aEndTimestamp);
	}
	
	// audit-objc-generics: @interface AgoraChatCursorResult<__covariant ObjectType> : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatCursorResult<T>
	{
		// @property (nonatomic, strong) NSArray<ObjectType> * _Nullable list;
		[NullAllowed, Export ("list", ArgumentSemantic.Strong)]
		NSObject[] List { get; set; }
	
		// @property (copy, nonatomic) NSString * _Nullable cursor;
		[NullAllowed, Export ("cursor")]
		string Cursor { get; set; }
	
		// +(instancetype _Nonnull)cursorResultWithList:(NSArray<ObjectType> * _Nullable)aList andCursor:(NSString * _Nullable)aCusror;
		[Static]
		[Export ("cursorResultWithList:andCursor:")]
		AgoraChatCursorResult<T> CursorResultWithList ([NullAllowed] NSObject[] aList, [NullAllowed] string aCusror);
	}
	// @interface AgoraChatTextMessageBody : AgoraChatMessageBody
	[BaseType (typeof(AgoraChatMessageBody))]
	[DisableDefaultCtor]
	interface AgoraChatTextMessageBody
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable targetLanguages;
		[NullAllowed, Export ("targetLanguages", ArgumentSemantic.Copy)]
		string[] TargetLanguages { get; set; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable translations;
		[NullAllowed, Export ("translations", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Translations { get; }

		// -(instancetype _Nonnull)initWithText:(NSString * _Nullable)aText;
		[Export ("initWithText:")]
		NativeHandle Constructor ([NullAllowed] string aText);
	}
	// @protocol AgoraChatLogDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "AgoraChatLogDelegate")]
	interface AgoraChatLogDelegate
	{
		// @optional -(void)logDidOutput:(NSString * _Nonnull)log;
		[Export ("logDidOutput:")]
		void LogDidOutput (string log);
	}
}