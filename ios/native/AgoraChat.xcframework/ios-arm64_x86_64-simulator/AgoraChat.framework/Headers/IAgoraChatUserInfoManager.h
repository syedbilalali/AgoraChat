//
//  IAgoraChatUserInfoManager.h
//  HyphenateSDK
//
//  Created by lixiaoming on 2021/3/17.
//  Copyright © 2021 easemob.com. All rights reserved.
//

/**
 *  
 *  @header IAgoraChatUserInfoManager.h
 *  @abstract The user information operation class.
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>
#import "AgoraChatUserInfo.h"
#import "AgoraChatError.h"

@protocol IAgoraChatUserInfoManager <NSObject>

/**
 *  
 *  Sets all of the user's information.
 *
 *  @param aUserData           The user information data to set.
 *  @param aCompletionBlock    The completion block, which contains the error message if the method fails.
 */
- (void)updateOwnUserInfo:(AgoraChatUserInfo*_Nonnull)aUserData
               completion:(void (^_Nullable)(AgoraChatUserInfo*_Nullable aUserInfo,AgoraChatError *_Nullable aError))aCompletionBlock;

/**
 *  
 *  Sets a specific user information of the user.
 *
 *  @param aValue       The user information data to set.
 *  @param aType         The user information type to set.
 *  @param aCompletionBlock   The completion block, which contains the error message if the method fails.
 */
- (void)updateOwnUserInfo:(NSString*_Nullable )aValue
                 withType:(AgoraChatUserInfoType)aType
               completion:(void (^_Nullable )(AgoraChatUserInfo*_Nullable aUserInfo,AgoraChatError * _Nullable aError))aCompletionBlock;

/**
 *  
 *  Gets the user information by user ID.
 *
 *  @param aUserIds            The user ID list.
 *  @param aCompletionBlock    The completion block, which contains the error message if the method fails.
 */
- (void)fetchUserInfoById:(NSArray<NSString*>*_Nonnull)aUserIds
               completion:(void (^_Nullable)(NSDictionary<NSString*,AgoraChatUserInfo*> *_Nullable aUserDatas,AgoraChatError *_Nullable aError))aCompletionBlock;
/**
 *  
 *  Gets the specific user information by user ID.
 *
 *  @param aUserIds              The user ID list.
 *  @param aType                 The user information type list.
 *  @param aCompletionBlock      The completion block, which contains the error message if the method fails.
 */
- (void)fetchUserInfoById:(NSArray<NSString*>* _Nonnull)aUserIds
                     type:(NSArray<NSNumber*>*_Nonnull)aType
               completion:(void (^_Nullable)(NSDictionary<NSString*,AgoraChatUserInfo*> *_Nullable aUserDatas,AgoraChatError *_Nullable aError))aCompletionBlock;
@end

