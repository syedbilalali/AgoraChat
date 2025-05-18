//
//  AgoraChatContact.h
//  AgoraChat
//
//  Created by li xiaoming on 2023/8/30.
//  Copyright © 2023 easemob.com. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 *  
 *  The contact object.
 */
@interface AgoraChatContact : NSObject <NSCoding>

/**
 *  
 *  The contact userId.
 */
@property (nonatomic,strong,readonly) NSString* _Nonnull userId;

/**
 *  
 *  The contact remark.
 */
@property (nonatomic,strong) NSString* _Nullable remark;

/**
 *  
 *  Initialize contact object
 *
 *  @param userId  The contact userId
 *  @param remark  The contact remark
 *
 *  @return Contact object
 */

- (instancetype)initWithUserId:(NSString* _Nonnull)userId remark:(NSString* _Nullable)remark;
@end
