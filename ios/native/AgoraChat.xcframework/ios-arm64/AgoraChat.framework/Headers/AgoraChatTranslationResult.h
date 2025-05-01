//
//  AgoraChatTranslationResult.h
//  AgoraChat
//
//  Created by lixiaoming on 2021/11/9.
//  Copyright © 2021 easemob.com. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

/**
 *  
 *  The message translate info
 *  @Deprecated This object has been deprecated
 */
@interface AgoraChatTranslationResult : NSObject
/*!
 *  
 *  The Translation's messageId
 */
@property (nonatomic,strong)    NSString* msgId;
/*!
 *  
 *  Weather to show the translations
 */
@property (nonatomic,assign)   BOOL showTranslation;
/*!
 *  
 *  How many tims the message have been translated
 */
@property (nonatomic,assign)   NSUInteger translateTimes;
/*!
 *  
 *  The translation result content
 */
@property (nonatomic,strong)   NSString* translations;
@end

NS_ASSUME_NONNULL_END
