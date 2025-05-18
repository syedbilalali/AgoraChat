/**
 *  
 *  @header AgoraChatGroupOptions.h
 *  @abstract Group property options
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>

#define KSDK_GROUP_MINUSERSCOUNT 3
#define KSDK_GROUP_USERSCOUNTDEFAULT 200

/**
 *  
 *  The group type.
 */
typedef NS_ENUM(NSInteger, AgoraChatGroupStyle) {
    AgoraChatGroupStylePrivateOnlyOwnerInvite  = 0,    /**!  A private group, where only the group owner can invite users to join. */
    AgoraChatGroupStylePrivateMemberCanInvite,         /**!  A private group, where all the group members including the group owner, group manager, and other group members can invite users to join.  */
    AgoraChatGroupStylePublicJoinNeedApproval,         /**!  A public group, where the group owner can invite users to user. Users can send a join request and join the group if the owner approves it. */
    AgoraChatGroupStylePublicOpenJoin,                 /**!  A public group, where users can join freely. */
};

/**
 *  
 *  The group options.
 */
@interface AgoraChatGroupOptions : NSObject

/**
 *  
 *  The group style.
 */
@property (nonatomic) AgoraChatGroupStyle style;

/**
 *  
 *  The maximum number of members in a group. The value range is [3,2000]; the default value is 200.
 */
@property (nonatomic) NSInteger maxUsers;

/**
 *  
 *  Whether to send an invitation notification when inviting a user to join the group. If you set it as NO, the user joins the group automatically.
 */
@property (nonatomic) BOOL IsInviteNeedConfirm;

/**
 *  
 *  The extra information of the group.
 */
@property (nonatomic, strong) NSString *ext;

#pragma mark - EM_DEPRECATED_IOS 3.8.8

/**
 *  
 *  The group capacity (3-2000, the default is 200)
 */
@property (nonatomic) NSInteger maxUsersCount
__deprecated_msg("Use maxUsers instead");


@end
