namespace VortexGames.EngineCore.TaskManagement
{
    public class TaskBatch : CompositeTask
    {
        public override void Execute()
        {
            bool anyExecuting = false;

            foreach (var task in CompositeTasks)
            {
                var taskStatus = task.CurrentStatus;

                if (taskStatus == TaskStatus.Pending || taskStatus == TaskStatus.Running)
                {
                    anyExecuting = true;
                    task.Execute();
                }
            }

            if (anyExecuting)
                CurrentStatus = TaskStatus.Running;
            else
            {
                CurrentStatus = TaskStatus.Success;
                foreach(var task in CompositeTasks)
                    if(task.CurrentStatus == TaskStatus.Failure)
                    {
                        CurrentStatus = TaskStatus.Failure;
                        break;
                    }
            }

            CheckFinish();
        }
    }
}