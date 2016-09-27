using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;

namespace MyTasks.Core.ViewModels
{
    public class TaskListViewModel : MvxViewModel
    {
        public ObservableCollection<string> ListItems { get; set; }

        public TaskListViewModel()
        {
            ListItems = new ObservableCollection<string>();
        }

        private string _newTaskTitle;
        public string NewTaskTitle
        {
            get { return _newTaskTitle; }
            set { SetProperty(ref _newTaskTitle, value); }
        }

        public IMvxCommand AddNewTaskCommand => new MvxCommand(AddNewTask);

        private void AddNewTask()
        {
            //Add the task using a service and update the list of tasks
            if (string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                return;
            }
            ListItems.Add(NewTaskTitle);
        }


    }
}
