namespace VortexGames.EngineCore.TaskManagement
{
    public class TaskSequence : CompositeTask
    {
        private int _currentTaskIndex = 0;

        public override void Execute()
        {
            var currentTask = CompositeTasks[_currentTaskIndex];
            var currentTaskStatus = currentTask.CurrentStatus;

            if(currentTaskStatus == TaskStatus.Pending || currentTaskStatus == TaskStatus.Running)
                currentTask.Execute();
            else
                _currentTaskIndex++;

            if (_currentTaskIndex < CompositeTasks.Count)
                CurrentStatus = TaskStatus.Running;
            else
            {
                CurrentStatus = TaskStatus.Success;
                foreach(var task in CompositeTasks)
                    if (task.CurrentStatus == TaskStatus.Failure)
                    {
                        CurrentStatus = TaskStatus.Failure;
                        break;
                    }
            }

            CheckFinish();
        }
    }
}