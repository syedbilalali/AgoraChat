using ObjCRuntime;
[assembly:  LinkWith("AgoraChat.framework" ,SmartLink = true, ForceLoad = true, Frameworks = "Foundation, UIKit", LinkerFlags = "-ObjC")]