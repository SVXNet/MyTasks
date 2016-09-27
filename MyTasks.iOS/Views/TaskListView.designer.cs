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
    [Register ("TaskListView")]
    partial class TaskListView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddTaskButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TaskListTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TaskTitleTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddTaskButton != null) {
                AddTaskButton.Dispose ();
                AddTaskButton = null;
            }

            if (TaskListTableView != null) {
                TaskListTableView.Dispose ();
                TaskListTableView = null;
            }

            if (TaskTitleTextField != null) {
                TaskTitleTextField.Dispose ();
                TaskTitleTextField = null;
            }
        }
    }
}