/**
 *  
 *  @header IAgoraChatGroupManager.h
 *  @abstract This protocol defines the group operations.
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>

#import "AgoraChatCommonDefs.h"
#import "AgoraChatGroupManagerDelegate.h"
#import "AgoraChatGroup.h"
#import "AgoraChatGroupOptions.h"
#import "AgoraChatCursorResult.h"
#import "AgoraChatGroupSharedFile.h"

/**
 *  
 *  The group operations.
 */
@protocol IAgoraChatGroupManager <NSObject>

@required

#pragma mark - Delegate

/**
 *  
 *  Adds delegate.
 *
 *  @param aDelegate  The delegate to be added.
 *  @param aQueue     (optional) The queue of calling delegate methods. Pass in nil to run on main thread.
 */
- (void)addDelegate:(id<AgoraChatGroupManagerDelegate> _Nonnull)aDelegate
      delegateQueue:(dispatch_queue_t _Nullable )aQueue;

/**
 *  
 *  Removes delegate.
 *
 *  @param aDelegate  The delegate to be removed.
 */
- (void)removeDelegate:(id _Nonnull)aDelegate;


#pragma mark - Get Group

/**
 *  
 *  Gets the local information of all groups created and joined by the current user.
 *
 *  @result  The group list.
 *
 */
- (NSArray<AgoraChatGroup *> *_Nullable )getJoinedGroups;

/**
 *  
 *  Clears the information of all groups in the local database.
 *
 */
- (void)cleanAllGroupsFromDB;

/**
 *  
 *  Gets the list of groups which have disabled Apple Push Notification Service.
 *
 *  @param pError    The error information if the method fails: Error.
 *
 *  @result   The group ID list.
 */
- (NSArray *)getGroupsWithoutPushNotification:(AgoraChatError **)pError EM_DEPRECATED_IOS(3_3_2, 3_8_3, "Use -IAgoraChatPushManager::noPushGroups");


#pragma mark - Get group from server

/**
 *  
 *  Gets pagesize number group you joined from the server.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aPageNum        Gets the cursor to join the group. Sets the parameter as nil for the first time.
 *  @param aPageSize       The number of results expected to be returned. If <0 then all results will be returned at once
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result  The Group list. 
 */
- (NSArray<AgoraChatGroup *> *_Nullable )getJoinedGroupsFromServerWithPage:(NSInteger)aPageNum
                                                           pageSize:(NSInteger)aPageSize
                                                              error:(AgoraChatError **_Nullable )pError __deprecated_msg("Use -getJoinedGroupsFromServerWithPage:pageSize:needMemberCount:needRole:error:completion: instead");;

/**
 *  
 *  Gets the public groups with the specified range from the server.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aCursor   The cursor to join the group. Sets the parameter as nil for the first time.
 *  @param aPageSize The number of results expected to be returned. If the number is less than 0 then all results will be returned at once.
 *  @param pError    The error information if the method fails: Error.
 *
 *  @result     The result. 
 */
- (AgoraChatCursorResult<AgoraChatGroup*> *_Nullable)getPublicGroupsFromServerWithCursor:(NSString *_Nullable)aCursor
                                               pageSize:(NSInteger)aPageSize
                                                  error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Gets public groups with the specified range from the server.
 * 
 *  This is an asynchronous method.
 *
 *  @param aCursor          Gets the cursor to join the group. Sets the parameter as nil for the first time.
 *  @param aPageSize        The number of results expected to be returned. If the number is less than 0 then all results will be returned at once.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)getPublicGroupsFromServerWithCursor:(NSString *_Nullable)aCursor
                                   pageSize:(NSInteger)aPageSize
                                 completion:(void (^_Nullable)(AgoraChatCursorResult<AgoraChatGroup*> *_Nullable aResult, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Searches a public group with the group ID.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroundId   The group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result   The groups searched.
 */
- (AgoraChatGroup * _Nullable)searchPublicGroupWithId:(NSString *_Nonnull)aGroundId
                               error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Searches public group with group ID.
 *
 *  @param aGroundId        The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)searchPublicGroupWithId:(NSString *_Nonnull)aGroundId
                     completion:(void (^_Nullable)(AgoraChatGroup *aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 * 
 * Gets groups count of the current user joined from the server.
 *
 * This is an asynchronous method.
 *
 * @param aCompletionBlock             The completion block, which contains the error message if the method fails.
 *
 */
- (void)getJoinedGroupsCountFromServerWithCompletion:(void (^_Nullable)(NSInteger groupCount, AgoraChatError *_Nullable aError))aCompletionBlock;

#pragma mark - Create

/**
 *  
 *  Creates a group.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aSubject        The subject of the group.
 *  @param aDescription    The description of the group.
 *  @param aInvitees       The members of the group. Do not include the creator.
 *  @param aMessage        The invitation message.
 *  @param aSetting        The group options.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result   The group instance. 
 */
- (AgoraChatGroup * _Nullable)createGroupWithSubject:(NSString *_Nullable)aSubject
                                  description:(NSString *_Nullable)aDescription
                                     invitees:(NSArray<NSString *> * _Nullable)aInvitees
                                      message:(NSString *_Nullable)aMessage
                                      setting:(AgoraChatGroupOptions *_Nullable)aSetting
                                        error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Creates a group.
 * 
 *  This is an asynchronous method.
 *
 *  @param aSubject         The subject of the group.
 *  @param aDescription     The description of the group.
 *  @param aInvitees        The members of the group. Do not include the creator.
 *  @param aMessage         The invitation message.
 *  @param aSetting         The group options.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)createGroupWithSubject:(NSString *_Nullable)aSubject
                   description:(NSString *_Nullable)aDescription
                      invitees:(NSArray<NSString *> * _Nullable)aInvitees
                       message:(NSString *_Nullable)aMessage
                       setting:(AgoraChatGroupOptions *_Nullable)aSetting
                    completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

#pragma mark - Fetch Info

/**
 *  
 *  Fetches the group information，including the group ID, name, description，setting, owner and admins.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId        The group ID.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result    The group instance. 
 */
- (AgoraChatGroup * _Nullable)getGroupSpecificationFromServerWithId:(NSString *_Nonnull)aGroupId
                                             error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Fetches the group specification, including the group ID, name, description, setting, owner, admins.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId              The group ID.
 *  @param fetchMembers          Whether to fetch the group members. The default action fetches at most 200 members.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)getGroupSpecificationFromServerWithId:(NSString *_Nonnull)aGroupId
                                      fetchMembers:(BOOL)fetchMembers
                                             error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Fetches the group specification, including: ID, name, description, setting, owner, admins.
 * 
 *  This is an asynchronous method.
 *
 *  @param aGroupId              The group ID.
 *  @param aCompletionBlock      The completion block, which contains the error message if the method fails.
 *
 */
- (void)getGroupSpecificationFromServerWithId:(NSString *_Nonnull)aGroupId
                                   completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Fetches the group specification, including: ID, name, description, setting, owner, admins.
 *
 *  @param aGroupId              The group ID.
 *  @param fetchMembers          Whether to fetch the group members. The default action fetches at most 200 members.
 *  @param aCompletionBlock      The completion block, which contains the error message if the method fails.
 *
 */
- (void)getGroupSpecificationFromServerWithId:(NSString *_Nonnull)aGroupId
                                 fetchMembers:(BOOL)fetchMembers
                                   completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets the list of group members from the server.
 * 
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId         The group ID.
 *  @param aCursor          The cursor when joins the group. Sets the parameter as nil for the first time.
 *  @param aPageSize        The expect entry number of the list.
 *  @param pError           The error information if the method fails: Error.
 *
 *  @result    The list and cursor.
 *
 */
- (AgoraChatCursorResult<NSString*> *)getGroupMemberListFromServerWithId:(NSString *_Nonnull)aGroupId
                                                cursor:(NSString *_Nullable)aCursor
                                              pageSize:(NSInteger)aPageSize
                                                 error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Gets the list of group members from the server.
 *
 *  @param aGroupId         The group ID.
 *  @param aCursor          The cursor when joins the group. Sets the parameter as nil for the first time.
 *  @param aPageSize        The page size.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)getGroupMemberListFromServerWithId:(NSString *_Nonnull)aGroupId
                                    cursor:(NSString *_Nullable)aCursor
                                  pageSize:(NSInteger)aPageSize
                                completion:(void (^_Nullable)(AgoraChatCursorResult<NSString*> *aResult, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets the blocklist of group from the server.
 * 
 *  Only the group owner or admin can call this method.
 *
 *  @param aGroupId         The group ID.
 *  @param aPageNum         The page number.
 *  @param aPageSize        The page size.
 *  @param pError           The error information if the method fails: Error.
 *
 *  @result     The blockList of the group.
 */
- (NSArray<NSString *> * _Nullable)getGroupBlacklistFromServerWithId:(NSString *_Nonnull)aGroupId
                                    pageNumber:(NSInteger)aPageNum
                                      pageSize:(NSInteger)aPageSize
                                         error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Gets the group's blocklist.
 * 
 *  Only the group owner or admin can call this method.
 *
 *  @param aGroupId         The group ID.
 *  @param aPageNum         The page number.
 *  @param aPageSize        The page size.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)getGroupBlacklistFromServerWithId:(NSString *_Nonnull)aGroupId
                               pageNumber:(NSInteger)aPageNum
                                 pageSize:(NSInteger)aPageSize
                               completion:(void (^_Nullable)(NSArray<NSString *> * _Nullable aList, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets the mutelist of the group from the server.
 *
 *  Only the group owner or admin can call this method.
 *
 *  @param aGroupId         The group ID.
 *  @param aPageNum         The page number.
 *  @param aPageSize        The page size.
 *  @param pError           The error information if the method fails: Error.
 *
 *  @result     The mutelist of the group.
 */
- (NSArray<NSString *> * _Nullable)getGroupMuteListFromServerWithId:(NSString *_Nonnull)aGroupId
                                   pageNumber:(NSInteger)aPageNum
                                     pageSize:(NSInteger)aPageSize
                                        error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Gets the mutelist of the group from the server.
 *
 *  Only the group owner or admin can call this method.
 *
 *  @param aGroupId         The group ID.
 *  @param aPageNum         The page number.
 *  @param aPageSize        The page size.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)getGroupMuteListFromServerWithId:(NSString *_Nonnull)aGroupId
                              pageNumber:(NSInteger)aPageNum
                                pageSize:(NSInteger)aPageSize
                              completion:(void (^_Nullable)(NSArray<NSString *> * _Nullable aList, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets the mutelist of the group from the server.
 *
 *  Only the group owner or admin can call this method.
 *
 *  @param aGroupId         The group ID.
 *  @param aPageNum         The page number.
 *  @param aPageSize        The page size.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)fetchGroupMuteListFromServerWithId:(NSString *_Nonnull)aGroupId
                              pageNumber:(NSInteger)aPageNum
                                pageSize:(NSInteger)aPageSize
                              completion:(void (^_Nullable)(NSDictionary<NSString *, NSNumber *> *_Nullable aDict, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets the share files of group from the server.
 *
 *  @param aGroupId         The group ID.
 *  @param aPageNum         The page number.
 *  @param aPageSize        The page size.
 *  @param pError           The error information if the method fails: Error.
 *
 *  @result   The list of share files of group.
 */
- (NSArray<AgoraChatGroupSharedFile *> *_Nullable)getGroupFileListWithId:(NSString *_Nonnull)aGroupId
                                              pageNumber:(NSInteger)aPageNum
                                                pageSize:(NSInteger)aPageSize
                                                   error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Gets the share files of group from the server.
 * 
 *  This is an asynchronous method.
 *
 *  @param aGroupId         The group ID.
 *  @param aPageNum         The page number.
 *  @param aPageSize        The page size.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 */
- (void)getGroupFileListWithId:(NSString *_Nonnull)aGroupId
                    pageNumber:(NSInteger)aPageNum
                      pageSize:(NSInteger)aPageSize
                    completion:(void (^_Nullable)(NSArray<AgoraChatGroupSharedFile *> *_Nullable aList, AgoraChatError *_Nullable aError))aCompletionBlock;


/**
 *  
 *  Gets the allowlist of group from the server.
 *
 *  @param aGroupId        The group ID.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result     The allowList of the group.
 *
 */
- (NSArray *)getGroupWhiteListFromServerWithId:(NSString *_Nonnull)aGroupId
                                         error:(AgoraChatError **_Nullable)pError;


/**
 *  
 *  Gets the allowlist of group from the server.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)getGroupWhiteListFromServerWithId:(NSString *_Nonnull)aGroupId
                               completion:(void (^_Nullable)(NSArray<NSString *> * _Nullable aList, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets whether the member is on the allowlist.
 *
 *  @param aGroupId        The group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result  BOOL.    YES: in whiteList.    NO: not in whiteList.
 *
 */
- (BOOL)isMemberInWhiteListFromServerWithGroupId:(NSString *_Nonnull)aGroupId
                                           error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Gets whether the member is on the allowlist.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)isMemberInWhiteListFromServerWithGroupId:(NSString *_Nonnull)aGroupId
                                      completion:(void (^_Nullable)(BOOL inWhiteList, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets the announcement of group from the server.
 *
 *  @param aGroupId        The group ID.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result    The group Announcement. The SDK will return nil if fails.
 */
- (NSString *_Nullable)getGroupAnnouncementWithId:(NSString *_Nonnull)aGroupId
                                   error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Checks whether the current user is on the mute list of a group.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)isMemberInMuteListFromServerWithGroupId:(NSString * _Nonnull)aGroupId
                                     completion:(void (^ _Nonnull)(BOOL inMuteList, AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets the announcement of group from the server.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)getGroupAnnouncementWithId:(NSString *_Nonnull)aGroupId
                        completion:(void (^_Nullable)(NSString *aAnnouncement, AgoraChatError *_Nullable aError))aCompletionBlock;

#pragma mark - Edit Group

/**
 *  
 *  Invites users to join a group.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aOccupants      The users who are invited.
 *  @param aGroupId        The group ID.
 *  @param aWelcomeMessage The welcome message.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result    The group instance. The SDK will return nil if fails.
 */
- (AgoraChatGroup * _Nullable)addOccupants:(NSArray<NSString *> * _Nonnull)aOccupants
                  toGroup:(NSString *_Nonnull)aGroupId
           welcomeMessage:(NSString *_Nullable)aWelcomeMessage
                    error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Invites users to join a group.
 *
 *  @param aUsers           The users who are invited to join the group.
 *  @param aGroupId         The group ID.
 *  @param aMessage         The welcome message.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)addMembers:(NSArray<NSString *> * _Nonnull)aUsers
           toGroup:(NSString *_Nonnull)aGroupId
           message:(NSString *_Nullable)aMessage
        completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Removes members from the group.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aOccupants  The users to be removed from the group.
 *  @param aGroupId    The group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result            The group instance.
 */
- (AgoraChatGroup * _Nullable)removeOccupants:(NSArray<NSString *> * _Nonnull)aOccupants
                   fromGroup:(NSString *_Nonnull)aGroupId
                       error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Removes members from the group.
 * 
 *  Only the group owner can call this method.
 *
 *  @param aUsers           The members to be removed from the group.
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)removeMembers:(NSArray<NSString *> * _Nonnull)aUsers
            fromGroup:(NSString *_Nonnull)aGroupId
           completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Adds users to blocklist of the group.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aOccupants  The users to be added to the blockList.
 *  @param aGroupId    The group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance. 
 */
- (AgoraChatGroup * _Nullable)blockOccupants:(NSArray<NSString *> * _Nonnull)aOccupants
                  fromGroup:(NSString *_Nonnull)aGroupId
                      error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Adds users to blocklist of the group.
 * 
 *  Only the group owner can call this method.
 *
 *  @param aMembers         The users to be added to the blockList.
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)blockMembers:(NSArray<NSString *> * _Nonnull)aMembers
           fromGroup:(NSString *_Nonnull)aGroupId
          completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;


/**
 *  
 *  Removes users from the blocklist of the group.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aOccupants  The users to be removed from the blockList.
 *  @param aGroupId    The group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result   The group instance.
 */
- (AgoraChatGroup * _Nullable)unblockOccupants:(NSArray<NSString *> * _Nonnull)aOccupants
                     forGroup:(NSString *_Nonnull)aGroupId
                        error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Removes users out of the blocklist of the group.
 * 
 *  Only the group owner can call this method.
 *
 *  @param aMembers         The users to be removed from the blockList.
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)unblockMembers:(NSArray<NSString *> * _Nonnull)aMembers
             fromGroup:(NSString *_Nonnull)aGroupId
            completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Changes the subject of the group.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aSubject   The new subject of the group.
 *  @param aGroupId   The group ID.
 *  @param pError     The error information if the method fails: Error.
 *
 *  @result    The group instance. 
 */
- (AgoraChatGroup * _Nullable)changeGroupSubject:(NSString *_Nullable)aSubject
                       forGroup:(NSString *_Nonnull)aGroupId
                          error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Changes the group subject.
 * 
 *  Only the group owner can call this method.
 *
 *  @param aSubject         The new subject of the group.
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)updateGroupSubject:(NSString *_Nullable)aSubject
                  forGroup:(NSString *_Nonnull)aGroupId
                completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Changes the group description.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aDescription  The new group description.
 *  @param aGroupId      The group ID.
 *  @param pError        The error information if the method fails: Error.
 *
 *  @result       The group instance. 
 */
- (AgoraChatGroup * _Nullable)changeDescription:(NSString *_Nullable)aDescription
                      forGroup:(NSString *_Nonnull)aGroupId
                         error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Changes the group description.
 * 
 *  Only the group owner can call this method.
 *
 *  @param aDescription     The new group‘s description.
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)updateDescription:(NSString *_Nullable)aDescription
                 forGroup:(NSString *_Nonnull)aGroupId
               completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Leaves a group. The owner can't leave the group, can only destroy the group.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId   The group ID.
 *  @param pError     The error information if the method fails: Error.
 *
 */
- (void)leaveGroup:(NSString *_Nonnull)aGroupId
             error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Leaves a group. The owner can't leave the group, can only destroy the group.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)leaveGroup:(NSString *_Nonnull)aGroupId
        completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Destroys a group.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId  The group ID.
 *
 *  @result   The error information if the method fails: Error. The SDK wil return nil if the method succeed.
 */
- (AgoraChatError *)destroyGroup:(NSString *_Nonnull)aGroupId;

/**
 *  
 *  Destroys a group.
 * 
 *  Only the group owner can call this method.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)destroyGroup:(NSString *_Nonnull)aGroupId
    finishCompletion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;


/**
 *  
 *  Blocks group messages. The server will block the messages from the group.
 * 
 *  The group owner can't block the group's messages.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId    The group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)blockGroup:(NSString *_Nonnull)aGroupId
                  error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Blocks group messages, so the server blocks the messages from the group. 
 *  
 *  The group owner can't block the group's messages.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)blockGroup:(NSString *_Nonnull)aGroupId
        completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Unblocks group messages.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId   The group ID.
 *  @param pError     The error information if the method fails: Error.
 *
 *  @result    The group instance. 
 */
- (AgoraChatGroup * _Nullable)unblockGroup:(NSString *_Nonnull)aGroupId
                    error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Unblocks group messages.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)unblockGroup:(NSString *_Nonnull)aGroupId
          completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;


/**
 *  
 *  Changes the owner of the group.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId    The group ID.
 *  @param aNewOwner   The new group owner.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance. 
 */
- (AgoraChatGroup * _Nullable)updateGroupOwner:(NSString *_Nonnull)aGroupId
                     newOwner:(NSString *_Nonnull)aNewOwner
                        error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Changes the owner of the group.
 * 
 *  Only the group owner can call this method.
 *
 *  @param aGroupId   The group ID.
 *  @param aNewOwner  The new group owner.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)updateGroupOwner:(NSString *_Nonnull)aGroupId
                newOwner:(NSString *_Nonnull)aNewOwner
              completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Adds group admin.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aAdmin     The admin to be added.
 *  @param aGroupId   The group ID.
 *  @param pError     The error information if the method fails: Error.
 *  @result           The group instance.
 */
- (AgoraChatGroup * _Nullable)addAdmin:(NSString *_Nonnull)aAdmin
              toGroup:(NSString *_Nonnull)aGroupId
                error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Adds group admin.
 * 
 *  This is an asynchronous method.
 * 
 *  Only the group owner can call this method.
 *
 *  @param aAdmin      The admin to be added.
 *  @param aGroupId    The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)addAdmin:(NSString *_Nonnull)aAdmin
         toGroup:(NSString *_Nonnull)aGroupId
      completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Removes a group admin.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aAdmin      The admin to be removed.
 *  @param aGroupId    The group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)removeAdmin:(NSString *_Nonnull)aAdmin
               fromGroup:(NSString *_Nonnull)aGroupId
                   error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Removes the group admin.
 * 
 *  Only the group owner can call this method.
 * 
 *  This is an asynchronous method.
 *
 *  @param aAdmin     The admin to be removed.
 *  @param aGroupId   The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)removeAdmin:(NSString *_Nonnull)aAdmin
          fromGroup:(NSString *_Nonnull)aGroupId
         completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;


/**
 *  
 *  Mutes group members.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aMuteMembers         The list of members to be muted.
 *  @param aMuteMilliseconds    The muted time duration in millisecond.
 *  @param aGroupId             The group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)muteMembers:(NSArray<NSString *> * _Nonnull)aMuteMembers
        muteMilliseconds:(NSInteger)aMuteMilliseconds
               fromGroup:(NSString *_Nonnull)aGroupId
                   error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Mutes group members.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  This is an asynchronous method.
 *
 *  @param aMuteMembers         The list of mute, type is <NSString>
 *  @param aMuteMilliseconds    Muted time duration in millisecond
 *  @param aGroupId             The group ID.
 *  @param aCompletionBlock     The completion block, which contains the error message if the method fails.
 *
 */
- (void)muteMembers:(NSArray<NSString *> * _Nonnull)aMuteMembers
   muteMilliseconds:(NSInteger)aMuteMilliseconds
          fromGroup:(NSString *_Nonnull)aGroupId
         completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Unmutes group members.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aMembers        The list of members to be unmuted.
 *  @param aGroupId        The group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)unmuteMembers:(NSArray<NSString *> * _Nonnull)aMembers
                 fromGroup:(NSString *_Nonnull)aGroupId
                     error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Unmutes group members.
 * 
 *  Only the chatroom owner or admin can call this method.
 * 
 *  This is an asynchronous method.
 *
 *  @param aMembers        The list of members to be unmuted.
 *  @param aGroupId        The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)unmuteMembers:(NSArray<NSString *> * _Nonnull)aMembers
            fromGroup:(NSString *_Nonnull)aGroupId
           completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Mutes all members.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId        The group ID.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)muteAllMembersFromGroup:(NSString *_Nonnull)aGroupId
                                  error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  mute all members.
 * 
 *  Only the chatroom owner or admin can call this method.
 * 
 *  This is an asynchronous method.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)muteAllMembersFromGroup:(NSString *_Nonnull)aGroupId
                     completion:(void(^)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;


/**
 *  
 *  Unmutes all members.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId        The group ID.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)unmuteAllMembersFromGroup:(NSString *_Nonnull)aGroupId
                                 error:(AgoraChatError **_Nullable)pError;


/**
 *  
 *  Unmutes all members.
 * 
 *  Only the chatroom owner or admin can call this method.
 * 
 *  This is an asynchronous method.
 *
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)unmuteAllMembersFromGroup:(NSString *_Nonnull)aGroupId
                       completion:(void(^)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;


/**
 *  
 *  Adds members to the allowlist.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aMembers        The members to be added to the allowlist.
 *  @param aGroupId        The group ID.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)addWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers
                       fromGroup:(NSString *_Nonnull)aGroupId
                           error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Adds members to the allowlist.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  @param aMembers         The members to be added to the allowlist.
 *  @param aGroupId         The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)addWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers
                  fromGroup:(NSString *_Nonnull)aGroupId
                 completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;


/**
 *  
 *  Removes members from the allowlist.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aMembers        The members to be removed from the allowlist.
 *  @param aGroupId        The group ID.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)removeWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers
                          fromGroup:(NSString *_Nonnull)aGroupId
                              error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Removes members from the allowlist.
 * 
 *  This is an asynchronous method.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  @param aMembers        The members to be removed from the allowlist.
 *  @param aGroupId        The group ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)removeWhiteListMembers:(NSArray<NSString *> * _Nonnull)aMembers
                     fromGroup:(NSString *_Nonnull)aGroupId
                    completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Uploads the share file of group.
 *
 *  @param aGroupId        The group ID.
 *  @param aFilePath       The path of file.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (void)uploadGroupSharedFileWithId:(NSString *_Nonnull)aGroupId
                           filePath:(NSString* _Nonnull)aFilePath
                           progress:(void (^_Nullable)(int progress))aProgressBlock
                         completion:(void (^_Nullable)(AgoraChatGroupSharedFile *_Nullable aSharedFile, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Downloads the share file of group.
 *
 *  @param aGroupId         The group ID.
 *  @param aFilePath        The path of file.
 *  @param aSharedFileId    The shared file ID.
 *  @param aProgressBlock   The block of attachment upload progress
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 */
- (void)downloadGroupSharedFileWithId:(NSString *_Nonnull)aGroupId
                             filePath:(NSString *_Nonnull)aFilePath
                         sharedFileId:(NSString *_Nonnull)aSharedFileId
                             progress:(void (^_Nullable)(int progress))aProgressBlock
                           completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Removes the share file of the group.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId        The group ID.
 *  @param aSharedFileId   The share file ID.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)removeGroupSharedFileWithId:(NSString *_Nonnull)aGroupId
                            sharedFileId:(NSString *_Nonnull)aSharedFileId
                                   error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Removes the share file of group.
 *
 *  @param aGroupId         The group ID.
 *  @param aSharedFileId    The share file ID.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 */
- (void)removeGroupSharedFileWithId:(NSString *_Nonnull)aGroupId
                       sharedFileId:(NSString *_Nonnull)aSharedFileId
                         completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Updates the announcement of group.
 * 
 *  Only the chatroom owner or admin can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId         The group ID.
 *  @param aAnnouncement    The announcement of the group.
 *  @param pError           The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)updateGroupAnnouncementWithId:(NSString *_Nonnull)aGroupId
                              announcement:(NSString *_Nullable)aAnnouncement
                                     error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Updates the announcement of group.
 * 
 *  Only the chatroom owner or admin can call this method.
 * 
 *  This is an asynchronous method.
 *
 *  @param aGroupId         The group ID.
 *  @param aAnnouncement    The announcement of the group.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)updateGroupAnnouncementWithId:(NSString *_Nonnull)aGroupId
                         announcement:(NSString *_Nullable)aAnnouncement
                           completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Updates the extended of the group.
 * 
 *  Only the owner of the group can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId        The group ID.
 *  @param aExt            The extended information of the group.
 *  @param pError          The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)updateGroupExtWithId:(NSString *_Nonnull)aGroupId
                              ext:(NSString *_Nullable)aExt
                            error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Updates the extended information of the group.
 * 
 *  Only the group owner can call this method.
 *
 *  @param aGroupId         The group ID.
 *  @param aExt             The extended information of the group.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)updateGroupExtWithId:(NSString *_Nonnull)aGroupId
                         ext:(NSString *_Nullable)aExt
                  completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

#pragma mark - Edit Public Group

/**
 *  
 *  Joins a public group. The group style should be AgoraChatGroupStylePublicOpenJoin.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId    The public group ID.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)joinPublicGroup:(NSString *_Nonnull)aGroupId
                       error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Joins a public group. The group style should be AgoraChatGroupStylePublicOpenJoin.
 *
 *  @param aGroupId         The public group ID。
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)joinPublicGroup:(NSString *_Nonnull)aGroupId
             completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  The request to join a public group. The group style should be AgoraChatGroupStylePublicJoinNeedApproval.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId    The public group ID。
 *  @param aMessage    The message in the request.
 *  @param pError      The error information if the method fails: Error.
 *
 *  @result    The group instance.
 */
- (AgoraChatGroup * _Nullable)applyJoinPublicGroup:(NSString *_Nonnull)aGroupId
                          message:(NSString *_Nullable)aMessage
                            error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Requests to join a public group. The group style should be AgoraChatGroupStylePublicJoinNeedApproval.
 *
 *  @param aGroupId         The public group ID.
 *  @param aMessage         The information in the request.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)requestToJoinPublicGroup:(NSString *_Nonnull)aGroupId
                         message:(NSString *_Nullable)aMessage
                      completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

#pragma mark - Application

/**
 *  
 *  Accepts a group request.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId   The group ID.
 *  @param aUsername  The user who sends the request for join the group.
 *
 *  @result Error
 */
- (AgoraChatError *)acceptJoinApplication:(NSString *_Nonnull)aGroupId
                         applicant:(NSString *_Nonnull)aUsername;

/**
 *  
 *  Approves a group request.
 * 
 *  Only the group owner can call this method.
 * 
 *  This is an asynchronous method.
 *
 *  @param aGroupId         The group ID.
 *  @param aUsername        The user who sends the request for join the group.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)approveJoinGroupRequest:(NSString *_Nonnull)aGroupId
                         sender:(NSString *_Nonnull)aUsername
                     completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Declines a group request.
 * 
 *  Only the group owner can call this method.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId  The group ID.
 *  @param aUsername The user who sends the request for join the group.
 *  @param aReason   The reason of declining.
 *
 *  @result Error
 */
- (AgoraChatError *)declineJoinApplication:(NSString *_Nonnull)aGroupId
                          applicant:(NSString *_Nonnull)aUsername
                             reason:(NSString *_Nullable)aReason;

/**
 *  
 *  Declines a group request.
 * 
 *  Only the group owner can call this method.
 * 
 *  This is an asynchronous method.
 *
 *  @param aGroupId         The group ID.
 *  @param aUsername        The user who sends the request for join the group.
 *  @param aReason          The reason for declining.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)declineJoinGroupRequest:(NSString *_Nonnull)aGroupId
                         sender:(NSString *_Nonnull)aUsername
                         reason:(NSString *_Nullable)aReason
                     completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Accepts a group invitation.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId     The group ID.
 *  @param aUsername    The user who initiates the invitation.
 *  @param pError       The error information if the method fails: Error.
 *
 *  @result  The group instance.
 */
- (AgoraChatGroup * _Nullable)acceptInvitationFromGroup:(NSString *_Nonnull)aGroupId
                               inviter:(NSString *_Nonnull)aUsername
                                 error:(AgoraChatError **_Nullable)pError;

/**
 *  
 *  Accepts a group invitation.
 * 
 *  This is an asynchronous method.
 *
 *  @param aGroupId         The group ID.
 *  @param aUsername        The user who initiates the invitation. 
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)acceptInvitationFromGroup:(NSString *_Nonnull)aGroupId
                          inviter:(NSString *_Nonnull)aUsername
                       completion:(void (^_Nullable)(AgoraChatGroup *_Nullable aGroup, AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Declines a group invitation.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupId  The group ID.
 *  @param aUsername The user who initiates the invitation.
 *  @param aReason   The reason for declining.
 *
 *  @result  The error information if the method fails: Error.
 */
- (AgoraChatError *)declineInvitationFromGroup:(NSString *_Nonnull)aGroupId
                                inviter:(NSString *_Nonnull)aUsername
                                 reason:(NSString *_Nullable)aReason;

/**
 *  
 *  Declines a group invitation.
 * 
 *  This is an asynchronous method.
 *
 *  @param aGroupId         The group ID.
 *  @param aInviter         The user who send the invitation.
 *  @param aReason          The reason of declining.
 *  @param aCompletionBlock The completion block, which contains the error message if the method fails.
 *
 */
- (void)declineGroupInvitation:(NSString *_Nonnull)aGroupId
                       inviter:(NSString *_Nonnull)aInviter
                        reason:(NSString *_Nullable)aReason
                    completion:(void (^_Nullable)(AgoraChatError *_Nullable aError))aCompletionBlock;

/**
  *  
  *  Uses the pagination to get the number group that you joined.

  *  This method gets data from the server.
  *
  *  This is an asynchronous method.
  *
  *  @param aPageNum             The current page number, starting from 0.
   * After this parameter is set, the SDK gets data from the specified position in the reverse chronological order of when the user joined groups.
   * At the first method call, if you set this parameter as `0`, the SDK gets data starting from the latest group that the user joined.
  *  @param aPageSize           The number of groups that you expect to get on each page. The value range is  [1,20].
  *  @param aNeedMemberCount need member count    Whether the number of group members is required.
  *                                                    - `YES`：Yes.
  *                                                    - `NO`：No.
  *  @param aNeedRole need role    Whether the role of the current user in the group is required.
  *                                                    - `YES`：Yes.
  *                                                    - `NO`：No.
  *  @param aCompletionBlock    The completion block, which contains the error message if the method fails.
  *
  */

- (void)getJoinedGroupsFromServerWithPage:(NSInteger)aPageNum
                                 pageSize:(NSInteger)aPageSize
                          needMemberCount:(BOOL)aNeedMemberCount
                                 needRole:(BOOL)aNeedRole
                               completion:(void (^_Nullable)(NSArray<AgoraChatGroup *> *_Nullable aList, AgoraChatError *_Nullable aError))aCompletionBlock;

#pragma mark - Apns

/**
 *  
 *  Blocks/unblocks group message‘s push notification.
 *
 *  This is a synchronous method and blocks the current thread.
 * 
 *  Deprecated, please use  {@link IAgoraChatPushManager::updatePushServiceForGroups:disablePush:}  instead.
 *
 *  @param aGroupId     The group ID.
 *  @param aIsIgnore    Whether to show or ignore the push notification.
 *
 *  @result    The error information if the method fails: Error.
 */
- (AgoraChatError *)ignoreGroupPush:(NSString *)aGroupId
                      ignore:(BOOL)aIsIgnore EM_DEPRECATED_IOS(3_3_2, 3_8_3, "Use -IAgoraChatPushManager::updatePushServiceForGroups:disablePush:");


/**
 *  
 *  Blocks/unblocks the group message‘s push notification.
 * 
 *  Deprecated, please use  {@link IAgoraChatPushManager::updatePushServiceForGroups:disablePush:completion:}  instead.
 *
 *  @param aGroupId          The group ID.
 *  @param aIsEnable         Whether to block or unblock the push notification.
 *  @param aCompletionBlock  The completion block, which contains the error message if the method fails.
 *
 */
- (void)updatePushServiceForGroup:(NSString *)aGroupId
                    isPushEnabled:(BOOL)aIsEnable
                       completion:(void (^)(AgoraChatGroup *aGroup, AgoraChatError *aError))aCompletionBlock EM_DEPRECATED_IOS(3_3_2, 3_8_3, "Use -IAgoraChatPushManager::updatePushServiceForGroups:disablePush:completion:");


/**
 *  
 *  Blocks/unblocks the group message‘s push notification.
 * 
 *  Deprecated, please use  {@link IAgoraChatPushManager::updatePushServiceForGroups:disablePush:}  instead.
 *
 *  This is a synchronous method and blocks the current thread.
 *
 *  @param aGroupIDs    The group ID list.
 *  @param aIsIgnore    Whether to show or ignore the push notification.
 *
 *  @result    The error information if the method fails: Error.
 */
- (AgoraChatError *)ignoreGroupsPush:(NSArray *)aGroupIDs
                       ignore:(BOOL)aIsIgnore EM_DEPRECATED_IOS(3_3_2, 3_8_3, "Use -IAgoraChatPushManager::updatePushServiceForGroups:disablePush:");

/**
 *  
 *  Blocks/unblocks the group message‘s push notification.
 * 
 *  Deprecated, please use  {@link IAgoraChatPushManager::updatePushServiceForGroups:disablePush:completion:}  instead.
 *
 *  @param aGroupIDs         The group ID list.
 *  @param aIsEnable         Whether to enable group messages push.
 *  @param aCompletionBlock  The completion block, which contains the error message if the method fails.
 *
 */
- (void)updatePushServiceForGroups:(NSArray *)aGroupIDs
                     isPushEnabled:(BOOL)aIsEnable
                        completion:(void (^)(NSArray *groups, AgoraChatError *aError))aCompletionBlock EM_DEPRECATED_IOS(3_3_2, 3_8_3, "Use -IAgoraChatPushManager::updatePushServiceForGroups:disablePush:completion:");

#pragma mark - Group member attributes
/**
*  
*  Sets custom attributes of a group member.
*
*  @param groupId      The group ID.
*  @param userId       The user ID of the group member for whom the custom attributes are set.
*  @param attributes   The map of custom attributes in key-value format. In a key-value pair, if the value is set to an empty string, the custom attribute will be deleted.
*  @param completion The completion block, which contains the error message if the method call fails.
*/
- (void)setMemberAttribute:(NSString *_Nonnull)groupId userId:(NSString *_Nonnull)userId attributes:(NSDictionary<NSString*,NSString*> *_Nonnull)attributes completion:(void (^_Nullable)(AgoraChatError *_Nullable error))completionBlock;

/**
*  
*  Gets all custom attributes of a group member.
*
*  @param groupId      The group ID.
*  @param userId       The user ID of the group member whose all custom attributes are retrieved.
*  @param completion   The completion block, which contains the map of all retrieved attributes and the error message (AgoraChatError) if the method call fails:
* - If the method call succeeds, the SDK returns the map of retrieved custom attributes in key-value pairs. In this case, AgoraChatError is empty.
* - If the method call fails, the SDK returns the reason for the failure (AgoraChatError). In this case, the map of custom attributes is empty.
* - If both the map of custom attributes and AgoraChatError are empty, no custom attribute is set for the group member.
*/
- (void)fetchMemberAttribute:(NSString *_Nonnull)groupId userId:(NSString *_Nonnull)userId completion:(void (^ _Nullable)(NSDictionary<NSString *,NSString *> * _Nullable, AgoraChatError * _Nullable))completionBlock;
/**
*  
*  Gets custom attributes of multiple group members by attribute key.
*
*  @param groupId        The group ID.
*  @param userIds        The array of user IDs of group members whose custom attributes are retrieved.(limitation is ten.More than callback error. )
*  @param keys           The array of keys of custom attributes to be retrieved.
*  @param completion     The completion block, which contains the map of retrieved attributes and the error message (AgoraChatError) if the method call fails.
* - If the method call succeeds, the SDK returns the map of retrieved custom attributes in key-value pairs. In this case, AgoraChatError is empty. If no custom attribute is set for a group members, the map of custom attribute is empty for this member.
* - If the method call fails, the SDK returns the reason for the failure (AgoraChatError). In this case, the map of custom attributes is empty for the group members.
* - If both the map of custom attributes and AgoraChatError are empty, no custom attribute is set for the group members.
*/
- (void)fetchMembersAttributes:(NSString *_Nonnull)groupId userIds:(NSArray<__kindof NSString *> *_Nonnull)userIds keys:(NSArray<__kindof NSString *> *_Nonnull)keys completion:(void (^_Nullable)(NSDictionary<NSString*,NSDictionary<NSString*,NSString*>*> *_Nullable attributes, AgoraChatError *_Nullable error))completionBlock;

#pragma mark - EM_DEPRECATED_IOS  3.8.8

/**
 *  
 *  Gets the pagesize number group you joined from the server.
 *
 *  Deprecated, please use  {@link getJoinedGroupsFromServerWithPage:pageSize:needMemberCount:needRole:error:completion:}  instead.
 *
 *  This is an asynchronous method.
 *
 *  @param aPageNum            The cursor when joins the group. Sets the parameter as nil for the first time.
 *  @param aPageSize           The number of results expected to be returned, if <0 then all results will be returned at once.
 *  @param aCompletionBlock    The completion block, which contains the error message if the method fails.
 *
 */

- (void)getJoinedGroupsFromServerWithPage:(NSInteger)aPageNum
                                 pageSize:(NSInteger)aPageSize
                               completion:(void (^_Nullable)(NSArray<AgoraChatGroup *> *aList, AgoraChatError *_Nullable aError))aCompletionBlock
                                __deprecated_msg("Use -getJoinedGroupsFromServerWithPage:pageSize:needMemberCount:needRole:error:completion: instead");

@end
