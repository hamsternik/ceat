#pragma clang diagnostic ignored "-Wdeprecated-declarations"
#pragma clang diagnostic ignored "-Wtypedef-redefinition"
#pragma clang diagnostic ignored "-Wobjc-designated-initializers"
#include <stdarg.h>
#include <objc/objc.h>
#include <objc/runtime.h>
#include <objc/message.h>
#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>
#import <CloudKit/CloudKit.h>
#import <CoreGraphics/CoreGraphics.h>

@class NSApplicationDelegate;
@protocol NSMenuValidation;
@class NSOutlineViewDataSource;
@class NSOutlineViewDelegate;
@class __monomac_internal_ActionDispatcher;
@class NSURLSessionDataDelegate;
@class Foundation_InternalNSNotificationHandler;
@class Foundation_NSDispatcher;
@class __MonoMac_NSSynchronizationContextDispatcher;
@class __Xamarin_NSTimerActionDispatcher;
@class Foundation_NSAsyncDispatcher;
@class __MonoMac_NSAsyncActionDispatcher;
@class __MonoMac_NSAsyncSynchronizationContextDispatcher;
@class OpenTK_Platform_MacOS_MonoMacGameView;
@class __NSGestureRecognizerToken;
@class __NSClickGestureRecognizer;
@class __NSGestureRecognizerParameterlessToken;
@class __NSGestureRecognizerParametrizedToken;
@class __NSMagnificationGestureRecognizer;
@class __NSPanGestureRecognizer;
@class __NSPressGestureRecognizer;
@class __NSRotationGestureRecognizer;
@class AppKit_NSTableView__NSTableViewDelegate;
@class Foundation_NSUrlSessionHandler_WrappedNSInputStream;
@class __NSObject_Disposer;
@class Foundation_NSUrlSessionHandler_NSUrlSessionHandlerDelegate;
@class AppDelegate;
@class ceat_Sources_LoadedDataOutlineDataSource;
@class ceat_Sources_LoadedDataOutlineDelegate;
@class ceat_Sources_Models_File;
@class ceat_Sources_Models_ExcelFile;
@class ViewController;
@class ceat_Sources_Models_Directory;
@class ceat_Sources_Models_RootDirectory;

@interface NSApplicationDelegate : NSObject<NSApplicationDelegate> {
}
	-(id) init;
@end

@protocol NSMenuValidation
	@required -(BOOL) validateMenuItem:(NSMenuItem *)p0;
@end

@interface NSOutlineViewDataSource : NSObject<NSOutlineViewDataSource> {
}
	-(id) init;
@end

@interface NSOutlineViewDelegate : NSObject<NSOutlineViewDelegate> {
}
	-(id) init;
@end

@interface NSURLSessionDataDelegate : NSObject<NSURLSessionDataDelegate, NSURLSessionTaskDelegate, NSURLSessionDelegate> {
}
	-(id) init;
@end

@interface OpenTK_Platform_MacOS_MonoMacGameView : NSView {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) drawRect:(CGRect)p0;
	-(void) lockFocus;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) initWithFrame:(CGRect)p0;
	-(id) initWithCoder:(NSCoder *)p0;
@end

@interface __NSGestureRecognizerToken : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface __NSGestureRecognizerParameterlessToken : __NSGestureRecognizerToken {
}
	-(void) target;
@end

@interface __NSGestureRecognizerParametrizedToken : __NSGestureRecognizerToken {
}
	-(void) target:(NSGestureRecognizer *)p0;
@end

@interface AppDelegate : NSObject<NSApplicationDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) applicationDidFinishLaunching:(NSNotification *)p0;
	-(void) applicationWillTerminate:(NSNotification *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface ceat_Sources_LoadedDataOutlineDataSource : NSObject<NSOutlineViewDataSource> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(NSInteger) outlineView:(NSOutlineView *)p0 numberOfChildrenOfItem:(NSObject *)p1;
	-(NSObject *) outlineView:(NSOutlineView *)p0 child:(NSInteger)p1 ofItem:(NSObject *)p2;
	-(BOOL) outlineView:(NSOutlineView *)p0 isItemExpandable:(NSObject *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ceat_Sources_LoadedDataOutlineDelegate : NSObject<NSOutlineViewDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(NSView *) outlineView:(NSOutlineView *)p0 viewForTableColumn:(NSTableColumn *)p1 item:(NSObject *)p2;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ceat_Sources_Models_File : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ceat_Sources_Models_ExcelFile : ceat_Sources_Models_File {
}
@end

@interface ViewController : NSViewController {
}
	@property (nonatomic, assign) NSButton * LoadDataButton;
	@property (nonatomic, assign) NSOutlineView * LoadedDataOutlineView;
	@property (nonatomic, assign) NSButton * ProcessDataButton;
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(NSButton *) LoadDataButton;
	-(void) setLoadDataButton:(NSButton *)p0;
	-(NSOutlineView *) LoadedDataOutlineView;
	-(void) setLoadedDataOutlineView:(NSOutlineView *)p0;
	-(NSButton *) ProcessDataButton;
	-(void) setProcessDataButton:(NSButton *)p0;
	-(void) viewDidLoad;
	-(NSObject *) representedObject;
	-(void) setRepresentedObject:(NSObject *)p0;
	-(void) ChangeWorkMode:(NSButton *)p0;
	-(void) LoadDataClicked:(NSButton *)p0;
	-(void) ProcessDataClicked:(NSButton *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ceat_Sources_Models_Directory : ceat_Sources_Models_File {
}
@end

@interface ceat_Sources_Models_RootDirectory : ceat_Sources_Models_File {
}
@end


