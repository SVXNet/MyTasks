using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MyTasks.Core.ViewModels;

namespace MyTasks.iOS.Views
{
    public partial class TaskListView : MvxViewController
    {
        public TaskListView() : base("TaskListView", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            var set = this.CreateBindingSet<TaskListView, TaskListViewModel>();
            set.Bind(TaskTitleTextField).To(vm => vm.NewTaskTitle);
            set.Bind(AddTaskButton).To(vm => vm.AddNewTaskCommand);
            var source = new MvxStandardTableViewSource(TaskListTableView, "TitleText .");
            TaskListTableView.Source = source;
            set.Bind(source).To(vm => vm.ListItems);
            set.Apply();

            TaskListTableView.ReloadData();
        }
    }
}