/**
 *  
 *  @header AgoraChatGroup.h
 *  @abstract The group model.
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>

#import "AgoraChatCommonDefs.h"
#import "AgoraChatGroupOptions.h"
@class AgoraChatGroupSharedFile;

/**
 *  
 *  The group permission type.
 */
typedef NS_ENUM(NSInteger, AgoraChatGroupPermissionType) {
    AgoraChatGroupPermissionTypeNone   = -1,    /**  The unknown type.*/
    AgoraChatGroupPermissionTypeMember = 0,     /**  The group member.*/
    AgoraChatGroupPermissionTypeAdmin,          /**  The group admin.*/
    AgoraChatGroupPermissionTypeOwner,          /**  The group owner.*/
};

/**
 *  
 *  The group.
 */
@interface AgoraChatGroup : NSObject

/**
 *  
 *  The group ID.
 */
@property (nonatomic, copy, readonly) NSString *groupId;

/**
*  
*  The subject of the group. To get the value of this member, you need to call `getGroupSpecificationFromServerWithId` to get the group details first.
*/
@property (nonatomic, copy, readonly) NSString *groupName;

/**
 *  
 *  The description of the group. To get the value of this member, you need to call `getGroupSpecificationFromServerWithId` first.
 */
@property (nonatomic, copy, readonly) NSString *description;

/**
 *  
 *  The announcement of the group. To get the value of this member, you need to call `getGroupAnnouncementWithId` first.
 */
@property (nonatomic, copy, readonly) NSString *announcement;

/**
 *  
 *  The setting options of group. To get the value of this member, you need to call `getGroupSpecificationFromServerWithId` first.
 */
@property (nonatomic, strong, readonly) AgoraChatGroupOptions *settings;

/**
 *  
 *  The owner of the group who has the highest privilege of the group. To get the value of this member, you need to call `getGroupSpecificationFromServerWithId` first.
 *
 *  Each chat group has only one owner.
 */
@property (nonatomic, copy, readonly) NSString *owner;

/**
 *  
 *  The admins of the group who have the group management authority. To get the value of this member, you need to call `getGroupSpecificationFromServerWithId` first.
 *
 */
@property (nonatomic, copy, readonly) NSArray<NSString *> *adminList;

/**
 *  
 *  The member list of the group. To get the value of this member, you need to call `getGroupSpecificationFromServerWithId` first.
 */
@property (nonatomic, copy, readonly) NSArray<NSString *> *memberList;

/**
 *  
 *  The blocklist of the chat group. To get the value of this member, you need to call `getGroupSpecificationFromServerWithId` first.
 *
 *  Only the group owner can call this method. Otherwise, the SDK returns nil.
 */
@property (nonatomic, strong, readonly) NSArray<NSString *> *blacklist;

/**
 *  
 *  The list of muted members.
 *
 *  Only the group owner or admin can call this method. Otherwise, the SDK returns nil.
 */
@property (nonatomic, strong, readonly) NSArray<NSString *> *muteList;


/**
 *  
 *  The allowlist of the chat group. 
 *
 *  Only the group owner can call this method. Otherwise, the SDK returns nil.
 */
@property (nonatomic, strong, readonly) NSArray<NSString *> *whiteList;

/**
 *  
 *  The list of group shared files.
 */
@property (nonatomic, strong, readonly) NSArray<AgoraChatGroupSharedFile *> *sharedFileList;

/**
 *  
 *  Whether to enable the push notification service for the group.
 */
@property (nonatomic, readonly) BOOL isPushNotificationEnabled;

/**
 *  
 *  Whether the group is a public group. To get the value of this member, you need to call `getGroupSpecificationFromServerWithId` first.
 */
@property (nonatomic, readonly) BOOL isPublic;

/**
 *  
 *  Whether to block the current group‘s messages.
 */
@property (nonatomic, readonly) BOOL isBlocked;

/**
 *  
 *  The group membership type of the current login account.
 */
@property (nonatomic, readonly) AgoraChatGroupPermissionType permissionType;

/**
 *  
 *  All occupants of the group, including the group owner, admins, and all other group members.
 */
@property (nonatomic, strong, readonly) NSArray<NSString *> *users;

/**
 *  
 *  The total number of group occupants, including the owner, admins, and all other group members. To get the value of this member, you need to call getGroupSpecificationFromServerWithId first. 
 */
@property (nonatomic, readonly) NSInteger occupantsCount;

/**
 *  
 *  Whether all the group members are muted.
 */
@property (nonatomic, readonly) BOOL isMuteAllMembers;

/**
  *  
  *  Whether the group is disabled. The default value for reading or pulling roaming messages from the database is NO
  */
 @property (nonatomic, readonly) BOOL isDisabled;

/**
 *  
 *  Gets the group instance. Creates an instance if it does not exist.
 *
 *  @param aGroupId  The group ID.
 *
 *  @result The group instance.
 */
+ (instancetype)groupWithId:(NSString *)aGroupId;

#pragma mark - EM_DEPRECATED_IOS 3.8.8
/**
 *  
 *  Setting options of group, require fetch group's detail first.
 * 
 *  Deprecated. Please use  {@link settings}  instead.
 */
@property (nonatomic, strong, readonly) AgoraChatGroupOptions *setting __deprecated_msg("Use settings instead");

/**
 *  
 *  All occupants of the group, includes the group owner and admins and all other group members.
 * 
 *  Deprecated. Please use  {@link users}  instead.
 */
@property (nonatomic, strong, readonly) NSArray *occupants
__deprecated_msg("Use users instead");

@end
