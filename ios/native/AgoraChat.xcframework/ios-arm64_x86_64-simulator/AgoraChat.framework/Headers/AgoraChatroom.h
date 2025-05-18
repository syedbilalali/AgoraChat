/**
 *  
 *  @header AgoraChatroom.h
 *  @abstract Chatroom
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>

#import "AgoraChatCommonDefs.h"

/**
 *  
 *  The enum of chat room permission types.
 */
typedef NS_ENUM(NSInteger, AgoraChatroomPermissionType) {
    AgoraChatroomPermissionTypeNone   = -1,    /**  Unknown type*/
    AgoraChatroomPermissionTypeMember = 0,     /**  Normal member type*/
    AgoraChatroomPermissionTypeAdmin,          /**  Chatroom admin type*/
    AgoraChatroomPermissionTypeOwner,          /**  Chatroom owner  type*/
};


/**
 *   
 *  The chat room object.
 */
@interface AgoraChatroom : NSObject

/**
 *   
 *  The chat room ID.
 */
@property (nonatomic, copy, readonly) NSString * _Nullable chatroomId;

/**
 *   
 *  The subject of the chat room.
 */
@property (nonatomic, copy, readonly) NSString * _Nullable subject;

/**
 *   
 *  The description of chat room.
 */
@property (nonatomic, copy, readonly) NSString * _Nullable description;

/**
 *  
 *  The owner of the chat room. There is only one owner per chat room. 
 */
@property (nonatomic, copy, readonly) NSString * _Nullable owner;

/**
 *  
 *  The announcement of the chat room.
 */
@property (nonatomic, copy, readonly) NSString * _Nullable announcement;

/**
 *  
 *  The admins of the chatroom.
 *
 */
@property (nonatomic, copy, readonly) NSArray<NSString *> * _Nullable adminList;

/**
 *  
 *  The list of members in the chat room.
 */
@property (nonatomic, copy, readonly) NSArray<NSString *> * _Nullable memberList;

/**
 *  
 *  The blocklist of the chatroom.
 *
 *  Only the chatroom owner can call the method. Returns nil if the user is not the chatroom owner.
 */
@property (nonatomic, strong, readonly) NSArray<NSString *> * _Nullable blacklist;


/**
 *  
 *  The list of muted members.
 *
 *  Only the chatroom owner can call the method. Returns nil if the user is not the chatroom owner.
 */
@property (nonatomic, strong, readonly) NSArray<NSString *> * _Nullable muteList;

/**
*  
*  The allowlist members <NSString>
*
*  Only the chatroom owner can call the method. Returns nil if the user is not the chatroom owner.
*/
@property (nonatomic, strong, readonly) NSArray<NSString *> * _Nullable whitelist;

/**
 *  
 *  The chatroom membership type of the current login account.
 */
@property (nonatomic, readonly) AgoraChatroomPermissionType permissionType;

/**
 *  
 *  The maximum member number of the chat room.
 */
@property (nonatomic, readonly) NSInteger maxOccupantsCount;

/**
 *  
 *  The current number of members in the chat room.
 */
@property (nonatomic, readonly) NSInteger occupantsCount;

/**
 *  
 *  Whether all members of the chat room are muted.
 */
@property (nonatomic, readonly) BOOL isMuteAllMembers;
/**
 *  
 *  Constructs a chatroom instance with chatroom ID.
 *
 *  @param aChatroomId   The chatroom ID.
 *
 *  @result The chatroom instance.
 */
+ (instancetype _Nullable)chatroomWithId:(NSString * _Nonnull )aChatroomId;

#pragma mark - EM_DEPRECATED_IOS 3.8.8

/**
*  
*  List of whitelist members<NSString>
*
*  Need owner's authority to access, return nil if user is not the chatroom owner.
*/
@property (nonatomic, strong, readonly) NSArray *whiteList __deprecated_msg("Use whitelist instead");

#pragma mark - EM_DEPRECATED_IOS 3.3.0

/**
 *  
 *  Deprecated, please use -memberList instead. The list of members in the chat room.
 */
@property (nonatomic, copy, readonly) NSArray *members EM_DEPRECATED_IOS(3_1_0, 3_3_0, "Use -memberList instead");

/**
 *  
 *  Deprecated, please use -occupantsCount instead. The total number of members in the chat room.
 */
@property (nonatomic, readonly) NSInteger membersCount EM_DEPRECATED_IOS(3_1_0, 3_3_0, "Use -occupantsCount instead");

/**
 *  
 *  Deprecated, please use -maxOccupantsCount instead.The maximum member number of the chat room.
 */
@property (nonatomic, readonly) NSInteger maxMembersCount EM_DEPRECATED_IOS(3_1_0, 3_3_0, "Use -maxOccupantsCount instead");

#pragma mark - EM_DEPRECATED_IOS < 3.2.3

/**
 *  
 *  Deprecated, please use - members instead. The list of members in the chat room.
 */
@property (nonatomic, copy, readonly) NSArray *occupants __deprecated_msg("Use -members instead");

/**
 *  
 *  Deprecated, please use  {@link +chatroomWithId:}  instead.Initializes chatroom instance.
 *
 *   
 *
 *  @result nil
 */
- (instancetype)init __deprecated_msg("Use +chatroomWithId: instead");

@end
