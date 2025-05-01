//
//  IAgoraChatTranslateManager.h
//  HyphenateSDK
//
//  Created by lixiaoming on 2021/11/10.
//  Copyright © 2021 easemob.com. All rights reserved.
//

#ifndef IAgoraChatTranslateManager_h
#define IAgoraChatTranslateManager_h
#import "AgoraChatTranslationResult.h"
/*!
 *  
 *  @header IAgoraChatTranslateManager.h
 *  @abstract Translate service manager interface
 *  @author Hyphenate
 *  @version 3.00
 */
@protocol IAgoraChatTranslateManager <NSObject>
/*!
 *  
 *  Set translate info of message
 *
 *  @param translate       The translate info to set
 */
- (BOOL)updateTranslate:(AgoraChatTranslationResult*)translate conversationId:(NSString*)conversationId;
/*!
 *  
 *  Get translate info by messageId
 *
 *  @param msgId               Message Id
 *  @result translate       The translate info to set
 */
- (AgoraChatTranslationResult*)getTranslationResultByMsgId:(NSString*)msgId;
/*!
 *  
 *  Gets the latest message translation information for the specified number of messages
 *
 *  @param count               Message Id
 *  @result translateResults       The translates info getted
 */
- (NSArray<AgoraChatTranslationResult*>*)loadTranslateResults:(NSNumber*)count;
/*!
 *  
 *  Remove translation infos by messageIds
 *
 *  @param msgIds       MessageIds to remove translation info
 */
- (BOOL)removeTranslationsByMsgId:(NSArray<NSString*>*)msgIds;
/*!
 *  
 *  Remove translation infos by conversationId
 *
 *  @param conversationId       conversationId to remove translation info
 */
- (BOOL)removeTranslationsByConversationId:(NSString*)conversationId;
/*!
 *  
 *  Remove all translation infos
 *
 */
- (BOOL)removeAllTranslations;
@end

#endif /* IAgoraChatTranslateManager_h */
