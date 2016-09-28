using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MyTasks.Core.ViewModels;

namespace MyTasks.iOS.Views
{
    public partial class TaskDetailsView : MvxViewController
    {
        public TaskDetailsView() : base("TaskDetailsView", null)
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
            var set = this.CreateBindingSet<TaskDetailsView, TaskDetailsViewModel>();
            set.Bind(TaskTitleTextField).To(vm => vm.TaskModel.Title);
            set.Bind(CompleteByDatePicker).To(vm => vm.TaskModel.CompleteBy);
            set.Bind(CompletedButton).To(vm => vm.MarkAsDoneCommand);
            set.Bind(UpdateButton).To(vm => vm.UpdateCommand);
            set.Apply();

        }
    }
}