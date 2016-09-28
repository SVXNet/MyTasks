using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using MyTasks.Core.Models;
using MyTasks.Core.Services;
using Plugin.Fingerprint.Abstractions;

namespace MyTasks.Core.ViewModels
{
    public class TaskListViewModel : MvxViewModel
    {
        private readonly ITaskService _taskService;
        private readonly IFingerprint _fingerprint;
        public ObservableCollection<TaskModel> ListItems { get; set; }

        public TaskListViewModel(ITaskService taskService, IFingerprint fingerprint)
        {
            _taskService = taskService;
            _fingerprint = fingerprint;
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
            NewTaskTitle = null;
            ListItems.Add(item);
        }

        public IMvxCommand ItemSelectedCommand => new MvxCommand<TaskModel>(ItemSelected);

        private void ItemSelected(TaskModel task)
        {
            if (task == null)
            {
                return;
            }
            ShowViewModel<TaskDetailsViewModel>(new TaskDetailsViewModel.Parameters {TaskId = task.Id});
        }

        public override async void Start()
        {
            base.Start();
            var result = await _fingerprint.AuthenticateAsync("Prove you have mvx fingers!");
            if (result.Authenticated)
            {
                LoadTasks();
            }
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
