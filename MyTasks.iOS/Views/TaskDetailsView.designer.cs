// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MyTasks.iOS.Views
{
    [Register ("TaskDetailsView")]
    partial class TaskDetailsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker CompleteByDatePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CompletedButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TaskTitleTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton UpdateButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CompleteByDatePicker != null) {
                CompleteByDatePicker.Dispose ();
                CompleteByDatePicker = null;
            }

            if (CompletedButton != null) {
                CompletedButton.Dispose ();
                CompletedButton = null;
            }

            if (TaskTitleTextField != null) {
                TaskTitleTextField.Dispose ();
                TaskTitleTextField = null;
            }

            if (UpdateButton != null) {
                UpdateButton.Dispose ();
                UpdateButton = null;
            }
        }
    }
}