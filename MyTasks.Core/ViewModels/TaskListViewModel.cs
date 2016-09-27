using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using MyTasks.Core.Models;
using MyTasks.Core.Services;

namespace MyTasks.Core.ViewModels
{
    public class TaskListViewModel : MvxViewModel
    {
        private ITaskService _taskService;
        public ObservableCollection<TaskModel> ListItems { get; set; }

        public TaskListViewModel(ITaskService taskService)
        {
            _taskService = taskService;
            ListItems = new ObservableCollection<TaskModel>();
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
            var item = _taskService.AddTask(NewTaskTitle);
            ListItems.Add(item);
        }

        public override void Start()
        {
            base.Start();
            LoadTasks();
        }

        private void LoadTasks()
        {
            var items = _taskService.GetTasks();
            ListItems.Clear();
            foreach (var item in items)
            {
                ListItems.Add(item);
            }
        }
    }
}
