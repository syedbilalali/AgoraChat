//
//  AgoraChatGroupMessageAck.h
//  HyphenateSDK
//
//  Created by 杜洁鹏 on 2019/6/3.
//  Copyright © 2019 easemob.com. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

/**
 *  
 *  The group message receipt.
 */
@interface AgoraChatGroupMessageAck : NSObject

/**
 *  
 *  The group message ID.
 */
@property (nonatomic, copy) NSString *messageId;

/**
 *  
 *  The group message read receipt ID.
 */
@property (nonatomic, copy) NSString *readAckId;

/**
 *  
 *  The user that sends the group message ack.
 */
@property (nonatomic, copy) NSString *from;

/**
 *  
 *  The group message content.
 */
@property (nonatomic, copy) NSString *content;

/**
 *  
 *  The number of group members that have read the group message.
 */
@property (nonatomic) int readCount;

/**
 *  
 *  The Unix timestamp for group message ack.
 */
@property (nonatomic) long long timestamp;

@end

NS_ASSUME_NONNULL_END
