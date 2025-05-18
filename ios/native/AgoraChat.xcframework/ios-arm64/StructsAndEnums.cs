using ObjCRuntime;

namespace HotCoffee.AgoraChat.iOS
{
	[Native]
	public enum AgoraChatErrorCode : long
	{
		NoError = 0,
		General = 1,
		NetworkUnavailable,
		DatabaseOperationFailed,
		ExceedServiceLimit,
		ServiceArrearages,
		PushReportActionFailed,
		PartialSuccess,
		AppActiveNumbersReachLimitation,
		InvalidAppkey = 100,
		InvalidUsername,
		InvalidPassword,
		InvalidURL,
		InvalidToken,
		UsernameTooLong,
		ChannelSyncNotOpen,
		InvalidConversation,
		TokenExpire,
		TokeWillExpire,
		InvalidParam = 110,
		OperationUnsupported,
		QueryParamReachesLimit,
		UserAlreadyLoginSame = 200,
		UserNotLogin,
		UserAuthenticationFailed,
		UserAlreadyExist,
		UserNotFound,
		UserIllegalArgument,
		UserLoginOnAnotherDevice,
		UserRemoved,
		UserRegisterFailed,
		UpdateApnsConfigsFailed,
		UserPermissionDenied,
		UserBindDeviceTokenFailed,
		UserUnbindDeviceTokenFailed,
		UserBindAnotherDevice,
		UserLoginTooManyDevices,
		UserMuted,
		UserKickedByChangePassword,
		UserKickedByOtherDevice,
		UserAlreadyLoginAnother,
		UserMutedByAdmin,
		UserDeviceChanged,
		UserNotOnRoster,
		ServerNotReachable = 300,
		ServerTimeout,
		ServerBusy,
		ServerUnknownError,
		ServerGetDNSConfigFailed,
		ServerServingForbidden,
		ServerDecryptionFailed,
		ServerGetRTCConfigFailed,
		ServerNoMatchURL,
		FileNotFound = 400,
		FileInvalid,
		FileUploadFailed,
		FileDownloadFailed,
		FileDeleteFailed,
		FileTooLarge,
		FileContentImproper,
		FileExpired,
		MessageInvalid = 500,
		MessageIncludeIllegalContent,
		MessageTrafficLimit,
		MessageEncryption,
		MessageRecallTimeLimit,
		ServiceNotEnable,
		MessageExpired,
		MessageIllegalWhiteList,
		MessageExternalLogicBlocked,
		MessageCurrentLimiting,
		MessageSizeLimit,
		EditFailed,
		GroupInvalidId = 600,
		GroupAlreadyJoined,
		GroupNotJoined,
		GroupPermissionDenied,
		GroupMembersFull,
		GroupSharedFileInvalidId,
		GroupNotExist,
		GroupDisabled,
		GroupNameViolation,
		GroupMemberAttributesReachLimit,
		GroupMemberAttributesUpdateFailed,
		GroupMemberAttributesKeyReachLimit,
		GroupMemberAttributesValueReachLimit,
		GroupUserInBlockList,
		ChatroomInvalidId = 700,
		ChatroomAlreadyJoined,
		ChatroomNotJoined,
		ChatroomPermissionDenied,
		ChatroomMembersFull,
		ChatroomNotExist,
		ChatroomOwnerNotAllowLeave,
		ChatroomUserInBlockList,
		UserCountExceed = 900,
		UserInfoDataLengthExceed = 901,
		ContactAddFaild = 1000,
		ContactReachLimit = 1001,
		ContactReachLimitPeer = 1002,
		PresenceParamExceed = 1100,
		PresenceCannotSubscribeSelf = 1101,
		TranslateParamError = 1110,
		TranslateServiceNotEnabled = 1111,
		TranslateUsageLimit = 1112,
		TranslateServiceFail = 1113,
		ModerationFailed = 1200,
		ThirdServiceFailed = 1299,
		ReactionReachLimit = 1300,
		ReactionHasBeenOperated = 1301,
		ReactionOperationIsIllegal = 1302,
		ThreadNotExist = 1400,
		ThreadAlreadyExist = 1401,
		ThreadCreateMessageIllegal = 1402,
		NotSupportPush,
		PushBindFailed = 1501,
		PushUnBindFailed = 1502
	}

	[Native]
	public enum AgoraChatConnectionState : long
	{
		Connected = 0,
		Disconnected
	}

	[Native]
	public enum AgoraChatMessageBodyType : long
	{
		Text = 1,
		Image,
		Video,
		Location,
		Voice,
		File,
		Cmd,
		Custom,
		Combine
	}

	[Native]
	public enum AgoraChatSilentModeParamType : long
	{
		RemindType = 0,
		Duration,
		Interval
	}

	[Native]
	public enum AgoraChatPushRemindType : long
	{
		All,
		MentionOnly,
		None
	}

	[Native]
	public enum AgoraChatConversationType : long
	{
		Chat = 0,
		GroupChat,
		ChatRoom
	}

	[Native]
	public enum AgoraChatMarkType : long
	{
		AgoraChatMarkType0 = 0,
		AgoraChatMarkType1 = 1,
		AgoraChatMarkType2 = 2,
		AgoraChatMarkType3 = 3,
		AgoraChatMarkType4 = 4,
		AgoraChatMarkType5 = 5,
		AgoraChatMarkType6 = 6,
		AgoraChatMarkType7 = 7,
		AgoraChatMarkType8 = 8,
		AgoraChatMarkType9 = 9,
		AgoraChatMarkType10 = 10,
		AgoraChatMarkType11 = 11,
		AgoraChatMarkType12 = 12,
		AgoraChatMarkType13 = 13,
		AgoraChatMarkType14 = 14,
		AgoraChatMarkType15 = 15,
		AgoraChatMarkType16 = 16,
		AgoraChatMarkType17 = 17,
		AgoraChatMarkType18 = 18,
		AgoraChatMarkType19 = 19
	}

	[Native]
	public enum AgoraChatMessageSearchDirection : long
	{
		Up = 0,
		Down
	}

	[Native]
	public enum AgoraChatMessageSearchScope : long
	{
		Content = 0,
		Ext,
		All
	}

	[Native]
	public enum AgoraChatMultiDevicesEvent : long
	{
		Unknow = -1,
		ContactRemove = 2,
		ContactAccept = 3,
		ContactDecline = 4,
		ContactBan = 5,
		ContactAllow = 6,
		GroupCreate = 10,
		GroupDestroy = 11,
		GroupJoin = 12,
		GroupLeave = 13,
		GroupApply = 14,
		GroupApplyAccept = 15,
		GroupApplyDecline = 16,
		GroupInvite = 17,
		GroupInviteAccept = 18,
		GroupInviteDecline = 19,
		GroupKick = 20,
		GroupBan = 21,
		GroupAllow = 22,
		GroupBlock = 23,
		GroupUnBlock = 24,
		GroupAssignOwner = 25,
		GroupAddAdmin = 26,
		GroupRemoveAdmin = 27,
		GroupAddMute = 28,
		GroupRemoveMute = 29,
		GroupAddWhiteList = 30,
		GroupRemoveWhiteList = 31,
		GroupAllBan = 32,
		GroupRemoveAllBan = 33,
		GroupDisabled = 34,
		GroupAble = 35,
		ChatThreadCreate = 40,
		ChatThreadDestroy = 41,
		ChatThreadJoin = 42,
		ChatThreadLeave = 43,
		ChatThreadUpdate = 44,
		ChatThreadKick = 45,
		GroupMemberAttributesChanged = 52,
		ConversationPinned = 60,
		ConversationUnpinned = 61,
		ConversationDelete = 62,
		ConversationUpdateMark = 63,
		ConversationMuteInfoChanged = 64
	}

	[Native]
	public enum AgoraChatLogLevel : long
	{
		Debug = 0,
		Warning,
		Error
	}

	[Native]
	public enum AreaCode : long
	{
		Cn = 1L << 0,
		Na = 1L << 1,
		Eu = 1L << 2,
		As = 1L << 3,
		Jp = 1L << 4,
		In = 1L << 5,
		Glob = -1
	}

	[Native]
	public enum AgoraChatPushDisplayStyle : long
	{
		SimpleBanner = 0,
		MessageSummary
	}

	[Native]
	public enum AgoraChatType : long
	{
		Chat = 0,
		GroupChat,
		ChatRoom
	}

	[Native]
	public enum AgoraChatMessageStatus : long
	{
		Pending = 0,
		Delivering,
		Succeed,
		Failed
	}

	[Native]
	public enum AgoraChatMessageDirection : long
	{
		Send = 0,
		Receive
	}

	[Native]
	public enum AgoraChatRoomMessagePriority : long
	{
		High = 0,
		Normal,
		Low
	}

	[Native]
	public enum AgoraChatMessagePinOperation : long
	{
		Pin = 0,
		Unpin
	}

	[Native]
	public enum AgoraChatDownloadStatus : long
	{
		Downloading = 0,
		Succeed,
		Failed,
		Pending,
		Successed = Succeed
	}

	[Native]
	public enum AgoraChatMessageFetchHistoryDirection : ulong
	{
		Up = 0,
		Down
	}

	[Native]
	public enum AgoraChatroomBeKickedReason : long
	{
		BeRemoved = 0,
		Destroyed,
		Offline
	}

	[Native]
	public enum AgoraChatroomPermissionType : long
	{
		None = -1,
		Member = 0,
		Admin,
		Owner
	}

	[Native]
	public enum AgoraChatGroupLeaveReason : long
	{
		BeRemoved = 0,
		UserLeave,
		Destroyed
	}

	[Native]
	public enum AgoraChatGroupStyle : long
	{
		rivateOnlyOwnerInvite = 0,
		rivateMemberCanInvite,
		ublicJoinNeedApproval,
		ublicOpenJoin
	}

	[Native]
	public enum AgoraChatGroupPermissionType : long
	{
		None = -1,
		Member = 0,
		Admin,
		Owner
	}

	[Native]
	public enum AgoraChatThreadOperation : ulong
	{
		Unknown,
		Create,
		Update,
		Delete,
		Update_msg
	}

	[Native]
	public enum AgoraChatUserInfoType : long
	{
		NickName = 0,
		AvatarURL,
		Phone,
		Mail,
		Gender,
		Sign,
		Birth,
		Ext = 100
	}

	[Native]
	public enum AgoraChatMessageStatisticsDirection : ulong
	{
		Send = 0,
		Receive,
		All = 100
	}

	[Native]
	public enum AgoraChatMessageStatisticsType : ulong
	{
		Text = 0,
		Image,
		Video,
		Location,
		Voice,
		File,
		Cmd,
		Custom,
		All = 100
	}

	[Native]
	public enum AgoraChatNotificationState : long
	{
		WillPresentNotification = 0,
		DidReceiveNotificationResponse
	}

	[Native]
	public enum AgoraChatServerCheckType : long
	{
		AccountValidation = 0,
		GetDNSListFromServer,
		GetTokenFromServer,
		DoLogin,
		DoLogout
	}

	[Native]
	public enum AgoraChatMessageReactionOperate : ulong
	{
		Remove = 0,
		Add
	}
}
