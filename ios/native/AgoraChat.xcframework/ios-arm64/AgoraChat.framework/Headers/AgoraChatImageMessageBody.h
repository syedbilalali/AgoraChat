/**
 *  
 *  @header AgoraChatImageMessageBody.h
 *  @abstract Image message body class
 *  @author Hyphenate
 *  @version 3.00
 */

#import <Foundation/Foundation.h>

#import "AgoraChatFileMessageBody.h"

/**
 *  
 *  The image message body.
 * 
 *  You can create an image message body by calling one of the following methods:
 * 
 *   -`(instancetype)initWithData:displayName:`
 *   -`(instancetype)initWithData:thumbnailData:`
 * 
 *  Note: SDK will compress the image based on the attribute compressRatio when delivering the image.
 */
@interface AgoraChatImageMessageBody : AgoraChatFileMessageBody

/**
 *  
 *  The resolution of the image.
 */
@property (nonatomic) CGSize size;

/**
 *  
 *  The compression ratio of the image file.
 *  
 *  When sending the image message, the SDK compresses the image file according to the value of this parameter. The value range is (0.0, 1.0], and the default value is 0.6. 1.0 means that the SDK does not compress the image file, and 0.6 means that the SDK compresses the file size to 60% of the original. If you set this parameter to a value lower than 0 (included), the SDK uses the default value.
 */
@property (nonatomic) CGFloat compressionRatio;

/**
 *  
 *  The display name of thumbnail.
 */
@property (nonatomic, copy) NSString *thumbnailDisplayName;

/**
 *  
 *  The local path of the thumbnail.
 *  UIImage *image = [UIImage imageWithContentsOfFile:thumbnailLocalPath];
 */
@property (nonatomic, copy) NSString *thumbnailLocalPath;

/**
 *  
 *  The URL path of the thumbnail of the server.
 *  
 *   The message receiver gets the thumbnail with this member.
 */
@property (nonatomic, copy) NSString *thumbnailRemotePath;

/**
 *  
 *  The secret key for the thumbnail. A key is required for verification when downloading thumbnail.
 */
@property (nonatomic, copy) NSString *thumbnailSecretKey;

/**
 *  
 *  The resolution of the thumbnail file.
 */
@property (nonatomic) CGSize thumbnailSize;

/**
 *  
 *  The data length (bytes) of the thumbnail file.
 */
@property (nonatomic) long long thumbnailFileLength;

/**
 *  
 *  The download status of the thumbnail.
 */
@property (nonatomic)AgoraChatDownloadStatus thumbnailDownloadStatus;

/**
 *  
 *  Initializes an image message body instance.
 *
 *  The image receiver will receive object thumbnail that generated based on sender's aData object.
 * 
 *  Adjusts thumbnail resolution on Hyphenate console -> "Thumbnail Size" -> width and height. Unit in px.
 *  ex. aData resolution 200 x 400 (1：2), thumbnail resolution setting (width x height) 200 x 200, then will generate thumbnail in 100 x 200
 *  ex. aData resolution 600 x 300 (2：1), thumbnail resolution setting (width x height) 200 x 200, then will generate thumbnail in 200 x 100
 *
 *  The image sender can obtain thumbnail from thumbnailLocalPath.
 * 
 *  The image receiver will get thumbnail stored under thumbnailRemotePath after a successful download automatically.
 *  However, if the automatic downloading failed, use the following method,
 *  downloadMessageThumbnail:progress:completion:
 *
 *  @param aData            The original image object in NSData format.
 *  @param aThumbnailData   The thumbnail in NSData format. Will not push to server, but only for local usage.
 *
 *  @result An image message body instance.
 */
- (instancetype)initWithData:(NSData *)aData
               thumbnailData:(NSData *)aThumbnailData;

@end
