using System;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UserNotifications;
using System.Collections.Generic;

namespace HotCoffee.AgoraChat.iOS
{
	// @interface AgoraChatLoginExtensionInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatLoginExtensionInfo
	{
		// @property (copy, nonatomic) NSString * _Nonnull deviceName;
		[Export ("deviceName")]
		string DeviceName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull extensionInfo;
		[Export ("extensionInfo")]
		string ExtensionInfo { get; set; }
	}

	// @protocol AgoraChatClientDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
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
	[BaseType (typeof(NSObject))]
	interface AgoraChatError : INativeObject
	{
		// @property (nonatomic) AgoraChatErrorCode code;
		[Export ("code", ArgumentSemantic.Assign)]
		AgoraChatErrorCode Code { get; set; }

		// @property (copy, nonatomic) NSString * errorDescription;
		[Export ("errorDescription")]
		string ErrorDescription { get; set; }

		// -(instancetype)initWithDescription:(NSString *)aDescription code:(AgoraChatErrorCode)aCode;
		[Export ("initWithDescription:code:")]
		NativeHandle Constructor (string aDescription, AgoraChatErrorCode aCode);

		// +(instancetype _Nonnull)errorWithDescription:(NSString * _Nullable)aDescription code:(AgoraChatErrorCode)aCode;
		[Static]
		[Export ("errorWithDescription:code:")]
		AgoraChatError ErrorWithDescription ([NullAllowed] string aDescription, AgoraChatErrorCode aCode);
	}

	// @interface AgoraChatMessageBody : NSObject
	[BaseType (typeof(NSObject))]
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

	// audit-objc-generics: @interface AgoraChatCursorResult<__covariant ObjectType> : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatCursorResult<T> : INativeObject
	{
		// @property (nonatomic, strong) NSArray<ObjectType> * _Nullable list;
		[NullAllowed, Export ("list", ArgumentSemantic.Strong)]
		NSObject[] List { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cursor;
		[NullAllowed, Export ("cursor")]
		T Cursor { get; set; }

		// +(instancetype _Nonnull)cursorResultWithList:(NSArray<ObjectType> * _Nullable)aList andCursor:(NSString * _Nullable)aCusror;
		[Static]
		[Export ("cursorResultWithList:andCursor:")]
		AgoraChatCursorResult<T> CursorResultWithList ([NullAllowed] NSObject[] aList, [NullAllowed] T aCusror);
	}

	// @interface AgoraChatSilentModeTime : NSObject <NSCopying, NSCoding>
	[BaseType (typeof(NSObject))]
	interface AgoraChatSilentModeTime : INSCopying, INSCoding
	{
		// @property (readonly, assign, nonatomic) int hours;
		[Export ("hours")]
		int Hours { get; }

		// @property (readonly, assign, nonatomic) int minutes;
		[Export ("minutes")]
		int Minutes { get; }

		// -(instancetype _Nonnull)initWithHours:(int)aHours minutes:(int)aMinutes;
		[Export ("initWithHours:minutes:")]
		NativeHandle Constructor (int aHours, int aMinutes);
	}

	// @interface AgoraChatSilentModeParam : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatSilentModeParam
	{
		// @property (readonly, assign, nonatomic) AgoraChatSilentModeParamType paramType;
		[Export ("paramType", ArgumentSemantic.Assign)]
		AgoraChatSilentModeParamType ParamType { get; }

		// @property (assign, nonatomic) int silentModeDuration;
		[Export ("silentModeDuration")]
		int SilentModeDuration { get; set; }

		// @property (assign, nonatomic) AgoraChatPushRemindType remindType;
		[Export ("remindType", ArgumentSemantic.Assign)]
		AgoraChatPushRemindType RemindType { get; set; }

		// @property (nonatomic, strong) AgoraChatSilentModeTime * _Nullable silentModeStartTime;
		[NullAllowed, Export ("silentModeStartTime", ArgumentSemantic.Strong)]
		AgoraChatSilentModeTime SilentModeStartTime { get; set; }

		// @property (nonatomic, strong) AgoraChatSilentModeTime * _Nullable silentModeEndTime;
		[NullAllowed, Export ("silentModeEndTime", ArgumentSemantic.Strong)]
		AgoraChatSilentModeTime SilentModeEndTime { get; set; }

		// -(instancetype _Nonnull)initWithParamType:(AgoraChatSilentModeParamType)aParamType;
		[Export ("initWithParamType:")]
		NativeHandle Constructor (AgoraChatSilentModeParamType aParamType);
	}

	// @interface AgoraChatConversation : NSObject
	[BaseType (typeof(NSObject))]
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
		// [Verify (MethodToProperty)]
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
		//[Verify (MethodToProperty)]
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

	// @protocol AgoraChatMultiDevicesDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AgoraChatMultiDevicesDelegate
	{
		// @optional -(void)multiDevicesContactEventDidReceive:(AgoraChatMultiDevicesEvent)aEvent username:(NSString * _Nonnull)aUsername ext:(NSString * _Nullable)aExt;
		[Export ("multiDevicesContactEventDidReceive:username:ext:")]
		void MultiDevicesContactEventDidReceive (AgoraChatMultiDevicesEvent aEvent, string aUsername, [NullAllowed] string aExt);

		// @optional -(void)multiDevicesGroupEventDidReceive:(AgoraChatMultiDevicesEvent)aEvent groupId:(NSString * _Nonnull)aGroupId ext:(id _Nullable)aExt;
		[Export ("multiDevicesGroupEventDidReceive:groupId:ext:")]
		void MultiDevicesGroupEventDidReceive (AgoraChatMultiDevicesEvent aEvent, string aGroupId, [NullAllowed] NSObject aExt);

		// @optional -(void)multiDevicesChatThreadEventDidReceive:(AgoraChatMultiDevicesEvent)aEvent threadId:(NSString * _Nonnull)aThreadId ext:(id _Nullable)aExt;
		[Export ("multiDevicesChatThreadEventDidReceive:threadId:ext:")]
		void MultiDevicesChatThreadEventDidReceive (AgoraChatMultiDevicesEvent aEvent, string aThreadId, [NullAllowed] NSObject aExt);

		// @optional -(void)multiDevicesUndisturbEventNotifyFormOtherDeviceData:(NSString * _Nullable)undisturbData __attribute__((deprecated("Use -multiDevicesConversationEvent:conversationId:conversationType: instead")));
		[Export ("multiDevicesUndisturbEventNotifyFormOtherDeviceData:")]
		void MultiDevicesUndisturbEventNotifyFormOtherDeviceData ([NullAllowed] string undisturbData);

		// @optional -(void)multiDevicesMessageBeRemoved:(NSString * _Nonnull)conversationId deviceId:(NSString * _Nonnull)deviceId;
		[Export ("multiDevicesMessageBeRemoved:deviceId:")]
		void MultiDevicesMessageBeRemoved (string conversationId, string deviceId);

		// @optional -(void)multiDevicesConversationEvent:(AgoraChatMultiDevicesEvent)event conversationId:(NSString * _Nonnull)conversationId conversationType:(AgoraChatConversationType)conversationType;
		[Export ("multiDevicesConversationEvent:conversationId:conversationType:")]
		void MultiDevicesConversationEvent (AgoraChatMultiDevicesEvent @event, string conversationId, AgoraChatConversationType conversationType);
	}

	// @interface AgoraChatOptions : NSObject
	[BaseType (typeof(NSObject))]
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

	// @interface AgoraChatPushOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatPushOptions
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName", ArgumentSemantic.Strong)]
		string DisplayName { get; }

		// @property (readonly, nonatomic) AgoraChatPushDisplayStyle displayStyle;
		[Export ("displayStyle")]
		AgoraChatPushDisplayStyle DisplayStyle { get; }

		// @property (readonly, nonatomic) NSInteger silentModeStart __attribute__((deprecated("")));
		[Export ("silentModeStart")]
		nint SilentModeStart { get; }

		// @property (readonly, nonatomic) NSInteger silentModeEnd __attribute__((deprecated("")));
		[Export ("silentModeEnd")]
		nint SilentModeEnd { get; }

		// @property (readonly, nonatomic) BOOL silentModeEnabled __attribute__((deprecated("")));
		[Export ("silentModeEnabled")]
		bool SilentModeEnabled { get; }

		// @property (readonly, nonatomic) NSInteger noDisturbingStartH __attribute__((deprecated("Use silentModeStart instead")));
		[Export ("noDisturbingStartH")]
		nint NoDisturbingStartH { get; }

		// @property (readonly, nonatomic) NSInteger noDisturbingEndH __attribute__((deprecated("Use silentModeEnd instead")));
		[Export ("noDisturbingEndH")]
		nint NoDisturbingEndH { get; }

		// @property (readonly, nonatomic) BOOL isNoDisturbEnable __attribute__((deprecated("Use silentModeEnabled instead")));
		[Export ("isNoDisturbEnable")]
		bool IsNoDisturbEnable { get; }
	}

	// @interface AgoraChatMessageReaction : NSObject
	[BaseType (typeof(NSObject))]
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

	// @interface AgoraChatMessage : NSObject
	[BaseType (typeof(NSObject))]
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
		[NullAllowed, Export ("reactionList")]
		AgoraChatMessageReaction[] ReactionList { get; }

		// -(AgoraChatMessageReaction * _Nullable)getReaction:(NSString * _Nonnull)reaction;
		[Export ("getReaction:")]
		[return: NullAllowed]
		AgoraChatMessageReaction GetReaction (string reaction);

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

	// @interface AgoraChatRecallMessageInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatRecallMessageInfo
	{
		// @property (copy, nonatomic) NSString * _Nonnull recallBy;
		[Export ("recallBy")]
		string RecallBy { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull recallMessageId;
		[Export ("recallMessageId")]
		string RecallMessageId { get; set; }

		// @property (nonatomic, strong) AgoraChatMessage * _Nullable recallMessage;
		[NullAllowed, Export ("recallMessage", ArgumentSemantic.Strong)]
		AgoraChatMessage RecallMessage { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable ext;
		[NullAllowed, Export ("ext", ArgumentSemantic.Strong)]
		string Ext { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull conversationId;
		[Export ("conversationId", ArgumentSemantic.Strong)]
		string ConversationId { get; set; }
	}

	// @protocol AgoraChatManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AgoraChatManagerDelegate
	{
		// @optional -(void)conversationListDidUpdate:(NSArray<AgoraChatConversation *> * _Nonnull)aConversationList;
		[Export ("conversationListDidUpdate:")]
		void ConversationListDidUpdate (AgoraChatConversation[] aConversationList);

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
		[Export ("groupMessageDidRead:groupAcks:")]
		void GroupMessageDidRead (AgoraChatMessage aMessage, AgoraChatGroupMessageAck[] aGroupAcks);

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
		[Export ("messagesInfoDidRecall:")]
		void MessagesInfoDidRecall (AgoraChatRecallMessageInfo[] aRecallMessagesInfo);

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
		[Export ("onMessagePinChanged:conversationId:operation:pinInfo:")]
		void OnMessagePinChanged (string messageId, string conversationId, AgoraChatMessagePinOperation pinOperation, AgoraChatMessagePinInfo pinInfo);

		// @optional -(void)messagesDidRecall:(NSArray *)aMessages __attribute__((deprecated("Use -messagesInfoDidRecall: instead")));
		[Export ("messagesDidRecall:")]
		//[Verify (StronglyTypedNSArray)]
		void MessagesDidRecall (NSObject[] aMessages);

		// @optional -(void)messageReactionDidChange:(NSArray<AgoraChatMessageReactionChange *> * _Nonnull)changes;
		[Export ("messageReactionDidChange:")]
		void MessageReactionDidChange (AgoraChatMessageReactionChange[] changes);
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

	// @interface AgoraChatLocationMessageBody : AgoraChatMessageBody
	[BaseType (typeof(AgoraChatMessageBody))]
	[DisableDefaultCtor]
	interface AgoraChatLocationMessageBody
	{
		// @property (nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; set; }

		// @property (nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable address;
		[NullAllowed, Export ("address")]
		string Address { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable buildingName;
		[NullAllowed, Export ("buildingName")]
		string BuildingName { get; set; }

		// -(instancetype _Nonnull)initWithLatitude:(double)aLatitude longitude:(double)aLongitude address:(NSString * _Nullable)aAddress;
		[Export ("initWithLatitude:longitude:address:")]
		NativeHandle Constructor (double aLatitude, double aLongitude, [NullAllowed] string aAddress);

		// -(instancetype _Nonnull)initWithLatitude:(double)aLatitude longitude:(double)aLongitude address:(NSString * _Nullable)aAddress buildingName:(NSString * _Nullable)aBuildingName;
		[Export ("initWithLatitude:longitude:address:buildingName:")]
		NativeHandle Constructor (double aLatitude, double aLongitude, [NullAllowed] string aAddress, [NullAllowed] string aBuildingName);
	}

	// @interface AgoraChatCmdMessageBody : AgoraChatMessageBody
	[BaseType (typeof(AgoraChatMessageBody))]
	[DisableDefaultCtor]
	interface AgoraChatCmdMessageBody
	{
		// @property (copy, nonatomic) NSString * action;
		[Export ("action")]
		string Action { get; set; }

		// @property (nonatomic) BOOL isDeliverOnlineOnly;
		[Export ("isDeliverOnlineOnly")]
		bool IsDeliverOnlineOnly { get; set; }

		// -(instancetype _Nonnull)initWithAction:(NSString * _Nonnull)aAction;
		[Export ("initWithAction:")]
		NativeHandle Constructor (string aAction);
	}

	// @interface AgoraChatFileMessageBody : AgoraChatMessageBody
	[BaseType (typeof(AgoraChatMessageBody))]
	interface AgoraChatFileMessageBody
	{
		// @property (copy, nonatomic) NSString * displayName;
		[Export ("displayName")]
		string DisplayName { get; set; }

		// @property (copy, nonatomic) NSString * localPath;
		[Export ("localPath")]
		string LocalPath { get; set; }

		// @property (copy, nonatomic) NSString * remotePath;
		[Export ("remotePath")]
		string RemotePath { get; set; }

		// @property (copy, nonatomic) NSString * secretKey;
		[Export ("secretKey")]
		string SecretKey { get; set; }

		// @property (nonatomic) long long fileLength;
		[Export ("fileLength")]
		long FileLength { get; set; }

		// @property (nonatomic) AgoraChatDownloadStatus downloadStatus;
		[Export ("downloadStatus", ArgumentSemantic.Assign)]
		AgoraChatDownloadStatus DownloadStatus { get; set; }

		// -(instancetype _Nonnull)initWithLocalPath:(NSString * _Nullable)aLocalPath displayName:(NSString * _Nullable)aDisplayName;
		[Export ("initWithLocalPath:displayName:")]
		NativeHandle Constructor ([NullAllowed] string aLocalPath, [NullAllowed] string aDisplayName);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nullable)aData displayName:(NSString * _Nullable)aDisplayName;
		[Export ("initWithData:displayName:")]
		NativeHandle Constructor ([NullAllowed] NSData aData, [NullAllowed] string aDisplayName);
	}

	// @interface AgoraChatImageMessageBody : AgoraChatFileMessageBody
	[BaseType (typeof(AgoraChatFileMessageBody))]
	interface AgoraChatImageMessageBody
	{
		// @property (nonatomic) CGSize size;
		[Export ("size", ArgumentSemantic.Assign)]
		CGSize Size { get; set; }

		// @property (nonatomic) CGFloat compressionRatio;
		[Export ("compressionRatio")]
		nfloat CompressionRatio { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailDisplayName;
		[Export ("thumbnailDisplayName")]
		string ThumbnailDisplayName { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailLocalPath;
		[Export ("thumbnailLocalPath")]
		string ThumbnailLocalPath { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailRemotePath;
		[Export ("thumbnailRemotePath")]
		string ThumbnailRemotePath { get; set; }

		// @property (copy, nonatomic) NSString * thumbnailSecretKey;
		[Export ("thumbnailSecretKey")]
		string ThumbnailSecretKey { get; set; }

		// @property (nonatomic) CGSize thumbnailSize;
		[Export ("thumbnailSize", ArgumentSemantic.Assign)]
		CGSize ThumbnailSize { get; set; }

		// @property (nonatomic) long long thumbnailFileLength;
		[Export ("thumbnailFileLength")]
		long ThumbnailFileLength { get; set; }

		// @property (nonatomic) AgoraChatDownloadStatus thumbnailDownloadStatus;
		[Export ("thumbnailDownloadStatus", ArgumentSemantic.Assign)]
		AgoraChatDownloadStatus ThumbnailDownloadStatus { get; set; }

		// -(instancetype)initWithData:(NSData *)aData thumbnailData:(NSData *)aThumbnailData;
		[Export ("initWithData:thumbnailData:")]
		NativeHandle Constructor (NSData aData, NSData aThumbnailData);
	}

	// @interface AgoraChatVoiceMessageBody : AgoraChatFileMessageBody
	[BaseType (typeof(AgoraChatFileMessageBody))]
	[DisableDefaultCtor]
	interface AgoraChatVoiceMessageBody
	{
		// @property (nonatomic) int duration;
		[Export ("duration")]
		int Duration { get; set; }
	}

	// @interface AgoraChatVideoMessageBody : AgoraChatFileMessageBody
	[BaseType (typeof(AgoraChatFileMessageBody))]
	[DisableDefaultCtor]
	interface AgoraChatVideoMessageBody
	{
		// @property (nonatomic) int duration;
		[Export ("duration")]
		int Duration { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable thumbnailLocalPath;
		[NullAllowed, Export ("thumbnailLocalPath")]
		string ThumbnailLocalPath { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable thumbnailRemotePath;
		[NullAllowed, Export ("thumbnailRemotePath")]
		string ThumbnailRemotePath { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable thumbnailSecretKey;
		[NullAllowed, Export ("thumbnailSecretKey")]
		string ThumbnailSecretKey { get; set; }

		// @property (nonatomic) CGSize thumbnailSize;
		[Export ("thumbnailSize", ArgumentSemantic.Assign)]
		CGSize ThumbnailSize { get; set; }

		// @property (nonatomic) AgoraChatDownloadStatus thumbnailDownloadStatus;
		[Export ("thumbnailDownloadStatus", ArgumentSemantic.Assign)]
		AgoraChatDownloadStatus ThumbnailDownloadStatus { get; set; }
	}

	// @interface AgoraChatCustomMessageBody : AgoraChatMessageBody
	[BaseType (typeof(AgoraChatMessageBody))]
	[DisableDefaultCtor]
	interface AgoraChatCustomMessageBody
	{
		// @property (copy, nonatomic) NSString * event;
		[Export ("event")]
		string Event { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * customExt;
		[Export ("customExt", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> CustomExt { get; set; }

		// -(instancetype _Nonnull)initWithEvent:(NSString * _Nullable)aEvent customExt:(NSDictionary<NSString *,NSString *> * _Nullable)aCustomExt;
		[Export ("initWithEvent:customExt:")]
		NativeHandle Constructor ([NullAllowed] string aEvent, [NullAllowed] NSDictionary<NSString, NSString> aCustomExt);
	}

	// @interface AgoraChatCombineMessageBody : AgoraChatFileMessageBody
	[BaseType (typeof(AgoraChatFileMessageBody))]
	[DisableDefaultCtor]
	interface AgoraChatCombineMessageBody
	{
		// @property (nonatomic, strong) NSString * _Nullable title;
		[NullAllowed, Export ("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable summary;
		[NullAllowed, Export ("summary", ArgumentSemantic.Strong)]
		string Summary { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable compatibleText;
		[NullAllowed, Export ("compatibleText", ArgumentSemantic.Strong)]
		string CompatibleText { get; set; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull messageIdList;
		[Export ("messageIdList")]
		string[] MessageIdList { get; }

		// -(instancetype _Nonnull)initWithTitle:(NSString * _Nullable)aTitle summary:(NSString * _Nullable)aSummary compatibleText:(NSString * _Nullable)aCompatibleText messageIdList:(NSArray<NSString *> * _Nonnull)aMessageIdList;
		[Export ("initWithTitle:summary:compatibleText:messageIdList:")]
		NativeHandle Constructor ([NullAllowed] string aTitle, [NullAllowed] string aSummary, [NullAllowed] string aCompatibleText, string[] aMessageIdList);
	}

	// @interface AgoraChatGroupMessageAck : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatGroupMessageAck
	{
		// @property (copy, nonatomic) NSString * _Nonnull messageId;
		[Export ("messageId")]
		string MessageId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull readAckId;
		[Export ("readAckId")]
		string ReadAckId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull from;
		[Export ("from")]
		string From { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull content;
		[Export ("content")]
		string Content { get; set; }

		// @property (nonatomic) int readCount;
		[Export ("readCount")]
		int ReadCount { get; set; }

		// @property (nonatomic) long long timestamp;
		[Export ("timestamp")]
		long Timestamp { get; set; }
	}

	// @interface AgoraChatTranslateLanguage : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatTranslateLanguage : INativeObject
	{
		// @property (nonatomic, strong) NSString * _Nonnull languageCode;
		[Export ("languageCode", ArgumentSemantic.Strong)]
		string LanguageCode { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull languageName;
		[Export ("languageName", ArgumentSemantic.Strong)]
		string LanguageName { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull languageNativeName;
		[Export ("languageNativeName", ArgumentSemantic.Strong)]
		string LanguageNativeName { get; set; }
	}

	// @interface AgoraChatFetchServerMessagesOption : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatFetchServerMessagesOption
	{
		// @property (nonatomic, strong) NSString * _Nullable from;
		[NullAllowed, Export ("from", ArgumentSemantic.Strong)]
		string From { get; set; }

		// @property (nonatomic, strong) NSArray<NSNumber *> * _Nullable msgTypes;
		[NullAllowed, Export ("msgTypes", ArgumentSemantic.Strong)]
		NSNumber[] MsgTypes { get; set; }

		// @property (nonatomic) NSInteger startTime;
		[Export ("startTime")]
		nint StartTime { get; set; }

		// @property (nonatomic) NSInteger endTime;
		[Export ("endTime")]
		nint EndTime { get; set; }

		// @property (nonatomic) AgoraChatMessageSearchDirection direction;
		[Export ("direction", ArgumentSemantic.Assign)]
		AgoraChatMessageSearchDirection Direction { get; set; }

		// @property (nonatomic) BOOL isSave;
		[Export ("isSave")]
		bool IsSave { get; set; }
	}

	// @interface AgoraChatConversationFilter : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatConversationFilter
	{
		// @property (nonatomic) NSInteger pageSize;
		[Export ("pageSize")]
		nint PageSize { get; set; }

		// @property (nonatomic) AgoraChatMarkType mark;
		[Export ("mark", ArgumentSemantic.Assign)]
		AgoraChatMarkType Mark { get; set; }

		// -(instancetype _Nonnull)initWithMark:(AgoraChatMarkType)mark pageSize:(NSInteger)pageSize;
		[Export ("initWithMark:pageSize:")]
		NativeHandle Constructor (AgoraChatMarkType mark, nint pageSize);
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
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IAgoraChatManager
	{
		// @required -(void)addDelegate:(id<AgoraChatManagerDelegate> _Nullable)aDelegate delegateQueue:(dispatch_queue_t _Nullable)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate ([NullAllowed] AgoraChatManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id<AgoraChatManagerDelegate> _Nonnull)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (AgoraChatManagerDelegate aDelegate);

		// @required -(NSArray<AgoraChatConversation *> * _Nullable)getAllConversations;
		[Abstract]
		[NullAllowed, Export ("getAllConversations")]
		//[Verify (MethodToProperty)]
		AgoraChatConversation[] AllConversations { get; }

		// @required -(NSArray<AgoraChatConversation *> * _Nullable)filterConversationsFromDB:(BOOL)cleanMemoryCache filter:(BOOL (^ _Nullable)(AgoraChatConversation * _Nonnull))filter __attribute__((swift_name("filterConversationsFromDB(cleanMemoryCache:filter:)")));
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

		// @required -(void)getConversationsFromServer:(void (^ _Nullable)(NSArray<AgoraChatConversation *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("")));
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

		// @required -(void)getPinnedConversationsFromServerWithCursor:(NSString * _Nullable)cursor pageSize:(UInt8)limit completion:(void (^ _Nonnull)(AgoraChatCursorResult<AgoraChatConversation *> * _Nullable, AgoraChatError * _Nullable))completionBlock;
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

		// @required -(void)deleteConversation:(NSString * _Nonnull)aConversationId isDeleteMessages:(BOOL)aIsDeleteMessages completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
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

		// @required -(NSString * _Nullable)getMessageAttachmentPath:(NSString * _Nonnull)aConversationId;
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

		// @required -(void)sendGroupMessageReadAck:(NSString * _Nonnull)aMessageId toGroup:(NSString * _Nonnull)aGroupId content:(NSString * _Nullable)aContent completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
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
		[Abstract]
		[Export ("sendMessage:progress:completion:")]
		void SendMessage (AgoraChatMessage aMessage, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);

		// @required -(void)resendMessage:(AgoraChatMessage * _Nonnull)aMessage progress:(void (^ _Nullable)(int))aProgressBlock completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("resendMessage:progress:completion:")]
		void ResendMessage (AgoraChatMessage aMessage, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);

		// @required -(void)downloadMessageThumbnail:(AgoraChatMessage * _Nonnull)aMessage progress:(void (^ _Nullable)(int))aProgressBlock completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("downloadMessageThumbnail:progress:completion:")]
		void DownloadMessageThumbnail (AgoraChatMessage aMessage, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);

		// @required -(void)downloadMessageAttachment:(AgoraChatMessage * _Nonnull)aMessage progress:(void (^ _Nullable)(int))aProgressBlock completion:(void (^ _Nullable)(AgoraChatMessage * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("downloadMessageAttachment:progress:completion:")]
		void DownloadMessageAttachment (AgoraChatMessage aMessage, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatMessage, AgoraChatError> aCompletionBlock);

		// @required -(void)downloadAndParseCombineMessage:(AgoraChatMessage * _Nonnull)aMessage completion:(void (^ _Nullable)(NSArray<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("downloadAndParseCombineMessage:completion:")]
		void DownloadAndParseCombineMessage (AgoraChatMessage aMessage, [NullAllowed] Action<NSArray<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatCursorResult<AgoraChatMessage *> * _Nullable)fetchHistoryMessagesFromServer:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType startMessageId:(NSString * _Nullable)aStartMessageId fetchDirection:(AgoraChatMessageFetchHistoryDirection)direction pageSize:(int)aPageSize error:(AgoraChatError ** _Nullable)pError __attribute__((deprecated("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead")));
		[Abstract]
		[Export ("fetchHistoryMessagesFromServer:conversationType:startMessageId:fetchDirection:pageSize:error:")]
		[return: NullAllowed]
		AgoraChatCursorResult<AgoraChatMessage> FetchHistoryMessagesFromServer (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] string aStartMessageId, AgoraChatMessageFetchHistoryDirection direction, int aPageSize, out AgoraChatError pError);

		// @required -(AgoraChatCursorResult<AgoraChatMessage *> * _Nullable)fetchHistoryMessagesFromServer:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType startMessageId:(NSString * _Nullable)aStartMessageId pageSize:(int)aPageSize error:(AgoraChatError ** _Nullable)pError __attribute__((deprecated("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead")));
		[Abstract]
		[Export ("fetchHistoryMessagesFromServer:conversationType:startMessageId:pageSize:error:")]
		[return: NullAllowed]
		AgoraChatCursorResult<AgoraChatMessage> FetchHistoryMessagesFromServer (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] string aStartMessageId, int aPageSize, out AgoraChatError pError);

		// @required -(void)asyncFetchHistoryMessagesFromServer:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType startMessageId:(NSString * _Nullable)aStartMessageId pageSize:(int)aPageSize completion:(void (^ _Nullable)(AgoraChatCursorResult<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead")));
		[Abstract]
		[Export ("asyncFetchHistoryMessagesFromServer:conversationType:startMessageId:pageSize:completion:")]
		void AsyncFetchHistoryMessagesFromServer (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] string aStartMessageId, int aPageSize, [NullAllowed] Action<AgoraChatCursorResult<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// @required -(void)asyncFetchHistoryMessagesFromServer:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType startMessageId:(NSString * _Nullable)aStartMessageId fetchDirection:(AgoraChatMessageFetchHistoryDirection)direction pageSize:(int)aPageSize completion:(void (^ _Nullable)(AgoraChatCursorResult<AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("Use -fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion: instead")));
		[Abstract]
		[Export ("asyncFetchHistoryMessagesFromServer:conversationType:startMessageId:fetchDirection:pageSize:completion:")]
		void AsyncFetchHistoryMessagesFromServer (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] string aStartMessageId, AgoraChatMessageFetchHistoryDirection direction, int aPageSize, [NullAllowed] Action<AgoraChatCursorResult<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// @required -(void)asyncFetchGroupMessageAcksFromServer:(NSString * _Nonnull)aMessageId groupId:(NSString * _Nonnull)aGroupId startGroupAckId:(NSString * _Nonnull)aGroupAckId pageSize:(int)aPageSize completion:(void (^ _Nullable)(AgoraChatCursorResult<AgoraChatGroupMessageAck *> * _Nullable, AgoraChatError * _Nullable, int))aCompletionBlock;
		[Abstract]
		[Export ("asyncFetchGroupMessageAcksFromServer:groupId:startGroupAckId:pageSize:completion:")]
		void AsyncFetchGroupMessageAcksFromServer (string aMessageId, string aGroupId, string aGroupAckId, int aPageSize, [NullAllowed] Action<AgoraChatCursorResult<AgoraChatGroupMessageAck>, AgoraChatError, int> aCompletionBlock);

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
		[Abstract]
		[Export ("fetchSupportedLanguages:")]
		void FetchSupportedLanguages ([NullAllowed] Action<NSArray<AgoraChatTranslateLanguage>, AgoraChatError> aCompletionBlock);

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
		[Abstract]
		[Export ("fetchMessagesFromServerBy:conversationType:cursor:pageSize:option:completion:")]
		void FetchMessagesFromServerBy (string conversationId, AgoraChatConversationType type, [NullAllowed] string cursor, nuint pageSize, [NullAllowed] AgoraChatFetchServerMessagesOption option, [NullAllowed] Action<AgoraChatCursorResult<AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// @required -(void)addConversationMark:(NSArray<NSString *> * _Nonnull)conversationIds mark:(AgoraChatMarkType)mark completion:(void (^ _Nullable)(AgoraChatError * _Nullable))completion;
		[Abstract]
		[Export ("addConversationMark:mark:completion:")]
		void AddConversationMark (string[] conversationIds, AgoraChatMarkType mark, [NullAllowed] Action<AgoraChatError> completion);

		// @required -(void)removeConversationMark:(NSArray<NSString *> * _Nonnull)conversationIds mark:(AgoraChatMarkType)mark completion:(void (^ _Nullable)(AgoraChatError * _Nullable))completion;
		[Abstract]
		[Export ("removeConversationMark:mark:completion:")]
		void RemoveConversationMark (string[] conversationIds, AgoraChatMarkType mark, [NullAllowed] Action<AgoraChatError> completion);

		// @required -(void)getConversationsFromServerWithCursor:(NSString * _Nullable)cursor filter:(AgoraChatConversationFilter * _Nonnull)filter completion:(void (^ _Nonnull)(AgoraChatCursorResult<AgoraChatConversation *> * _Nullable, AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("getConversationsFromServerWithCursor:filter:completion:")]
		void GetConversationsFromServerWithCursor ([NullAllowed] string cursor, AgoraChatConversationFilter filter, Action<AgoraChatCursorResult<AgoraChatConversation>, AgoraChatError> completionBlock);

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
		void GetMessageCountWithCompletion (Action<nint, AgoraChatError> completion);
	}

	// @protocol AgoraChatroomManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AgoraChatroomManagerDelegate
	{
		// @optional -(void)userDidJoinChatroom:(AgoraChatroom * _Nonnull)aChatroom user:(NSString * _Nonnull)aUsername ext:(NSString * _Nullable)ext;
		[Export ("userDidJoinChatroom:user:ext:")]
		void UserDidJoinChatroom (AgoraChatroom aChatroom, string aUsername, [NullAllowed] string ext);

		// @optional -(void)userDidLeaveChatroom:(AgoraChatroom * _Nonnull)aChatroom user:(NSString * _Nonnull)aUsername;
		[Export ("userDidLeaveChatroom:user:")]
		void UserDidLeaveChatroom (AgoraChatroom aChatroom, string aUsername);

		// @optional -(void)didDismissFromChatroom:(AgoraChatroom * _Nonnull)aChatroom reason:(AgoraChatroomBeKickedReason)aReason;
		[Export ("didDismissFromChatroom:reason:")]
		void DidDismissFromChatroom (AgoraChatroom aChatroom, AgoraChatroomBeKickedReason aReason);

		// @optional -(void)chatroomSpecificationDidUpdate:(AgoraChatroom * _Nonnull)aChatroom;
		[Export ("chatroomSpecificationDidUpdate:")]
		void ChatroomSpecificationDidUpdate (AgoraChatroom aChatroom);

		// @optional -(void)chatroomMuteListDidUpdate:(AgoraChatroom * _Nonnull)aChatroom addedMutedMembers:(NSArray<NSString *> * _Nonnull)aMutes muteExpire:(NSInteger)aMuteExpire;
		[Export ("chatroomMuteListDidUpdate:addedMutedMembers:muteExpire:")]
		void ChatroomMuteListDidUpdate (AgoraChatroom aChatroom, string[] aMutes, nint aMuteExpire);

		// @optional -(void)chatroomMuteListDidUpdate:(AgoraChatroom * _Nonnull)aChatroom removedMutedMembers:(NSArray<NSString *> * _Nonnull)aMutes;
		[Export ("chatroomMuteListDidUpdate:removedMutedMembers:")]
		void ChatroomMuteListDidUpdate (AgoraChatroom aChatroom, string[] aMutes);

		// @optional -(void)chatroomWhiteListDidUpdate:(AgoraChatroom * _Nonnull)aChatroom addedWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers;
		[Export ("chatroomWhiteListDidUpdateAdded:addedWhiteListMembers:")]
		void ChatroomWhiteListDidUpdateAdded (AgoraChatroom aChatroom, string[] aMembers);

		// @optional -(void)chatroomWhiteListDidUpdate:(AgoraChatroom * _Nonnull)aChatroom removedWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers;
		[Export ("chatroomWhiteListDidUpdateRemoved:removedWhiteListMembers:")]
		void ChatroomWhiteListDidUpdateRemoved (AgoraChatroom aChatroom, string[] aMembers);

		// @optional -(void)chatroomAllMemberMuteChanged:(AgoraChatroom * _Nonnull)aChatroom isAllMemberMuted:(BOOL)aMuted;
		[Export ("chatroomAllMemberMuteChanged:isAllMemberMuted:")]
		void ChatroomAllMemberMuteChanged (AgoraChatroom aChatroom, bool aMuted);

		// @optional -(void)chatroomAdminListDidUpdate:(AgoraChatroom * _Nonnull)aChatroom addedAdmin:(NSString * _Nonnull)aAdmin;
		[Export ("chatroomAdminListDidUpdateAdded:addedAdmin:")]
		void ChatroomAdminListDidUpdateAdded (AgoraChatroom aChatroom, string aAdmin);

		// @optional -(void)chatroomAdminListDidUpdate:(AgoraChatroom * _Nonnull)aChatroom removedAdmin:(NSString * _Nonnull)aAdmin;
		[Export ("chatroomAdminListDidUpdateRemoved:removedAdmin:")]
		void ChatroomAdminListDidUpdateRemoved (AgoraChatroom aChatroom, string aAdmin);

		// @optional -(void)chatroomOwnerDidUpdate:(AgoraChatroom * _Nonnull)aChatroom newOwner:(NSString * _Nonnull)aNewOwner oldOwner:(NSString * _Nonnull)aOldOwner;
		[Export ("chatroomOwnerDidUpdate:newOwner:oldOwner:")]
		void ChatroomOwnerDidUpdate (AgoraChatroom aChatroom, string aNewOwner, string aOldOwner);

		// @optional -(void)chatroomAnnouncementDidUpdate:(AgoraChatroom * _Nonnull)aChatroom announcement:(NSString * _Nullable)aAnnouncement;
		[Export ("chatroomAnnouncementDidUpdate:announcement:")]
		void ChatroomAnnouncementDidUpdate (AgoraChatroom aChatroom, [NullAllowed] string aAnnouncement);

		// @optional -(void)chatroomAttributesDidUpdated:(NSString * _Nonnull)roomId attributeMap:(NSDictionary<NSString *,NSString *> * _Nonnull)attributeMap from:(NSString * _Nonnull)fromId;
		[Export ("chatroomAttributesDidUpdated:attributeMap:from:")]
		void ChatroomAttributesDidUpdated (string roomId, NSDictionary<NSString, NSString> attributeMap, string fromId);

		// @optional -(void)chatroomAttributesDidRemoved:(NSString * _Nonnull)roomId attributes:(NSArray<__kindof NSString *> * _Nonnull)attributes from:(NSString * _Nonnull)fromId;
		[Export ("chatroomAttributesDidRemoved:attributes:from:")]
		void ChatroomAttributesDidRemoved (string roomId, string[] attributes, string fromId);

		// @optional -(void)didReceiveUserJoinedChatroom:(AgoraChatroom * _Nonnull)aChatroom username:(NSString * _Nonnull)aUsername __attribute__((deprecated("Use -userDidJoinChatroom:user: instead")));
		[Export ("didReceiveUserJoinedChatroom:username:")]
		void DidReceiveUserJoinedChatroom (AgoraChatroom aChatroom, string aUsername);

		// @optional -(void)didReceiveUserLeavedChatroom:(AgoraChatroom * _Nonnull)aChatroom username:(NSString * _Nonnull)aUsername __attribute__((deprecated("Use -userDidLeaveChatroom:reason: instead")));
		[Export ("didReceiveUserLeavedChatroom:username:")]
		void DidReceiveUserLeavedChatroom (AgoraChatroom aChatroom, string aUsername);

		// @optional -(void)didReceiveKickedFromChatroom:(AgoraChatroom * _Nonnull)aChatroom reason:(AgoraChatroomBeKickedReason)aReason __attribute__((deprecated("Use -didDismissFromChatroom:reason: instead")));
		[Export ("didReceiveKickedFromChatroom:reason:")]
		void DidReceiveKickedFromChatroom (AgoraChatroom aChatroom, AgoraChatroomBeKickedReason aReason);

		// @optional -(void)userDidJoinChatroom:(AgoraChatroom * _Nonnull)aChatroom user:(NSString * _Nonnull)aUsername __attribute__((deprecated("Use -userDidJoinChatroom:user:ext: instead")));
		[Export ("userDidJoinChatroom:user:")]
		void UserDidJoinChatroom (AgoraChatroom aChatroom, string aUsername);
	}

	// @interface AgoraChatroomOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatroomOptions
	{
		// @property (nonatomic) NSInteger maxUsersCount;
		[Export ("maxUsersCount")]
		nint MaxUsersCount { get; set; }
	}

	// @interface AgoraChatroom : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatroom
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable chatroomId;
		[NullAllowed, Export ("chatroomId")]
		string ChatroomId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable subject;
		[NullAllowed, Export ("subject")]
		string Subject { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable description;
		[NullAllowed, Export ("description")]
		string Description { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable owner;
		[NullAllowed, Export ("owner")]
		string Owner { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable announcement;
		[NullAllowed, Export ("announcement")]
		string Announcement { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable adminList;
		[NullAllowed, Export ("adminList", ArgumentSemantic.Copy)]
		string[] AdminList { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable memberList;
		[NullAllowed, Export ("memberList", ArgumentSemantic.Copy)]
		string[] MemberList { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nullable blacklist;
		[NullAllowed, Export ("blacklist", ArgumentSemantic.Strong)]
		string[] Blacklist { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nullable muteList;
		[NullAllowed, Export ("muteList", ArgumentSemantic.Strong)]
		string[] MuteList { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nullable whitelist;
		[NullAllowed, Export ("whitelist", ArgumentSemantic.Strong)]
		string[] Whitelist { get; }

		// @property (readonly, nonatomic) AgoraChatroomPermissionType permissionType;
		[Export ("permissionType")]
		AgoraChatroomPermissionType PermissionType { get; }

		// @property (readonly, nonatomic) NSInteger maxOccupantsCount;
		[Export ("maxOccupantsCount")]
		nint MaxOccupantsCount { get; }

		// @property (readonly, nonatomic) NSInteger occupantsCount;
		[Export ("occupantsCount")]
		nint OccupantsCount { get; }

		// @property (readonly, nonatomic) BOOL isMuteAllMembers;
		[Export ("isMuteAllMembers")]
		bool IsMuteAllMembers { get; }

		// +(instancetype _Nullable)chatroomWithId:(NSString * _Nonnull)aChatroomId;
		[Static]
		[Export ("chatroomWithId:")]
		[return: NullAllowed]
		AgoraChatroom ChatroomWithId (string aChatroomId);

		// @property (readonly, nonatomic, strong) NSArray * whiteList __attribute__((deprecated("Use whitelist instead")));
		[Export ("whiteList", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] WhiteList { get; }

		// @property (readonly, copy, nonatomic) NSArray * members __attribute__((deprecated("")));
		[Export ("members", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Members { get; }

		// @property (readonly, nonatomic) NSInteger membersCount __attribute__((deprecated("")));
		[Export ("membersCount")]
		nint MembersCount { get; }

		// @property (readonly, nonatomic) NSInteger maxMembersCount __attribute__((deprecated("")));
		[Export ("maxMembersCount")]
		nint MaxMembersCount { get; }

		// @property (readonly, copy, nonatomic) NSArray * occupants __attribute__((deprecated("Use -members instead")));
		[Export ("occupants", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Occupants { get; }
	}

	// audit-objc-generics: @interface AgoraChatPageResult<__covariant ObjectType> : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatPageResult<T> : INativeObject
	{
		// @property (nonatomic, strong) NSArray<ObjectType> * _Nullable list;
		[NullAllowed, Export ("list", ArgumentSemantic.Strong)]
		NSObject[] List { get; set; }

		// @property (nonatomic) NSInteger count;
		[Export ("count")]
		nint Count { get; set; }

		// +(instancetype _Nonnull)pageResultWithList:(NSArray<ObjectType> * _Nullable)aList andCount:(NSInteger)aCount;
		[Static]
		[Export ("pageResultWithList:andCount:")]
		AgoraChatPageResult<T> PageResultWithList ([NullAllowed] NSObject[] aList, nint aCount);
	}

	// @protocol IAgoraChatroomManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IAgoraChatroomManager
	{
		// @required -(void)addDelegate:(id<AgoraChatroomManagerDelegate> _Nonnull)aDelegate delegateQueue:(dispatch_queue_t _Nullable)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (AgoraChatroomManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id<AgoraChatroomManagerDelegate> _Nonnull)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (AgoraChatroomManagerDelegate aDelegate);

		// @required -(AgoraChatPageResult<AgoraChatroom *> * _Nullable)getChatroomsFromServerWithPage:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getChatroomsFromServerWithPage:pageSize:error:")]
		[return: NullAllowed]
		AgoraChatPageResult<AgoraChatroom> GetChatroomsFromServerWithPage (nint aPageNum, nint aPageSize, out AgoraChatError pError);

		// @required -(void)getChatroomsFromServerWithPage:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(AgoraChatPageResult<AgoraChatroom *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomsFromServerWithPage:pageSize:completion:")]
		void GetChatroomsFromServerWithPage (nint aPageNum, nint aPageSize, [NullAllowed] Action<AgoraChatPageResult<AgoraChatroom>, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)createChatroomWithSubject:(NSString * _Nullable)aSubject description:(NSString * _Nullable)aDescription invitees:(NSArray<NSString *> * _Nullable)aInvitees message:(NSString * _Nullable)aMessage maxMembersCount:(NSInteger)aMaxMembersCount error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("createChatroomWithSubject:description:invitees:message:maxMembersCount:error:")]
		[return: NullAllowed]
		AgoraChatroom CreateChatroomWithSubject ([NullAllowed] string aSubject, [NullAllowed] string aDescription, [NullAllowed] string[] aInvitees, [NullAllowed] string aMessage, nint aMaxMembersCount, out AgoraChatError pError);

		// @required -(void)createChatroomWithSubject:(NSString * _Nullable)aSubject description:(NSString * _Nullable)aDescription invitees:(NSArray<NSString *> * _Nullable)aInvitees message:(NSString * _Nullable)aMessage maxMembersCount:(NSInteger)aMaxMembersCount completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("createChatroomWithSubject:description:invitees:message:maxMembersCount:completion:")]
		void CreateChatroomWithSubject ([NullAllowed] string aSubject, [NullAllowed] string aDescription, [NullAllowed] string[] aInvitees, [NullAllowed] string aMessage, nint aMaxMembersCount, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom *)joinChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("joinChatroom:error:")]
		AgoraChatroom JoinChatroom (string aChatroomId, out AgoraChatError pError);

		// @required -(void)joinChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("joinChatroom:completion:")]
		void JoinChatroom (string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(void)joinChatroom:(NSString * _Nonnull)aChatroomId ext:(NSString * _Nullable)ext leaveOtherRooms:(BOOL)leaveOtherRooms completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("joinChatroom:ext:leaveOtherRooms:completion:")]
		void JoinChatroom (string aChatroomId, [NullAllowed] string ext, bool leaveOtherRooms, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(void)leaveChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("leaveChatroom:error:")]
		void LeaveChatroom (string aChatroomId, out AgoraChatError pError);

		// @required -(void)leaveChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("leaveChatroom:completion:")]
		void LeaveChatroom (string aChatroomId, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError * _Nullable)destroyChatroom:(NSString * _Nonnull)aChatroomId;
		[Abstract]
		[Export ("destroyChatroom:")]
		[return: NullAllowed]
		AgoraChatError DestroyChatroom (string aChatroomId);

		// @required -(void)destroyChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("destroyChatroom:completion:")]
		void DestroyChatroom (string aChatroomId, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)getChatroomSpecificationFromServerWithId:(NSString * _Nonnull)aChatroomId error:(AgoraChatError * _Nullable *)pError;
		[Abstract]
		[Export ("getChatroomSpecificationFromServerWithId:error:")]
		[return: NullAllowed]
		AgoraChatroom GetChatroomSpecificationFromServerWithId (string aChatroomId, [NullAllowed] out AgoraChatError pError);

		// @required -(void)getChatroomSpecificationFromServerWithId:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomSpecificationFromServerWithId:completion:")]
		void GetChatroomSpecificationFromServerWithId (string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(void)getChatroomSpecificationFromServerWithId:(NSString * _Nonnull)aChatroomId fetchMembers:(_Bool)aFetchMembers completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomSpecificationFromServerWithId:fetchMembers:completion:")]
		void GetChatroomSpecificationFromServerWithId (string aChatroomId, bool aFetchMembers, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatCursorResult<NSString *> * _Nullable)getChatroomMemberListFromServerWithId:(NSString * _Nonnull)aChatroomId cursor:(NSString * _Nullable)aCursor pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getChatroomMemberListFromServerWithId:cursor:pageSize:error:")]
		[return: NullAllowed]
		AgoraChatCursorResult<NSString> GetChatroomMemberListFromServerWithId (string aChatroomId, [NullAllowed] string aCursor, nint aPageSize, out AgoraChatError pError);

		// @required -(void)getChatroomMemberListFromServerWithId:(NSString * _Nonnull)aChatroomId cursor:(NSString * _Nullable)aCursor pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(AgoraChatCursorResult<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomMemberListFromServerWithId:cursor:pageSize:completion:")]
		void GetChatroomMemberListFromServerWithId (string aChatroomId, [NullAllowed] string aCursor, nint aPageSize, [NullAllowed] Action<AgoraChatCursorResult<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(NSArray<NSString *> * _Nullable)getChatroomBlacklistFromServerWithId:(NSString * _Nonnull)aChatroomId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getChatroomBlacklistFromServerWithId:pageNumber:pageSize:error:")]
		[return: NullAllowed]
		string[] GetChatroomBlacklistFromServerWithId (string aChatroomId, nint aPageNum, nint aPageSize, out AgoraChatError pError);

		// @required -(void)getChatroomBlacklistFromServerWithId:(NSString * _Nonnull)aChatroomId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(NSArray<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomBlacklistFromServerWithId:pageNumber:pageSize:completion:")]
		void GetChatroomBlacklistFromServerWithId (string aChatroomId, nint aPageNum, nint aPageSize, [NullAllowed] Action<NSArray<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(NSArray<NSString *> * _Nullable)getChatroomMuteListFromServerWithId:(NSString * _Nonnull)aChatroomId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getChatroomMuteListFromServerWithId:pageNumber:pageSize:error:")]
		[return: NullAllowed]
		string[] GetChatroomMuteListFromServerWithId (string aChatroomId, nint aPageNum, nint aPageSize, out AgoraChatError pError);

		// @required -(void)getChatroomMuteListFromServerWithId:(NSString * _Nonnull)aChatroomId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(NSArray<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomMuteListFromServerWithId:pageNumber:pageSize:completion:")]
		void GetChatroomMuteListFromServerWithId (string aChatroomId, nint aPageNum, nint aPageSize, [NullAllowed] Action<NSArray<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(NSArray<NSString *> * _Nullable)getChatroomWhiteListFromServerWithId:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getChatroomWhiteListFromServerWithId:error:")]
		[return: NullAllowed]
		string[] GetChatroomWhiteListFromServerWithId (string aChatroomId, out AgoraChatError pError);

		// @required -(void)getChatroomWhiteListFromServerWithId:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(NSArray<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomWhiteListFromServerWithId:completion:")]
		void GetChatroomWhiteListFromServerWithId (string aChatroomId, [NullAllowed] Action<NSArray<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(BOOL)isMemberInWhiteListFromServerWithChatroomId:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("isMemberInWhiteListFromServerWithChatroomId:error:")]
		bool IsMemberInWhiteListFromServerWithChatroomId (string aChatroomId, out AgoraChatError pError);

		// @required -(void)isMemberInWhiteListFromServerWithChatroomId:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(BOOL, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("isMemberInWhiteListFromServerWithChatroomId:completion:")]
		void IsMemberInWhiteListFromServerWithChatroomId (string aChatroomId, [NullAllowed] Action<bool, AgoraChatError> aCompletionBlock);

		// @required -(void)isMemberInMuteListFromServerWithChatroomId:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(BOOL, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("isMemberInMuteListFromServerWithChatroomId:completion:")]
		void IsMemberInMuteListFromServerWithChatroomId (string aChatroomId, [NullAllowed] Action<bool, AgoraChatError> aCompletionBlock);

		// @required -(NSString * _Nullable)getChatroomAnnouncementWithId:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getChatroomAnnouncementWithId:error:")]
		[return: NullAllowed]
		string GetChatroomAnnouncementWithId (string aChatroomId, out AgoraChatError pError);

		// @required -(void)getChatroomAnnouncementWithId:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatroomAnnouncementWithId:completion:")]
		void GetChatroomAnnouncementWithId (string aChatroomId, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom *)updateSubject:(NSString * _Nullable)aSubject forChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("updateSubject:forChatroom:error:")]
		AgoraChatroom UpdateSubject ([NullAllowed] string aSubject, string aChatroomId, out AgoraChatError pError);

		// @required -(void)updateSubject:(NSString * _Nullable)aSubject forChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateSubject:forChatroom:completion:")]
		void UpdateSubject ([NullAllowed] string aSubject, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)updateDescription:(NSString * _Nullable)aDescription forChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("updateDescription:forChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom UpdateDescription ([NullAllowed] string aDescription, string aChatroomId, out AgoraChatError pError);

		// @required -(void)updateDescription:(NSString * _Nullable)aDescription forChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateDescription:forChatroom:completion:")]
		void UpdateDescription ([NullAllowed] string aDescription, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)removeMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("removeMembers:fromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom RemoveMembers (string[] aMembers, string aChatroomId, out AgoraChatError pError);

		// @required -(void)removeMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeMembers:fromChatroom:completion:")]
		void RemoveMembers (string[] aMembers, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)blockMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("blockMembers:fromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom BlockMembers (string[] aMembers, string aChatroomId, out AgoraChatError pError);

		// @required -(void)blockMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("blockMembers:fromChatroom:completion:")]
		void BlockMembers (string[] aMembers, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)unblockMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("unblockMembers:fromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom UnblockMembers (string[] aMembers, string aChatroomId, out AgoraChatError pError);

		// @required -(void)unblockMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("unblockMembers:fromChatroom:completion:")]
		void UnblockMembers (string[] aMembers, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)updateChatroomOwner:(NSString * _Nonnull)aChatroomId newOwner:(NSString * _Nonnull)aNewOwner error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("updateChatroomOwner:newOwner:error:")]
		[return: NullAllowed]
		AgoraChatroom UpdateChatroomOwner (string aChatroomId, string aNewOwner, out AgoraChatError pError);

		// @required -(void)updateChatroomOwner:(NSString * _Nonnull)aChatroomId newOwner:(NSString * _Nonnull)aNewOwner completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateChatroomOwner:newOwner:completion:")]
		void UpdateChatroomOwner (string aChatroomId, string aNewOwner, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)addAdmin:(NSString * _Nonnull)aAdmin toChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("addAdmin:toChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom AddAdmin (string aAdmin, string aChatroomId, out AgoraChatError pError);

		// @required -(void)addAdmin:(NSString * _Nonnull)aAdmin toChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("addAdmin:toChatroom:completion:")]
		void AddAdmin (string aAdmin, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)removeAdmin:(NSString * _Nonnull)aAdmin fromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("removeAdmin:fromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom RemoveAdmin (string aAdmin, string aChatroomId, out AgoraChatError pError);

		// @required -(void)removeAdmin:(NSString * _Nonnull)aAdmin fromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeAdmin:fromChatroom:completion:")]
		void RemoveAdmin (string aAdmin, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)muteMembers:(NSArray<NSString *> * _Nonnull)aMuteMembers muteMilliseconds:(NSInteger)aMuteMilliseconds fromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("muteMembers:muteMilliseconds:fromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom MuteMembers (string[] aMuteMembers, nint aMuteMilliseconds, string aChatroomId, out AgoraChatError pError);

		// @required -(void)muteMembers:(NSArray<NSString *> * _Nonnull)aMuteMembers muteMilliseconds:(NSInteger)aMuteMilliseconds fromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("muteMembers:muteMilliseconds:fromChatroom:completion:")]
		void MuteMembers (string[] aMuteMembers, nint aMuteMilliseconds, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)unmuteMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("unmuteMembers:fromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom UnmuteMembers (string[] aMembers, string aChatroomId, out AgoraChatError pError);

		// @required -(void)unmuteMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("unmuteMembers:fromChatroom:completion:")]
		void UnmuteMembers (string[] aMembers, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)muteAllMembersFromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("muteAllMembersFromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom MuteAllMembersFromChatroom (string aChatroomId, out AgoraChatError pError);

		// @required -(void)muteAllMembersFromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("muteAllMembersFromChatroom:completion:")]
		void MuteAllMembersFromChatroom (string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)unmuteAllMembersFromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("unmuteAllMembersFromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom UnmuteAllMembersFromChatroom (string aChatroomId, out AgoraChatError pError);

		// @required -(void)unmuteAllMembersFromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("unmuteAllMembersFromChatroom:completion:")]
		void UnmuteAllMembersFromChatroom (string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)addWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("addWhiteListMembers:fromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom AddWhiteListMembers (string[] aMembers, string aChatroomId, out AgoraChatError pError);

		// @required -(void)addWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("addWhiteListMembers:fromChatroom:completion:")]
		void AddWhiteListMembers (string[] aMembers, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)removeWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("removeWhiteListMembers:fromChatroom:error:")]
		[return: NullAllowed]
		AgoraChatroom RemoveWhiteListMembers (string[] aMembers, string aChatroomId, out AgoraChatError pError);

		// @required -(void)removeWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers fromChatroom:(NSString * _Nonnull)aChatroomId completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeWhiteListMembers:fromChatroom:completion:")]
		void RemoveWhiteListMembers (string[] aMembers, string aChatroomId, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatroom * _Nullable)updateChatroomAnnouncementWithId:(NSString * _Nonnull)aChatroomId announcement:(NSString * _Nullable)aAnnouncement error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("updateChatroomAnnouncementWithId:announcement:error:")]
		[return: NullAllowed]
		AgoraChatroom UpdateChatroomAnnouncementWithId (string aChatroomId, [NullAllowed] string aAnnouncement, out AgoraChatError pError);

		// @required -(void)updateChatroomAnnouncementWithId:(NSString * _Nonnull)aChatroomId announcement:(NSString * _Nullable)aAnnouncement completion:(void (^ _Nullable)(AgoraChatroom * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateChatroomAnnouncementWithId:announcement:completion:")]
		void UpdateChatroomAnnouncementWithId (string aChatroomId, [NullAllowed] string aAnnouncement, [NullAllowed] Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(void)setChatroomAttributes:(NSString * _Nonnull)roomId attributes:(NSDictionary<NSString *,NSString *> * _Nonnull)keyValues autoDelete:(BOOL)autoDelete completionBlock:(void (^ _Nullable)(AgoraChatError * _Nullable, NSDictionary<NSString *,AgoraChatError *> * _Nullable))completionBlock;
		[Abstract]
		[Export ("setChatroomAttributes:attributes:autoDelete:completionBlock:")]
		void SetChatroomAttributes (string roomId, NSDictionary<NSString, NSString> keyValues, bool autoDelete, [NullAllowed] Action<AgoraChatError, NSDictionary<NSString, AgoraChatError>> completionBlock);

		// @required -(void)setChatroomAttribute:(NSString * _Nonnull)roomId key:(NSString * _Nonnull)key value:(NSString * _Nonnull)value autoDelete:(BOOL)autoDelete completionBlock:(void (^ _Nullable)(AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("setChatroomAttribute:key:value:autoDelete:completionBlock:")]
		void SetChatroomAttribute (string roomId, string key, string value, bool autoDelete, [NullAllowed] Action<AgoraChatError> completionBlock);

		// @required -(void)setChatroomAttributesForced:(NSString * _Nonnull)roomId attributes:(NSDictionary<NSString *,NSString *> * _Nonnull)keyValues autoDelete:(BOOL)autoDelete completionBlock:(void (^ _Nullable)(AgoraChatError * _Nullable, NSDictionary<NSString *,AgoraChatError *> * _Nullable))completionBlock;
		[Abstract]
		[Export ("setChatroomAttributesForced:attributes:autoDelete:completionBlock:")]
		void SetChatroomAttributesForced (string roomId, NSDictionary<NSString, NSString> keyValues, bool autoDelete, [NullAllowed] Action<AgoraChatError, NSDictionary<NSString, AgoraChatError>> completionBlock);

		// @required -(void)setChatroomAttributeForced:(NSString * _Nonnull)roomId key:(NSString * _Nonnull)key value:(NSString * _Nonnull)value autoDelete:(BOOL)autoDelete completionBlock:(void (^ _Nullable)(AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("setChatroomAttributeForced:key:value:autoDelete:completionBlock:")]
		void SetChatroomAttributeForced (string roomId, string key, string value, bool autoDelete, [NullAllowed] Action<AgoraChatError> completionBlock);

		// @required -(void)removeChatroomAttributes:(NSString * _Nonnull)roomId attributes:(NSArray<__kindof NSString *> * _Nonnull)keyValues completionBlock:(void (^ _Nullable)(AgoraChatError * _Nullable, NSDictionary<NSString *,AgoraChatError *> * _Nullable))completionBlock;
		[Abstract]
		[Export ("removeChatroomAttributes:attributes:completionBlock:")]
		void RemoveChatroomAttributes (string roomId, string[] keyValues, [NullAllowed] Action<AgoraChatError, NSDictionary<NSString, AgoraChatError>> completionBlock);

		// @required -(void)removeChatroomAttribute:(NSString * _Nonnull)roomId key:(NSString * _Nonnull)key completionBlock:(void (^ _Nullable)(AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("removeChatroomAttribute:key:completionBlock:")]
		void RemoveChatroomAttribute (string roomId, string key, [NullAllowed] Action<AgoraChatError> completionBlock);

		// @required -(void)removeChatroomAttributesForced:(NSString * _Nonnull)roomId attributes:(NSArray<__kindof NSString *> * _Nonnull)keyValues completionBlock:(void (^ _Nullable)(AgoraChatError * _Nullable, NSDictionary<NSString *,AgoraChatError *> * _Nullable))completionBlock;
		[Abstract]
		[Export ("removeChatroomAttributesForced:attributes:completionBlock:")]
		void RemoveChatroomAttributesForced (string roomId, string[] keyValues, [NullAllowed] Action<AgoraChatError, NSDictionary<NSString, AgoraChatError>> completionBlock);

		// @required -(void)removeChatroomAttributeForced:(NSString * _Nonnull)roomId key:(NSString * _Nonnull)key completionBlock:(void (^ _Nullable)(AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("removeChatroomAttributeForced:key:completionBlock:")]
		void RemoveChatroomAttributeForced (string roomId, string key, [NullAllowed] Action<AgoraChatError> completionBlock);

		// @required -(void)fetchChatroomAttributes:(NSString * _Nonnull)roomId keys:(NSArray<__kindof NSString *> * _Nullable)keys completion:(void (^ _Nullable)(AgoraChatError * _Nullable, NSDictionary<NSString *,NSString *> * _Nullable))completionBlock;
		[Abstract]
		[Export ("fetchChatroomAttributes:keys:completion:")]
		void FetchChatroomAttributes (string roomId, [NullAllowed] string[] keys, [NullAllowed] Action<AgoraChatError, NSDictionary<NSString, NSString>> completionBlock);

		// @required -(void)fetchChatroomAllAttributes:(NSString * _Nonnull)roomId completion:(void (^ _Nullable)(AgoraChatError * _Nullable, NSDictionary<NSString *,NSString *> * _Nullable))completionBlock;
		[Abstract]
		[Export ("fetchChatroomAllAttributes:completion:")]
		void FetchChatroomAllAttributes (string roomId, [NullAllowed] Action<AgoraChatError, NSDictionary<NSString, NSString>> completionBlock);

		// @required -(AgoraChatroom *)fetchChatroomInfo:(NSString *)aChatroomId includeMembersList:(BOOL)aIncludeMembersList error:(AgoraChatError **)pError __attribute__((deprecated("")));
		[Abstract]
		[Export ("fetchChatroomInfo:includeMembersList:error:")]
		AgoraChatroom FetchChatroomInfo (string aChatroomId, bool aIncludeMembersList, out AgoraChatError pError);

		// @required -(void)getChatroomSpecificationFromServerByID:(NSString *)aChatroomId includeMembersList:(BOOL)aIncludeMembersList completion:(void (^)(AgoraChatroom *, AgoraChatError *))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("getChatroomSpecificationFromServerByID:includeMembersList:completion:")]
		void GetChatroomSpecificationFromServerByID (string aChatroomId, bool aIncludeMembersList, Action<AgoraChatroom, AgoraChatError> aCompletionBlock);

		// @required -(void)addDelegate:(id<AgoraChatroomManagerDelegate>)aDelegate __attribute__((deprecated("")));
		[Abstract]
		[Export ("addDelegate:")]
		void AddDelegate (AgoraChatroomManagerDelegate aDelegate);

		// @required -(NSArray *)getAllChatroomsFromServerWithError:(AgoraChatError **)pError __attribute__((deprecated("Use -getChatroomsFromServerWithPage instead")));
		[Abstract]
		[Export ("getAllChatroomsFromServerWithError:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetAllChatroomsFromServerWithError (out AgoraChatError pError);

		// @required -(void)getAllChatroomsFromServerWithCompletion:(void (^)(NSArray *, AgoraChatError *))aCompletionBlock __attribute__((deprecated("Use -getChatroomsFromServerWithPage instead")));
		[Abstract]
		[Export ("getAllChatroomsFromServerWithCompletion:")]
		void GetAllChatroomsFromServerWithCompletion (Action<NSArray, AgoraChatError> aCompletionBlock);

		// @required -(void)asyncGetAllChatroomsFromServer:(void (^)(NSArray *))aSuccessBlock failure:(void (^)(AgoraChatError *))aFailureBlock __attribute__((deprecated("Use -getAllChatroomsFromServerWithCompletion: instead")));
		[Abstract]
		[Export ("asyncGetAllChatroomsFromServer:failure:")]
		void AsyncGetAllChatroomsFromServer (Action<NSArray> aSuccessBlock, Action<AgoraChatError> aFailureBlock);

		// @required -(void)asyncJoinChatroom:(NSString *)aChatroomId success:(void (^)(AgoraChatroom *))aSuccessBlock failure:(void (^)(AgoraChatError *))aFailureBlock __attribute__((deprecated("Use -joinChatroom:completion: instead")));
		[Abstract]
		[Export ("asyncJoinChatroom:success:failure:")]
		void AsyncJoinChatroom (string aChatroomId, Action<AgoraChatroom> aSuccessBlock, Action<AgoraChatError> aFailureBlock);

		// @required -(void)asyncLeaveChatroom:(NSString *)aChatroomId success:(void (^)(AgoraChatroom *))aSuccessBlock failure:(void (^)(AgoraChatError *))aFailureBlock __attribute__((deprecated("Use -leaveChatroom:completion: instead")));
		[Abstract]
		[Export ("asyncLeaveChatroom:success:failure:")]
		void AsyncLeaveChatroom (string aChatroomId, Action<AgoraChatroom> aSuccessBlock, Action<AgoraChatError> aFailureBlock);

		// @required -(void)asyncFetchChatroomInfo:(NSString *)aChatroomId includeMembersList:(BOOL)aIncludeMembersList success:(void (^)(AgoraChatroom *))aSuccessBlock failure:(void (^)(AgoraChatError *))aFailureBlock __attribute__((deprecated("Use -getChatroomSpecificationFromServerByID:includeMembersList:completion: instead")));
		[Abstract]
		[Export ("asyncFetchChatroomInfo:includeMembersList:success:failure:")]
		void AsyncFetchChatroomInfo (string aChatroomId, bool aIncludeMembersList, Action<AgoraChatroom> aSuccessBlock, Action<AgoraChatError> aFailureBlock);
	}

	// @protocol AgoraChatContactManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AgoraChatContactManagerDelegate
	{
		// @optional -(void)friendRequestDidApproveByUser:(NSString * _Nonnull)aUsername;
		[Export ("friendRequestDidApproveByUser:")]
		void FriendRequestDidApproveByUser (string aUsername);

		// @optional -(void)friendRequestDidDeclineByUser:(NSString * _Nonnull)aUsername;
		[Export ("friendRequestDidDeclineByUser:")]
		void FriendRequestDidDeclineByUser (string aUsername);

		// @optional -(void)friendshipDidRemoveByUser:(NSString * _Nonnull)aUsername;
		[Export ("friendshipDidRemoveByUser:")]
		void FriendshipDidRemoveByUser (string aUsername);

		// @optional -(void)friendshipDidAddByUser:(NSString * _Nonnull)aUsername;
		[Export ("friendshipDidAddByUser:")]
		void FriendshipDidAddByUser (string aUsername);

		// @optional -(void)friendRequestDidReceiveFromUser:(NSString * _Nonnull)aUsername message:(NSString * _Nullable)aMessage;
		[Export ("friendRequestDidReceiveFromUser:message:")]
		void FriendRequestDidReceiveFromUser (string aUsername, [NullAllowed] string aMessage);
	}

	// @interface AgoraChatContact : NSObject <NSCoding>
	[BaseType (typeof(NSObject))]
	interface AgoraChatContact : INSCoding
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull userId;
		[Export ("userId", ArgumentSemantic.Strong)]
		string UserId { get; }

		// @property (nonatomic, strong) NSString * _Nullable remark;
		[NullAllowed, Export ("remark", ArgumentSemantic.Strong)]
		string Remark { get; set; }

		// -(instancetype)initWithUserId:(NSString * _Nonnull)userId remark:(NSString * _Nullable)remark;
		[Export ("initWithUserId:remark:")]
		NativeHandle Constructor (string userId, [NullAllowed] string remark);
	}

	// @protocol IAgoraChatContactManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IAgoraChatContactManager
	{
		// @required -(void)addDelegate:(id<AgoraChatContactManagerDelegate> _Nonnull)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (AgoraChatContactManagerDelegate aDelegate, DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id _Nonnull)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NSObject aDelegate);

		// @required -(NSArray<NSString *> * _Nullable)getContacts;
		[Abstract]
		[NullAllowed, Export ("getContacts")]
		//[Verify (MethodToProperty)]
		string[] Contacts { get; }

		// @required -(NSArray<AgoraChatContact *> * _Nullable)getAllContacts;
		[Abstract]
		[NullAllowed, Export ("getAllContacts")]
		//[Verify (MethodToProperty)]
		AgoraChatContact[] AllContacts { get; }

		// @required -(void)setContactRemark:(NSString * _Nonnull)userId remark:(NSString * _Nullable)remark completion:(void (^ _Nullable)(AgoraChatContact * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("setContactRemark:remark:completion:")]
		void SetContactRemark (string userId, [NullAllowed] string remark, [NullAllowed] Action<AgoraChatContact, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatContact * _Nullable)getContact:(NSString * _Nonnull)userId;
		[Abstract]
		[Export ("getContact:")]
		[return: NullAllowed]
		AgoraChatContact GetContact (string userId);

		// @required -(void)getAllContactsFromServerWithCompletion:(void (^ _Nullable)(NSArray<AgoraChatContact *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getAllContactsFromServerWithCompletion:")]
		void GetAllContactsFromServerWithCompletion ([NullAllowed] Action<NSArray<AgoraChatContact>, AgoraChatError> aCompletionBlock);

		// @required -(void)getContactsFromServerWithCursor:(NSString * _Nullable)cursor pageSize:(NSUInteger)pageSize completion:(void (^ _Nonnull)(AgoraChatCursorResult<AgoraChatContact *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getContactsFromServerWithCursor:pageSize:completion:")]
		void GetContactsFromServerWithCursor ([NullAllowed] string cursor, nuint pageSize, Action<AgoraChatCursorResult<AgoraChatContact>, AgoraChatError> aCompletionBlock);

		// @required -(void)getContactsFromServerWithCompletion:(void (^)(NSArray<NSString *> * _Nullable, AgoraChatError *))aCompletionBlock;
		[Abstract]
		[Export ("getContactsFromServerWithCompletion:")]
		void GetContactsFromServerWithCompletion (Action<NSArray<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(NSArray<NSString *> * _Nullable)getContactsFromServerWithError:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getContactsFromServerWithError:")]
		[return: NullAllowed]
		string[] GetContactsFromServerWithError (out AgoraChatError pError);

		// @required -(AgoraChatError * _Nullable)addContact:(NSString * _Nonnull)aUsername message:(NSString * _Nullable)aMessage;
		[Abstract]
		[Export ("addContact:message:")]
		[return: NullAllowed]
		AgoraChatError AddContact (string aUsername, [NullAllowed] string aMessage);

		// @required -(void)addContact:(NSString * _Nonnull)aUsername message:(NSString * _Nullable)aMessage completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("addContact:message:completion:")]
		void AddContact (string aUsername, [NullAllowed] string aMessage, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError * _Nullable)deleteContact:(NSString * _Nonnull)aUsername isDeleteConversation:(BOOL)aIsDeleteConversation;
		[Abstract]
		[Export ("deleteContact:isDeleteConversation:")]
		[return: NullAllowed]
		AgoraChatError DeleteContact (string aUsername, bool aIsDeleteConversation);

		// @required -(void)deleteContact:(NSString * _Nonnull)aUsername isDeleteConversation:(BOOL)aIsDeleteConversation completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("deleteContact:isDeleteConversation:completion:")]
		void DeleteContact (string aUsername, bool aIsDeleteConversation, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(void)approveFriendRequestFromUser:(NSString * _Nonnull)aUsername completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("approveFriendRequestFromUser:completion:")]
		void ApproveFriendRequestFromUser (string aUsername, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(void)declineFriendRequestFromUser:(NSString * _Nonnull)aUsername completion:(void (^ _Nullable)(NSString *, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("declineFriendRequestFromUser:completion:")]
		void DeclineFriendRequestFromUser (string aUsername, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(NSArray<NSString *> * _Nullable)getBlackList;
		[Abstract]
		[NullAllowed, Export ("getBlackList")]
		//[Verify (MethodToProperty)]
		string[] BlackList { get; }

		// @required -(void)getBlackListFromServerWithCompletion:(void (^ _Nullable)(NSArray<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getBlackListFromServerWithCompletion:")]
		void GetBlackListFromServerWithCompletion ([NullAllowed] Action<NSArray<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(NSArray<NSString *> * _Nullable)getBlackListFromServerWithError:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getBlackListFromServerWithError:")]
		[return: NullAllowed]
		string[] GetBlackListFromServerWithError (out AgoraChatError pError);

		// @required -(AgoraChatError * _Nullable)addUserToBlackList:(NSString * _Nonnull)aUsername;
		[Abstract]
		[Export ("addUserToBlackList:")]
		[return: NullAllowed]
		AgoraChatError AddUserToBlackList (string aUsername);

		// @required -(void)addUserToBlackList:(NSString * _Nonnull)aUsername completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("addUserToBlackList:completion:")]
		void AddUserToBlackList (string aUsername, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError * _Nullable)removeUserFromBlackList:(NSString * _Nonnull)aUsername;
		[Abstract]
		[Export ("removeUserFromBlackList:")]
		[return: NullAllowed]
		AgoraChatError RemoveUserFromBlackList (string aUsername);

		// @required -(void)removeUserFromBlackList:(NSString * _Nonnull)aUsername completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeUserFromBlackList:completion:")]
		void RemoveUserFromBlackList (string aUsername, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError * _Nullable)acceptInvitationForUsername:(NSString * _Nonnull)aUsername;
		[Abstract]
		[Export ("acceptInvitationForUsername:")]
		[return: NullAllowed]
		AgoraChatError AcceptInvitationForUsername (string aUsername);

		// @required -(AgoraChatError * _Nullable)declineInvitationForUsername:(NSString * _Nonnull)aUsername;
		[Abstract]
		[Export ("declineInvitationForUsername:")]
		[return: NullAllowed]
		AgoraChatError DeclineInvitationForUsername (string aUsername);

		// @required -(NSArray<NSString *> * _Nullable)getSelfIdsOnOtherPlatformWithError:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getSelfIdsOnOtherPlatformWithError:")]
		[return: NullAllowed]
		string[] GetSelfIdsOnOtherPlatformWithError (out AgoraChatError pError);

		// @required -(void)getSelfIdsOnOtherPlatformWithCompletion:(void (^ _Nullable)(NSArray<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getSelfIdsOnOtherPlatformWithCompletion:")]
		void GetSelfIdsOnOtherPlatformWithCompletion ([NullAllowed] Action<NSArray<NSString>, AgoraChatError> aCompletionBlock);
	}

	// @protocol AgoraChatGroupManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AgoraChatGroupManagerDelegate
	{
		// @optional -(void)groupInvitationDidReceive:(NSString * _Nonnull)aGroupId groupName:(NSString * _Nonnull)aGroupName inviter:(NSString * _Nonnull)aInviter message:(NSString * _Nullable)aMessage;
		[Export ("groupInvitationDidReceive:groupName:inviter:message:")]
		void GroupInvitationDidReceive (string aGroupId, string aGroupName, string aInviter, [NullAllowed] string aMessage);

		// @optional -(void)groupInvitationDidAccept:(AgoraChatGroup * _Nonnull)aGroup invitee:(NSString * _Nonnull)aInvitee;
		[Export ("groupInvitationDidAccept:invitee:")]
		void GroupInvitationDidAccept (AgoraChatGroup aGroup, string aInvitee);

		// @optional -(void)groupInvitationDidDecline:(AgoraChatGroup * _Nonnull)aGroup invitee:(NSString * _Nonnull)aInvitee reason:(NSString * _Nullable)aReason;
		[Export ("groupInvitationDidDecline:invitee:reason:")]
		void GroupInvitationDidDecline (AgoraChatGroup aGroup, string aInvitee, [NullAllowed] string aReason);

		// @optional -(void)didJoinGroup:(AgoraChatGroup * _Nonnull)aGroup inviter:(NSString * _Nonnull)aInviter message:(NSString * _Nullable)aMessage;
		[Export ("didJoinGroup:inviter:message:")]
		void DidJoinGroup (AgoraChatGroup aGroup, string aInviter, [NullAllowed] string aMessage);

		// @optional -(void)didLeaveGroup:(AgoraChatGroup * _Nonnull)aGroup reason:(AgoraChatGroupLeaveReason)aReason;
		[Export ("didLeaveGroup:reason:")]
		void DidLeaveGroup (AgoraChatGroup aGroup, AgoraChatGroupLeaveReason aReason);

		// @optional -(void)joinGroupRequestDidReceive:(AgoraChatGroup * _Nonnull)aGroup user:(NSString * _Nonnull)aUsername reason:(NSString * _Nullable)aReason;
		[Export ("joinGroupRequestDidReceive:user:reason:")]
		void JoinGroupRequestDidReceive (AgoraChatGroup aGroup, string aUsername, [NullAllowed] string aReason);

		// @optional -(void)joinGroupRequestDidDecline:(NSString * _Nonnull)aGroupId reason:(NSString * _Nullable)aReason applicant:(NSString * _Nonnull)aApplicant;
		[Export ("joinGroupRequestDidDecline:reason:applicant:")]
		void JoinGroupRequestDidDecline (string aGroupId, [NullAllowed] string aReason, string aApplicant);

		// @optional -(void)joinGroupRequestDidDecline:(NSString * _Nonnull)aGroupId reason:(NSString * _Nullable)aReason decliner:(NSString * _Nullable)aDecliner applicant:(NSString * _Nonnull)aApplicant;
		[Export ("joinGroupRequestDidDecline:reason:decliner:applicant:")]
		void JoinGroupRequestDidDecline (string aGroupId, [NullAllowed] string aReason, [NullAllowed] string aDecliner, string aApplicant);

		// @optional -(void)joinGroupRequestDidApprove:(AgoraChatGroup * _Nonnull)aGroup;
		[Export ("joinGroupRequestDidApprove:")]
		void JoinGroupRequestDidApprove (AgoraChatGroup aGroup);

		// @optional -(void)groupListDidUpdate:(NSArray<AgoraChatGroup *> * _Nonnull)aGroupList;
		[Export ("groupListDidUpdate:")]
		void GroupListDidUpdate (AgoraChatGroup[] aGroupList);

		// @optional -(void)groupMuteListDidUpdate:(AgoraChatGroup * _Nonnull)aGroup addedMutedMembers:(NSArray<NSString *> * _Nonnull)aMutedMembers muteExpire:(NSInteger)aMuteExpire;
		[Export ("groupMuteListDidUpdate:addedMutedMembers:muteExpire:")]
		void GroupMuteListDidUpdate (AgoraChatGroup aGroup, string[] aMutedMembers, nint aMuteExpire);

		// @optional -(void)groupMuteListDidUpdate:(AgoraChatGroup * _Nonnull)aGroup removedMutedMembers:(NSArray<NSString *> * _Nonnull)aMutedMembers;
		[Export ("groupMuteListDidUpdate:removedMutedMembers:")]
		void GroupMuteListDidUpdate (AgoraChatGroup aGroup, string[] aMutedMembers);

		// @optional -(void)groupWhiteListDidUpdate:(AgoraChatGroup * _Nonnull)aGroup addedWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers;
		[Export ("groupWhiteListDidUpdateAdd:addedWhiteListMembers:")]
		void GroupWhiteListDidUpdateAdd (AgoraChatGroup aGroup, string[] aMembers);

		// @optional -(void)groupWhiteListDidUpdate:(AgoraChatGroup * _Nonnull)aGroup removedWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers;
		[Export ("groupWhiteListDidUpdateRemove:removedWhiteListMembers:")]
		void GroupWhiteListDidUpdateRemove (AgoraChatGroup aGroup, string[] aMembers);

		// @optional -(void)groupAllMemberMuteChanged:(AgoraChatGroup * _Nonnull)aGroup isAllMemberMuted:(BOOL)aMuted;
		[Export ("groupAllMemberMuteChanged:isAllMemberMuted:")]
		void GroupAllMemberMuteChanged (AgoraChatGroup aGroup, bool aMuted);

		// @optional -(void)groupAdminListDidUpdate:(AgoraChatGroup * _Nonnull)aGroup addedAdmin:(NSString * _Nonnull)aAdmin;
		[Export ("groupAdminListDidUpdateAdded:addedAdmin:")]
		void GroupAdminListDidUpdateAdded (AgoraChatGroup aGroup, string aAdmin);

		// @optional -(void)groupAdminListDidUpdate:(AgoraChatGroup * _Nonnull)aGroup removedAdmin:(NSString * _Nonnull)aAdmin;
		[Export ("groupAdminListDidUpdateRemoved:removedAdmin:")]
		void GroupAdminListDidUpdateRemoved (AgoraChatGroup aGroup, string aAdmin);

		// @optional -(void)groupOwnerDidUpdate:(AgoraChatGroup * _Nonnull)aGroup newOwner:(NSString * _Nonnull)aNewOwner oldOwner:(NSString * _Nonnull)aOldOwner;
		[Export ("groupOwnerDidUpdate:newOwner:oldOwner:")]
		void GroupOwnerDidUpdate (AgoraChatGroup aGroup, string aNewOwner, string aOldOwner);

		// @optional -(void)userDidJoinGroup:(AgoraChatGroup * _Nonnull)aGroup user:(NSString * _Nonnull)aUsername;
		[Export ("userDidJoinGroup:user:")]
		void UserDidJoinGroup (AgoraChatGroup aGroup, string aUsername);

		// @optional -(void)userDidLeaveGroup:(AgoraChatGroup * _Nonnull)aGroup user:(NSString * _Nonnull)aUsername;
		[Export ("userDidLeaveGroup:user:")]
		void UserDidLeaveGroup (AgoraChatGroup aGroup, string aUsername);

		// @optional -(void)groupAnnouncementDidUpdate:(AgoraChatGroup * _Nonnull)aGroup announcement:(NSString * _Nullable)aAnnouncement;
		[Export ("groupAnnouncementDidUpdate:announcement:")]
		void GroupAnnouncementDidUpdate (AgoraChatGroup aGroup, [NullAllowed] string aAnnouncement);

		// @optional -(void)groupFileListDidUpdate:(AgoraChatGroup * _Nonnull)aGroup addedSharedFile:(AgoraChatGroupSharedFile * _Nonnull)aSharedFile;
		[Export ("groupFileListDidUpdate:addedSharedFile:")]
		void GroupFileListDidUpdate (AgoraChatGroup aGroup, AgoraChatGroupSharedFile aSharedFile);

		// @optional -(void)groupFileListDidUpdate:(AgoraChatGroup * _Nonnull)aGroup removedSharedFile:(NSString * _Nonnull)aFileId;
		[Export ("groupFileListDidUpdate:removedSharedFile:")]
		void GroupFileListDidUpdate (AgoraChatGroup aGroup, string aFileId);

		// @optional -(void)groupStateChanged:(AgoraChatGroup *)aGroup isDisabled:(BOOL)aDisabled;
		[Export ("groupStateChanged:isDisabled:")]
		void GroupStateChanged (AgoraChatGroup aGroup, bool aDisabled);

		// @optional -(void)groupSpecificationDidUpdate:(AgoraChatGroup *)aGroup;
		[Export ("groupSpecificationDidUpdate:")]
		void GroupSpecificationDidUpdate (AgoraChatGroup aGroup);

		// @optional -(void)onAttributesChangedOfGroupMember:(NSString * _Nonnull)groupId userId:(NSString * _Nonnull)userId attributes:(NSDictionary<NSString *,NSString *> * _Nullable)attributes operatorId:(NSString * _Nonnull)operatorId;
		[Export ("onAttributesChangedOfGroupMember:userId:attributes:operatorId:")]
		void OnAttributesChangedOfGroupMember (string groupId, string userId, [NullAllowed] NSDictionary<NSString, NSString> attributes, string operatorId);

		// @optional -(void)groupInvitationDidReceive:(NSString *)aGroupId inviter:(NSString *)aInviter message:(NSString *)aMessage __attribute__((deprecated("Use -groupInvitationDidReceive:groupName:inviter:message: instead")));
		[Export ("groupInvitationDidReceive:inviter:message:")]
		void GroupInvitationDidReceive (string aGroupId, string aInviter, string aMessage);

		// @optional -(void)joinGroupRequestDidDecline:(NSString * _Nonnull)aGroupId reason:(NSString * _Nullable)aReason __attribute__((deprecated("")));
		[Export ("joinGroupRequestDidDecline:reason:")]
		void JoinGroupRequestDidDecline (string aGroupId, [NullAllowed] string aReason);
	}

	// @interface AgoraChatGroupOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatGroupOptions
	{
		// @property (nonatomic) AgoraChatGroupStyle style;
		[Export ("style", ArgumentSemantic.Assign)]
		AgoraChatGroupStyle Style { get; set; }

		// @property (nonatomic) NSInteger maxUsers;
		[Export ("maxUsers")]
		nint MaxUsers { get; set; }

		// @property (nonatomic) BOOL IsInviteNeedConfirm;
		[Export ("IsInviteNeedConfirm")]
		bool IsInviteNeedConfirm { get; set; }

		// @property (nonatomic, strong) NSString * ext;
		[Export ("ext", ArgumentSemantic.Strong)]
		string Ext { get; set; }

		// @property (nonatomic) NSInteger maxUsersCount __attribute__((deprecated("Use maxUsers instead")));
		[Export ("maxUsersCount")]
		nint MaxUsersCount { get; set; }
	}

	// @interface AgoraChatGroup : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatGroup : INativeObject
	{
		// @property (readonly, copy, nonatomic) NSString * groupId;
		[Export ("groupId")]
		string GroupId { get; }

		// @property (readonly, copy, nonatomic) NSString * groupName;
		[Export ("groupName")]
		string GroupName { get; }

		// @property (readonly, copy, nonatomic) NSString * description;
		[Export ("description")]
		string Description { get; }

		// @property (readonly, copy, nonatomic) NSString * announcement;
		[Export ("announcement")]
		string Announcement { get; }

		// @property (readonly, nonatomic, strong) AgoraChatGroupOptions * settings;
		[Export ("settings", ArgumentSemantic.Strong)]
		AgoraChatGroupOptions Settings { get; }

		// @property (readonly, copy, nonatomic) NSString * owner;
		[Export ("owner")]
		string Owner { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * adminList;
		[Export ("adminList", ArgumentSemantic.Copy)]
		string[] AdminList { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * memberList;
		[Export ("memberList", ArgumentSemantic.Copy)]
		string[] MemberList { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * blacklist;
		[Export ("blacklist", ArgumentSemantic.Strong)]
		string[] Blacklist { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * muteList;
		[Export ("muteList", ArgumentSemantic.Strong)]
		string[] MuteList { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * whiteList;
		[Export ("whiteList", ArgumentSemantic.Strong)]
		string[] WhiteList { get; }

		// @property (readonly, nonatomic, strong) NSArray<AgoraChatGroupSharedFile *> * sharedFileList;
		[Export ("sharedFileList", ArgumentSemantic.Strong)]
		AgoraChatGroupSharedFile[] SharedFileList { get; }

		// @property (readonly, nonatomic) BOOL isPushNotificationEnabled;
		[Export ("isPushNotificationEnabled")]
		bool IsPushNotificationEnabled { get; }

		// @property (readonly, nonatomic) BOOL isPublic;
		[Export ("isPublic")]
		bool IsPublic { get; }

		// @property (readonly, nonatomic) BOOL isBlocked;
		[Export ("isBlocked")]
		bool IsBlocked { get; }

		// @property (readonly, nonatomic) AgoraChatGroupPermissionType permissionType;
		[Export ("permissionType")]
		AgoraChatGroupPermissionType PermissionType { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * users;
		[Export ("users", ArgumentSemantic.Strong)]
		string[] Users { get; }

		// @property (readonly, nonatomic) NSInteger occupantsCount;
		[Export ("occupantsCount")]
		nint OccupantsCount { get; }

		// @property (readonly, nonatomic) BOOL isMuteAllMembers;
		[Export ("isMuteAllMembers")]
		bool IsMuteAllMembers { get; }

		// @property (readonly, nonatomic) BOOL isDisabled;
		[Export ("isDisabled")]
		bool IsDisabled { get; }

		// +(instancetype)groupWithId:(NSString *)aGroupId;
		[Static]
		[Export ("groupWithId:")]
		AgoraChatGroup GroupWithId (string aGroupId);

		// @property (readonly, nonatomic, strong) AgoraChatGroupOptions * setting __attribute__((deprecated("Use settings instead")));
		[Export ("setting", ArgumentSemantic.Strong)]
		AgoraChatGroupOptions Setting { get; }

		// @property (readonly, nonatomic, strong) NSArray * occupants __attribute__((deprecated("Use users instead")));
		[Export ("occupants", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Occupants { get; }
	}

	// @interface AgoraChatGroupSharedFile : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatGroupSharedFile : INativeObject
	{
		// @property (readonly, copy, nonatomic) NSString * fileId;
		[Export ("fileId")]
		string FileId { get; }

		// @property (readonly, copy, nonatomic) NSString * fileName;
		[Export ("fileName")]
		string FileName { get; }

		// @property (readonly, copy, nonatomic) NSString * fileOwner;
		[Export ("fileOwner")]
		string FileOwner { get; }

		// @property (nonatomic) long long createdAt;
		[Export ("createdAt")]
		long CreatedAt { get; set; }

		// @property (nonatomic) long long fileSize;
		[Export ("fileSize")]
		long FileSize { get; set; }

		// +(instancetype)sharedFileWithId:(NSString *)aFileId;
		[Static]
		[Export ("sharedFileWithId:")]
		AgoraChatGroupSharedFile SharedFileWithId (string aFileId);

		// @property (nonatomic) long long createTime __attribute__((deprecated("Use createdAt instead")));
		[Export ("createTime")]
		long CreateTime { get; set; }
	}

	// @protocol IAgoraChatGroupManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IAgoraChatGroupManager
	{
		// @required -(void)addDelegate:(id<AgoraChatGroupManagerDelegate> _Nonnull)aDelegate delegateQueue:(dispatch_queue_t _Nullable)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (AgoraChatGroupManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id _Nonnull)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (NSObject aDelegate);

		// @required -(NSArray<AgoraChatGroup *> * _Nullable)getJoinedGroups;
		[Abstract]
		[NullAllowed, Export ("getJoinedGroups")]
		//[Verify (MethodToProperty)]
		AgoraChatGroup[] JoinedGroups { get; }

		// @required -(void)cleanAllGroupsFromDB;
		[Abstract]
		[Export ("cleanAllGroupsFromDB")]
		void CleanAllGroupsFromDB ();

		// @required -(NSArray *)getGroupsWithoutPushNotification:(AgoraChatError **)pError __attribute__((deprecated("")));
		[Abstract]
		[Export ("getGroupsWithoutPushNotification:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetGroupsWithoutPushNotification (out AgoraChatError pError);

		// @required -(NSArray<AgoraChatGroup *> * _Nullable)getJoinedGroupsFromServerWithPage:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError __attribute__((deprecated("Use -getJoinedGroupsFromServerWithPage:pageSize:needMemberCount:needRole:error:completion: instead")));
		[Abstract]
		[Export ("getJoinedGroupsFromServerWithPage:pageSize:error:")]
		[return: NullAllowed]
		AgoraChatGroup[] GetJoinedGroupsFromServerWithPage (nint aPageNum, nint aPageSize, out AgoraChatError pError);

		// @required -(AgoraChatCursorResult<AgoraChatGroup *> * _Nullable)getPublicGroupsFromServerWithCursor:(NSString * _Nullable)aCursor pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getPublicGroupsFromServerWithCursor:pageSize:error:")]
		[return: NullAllowed]
		AgoraChatCursorResult<AgoraChatGroup> GetPublicGroupsFromServerWithCursor ([NullAllowed] string aCursor, nint aPageSize, out AgoraChatError pError);

		// @required -(void)getPublicGroupsFromServerWithCursor:(NSString * _Nullable)aCursor pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(AgoraChatCursorResult<AgoraChatGroup *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getPublicGroupsFromServerWithCursor:pageSize:completion:")]
		void GetPublicGroupsFromServerWithCursor ([NullAllowed] string aCursor, nint aPageSize, [NullAllowed] Action<AgoraChatCursorResult<AgoraChatGroup>, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)searchPublicGroupWithId:(NSString * _Nonnull)aGroundId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("searchPublicGroupWithId:error:")]
		[return: NullAllowed]
		AgoraChatGroup SearchPublicGroupWithId (string aGroundId, out AgoraChatError pError);

		// @required -(void)searchPublicGroupWithId:(NSString * _Nonnull)aGroundId completion:(void (^ _Nullable)(AgoraChatGroup *, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("searchPublicGroupWithId:completion:")]
		void SearchPublicGroupWithId (string aGroundId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(void)getJoinedGroupsCountFromServerWithCompletion:(void (^ _Nullable)(NSInteger, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getJoinedGroupsCountFromServerWithCompletion:")]
		void GetJoinedGroupsCountFromServerWithCompletion ([NullAllowed] Action<nint, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)createGroupWithSubject:(NSString * _Nullable)aSubject description:(NSString * _Nullable)aDescription invitees:(NSArray<NSString *> * _Nullable)aInvitees message:(NSString * _Nullable)aMessage setting:(AgoraChatGroupOptions * _Nullable)aSetting error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("createGroupWithSubject:description:invitees:message:setting:error:")]
		[return: NullAllowed]
		AgoraChatGroup CreateGroupWithSubject ([NullAllowed] string aSubject, [NullAllowed] string aDescription, [NullAllowed] string[] aInvitees, [NullAllowed] string aMessage, [NullAllowed] AgoraChatGroupOptions aSetting, out AgoraChatError pError);

		// @required -(void)createGroupWithSubject:(NSString * _Nullable)aSubject description:(NSString * _Nullable)aDescription invitees:(NSArray<NSString *> * _Nullable)aInvitees message:(NSString * _Nullable)aMessage setting:(AgoraChatGroupOptions * _Nullable)aSetting completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("createGroupWithSubject:description:invitees:message:setting:completion:")]
		void CreateGroupWithSubject ([NullAllowed] string aSubject, [NullAllowed] string aDescription, [NullAllowed] string[] aInvitees, [NullAllowed] string aMessage, [NullAllowed] AgoraChatGroupOptions aSetting, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)getGroupSpecificationFromServerWithId:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getGroupSpecificationFromServerWithId:error:")]
		[return: NullAllowed]
		AgoraChatGroup GetGroupSpecificationFromServerWithId (string aGroupId, out AgoraChatError pError);

		// @required -(AgoraChatGroup * _Nullable)getGroupSpecificationFromServerWithId:(NSString * _Nonnull)aGroupId fetchMembers:(BOOL)fetchMembers error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getGroupSpecificationFromServerWithId:fetchMembers:error:")]
		[return: NullAllowed]
		AgoraChatGroup GetGroupSpecificationFromServerWithId (string aGroupId, bool fetchMembers, out AgoraChatError pError);

		// @required -(void)getGroupSpecificationFromServerWithId:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getGroupSpecificationFromServerWithId:completion:")]
		void GetGroupSpecificationFromServerWithId (string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(void)getGroupSpecificationFromServerWithId:(NSString * _Nonnull)aGroupId fetchMembers:(BOOL)fetchMembers completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getGroupSpecificationFromServerWithId:fetchMembers:completion:")]
		void GetGroupSpecificationFromServerWithId (string aGroupId, bool fetchMembers, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatCursorResult<NSString *> *)getGroupMemberListFromServerWithId:(NSString * _Nonnull)aGroupId cursor:(NSString * _Nullable)aCursor pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getGroupMemberListFromServerWithId:cursor:pageSize:error:")]
		AgoraChatCursorResult<NSString> GetGroupMemberListFromServerWithId (string aGroupId, [NullAllowed] string aCursor, nint aPageSize, out AgoraChatError pError);

		// @required -(void)getGroupMemberListFromServerWithId:(NSString * _Nonnull)aGroupId cursor:(NSString * _Nullable)aCursor pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(AgoraChatCursorResult<NSString *> *, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getGroupMemberListFromServerWithId:cursor:pageSize:completion:")]
		void GetGroupMemberListFromServerWithId (string aGroupId, [NullAllowed] string aCursor, nint aPageSize, [NullAllowed] Action<AgoraChatCursorResult<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(NSArray<NSString *> * _Nullable)getGroupBlacklistFromServerWithId:(NSString * _Nonnull)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getGroupBlacklistFromServerWithId:pageNumber:pageSize:error:")]
		[return: NullAllowed]
		string[] GetGroupBlacklistFromServerWithId (string aGroupId, nint aPageNum, nint aPageSize, out AgoraChatError pError);

		// @required -(void)getGroupBlacklistFromServerWithId:(NSString * _Nonnull)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(NSArray<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getGroupBlacklistFromServerWithId:pageNumber:pageSize:completion:")]
		void GetGroupBlacklistFromServerWithId (string aGroupId, nint aPageNum, nint aPageSize, [NullAllowed] Action<NSArray<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(NSArray<NSString *> * _Nullable)getGroupMuteListFromServerWithId:(NSString * _Nonnull)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getGroupMuteListFromServerWithId:pageNumber:pageSize:error:")]
		[return: NullAllowed]
		string[] GetGroupMuteListFromServerWithId (string aGroupId, nint aPageNum, nint aPageSize, out AgoraChatError pError);

		// @required -(void)getGroupMuteListFromServerWithId:(NSString * _Nonnull)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(NSArray<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getGroupMuteListFromServerWithId:pageNumber:pageSize:completion:")]
		void GetGroupMuteListFromServerWithId (string aGroupId, nint aPageNum, nint aPageSize, [NullAllowed] Action<NSArray<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(void)fetchGroupMuteListFromServerWithId:(NSString * _Nonnull)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(NSDictionary<NSString *,NSNumber *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("fetchGroupMuteListFromServerWithId:pageNumber:pageSize:completion:")]
		void FetchGroupMuteListFromServerWithId (string aGroupId, nint aPageNum, nint aPageSize, [NullAllowed] Action<NSDictionary<NSString, NSNumber>, AgoraChatError> aCompletionBlock);

		// @required -(NSArray<AgoraChatGroupSharedFile *> * _Nullable)getGroupFileListWithId:(NSString * _Nonnull)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getGroupFileListWithId:pageNumber:pageSize:error:")]
		[return: NullAllowed]
		AgoraChatGroupSharedFile[] GetGroupFileListWithId (string aGroupId, nint aPageNum, nint aPageSize, out AgoraChatError pError);

		// @required -(void)getGroupFileListWithId:(NSString * _Nonnull)aGroupId pageNumber:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(NSArray<AgoraChatGroupSharedFile *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getGroupFileListWithId:pageNumber:pageSize:completion:")]
		void GetGroupFileListWithId (string aGroupId, nint aPageNum, nint aPageSize, [NullAllowed] Action<NSArray<AgoraChatGroupSharedFile>, AgoraChatError> aCompletionBlock);

		// @required -(NSArray *)getGroupWhiteListFromServerWithId:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getGroupWhiteListFromServerWithId:error:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] GetGroupWhiteListFromServerWithId (string aGroupId, out AgoraChatError pError);

		// @required -(void)getGroupWhiteListFromServerWithId:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(NSArray<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getGroupWhiteListFromServerWithId:completion:")]
		void GetGroupWhiteListFromServerWithId (string aGroupId, [NullAllowed] Action<NSArray<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(BOOL)isMemberInWhiteListFromServerWithGroupId:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("isMemberInWhiteListFromServerWithGroupId:error:")]
		bool IsMemberInWhiteListFromServerWithGroupId (string aGroupId, out AgoraChatError pError);

		// @required -(void)isMemberInWhiteListFromServerWithGroupId:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(BOOL, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("isMemberInWhiteListFromServerWithGroupId:completion:")]
		void IsMemberInWhiteListFromServerWithGroupId (string aGroupId, [NullAllowed] Action<bool, AgoraChatError> aCompletionBlock);

		// @required -(NSString * _Nullable)getGroupAnnouncementWithId:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("getGroupAnnouncementWithId:error:")]
		[return: NullAllowed]
		string GetGroupAnnouncementWithId (string aGroupId, out AgoraChatError pError);

		// @required -(void)isMemberInMuteListFromServerWithGroupId:(NSString * _Nonnull)aGroupId completion:(void (^ _Nonnull)(BOOL, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("isMemberInMuteListFromServerWithGroupId:completion:")]
		void IsMemberInMuteListFromServerWithGroupId (string aGroupId, Action<bool, AgoraChatError> aCompletionBlock);

		// @required -(void)getGroupAnnouncementWithId:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(NSString *, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getGroupAnnouncementWithId:completion:")]
		void GetGroupAnnouncementWithId (string aGroupId, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)addOccupants:(NSArray<NSString *> * _Nonnull)aOccupants toGroup:(NSString * _Nonnull)aGroupId welcomeMessage:(NSString * _Nullable)aWelcomeMessage error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("addOccupants:toGroup:welcomeMessage:error:")]
		[return: NullAllowed]
		AgoraChatGroup AddOccupants (string[] aOccupants, string aGroupId, [NullAllowed] string aWelcomeMessage, out AgoraChatError pError);

		// @required -(void)addMembers:(NSArray<NSString *> * _Nonnull)aUsers toGroup:(NSString * _Nonnull)aGroupId message:(NSString * _Nullable)aMessage completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("addMembers:toGroup:message:completion:")]
		void AddMembers (string[] aUsers, string aGroupId, [NullAllowed] string aMessage, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)removeOccupants:(NSArray<NSString *> * _Nonnull)aOccupants fromGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("removeOccupants:fromGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup RemoveOccupants (string[] aOccupants, string aGroupId, out AgoraChatError pError);

		// @required -(void)removeMembers:(NSArray<NSString *> * _Nonnull)aUsers fromGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeMembers:fromGroup:completion:")]
		void RemoveMembers (string[] aUsers, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)blockOccupants:(NSArray<NSString *> * _Nonnull)aOccupants fromGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("blockOccupants:fromGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup BlockOccupants (string[] aOccupants, string aGroupId, out AgoraChatError pError);

		// @required -(void)blockMembers:(NSArray<NSString *> * _Nonnull)aMembers fromGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("blockMembers:fromGroup:completion:")]
		void BlockMembers (string[] aMembers, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)unblockOccupants:(NSArray<NSString *> * _Nonnull)aOccupants forGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("unblockOccupants:forGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup UnblockOccupants (string[] aOccupants, string aGroupId, out AgoraChatError pError);

		// @required -(void)unblockMembers:(NSArray<NSString *> * _Nonnull)aMembers fromGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("unblockMembers:fromGroup:completion:")]
		void UnblockMembers (string[] aMembers, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)changeGroupSubject:(NSString * _Nullable)aSubject forGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("changeGroupSubject:forGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup ChangeGroupSubject ([NullAllowed] string aSubject, string aGroupId, out AgoraChatError pError);

		// @required -(void)updateGroupSubject:(NSString * _Nullable)aSubject forGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateGroupSubject:forGroup:completion:")]
		void UpdateGroupSubject ([NullAllowed] string aSubject, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)changeDescription:(NSString * _Nullable)aDescription forGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("changeDescription:forGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup ChangeDescription ([NullAllowed] string aDescription, string aGroupId, out AgoraChatError pError);

		// @required -(void)updateDescription:(NSString * _Nullable)aDescription forGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateDescription:forGroup:completion:")]
		void UpdateDescription ([NullAllowed] string aDescription, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(void)leaveGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("leaveGroup:error:")]
		void LeaveGroup (string aGroupId, out AgoraChatError pError);

		// @required -(void)leaveGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("leaveGroup:completion:")]
		void LeaveGroup (string aGroupId, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError *)destroyGroup:(NSString * _Nonnull)aGroupId;
		[Abstract]
		[Export ("destroyGroup:")]
		AgoraChatError DestroyGroup (string aGroupId);

		// @required -(void)destroyGroup:(NSString * _Nonnull)aGroupId finishCompletion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("destroyGroup:finishCompletion:")]
		void DestroyGroup (string aGroupId, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)blockGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("blockGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup BlockGroup (string aGroupId, out AgoraChatError pError);

		// @required -(void)blockGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("blockGroup:completion:")]
		void BlockGroup (string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)unblockGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("unblockGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup UnblockGroup (string aGroupId, out AgoraChatError pError);

		// @required -(void)unblockGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("unblockGroup:completion:")]
		void UnblockGroup (string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)updateGroupOwner:(NSString * _Nonnull)aGroupId newOwner:(NSString * _Nonnull)aNewOwner error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("updateGroupOwner:newOwner:error:")]
		[return: NullAllowed]
		AgoraChatGroup UpdateGroupOwner (string aGroupId, string aNewOwner, out AgoraChatError pError);

		// @required -(void)updateGroupOwner:(NSString * _Nonnull)aGroupId newOwner:(NSString * _Nonnull)aNewOwner completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateGroupOwner:newOwner:completion:")]
		void UpdateGroupOwner (string aGroupId, string aNewOwner, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)addAdmin:(NSString * _Nonnull)aAdmin toGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("addAdmin:toGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup AddAdmin (string aAdmin, string aGroupId, out AgoraChatError pError);

		// @required -(void)addAdmin:(NSString * _Nonnull)aAdmin toGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("addAdmin:toGroup:completion:")]
		void AddAdmin (string aAdmin, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)removeAdmin:(NSString * _Nonnull)aAdmin fromGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("removeAdmin:fromGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup RemoveAdmin (string aAdmin, string aGroupId, out AgoraChatError pError);

		// @required -(void)removeAdmin:(NSString * _Nonnull)aAdmin fromGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeAdmin:fromGroup:completion:")]
		void RemoveAdmin (string aAdmin, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)muteMembers:(NSArray<NSString *> * _Nonnull)aMuteMembers muteMilliseconds:(NSInteger)aMuteMilliseconds fromGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("muteMembers:muteMilliseconds:fromGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup MuteMembers (string[] aMuteMembers, nint aMuteMilliseconds, string aGroupId, out AgoraChatError pError);

		// @required -(void)muteMembers:(NSArray<NSString *> * _Nonnull)aMuteMembers muteMilliseconds:(NSInteger)aMuteMilliseconds fromGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("muteMembers:muteMilliseconds:fromGroup:completion:")]
		void MuteMembers (string[] aMuteMembers, nint aMuteMilliseconds, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)unmuteMembers:(NSArray<NSString *> * _Nonnull)aMembers fromGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("unmuteMembers:fromGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup UnmuteMembers (string[] aMembers, string aGroupId, out AgoraChatError pError);

		// @required -(void)unmuteMembers:(NSArray<NSString *> * _Nonnull)aMembers fromGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("unmuteMembers:fromGroup:completion:")]
		void UnmuteMembers (string[] aMembers, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)muteAllMembersFromGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("muteAllMembersFromGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup MuteAllMembersFromGroup (string aGroupId, out AgoraChatError pError);

		// @required -(void)muteAllMembersFromGroup:(NSString * _Nonnull)aGroupId completion:(void (^)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("muteAllMembersFromGroup:completion:")]
		void MuteAllMembersFromGroup (string aGroupId, Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)unmuteAllMembersFromGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("unmuteAllMembersFromGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup UnmuteAllMembersFromGroup (string aGroupId, out AgoraChatError pError);

		// @required -(void)unmuteAllMembersFromGroup:(NSString * _Nonnull)aGroupId completion:(void (^)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("unmuteAllMembersFromGroup:completion:")]
		void UnmuteAllMembersFromGroup (string aGroupId, Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)addWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers fromGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("addWhiteListMembers:fromGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup AddWhiteListMembers (string[] aMembers, string aGroupId, out AgoraChatError pError);

		// @required -(void)addWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers fromGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("addWhiteListMembers:fromGroup:completion:")]
		void AddWhiteListMembers (string[] aMembers, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)removeWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers fromGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("removeWhiteListMembers:fromGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup RemoveWhiteListMembers (string[] aMembers, string aGroupId, out AgoraChatError pError);

		// @required -(void)removeWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers fromGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeWhiteListMembers:fromGroup:completion:")]
		void RemoveWhiteListMembers (string[] aMembers, string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(void)uploadGroupSharedFileWithId:(NSString * _Nonnull)aGroupId filePath:(NSString * _Nonnull)aFilePath progress:(void (^ _Nullable)(int))aProgressBlock completion:(void (^ _Nullable)(AgoraChatGroupSharedFile * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("uploadGroupSharedFileWithId:filePath:progress:completion:")]
		void UploadGroupSharedFileWithId (string aGroupId, string aFilePath, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatGroupSharedFile, AgoraChatError> aCompletionBlock);

		// @required -(void)downloadGroupSharedFileWithId:(NSString * _Nonnull)aGroupId filePath:(NSString * _Nonnull)aFilePath sharedFileId:(NSString * _Nonnull)aSharedFileId progress:(void (^ _Nullable)(int))aProgressBlock completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("downloadGroupSharedFileWithId:filePath:sharedFileId:progress:completion:")]
		void DownloadGroupSharedFileWithId (string aGroupId, string aFilePath, string aSharedFileId, [NullAllowed] Action<int> aProgressBlock, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)removeGroupSharedFileWithId:(NSString * _Nonnull)aGroupId sharedFileId:(NSString * _Nonnull)aSharedFileId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("removeGroupSharedFileWithId:sharedFileId:error:")]
		[return: NullAllowed]
		AgoraChatGroup RemoveGroupSharedFileWithId (string aGroupId, string aSharedFileId, out AgoraChatError pError);

		// @required -(void)removeGroupSharedFileWithId:(NSString * _Nonnull)aGroupId sharedFileId:(NSString * _Nonnull)aSharedFileId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeGroupSharedFileWithId:sharedFileId:completion:")]
		void RemoveGroupSharedFileWithId (string aGroupId, string aSharedFileId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)updateGroupAnnouncementWithId:(NSString * _Nonnull)aGroupId announcement:(NSString * _Nullable)aAnnouncement error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("updateGroupAnnouncementWithId:announcement:error:")]
		[return: NullAllowed]
		AgoraChatGroup UpdateGroupAnnouncementWithId (string aGroupId, [NullAllowed] string aAnnouncement, out AgoraChatError pError);

		// @required -(void)updateGroupAnnouncementWithId:(NSString * _Nonnull)aGroupId announcement:(NSString * _Nullable)aAnnouncement completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateGroupAnnouncementWithId:announcement:completion:")]
		void UpdateGroupAnnouncementWithId (string aGroupId, [NullAllowed] string aAnnouncement, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)updateGroupExtWithId:(NSString * _Nonnull)aGroupId ext:(NSString * _Nullable)aExt error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("updateGroupExtWithId:ext:error:")]
		[return: NullAllowed]
		AgoraChatGroup UpdateGroupExtWithId (string aGroupId, [NullAllowed] string aExt, out AgoraChatError pError);

		// @required -(void)updateGroupExtWithId:(NSString * _Nonnull)aGroupId ext:(NSString * _Nullable)aExt completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateGroupExtWithId:ext:completion:")]
		void UpdateGroupExtWithId (string aGroupId, [NullAllowed] string aExt, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)joinPublicGroup:(NSString * _Nonnull)aGroupId error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("joinPublicGroup:error:")]
		[return: NullAllowed]
		AgoraChatGroup JoinPublicGroup (string aGroupId, out AgoraChatError pError);

		// @required -(void)joinPublicGroup:(NSString * _Nonnull)aGroupId completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("joinPublicGroup:completion:")]
		void JoinPublicGroup (string aGroupId, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)applyJoinPublicGroup:(NSString * _Nonnull)aGroupId message:(NSString * _Nullable)aMessage error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("applyJoinPublicGroup:message:error:")]
		[return: NullAllowed]
		AgoraChatGroup ApplyJoinPublicGroup (string aGroupId, [NullAllowed] string aMessage, out AgoraChatError pError);

		// @required -(void)requestToJoinPublicGroup:(NSString * _Nonnull)aGroupId message:(NSString * _Nullable)aMessage completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("requestToJoinPublicGroup:message:completion:")]
		void RequestToJoinPublicGroup (string aGroupId, [NullAllowed] string aMessage, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError *)acceptJoinApplication:(NSString * _Nonnull)aGroupId applicant:(NSString * _Nonnull)aUsername;
		[Abstract]
		[Export ("acceptJoinApplication:applicant:")]
		AgoraChatError AcceptJoinApplication (string aGroupId, string aUsername);

		// @required -(void)approveJoinGroupRequest:(NSString * _Nonnull)aGroupId sender:(NSString * _Nonnull)aUsername completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("approveJoinGroupRequest:sender:completion:")]
		void ApproveJoinGroupRequest (string aGroupId, string aUsername, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError *)declineJoinApplication:(NSString * _Nonnull)aGroupId applicant:(NSString * _Nonnull)aUsername reason:(NSString * _Nullable)aReason;
		[Abstract]
		[Export ("declineJoinApplication:applicant:reason:")]
		AgoraChatError DeclineJoinApplication (string aGroupId, string aUsername, [NullAllowed] string aReason);

		// @required -(void)declineJoinGroupRequest:(NSString * _Nonnull)aGroupId sender:(NSString * _Nonnull)aUsername reason:(NSString * _Nullable)aReason completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("declineJoinGroupRequest:sender:reason:completion:")]
		void DeclineJoinGroupRequest (string aGroupId, string aUsername, [NullAllowed] string aReason, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatGroup * _Nullable)acceptInvitationFromGroup:(NSString * _Nonnull)aGroupId inviter:(NSString * _Nonnull)aUsername error:(AgoraChatError ** _Nullable)pError;
		[Abstract]
		[Export ("acceptInvitationFromGroup:inviter:error:")]
		[return: NullAllowed]
		AgoraChatGroup AcceptInvitationFromGroup (string aGroupId, string aUsername, out AgoraChatError pError);

		// @required -(void)acceptInvitationFromGroup:(NSString * _Nonnull)aGroupId inviter:(NSString * _Nonnull)aUsername completion:(void (^ _Nullable)(AgoraChatGroup * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("acceptInvitationFromGroup:inviter:completion:")]
		void AcceptInvitationFromGroup (string aGroupId, string aUsername, [NullAllowed] Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError *)declineInvitationFromGroup:(NSString * _Nonnull)aGroupId inviter:(NSString * _Nonnull)aUsername reason:(NSString * _Nullable)aReason;
		[Abstract]
		[Export ("declineInvitationFromGroup:inviter:reason:")]
		AgoraChatError DeclineInvitationFromGroup (string aGroupId, string aUsername, [NullAllowed] string aReason);

		// @required -(void)declineGroupInvitation:(NSString * _Nonnull)aGroupId inviter:(NSString * _Nonnull)aInviter reason:(NSString * _Nullable)aReason completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("declineGroupInvitation:inviter:reason:completion:")]
		void DeclineGroupInvitation (string aGroupId, string aInviter, [NullAllowed] string aReason, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// @required -(void)getJoinedGroupsFromServerWithPage:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize needMemberCount:(BOOL)aNeedMemberCount needRole:(BOOL)aNeedRole completion:(void (^ _Nullable)(NSArray<AgoraChatGroup *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getJoinedGroupsFromServerWithPage:pageSize:needMemberCount:needRole:completion:")]
		void GetJoinedGroupsFromServerWithPage (nint aPageNum, nint aPageSize, bool aNeedMemberCount, bool aNeedRole, [NullAllowed] Action<NSArray<AgoraChatGroup>, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError *)ignoreGroupPush:(NSString *)aGroupId ignore:(BOOL)aIsIgnore __attribute__((deprecated("")));
		[Abstract]
		[Export ("ignoreGroupPush:ignore:")]
		AgoraChatError IgnoreGroupPush (string aGroupId, bool aIsIgnore);

		// @required -(void)updatePushServiceForGroup:(NSString *)aGroupId isPushEnabled:(BOOL)aIsEnable completion:(void (^)(AgoraChatGroup *, AgoraChatError *))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("updatePushServiceForGroup:isPushEnabled:completion:")]
		void UpdatePushServiceForGroup (string aGroupId, bool aIsEnable, Action<AgoraChatGroup, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError *)ignoreGroupsPush:(NSArray *)aGroupIDs ignore:(BOOL)aIsIgnore __attribute__((deprecated("")));
		[Abstract]
		[Export ("ignoreGroupsPush:ignore:")]
		//[Verify (StronglyTypedNSArray)]
		AgoraChatError IgnoreGroupsPush (NSObject[] aGroupIDs, bool aIsIgnore);

		// @required -(void)updatePushServiceForGroups:(NSArray *)aGroupIDs isPushEnabled:(BOOL)aIsEnable completion:(void (^)(NSArray *, AgoraChatError *))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("updatePushServiceForGroups:isPushEnabled:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void UpdatePushServiceForGroups (NSObject[] aGroupIDs, bool aIsEnable, Action<NSArray, AgoraChatError> aCompletionBlock);

		// @required -(void)setMemberAttribute:(NSString * _Nonnull)groupId userId:(NSString * _Nonnull)userId attributes:(NSDictionary<NSString *,NSString *> * _Nonnull)attributes completion:(void (^ _Nullable)(AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("setMemberAttribute:userId:attributes:completion:")]
		void SetMemberAttribute (string groupId, string userId, NSDictionary<NSString, NSString> attributes, [NullAllowed] Action<AgoraChatError> completionBlock);

		// @required -(void)fetchMemberAttribute:(NSString * _Nonnull)groupId userId:(NSString * _Nonnull)userId completion:(void (^ _Nullable)(NSDictionary<NSString *,NSString *> * _Nullable, AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("fetchMemberAttribute:userId:completion:")]
		void FetchMemberAttribute (string groupId, string userId, [NullAllowed] Action<NSDictionary<NSString, NSString>, AgoraChatError> completionBlock);

		// @required -(void)fetchMembersAttributes:(NSString * _Nonnull)groupId userIds:(NSArray<__kindof NSString *> * _Nonnull)userIds keys:(NSArray<__kindof NSString *> * _Nonnull)keys completion:(void (^ _Nullable)(NSDictionary<NSString *,NSDictionary<NSString *,NSString *> *> * _Nullable, AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("fetchMembersAttributes:userIds:keys:completion:")]
		void FetchMembersAttributes (string groupId, string[] userIds, string[] keys, [NullAllowed] Action<NSDictionary<NSString, NSDictionary<NSString, NSString>>, AgoraChatError> completionBlock);

		// @required -(void)getJoinedGroupsFromServerWithPage:(NSInteger)aPageNum pageSize:(NSInteger)aPageSize completion:(void (^ _Nullable)(NSArray<AgoraChatGroup *> *, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("Use -getJoinedGroupsFromServerWithPage:pageSize:needMemberCount:needRole:error:completion: instead")));
		[Abstract]
		[Export ("getJoinedGroupsFromServerWithPage:pageSize:completion:")]
		void GetJoinedGroupsFromServerWithPage (nint aPageNum, nint aPageSize, [NullAllowed] Action<NSArray<AgoraChatGroup>, AgoraChatError> aCompletionBlock);
	}

	// @interface AgoraChatThread : NSObject
	[BaseType (typeof(NSObject))]
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

	// @interface AgoraChatThreadEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatThreadEvent
	{
		// @property (readonly) AgoraChatThreadOperation type;
		[Export ("type")]
		AgoraChatThreadOperation Type { get; }

		// @property (readonly) NSString * from;
		[Export ("from")]
		string From { get; }

		// @property (readonly) AgoraChatThread * chatThread;
		[Export ("chatThread")]
		AgoraChatThread ChatThread { get; }
	}

	// @protocol AgoraChatThreadManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AgoraChatThreadManagerDelegate
	{
		// @optional -(void)onChatThreadCreate:(AgoraChatThreadEvent * _Nonnull)event;
		[Export ("onChatThreadCreate:")]
		void OnChatThreadCreate (AgoraChatThreadEvent @event);

		// @optional -(void)onChatThreadUpdate:(AgoraChatThreadEvent * _Nonnull)event;
		[Export ("onChatThreadUpdate:")]
		void OnChatThreadUpdate (AgoraChatThreadEvent @event);

		// @optional -(void)onChatThreadDestroy:(AgoraChatThreadEvent * _Nonnull)event;
		[Export ("onChatThreadDestroy:")]
		void OnChatThreadDestroy (AgoraChatThreadEvent @event);

		// @optional -(void)onUserKickOutOfChatThread:(AgoraChatThreadEvent * _Nonnull)event;
		[Export ("onUserKickOutOfChatThread:")]
		void OnUserKickOutOfChatThread (AgoraChatThreadEvent @event);
	}

	// @protocol IAgoraChatThreadManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IAgoraChatThreadManager
	{
		// @required -(void)addDelegate:(id<AgoraChatThreadManagerDelegate> _Nonnull)aDelegate delegateQueue:(dispatch_queue_t _Nullable)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (AgoraChatThreadManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id<AgoraChatThreadManagerDelegate> _Nonnull)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (AgoraChatThreadManagerDelegate aDelegate);

		// @required -(void)getChatThreadFromSever:(NSString * _Nonnull)threadId completion:(void (^ _Nonnull)(AgoraChatThread * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatThreadFromSever:completion:")]
		void GetChatThreadFromSever (string threadId, Action<AgoraChatThread, AgoraChatError> aCompletionBlock);

		// @required -(void)getJoinedChatThreadsFromServerWithCursor:(NSString * _Nonnull)aCursor pageSize:(NSInteger)aPageSize completion:(void (^ _Nonnull)(AgoraChatCursorResult<AgoraChatThread *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getJoinedChatThreadsFromServerWithCursor:pageSize:completion:")]
		void GetJoinedChatThreadsFromServerWithCursor (string aCursor, nint aPageSize, Action<AgoraChatCursorResult<AgoraChatThread>, AgoraChatError> aCompletionBlock);

		// @required -(void)getChatThreadsFromServerWithParentId:(NSString * _Nonnull)parentId cursor:(NSString * _Nonnull)aCursor pageSize:(NSInteger)aPageSize completion:(void (^ _Nonnull)(AgoraChatCursorResult<AgoraChatThread *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatThreadsFromServerWithParentId:cursor:pageSize:completion:")]
		void GetChatThreadsFromServerWithParentId (string parentId, string aCursor, nint aPageSize, Action<AgoraChatCursorResult<AgoraChatThread>, AgoraChatError> aCompletionBlock);

		// @required -(void)getJoinedChatThreadsFromServerWithParentId:(NSString * _Nonnull)parentId cursor:(NSString * _Nonnull)aCursor pageSize:(NSInteger)aPageSize completion:(void (^ _Nonnull)(AgoraChatCursorResult<AgoraChatThread *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getJoinedChatThreadsFromServerWithParentId:cursor:pageSize:completion:")]
		void GetJoinedChatThreadsFromServerWithParentId (string parentId, string aCursor, nint aPageSize, Action<AgoraChatCursorResult<AgoraChatThread>, AgoraChatError> aCompletionBlock);

		// @required -(void)getChatThreadMemberListFromServerWithId:(NSString * _Nonnull)threadId cursor:(NSString * _Nonnull)aCursor pageSize:(NSInteger)pageSize completion:(void (^ _Nonnull)(AgoraChatCursorResult<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getChatThreadMemberListFromServerWithId:cursor:pageSize:completion:")]
		void GetChatThreadMemberListFromServerWithId (string threadId, string aCursor, nint pageSize, Action<AgoraChatCursorResult<NSString>, AgoraChatError> aCompletionBlock);

		// @required -(void)getLastMessageFromSeverWithChatThreads:(NSArray<NSString *> * _Nonnull)threadIds completion:(void (^ _Nonnull)(NSDictionary<NSString *,AgoraChatMessage *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getLastMessageFromSeverWithChatThreads:completion:")]
		void GetLastMessageFromSeverWithChatThreads (string[] threadIds, Action<NSDictionary<NSString, AgoraChatMessage>, AgoraChatError> aCompletionBlock);

		// @required -(void)removeMemberFromChatThread:(NSString * _Nonnull)aUser threadId:(NSString * _Nonnull)athreadId completion:(void (^ _Nonnull)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("removeMemberFromChatThread:threadId:completion:")]
		void RemoveMemberFromChatThread (string aUser, string athreadId, Action<AgoraChatError> aCompletionBlock);

		// @required -(void)updateChatThreadName:(NSString * _Nonnull)name threadId:(NSString * _Nonnull)athreadId completion:(void (^ _Nonnull)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updateChatThreadName:threadId:completion:")]
		void UpdateChatThreadName (string name, string athreadId, Action<AgoraChatError> aCompletionBlock);

		// @required -(void)createChatThread:(NSString * _Nonnull)threadName messageId:(NSString * _Nonnull)messageId parentId:(NSString * _Nonnull)parentId completion:(void (^ _Nonnull)(AgoraChatThread * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("createChatThread:messageId:parentId:completion:")]
		void CreateChatThread (string threadName, string messageId, string parentId, Action<AgoraChatThread, AgoraChatError> aCompletionBlock);

		// @required -(void)joinChatThread:(NSString * _Nonnull)threadId completion:(void (^ _Nonnull)(AgoraChatThread * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("joinChatThread:completion:")]
		void JoinChatThread (string threadId, Action<AgoraChatThread, AgoraChatError> aCompletionBlock);

		// @required -(void)leaveChatThread:(NSString * _Nonnull)athreadId completion:(void (^ _Nonnull)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("leaveChatThread:completion:")]
		void LeaveChatThread (string athreadId, Action<AgoraChatError> aCompletionBlock);

		// @required -(void)destroyChatThread:(NSString * _Nonnull)athreadId completion:(void (^ _Nonnull)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("destroyChatThread:completion:")]
		void DestroyChatThread (string athreadId, Action<AgoraChatError> aCompletionBlock);
	}

	// @interface AgoraChatSilentModeResult : NSObject <NSCopying, NSCoding>
	[BaseType (typeof(NSObject))]
	interface AgoraChatSilentModeResult : INSCopying, INSCoding
	{
		// @property (readonly, assign, nonatomic) NSTimeInterval expireTimestamp;
		[Export ("expireTimestamp")]
		double ExpireTimestamp { get; }

		// @property (readonly, assign, nonatomic) AgoraChatPushRemindType remindType;
		[Export ("remindType", ArgumentSemantic.Assign)]
		AgoraChatPushRemindType RemindType { get; }

		// @property (readonly, nonatomic, strong) AgoraChatSilentModeTime * _Nullable silentModeStartTime;
		[NullAllowed, Export ("silentModeStartTime", ArgumentSemantic.Strong)]
		AgoraChatSilentModeTime SilentModeStartTime { get; }

		// @property (readonly, nonatomic, strong) AgoraChatSilentModeTime * _Nullable silentModeEndTime;
		[NullAllowed, Export ("silentModeEndTime", ArgumentSemantic.Strong)]
		AgoraChatSilentModeTime SilentModeEndTime { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull conversationID;
		[Export ("conversationID")]
		string ConversationID { get; }

		// @property (readonly, assign, nonatomic) AgoraChatConversationType conversationType;
		[Export ("conversationType", ArgumentSemantic.Assign)]
		AgoraChatConversationType ConversationType { get; }

		// @property (readonly, assign, nonatomic) BOOL isConversationRemindTypeEnabled;
		[Export ("isConversationRemindTypeEnabled")]
		bool IsConversationRemindTypeEnabled { get; }
	}

	// @protocol IAgoraChatPushManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IAgoraChatPushManager
	{
		// @required @property (readonly, nonatomic, strong) AgoraChatPushOptions * _Nullable pushOptions;
		[Abstract]
		[NullAllowed, Export ("pushOptions", ArgumentSemantic.Strong)]
		AgoraChatPushOptions PushOptions { get; }

		// @required @property (readonly, nonatomic, strong) EM_DEPRECATED_IOS(3_8_4, 3_9_1, "Use -getSilentModeForConversations:completion: instead") NSArray * noPushUIds __attribute__((deprecated("")));
		[Abstract]
		[Export ("noPushUIds", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] NoPushUIds { get; }

		// @required @property (readonly, nonatomic, strong) EM_DEPRECATED_IOS(3_7_4, 3_9_1, "Use -getSilentModeForConversations:completion: instead") NSArray * noPushGroups __attribute__((deprecated("")));
		[Abstract]
		[Export ("noPushGroups", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] NoPushGroups { get; }

		// @required -(AgoraChatError * _Nonnull)enableOfflinePush __attribute__((deprecated("")));
		[Abstract]
		[Export ("enableOfflinePush")]
		// [Verify (MethodToProperty)]
		AgoraChatError EnableOfflinePush { get; }

		// @required -(AgoraChatError * _Nonnull)disableOfflinePushStart:(int)aStartHour end:(int)aEndHour __attribute__((deprecated("")));
		[Abstract]
		[Export ("disableOfflinePushStart:end:")]
		AgoraChatError DisableOfflinePushStart (int aStartHour, int aEndHour);

		// @required -(AgoraChatError * _Nonnull)updatePushServiceForGroups:(NSArray * _Nonnull)aGroupIds disablePush:(BOOL)disable __attribute__((deprecated("")));
		[Abstract]
		[Export ("updatePushServiceForGroups:disablePush:")]
		//[Verify (StronglyTypedNSArray)]
		AgoraChatError UpdatePushServiceForGroups (NSObject[] aGroupIds, bool disable);

		// @required -(void)updatePushServiceForGroups:(NSArray * _Nonnull)aGroupIds disablePush:(BOOL)disable completion:(void (^ _Nonnull)(AgoraChatError * _Nonnull))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("updatePushServiceForGroups:disablePush:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void UpdatePushServiceForGroups (NSObject[] aGroupIds, bool disable, Action<AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError * _Nonnull)updatePushServiceForUsers:(NSArray * _Nonnull)aUIds disablePush:(BOOL)disable __attribute__((deprecated("")));
		[Abstract]
		[Export ("updatePushServiceForUsers:disablePush:")]
		//[Verify (StronglyTypedNSArray)]
		AgoraChatError UpdatePushServiceForUsers (NSObject[] aUIds, bool disable);

		// @required -(void)updatePushServiceForUsers:(NSArray * _Nonnull)aUIds disablePush:(BOOL)disable completion:(void (^ _Nonnull)(AgoraChatError * _Nonnull))aCompletionBlock __attribute__((deprecated("")));
		[Abstract]
		[Export ("updatePushServiceForUsers:disablePush:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void UpdatePushServiceForUsers (NSObject[] aUIds, bool disable, Action<AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError * _Nonnull)updatePushDisplayStyle:(AgoraChatPushDisplayStyle)pushDisplayStyle;
		[Abstract]
		[Export ("updatePushDisplayStyle:")]
		AgoraChatError UpdatePushDisplayStyle (AgoraChatPushDisplayStyle pushDisplayStyle);

		// @required -(void)updatePushDisplayStyle:(AgoraChatPushDisplayStyle)pushDisplayStyle completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updatePushDisplayStyle:completion:")]
		void UpdatePushDisplayStyle (AgoraChatPushDisplayStyle pushDisplayStyle, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatError * _Nullable)updatePushDisplayName:(NSString * _Nonnull)aDisplayName;
		[Abstract]
		[Export ("updatePushDisplayName:")]
		[return: NullAllowed]
		AgoraChatError UpdatePushDisplayName (string aDisplayName);

		// @required -(void)updatePushDisplayName:(NSString * _Nonnull)aDisplayName completion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("updatePushDisplayName:completion:")]
		void UpdatePushDisplayName (string aDisplayName, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(AgoraChatPushOptions * _Nullable)getPushOptionsFromServerWithError:(AgoraChatError * _Nullable * _Nullable)pError;
		[Abstract]
		[Export ("getPushOptionsFromServerWithError:")]
		[return: NullAllowed]
		AgoraChatPushOptions GetPushOptionsFromServerWithError ([NullAllowed] out AgoraChatError pError);

		// @required -(void)getPushNotificationOptionsFromServerWithCompletion:(void (^ _Nullable)(AgoraChatPushOptions * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getPushNotificationOptionsFromServerWithCompletion:")]
		void GetPushNotificationOptionsFromServerWithCompletion ([NullAllowed] Action<AgoraChatPushOptions, AgoraChatError> aCompletionBlock);

		// @required -(void)setSilentModeForAll:(AgoraChatSilentModeParam * _Nullable)aParam completion:(void (^ _Nullable)(AgoraChatSilentModeResult * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("setSilentModeForAll:completion:")]
		void SetSilentModeForAll ([NullAllowed] AgoraChatSilentModeParam aParam, [NullAllowed] Action<AgoraChatSilentModeResult, AgoraChatError> aCompletionBlock);

		// @required -(void)getSilentModeForAllWithCompletion:(void (^ _Nullable)(AgoraChatSilentModeResult * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getSilentModeForAllWithCompletion:")]
		void GetSilentModeForAllWithCompletion ([NullAllowed] Action<AgoraChatSilentModeResult, AgoraChatError> aCompletionBlock);

		// @required -(void)syncSilentModeConversationsFromServerCompletion:(void (^ _Nullable)(AgoraChatError * _Nullable))completionBlock;
		[Abstract]
		[Export ("syncSilentModeConversationsFromServerCompletion:")]
		void SyncSilentModeConversationsFromServerCompletion ([NullAllowed] Action<AgoraChatError> completionBlock);

		// @required -(void)setSilentModeForConversation:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType params:(AgoraChatSilentModeParam * _Nullable)aParam completion:(void (^ _Nullable)(AgoraChatSilentModeResult * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("setSilentModeForConversation:conversationType:params:completion:")]
		void SetSilentModeForConversation (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] AgoraChatSilentModeParam aParam, [NullAllowed] Action<AgoraChatSilentModeResult, AgoraChatError> aCompletionBlock);

		// @required -(void)getSilentModeForConversation:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType completion:(void (^ _Nullable)(AgoraChatSilentModeResult * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getSilentModeForConversation:conversationType:completion:")]
		void GetSilentModeForConversation (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] Action<AgoraChatSilentModeResult, AgoraChatError> aCompletionBlock);

		// @required -(void)clearRemindTypeForConversation:(NSString * _Nonnull)aConversationId conversationType:(AgoraChatConversationType)aConversationType completion:(void (^ _Nullable)(AgoraChatSilentModeResult * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("clearRemindTypeForConversation:conversationType:completion:")]
		void ClearRemindTypeForConversation (string aConversationId, AgoraChatConversationType aConversationType, [NullAllowed] Action<AgoraChatSilentModeResult, AgoraChatError> aCompletionBlock);

		// @required -(void)getSilentModeForConversations:(NSArray<AgoraChatConversation *> * _Nonnull)aConversationArray completion:(void (^ _Nullable)(NSDictionary<NSString *,AgoraChatSilentModeResult *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getSilentModeForConversations:completion:")]
		void GetSilentModeForConversations (AgoraChatConversation[] aConversationArray, [NullAllowed] Action<NSDictionary<NSString, AgoraChatSilentModeResult>, AgoraChatError> aCompletionBlock);

		// @required -(void)setPreferredNotificationLanguage:(NSString * _Nullable)aLaguangeCode completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("setPreferredNotificationLanguage:completion:")]
		void SetPreferredNotificationLanguage ([NullAllowed] string aLaguangeCode, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// @required -(void)getPreferredNotificationLanguageCompletion:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getPreferredNotificationLanguageCompletion:")]
		void GetPreferredNotificationLanguageCompletion ([NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// @required -(void)setPushTemplate:(NSString * _Nullable)aPushTemplateName completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("setPushTemplate:completion:")]
		void SetPushTemplate ([NullAllowed] string aPushTemplateName, [NullAllowed] Action<AgoraChatError> aCompletionBlock);

		// @required -(void)getPushTemplate:(void (^ _Nullable)(NSString * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Abstract]
		[Export ("getPushTemplate:")]
		void GetPushTemplate ([NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);
	}

	// @interface AgoraChatUserInfo : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
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

	// @protocol IAgoraChatUserInfoManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
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

	// @interface AgoraChatTranslationResult : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatTranslationResult
	{
		// @property (nonatomic, strong) NSString * _Nonnull msgId;
		[Export ("msgId", ArgumentSemantic.Strong)]
		string MsgId { get; set; }

		// @property (assign, nonatomic) BOOL showTranslation;
		[Export ("showTranslation")]
		bool ShowTranslation { get; set; }

		// @property (assign, nonatomic) NSUInteger translateTimes;
		[Export ("translateTimes")]
		nuint TranslateTimes { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull translations;
		[Export ("translations", ArgumentSemantic.Strong)]
		string Translations { get; set; }
	}

	// @protocol IAgoraChatTranslateManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IAgoraChatTranslateManager
	{
		// @required -(BOOL)updateTranslate:(AgoraChatTranslationResult *)translate conversationId:(NSString *)conversationId;
		[Abstract]
		[Export ("updateTranslate:conversationId:")]
		bool UpdateTranslate (AgoraChatTranslationResult translate, string conversationId);

		// @required -(AgoraChatTranslationResult *)getTranslationResultByMsgId:(NSString *)msgId;
		[Abstract]
		[Export ("getTranslationResultByMsgId:")]
		AgoraChatTranslationResult GetTranslationResultByMsgId (string msgId);

		// @required -(NSArray<AgoraChatTranslationResult *> *)loadTranslateResults:(NSNumber *)count;
		[Abstract]
		[Export ("loadTranslateResults:")]
		AgoraChatTranslationResult[] LoadTranslateResults (NSNumber count);

		// @required -(BOOL)removeTranslationsByMsgId:(NSArray<NSString *> *)msgIds;
		[Abstract]
		[Export ("removeTranslationsByMsgId:")]
		bool RemoveTranslationsByMsgId (string[] msgIds);

		// @required -(BOOL)removeTranslationsByConversationId:(NSString *)conversationId;
		[Abstract]
		[Export ("removeTranslationsByConversationId:")]
		bool RemoveTranslationsByConversationId (string conversationId);

		// @required -(BOOL)removeAllTranslations;
		[Abstract]
		[Export ("removeAllTranslations")]
		//[Verify (MethodToProperty)]
		bool RemoveAllTranslations { get; }
	}

	// @interface AgoraChatPresenceStatusDetail : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatPresenceStatusDetail
	{
		// @property (nonatomic, strong) NSString * _Nonnull device;
		[Export ("device", ArgumentSemantic.Strong)]
		string Device { get; set; }

		// @property (nonatomic) NSInteger status;
		[Export ("status")]
		nint Status { get; set; }
	}

	// @interface AgoraChatPresence : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatPresence : INativeObject
	{
		// @property (nonatomic, strong) NSString * _Nonnull publisher;
		[Export ("publisher", ArgumentSemantic.Strong)]
		string Publisher { get; set; }

		// @property (nonatomic, strong) NSArray<AgoraChatPresenceStatusDetail *> * _Nullable statusDetails;
		[NullAllowed, Export ("statusDetails", ArgumentSemantic.Strong)]
		AgoraChatPresenceStatusDetail[] StatusDetails { get; set; }

		// @property (nonatomic) NSString * _Nullable statusDescription;
		[NullAllowed, Export ("statusDescription")]
		string StatusDescription { get; set; }

		// @property (nonatomic) NSInteger lastTime;
		[Export ("lastTime")]
		nint LastTime { get; set; }

		// @property (nonatomic) NSInteger expirytime;
		[Export ("expirytime")]
		nint Expirytime { get; set; }
	}

	// @protocol AgoraChatPresenceManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AgoraChatPresenceManagerDelegate
	{
		// @optional -(void)presenceStatusDidChanged:(NSArray<AgoraChatPresence *> * _Nonnull)presences;
		[Export ("presenceStatusDidChanged:")]
		void PresenceStatusDidChanged (AgoraChatPresence[] presences);
	}

	// @protocol IAgoraChatPresenceManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IAgoraChatPresenceManager
	{
		// @required -(void)publishPresenceWithDescription:(NSString * _Nullable)aDescription completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletion;
		[Abstract]
		[Export ("publishPresenceWithDescription:completion:")]
		void PublishPresenceWithDescription ([NullAllowed] string aDescription, [NullAllowed] Action<AgoraChatError> aCompletion);

		// @required -(void)subscribe:(NSArray<NSString *> * _Nonnull)members expiry:(NSInteger)expiry completion:(void (^ _Nullable)(NSArray<AgoraChatPresence *> * _Nullable, AgoraChatError * _Nullable))aCompletion;
		[Abstract]
		[Export ("subscribe:expiry:completion:")]
		void Subscribe (string[] members, nint expiry, [NullAllowed] Action<NSArray<AgoraChatPresence>, AgoraChatError> aCompletion);

		// @required -(void)unsubscribe:(NSArray<NSString *> * _Nonnull)members completion:(void (^ _Nullable)(AgoraChatError * _Nullable))aCompletion;
		[Abstract]
		[Export ("unsubscribe:completion:")]
		void Unsubscribe (string[] members, [NullAllowed] Action<AgoraChatError> aCompletion);

		// @required -(void)fetchSubscribedMembersWithPageNum:(NSUInteger)pageNum pageSize:(NSUInteger)pageSize Completion:(void (^ _Nullable)(NSArray<NSString *> * _Nullable, AgoraChatError * _Nullable))aCompletion;
		[Abstract]
		[Export ("fetchSubscribedMembersWithPageNum:pageSize:Completion:")]
		void FetchSubscribedMembersWithPageNum (nuint pageNum, nuint pageSize, [NullAllowed] Action<NSArray<NSString>, AgoraChatError> aCompletion);

		// @required -(void)fetchPresenceStatus:(NSArray<NSString *> * _Nonnull)members completion:(void (^ _Nullable)(NSArray<AgoraChatPresence *> * _Nullable, AgoraChatError * _Nullable))aCompletion;
		[Abstract]
		[Export ("fetchPresenceStatus:completion:")]
		void FetchPresenceStatus (string[] members, [NullAllowed] Action<NSArray<AgoraChatPresence>, AgoraChatError> aCompletion);

		// @required -(void)addDelegate:(id<AgoraChatPresenceManagerDelegate> _Nonnull)aDelegate delegateQueue:(dispatch_queue_t _Nullable)aQueue;
		[Abstract]
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (AgoraChatPresenceManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// @required -(void)removeDelegate:(id<AgoraChatPresenceManagerDelegate> _Nonnull)aDelegate;
		[Abstract]
		[Export ("removeDelegate:")]
		void RemoveDelegate (AgoraChatPresenceManagerDelegate aDelegate);
	}

	// @interface AgoraChatMessageStatistics : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatMessageStatistics
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull messageId;
		[Export ("messageId", ArgumentSemantic.Strong)]
		string MessageId { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull to;
		[Export ("to", ArgumentSemantic.Strong)]
		string To { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull from;
		[Export ("from", ArgumentSemantic.Strong)]
		string From { get; }

		// @property (readonly, nonatomic) AgoraChatMessageBodyType type;
		[Export ("type")]
		AgoraChatMessageBodyType Type { get; }

		// @property (readonly, nonatomic) AgoraChatType chatType;
		[Export ("chatType")]
		AgoraChatType ChatType { get; }

		// @property (readonly, nonatomic) AgoraChatMessageDirection direction;
		[Export ("direction")]
		AgoraChatMessageDirection Direction { get; }

		// @property (readonly, nonatomic) NSUInteger messageSize;
		[Export ("messageSize")]
		nuint MessageSize { get; }

		// @property (readonly, nonatomic) NSUInteger attachmentSize;
		[Export ("attachmentSize")]
		nuint AttachmentSize { get; }

		// @property (readonly, nonatomic) NSUInteger thumbnailSize;
		[Export ("thumbnailSize")]
		nuint ThumbnailSize { get; }

		// @property (readonly, nonatomic) NSUInteger timestamp;
		[Export ("timestamp")]
		nuint Timestamp { get; }
	}

	// @protocol IAgoraChatStatisticsManager <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IAgoraChatStatisticsManager
	{
		// @required -(AgoraChatMessageStatistics * _Nullable)getMessageStatisticsById:(NSString * _Nonnull)messageId;
		[Abstract]
		[Export ("getMessageStatisticsById:")]
		[return: NullAllowed]
		AgoraChatMessageStatistics GetMessageStatisticsById (string messageId);

		// @required -(NSInteger)getMessageCountWithStart:(NSInteger)startTimestamp end:(NSInteger)endTimestamp direction:(AgoraChatMessageStatisticsDirection)direction type:(AgoraChatMessageStatisticsType)type;
		[Abstract]
		[Export ("getMessageCountWithStart:end:direction:type:")]
		nint GetMessageCountWithStart (nint startTimestamp, nint endTimestamp, AgoraChatMessageStatisticsDirection direction, AgoraChatMessageStatisticsType type);

		// @required -(NSInteger)getMessageStatisticsSizeWithStart:(NSInteger)startTimestamp end:(NSInteger)endTimestamp direction:(AgoraChatMessageStatisticsDirection)direction type:(AgoraChatMessageStatisticsType)type;
		[Abstract]
		[Export ("getMessageStatisticsSizeWithStart:end:direction:type:")]
		nint GetMessageStatisticsSizeWithStart (nint startTimestamp, nint endTimestamp, AgoraChatMessageStatisticsDirection direction, AgoraChatMessageStatisticsType type);
	}

	// @interface AgoraChatDeviceConfig : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatDeviceConfig : INativeObject
	{
		// @property (readonly, nonatomic) NSString * _Nullable resource;
		[NullAllowed, Export ("resource")]
		string Resource { get; }

		// @property (readonly, nonatomic) NSString * _Nullable deviceUUID;
		[NullAllowed, Export ("deviceUUID")]
		string DeviceUUID { get; }

		// @property (readonly, nonatomic) NSString * _Nullable deviceName;
		[NullAllowed, Export ("deviceName")]
		string DeviceName { get; }
	}

	// @protocol AgoraChatLocalNotificationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AgoraChatLocalNotificationDelegate
	{
		// @optional -(void)emuserNotificationCenter:(UNUserNotificationCenter * _Nonnull)center willPresentNotification:(UNNotification * _Nonnull)notification withCompletionHandler:(void (^ _Nonnull)(UNNotificationPresentationOptions))completionHandler;
		[Export ("emuserNotificationCenter:willPresentNotification:withCompletionHandler:")]
		void EmuserNotificationCenter (UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler);

		// @optional -(void)emuserNotificationCenter:(UNUserNotificationCenter * _Nonnull)center didReceiveNotificationResponse:(UNNotificationResponse * _Nonnull)response withCompletionHandler:(void (^ _Nonnull)(void))completionHandler;
		[Export ("emuserNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
		void EmuserNotificationCenter (UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler);

		// @optional -(void)emuserNotificationCenter:(UNUserNotificationCenter * _Nonnull)center openSettingsForNotification:(UNNotification * _Nonnull)notification;
		[Export ("emuserNotificationCenter:openSettingsForNotification:")]
		void EmuserNotificationCenter (UNUserNotificationCenter center, UNNotification notification);

		// @optional -(void)emGetNotificationMessage:(UNNotification * _Nonnull)notification state:(AgoraChatNotificationState)state;
		[Export ("emGetNotificationMessage:state:")]
		void EmGetNotificationMessage (UNNotification notification, AgoraChatNotificationState state);

		// @optional -(void)emHandleNotificationContent:(UNMutableNotificationContent * _Nonnull)content;
		[Export ("emHandleNotificationContent:")]
		void EmHandleNotificationContent (UNMutableNotificationContent content);

		// @optional -(void)emDidRecivePushSilentMessage:(NSDictionary * _Nonnull)messageDic;
		[Export ("emDidRecivePushSilentMessage:")]
		void EmDidRecivePushSilentMessage (NSDictionary messageDic);
	}

	// @interface AgoraChatLocalNotificationManager : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatLocalNotificationManager
	{
		// +(instancetype _Nonnull)sharedManager;
		[Static]
		[Export ("sharedManager")]
		AgoraChatLocalNotificationManager SharedManager ();

		// -(void)launchWithDelegate:(id<AgoraChatLocalNotificationDelegate> _Nonnull)aDelegate;
		[Export ("launchWithDelegate:")]
		void LaunchWithDelegate (AgoraChatLocalNotificationDelegate aDelegate);

		// -(void)userNotificationCenter:(UNUserNotificationCenter * _Nonnull)center willPresentNotification:(UNNotification * _Nonnull)notification withCompletionHandler:(void (^ _Nonnull)(UNNotificationPresentationOptions))completionHandler;
		[Export ("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
		void UserNotificationCenter (UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler);

		// -(void)userNotificationCenter:(UNUserNotificationCenter * _Nonnull)center didReceiveNotificationResponse:(UNNotificationResponse * _Nonnull)response withCompletionHandler:(void (^ _Nonnull)(void))completionHandler;
		[Export ("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
		void UserNotificationCenter (UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler);
	}

	// @protocol AgoraChatLogDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AgoraChatLogDelegate
	{
		// @optional -(void)logDidOutput:(NSString * _Nonnull)log;
		[Export ("logDidOutput:")]
		void LogDidOutput (string log);
	}

	// @interface AgoraChatClient : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
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
		[NullAllowed, Export ("contactManager", ArgumentSemantic.Strong)]
		IAgoraChatContactManager ContactManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatGroupManager> _Nullable groupManager;
		[NullAllowed, Export ("groupManager", ArgumentSemantic.Strong)]
		IAgoraChatGroupManager GroupManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatThreadManager> _Nullable threadManager;
		[NullAllowed, Export ("threadManager", ArgumentSemantic.Strong)]
		IAgoraChatThreadManager ThreadManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatroomManager> _Nullable roomManager;
		[NullAllowed, Export ("roomManager", ArgumentSemantic.Strong)]
		IAgoraChatroomManager RoomManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatPushManager> _Nullable pushManager;
		[NullAllowed, Export ("pushManager", ArgumentSemantic.Strong)]
		IAgoraChatPushManager PushManager { get; }

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
		[NullAllowed, Export ("presenceManager", ArgumentSemantic.Strong)]
		IAgoraChatPresenceManager PresenceManager { get; }

		// @property (readonly, nonatomic, strong) id<IAgoraChatStatisticsManager> _Nullable statisticsManager;
		[NullAllowed, Export ("statisticsManager", ArgumentSemantic.Strong)]
		IAgoraChatStatisticsManager StatisticsManager { get; }

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
		[Export ("addMultiDevicesDelegate:delegateQueue:")]
		void AddMultiDevicesDelegate (AgoraChatMultiDevicesDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// -(void)removeMultiDevicesDelegate:(id<AgoraChatMultiDevicesDelegate> _Nonnull)aDelegate;
		[Export ("removeMultiDevicesDelegate:")]
		void RemoveMultiDevicesDelegate (AgoraChatMultiDevicesDelegate aDelegate);

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
		[Export ("loginWithUsernamePassword:password:")]
		[return: NullAllowed]
		AgoraChatError LoginWithUsernamePassword (string aUsername, string aPassword);

		// -(void)loginWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword completion:(void (^ _Nullable)(NSString * _Nonnull, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("")));
		[Export ("loginWithUsernamePasswordClk:password:completion:")]
		void LoginWithUsernamePasswordClk (string aUsername, string aPassword, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)loginWithUsername:(NSString * _Nonnull)aUsername token:(NSString * _Nonnull)aToken;
		[Export ("loginWithUsernameToken:token:")]
		[return: NullAllowed]
		AgoraChatError LoginWithUsernameToken (string aUsername, string aToken);

		// -(void)loginWithUsername:(NSString * _Nonnull)aUsername token:(NSString * _Nonnull)aToken completion:(void (^ _Nullable)(NSString * _Nonnull, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("loginWithUsernameTokenClk:token:completion:")]
		void LoginWithUsernameTokenClk (string aUsername, string aToken, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

		// -(AgoraChatError * _Nullable)loginWithUsername:(NSString * _Nonnull)aUsername agoraToken:(NSString * _Nonnull)aAgoraToken __attribute__((deprecated("")));
		[Export ("loginWithUsernameAgoraToken:agoraToken:")]
		[return: NullAllowed]
		AgoraChatError LoginWithUsernameAgoraToken (string aUsername, string aAgoraToken);

		// -(void)loginWithUsername:(NSString * _Nonnull)aUsername agoraToken:(NSString * _Nonnull)aAgoraToken completion:(void (^ _Nullable)(NSString * _Nonnull, AgoraChatError * _Nullable))aCompletionBlock __attribute__((deprecated("")));
		[Export ("loginWithUsernameAgoraTokenClk:agoraToken:completion:")]
		void LoginWithUsernameAgoraTokenClk (string aUsername, string aAgoraToken, [NullAllowed] Action<NSString, AgoraChatError> aCompletionBlock);

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
		[Export ("getLoggedInDevicesFromServerWithUsername:password:error:")]
		[return: NullAllowed]
		AgoraChatDeviceConfig[] GetLoggedInDevicesFromServerWithUsername (string aUsername, string aPassword, out AgoraChatError pError);

		// -(void)getLoggedInDevicesFromServerWithUsername:(NSString * _Nonnull)aUsername password:(NSString * _Nonnull)aPassword completion:(void (^ _Nullable)(NSArray<AgoraChatDeviceConfig *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("getLoggedInDevicesFromServerWithUsername:password:completion:")]
		void GetLoggedInDevicesFromServerWithUsername (string aUsername, string aPassword, [NullAllowed] Action<NSArray<AgoraChatDeviceConfig>, AgoraChatError> aCompletionBlock);

		// -(void)getLoggedInDevicesFromServerWithUserId:(NSString * _Nonnull)aUserID token:(NSString * _Nonnull)aToken completion:(void (^ _Nullable)(NSArray<AgoraChatDeviceConfig *> * _Nullable, AgoraChatError * _Nullable))aCompletionBlock;
		[Export ("getLoggedInDevicesFromServerWithUserId:token:completion:")]
		void GetLoggedInDevicesFromServerWithUserId (string aUserID, string aToken, [NullAllowed] Action<NSArray<AgoraChatDeviceConfig>, AgoraChatError> aCompletionBlock);

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
		[Export ("getDeviceConfig:")]
		AgoraChatDeviceConfig GetDeviceConfig (out AgoraChatError pError);

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
		[Export ("translateManager", ArgumentSemantic.Strong)]
		IAgoraChatTranslateManager TranslateManager { get; }
	}

	// @interface AgoraChatMessageReactionOperation : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatMessageReactionOperation
	{
		// @property (readonly, copy) NSString * _Nonnull userId;
		[Export ("userId")]
		string UserId { get; }

		// @property (readonly, copy) NSString * _Nonnull reaction;
		[Export ("reaction")]
		string Reaction { get; }

		// @property (readonly, assign) AgoraChatMessageReactionOperate operate;
		[Export ("operate", ArgumentSemantic.Assign)]
		AgoraChatMessageReactionOperate Operate { get; }
	}

	// @interface AgoraChatMessageReactionChange : NSObject
	[BaseType (typeof(NSObject))]
	interface AgoraChatMessageReactionChange
	{
		// @property (readonly) NSString * _Nullable conversationId;
		[NullAllowed, Export ("conversationId")]
		string ConversationId { get; }

		// @property (readonly) NSString * _Nullable messageId;
		[NullAllowed, Export ("messageId")]
		string MessageId { get; }

		// @property (readonly) NSArray<AgoraChatMessageReaction *> * _Nullable reactions;
		[NullAllowed, Export ("reactions")]
		AgoraChatMessageReaction[] Reactions { get; }

		// @property (readonly) NSArray<AgoraChatMessageReactionOperation *> * _Nullable operations;
		[NullAllowed, Export ("operations")]
		AgoraChatMessageReactionOperation[] Operations { get; }
	}
}
