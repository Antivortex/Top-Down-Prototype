using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VortexGames.EngineCore.TaskManagement
{
    public class TaskManager : MonoBehaviour
    {
        private readonly Queue<TaskBase> _pendingTasks = new Queue<TaskBase>();
        private readonly HashSet<Type> _singnelTaskTypeFilter = new HashSet<Type>();

        private bool _paused = false;

        private void Start()
        {
            StartCoroutine(ProcessTasks());
        }

        public void AddSingleType(Type type)
        {
            if(!type.IsSubclassOf(typeof(TaskBase)))
                throw new InvalidOperationException(string.Format("Type {0} is not a subclass of TaskBase", type.Name));

            _singnelTaskTypeFilter.Add(type);
        }

        public void EnqueueTask(TaskBase task)
        {
            var taskType = task.GetType();

            if (_paused)
            {
                Debug.LogFormat("Task {0} dropped by pause", taskType.Name);
                return;
            }

            bool isSingleType = _singnelTaskTypeFilter.Contains(taskType);

            if (isSingleType && _pendingTasks.Any(pendingCmd => pendingCmd.GetType() == taskType))
            {
                Debug.LogFormat("Task {0} dropped by single type", taskType.Name);
                return;
            }

        }

        public void Pause()
        {
            var str = string.Empty;
            foreach (var task in _pendingTasks)
                str += task.GetType().Name + " ";

            Debug.LogFormat("TaskManager pause, tasks dropped: {0}", str);

            _pendingTasks.Clear();
            _paused = true;
        }

        public void Resume()
        {
            Debug.Log("TaskManager resume");
            _paused = false;
        }

        private IEnumerator ProcessTasks()
        {
            while (true)
            {

                if (_pendingTasks.Count > 0)
                {
                    if (_paused)
                    {
                        _pendingTasks.Dequeue();
                        continue;
                    }

                    var task = _pendingTasks.Peek();

                    while (task.CurrentStatus == TaskStatus.Running || task.CurrentStatus == TaskStatus.Pending)
                    {
                        task.Execute();
                        yield return null;
                    }

                    _pendingTasks.Dequeue();
                }
            }
        }

    }
}