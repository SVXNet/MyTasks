using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace MyTasks.Droid.Views
{
    [Activity]
    public class TaskDetailsView: MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TaskDetailsView);
        }
    }
}