using System.Collections.Generic;

namespace VortexGames.EngineCore.TaskManagement
{
    public class CompositeTask : TaskBase
    {
        protected readonly List<TaskBase> CompositeTasks = new List<TaskBase>();

        public void AddTask(TaskBase task)
        {
            CompositeTasks.Add(task);
        }

        public override void Execute()
        {}
    }
}