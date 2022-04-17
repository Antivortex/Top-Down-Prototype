using System;
using UnityEngine;
using VortexGames.Core.Extensions;

namespace VortexGames.EngineCore.TaskManagement
{
    public enum TaskStatus
    {
        Pending = 0,
        Running = 1,
        Success = 2,
        Failure = 3
    }

    public abstract class TaskBase
    {
        private Action<TaskStatus> _onTaskFinished;

        private readonly float _maxExecutionTime;

        public TaskStatus CurrentStatus { get; protected set; }

        private float _executionTime = 0f;

        protected TaskBase()
        {
            _maxExecutionTime = 10f;
        }

        protected TaskBase(float maxExecutionTime)
        {
            _maxExecutionTime = maxExecutionTime;
        }

        public abstract void Execute();
        protected void CheckTimeout()
        {
            if (CurrentStatus == TaskStatus.Running)
            {
                _executionTime += Time.deltaTime;

                if (_executionTime > _maxExecutionTime)
                {
                    CurrentStatus = TaskStatus.Failure;
                    _onTaskFinished.SafeInvoke(CurrentStatus);
                    Debug.LogErrorFormat("Command {0} failed to execute by timer", GetType().Name);
                }
            }
        }

        protected void CheckFinish()
        {
            if (CurrentStatus == TaskStatus.Success || CurrentStatus == TaskStatus.Failure)
                _onTaskFinished.SafeInvoke(CurrentStatus);
        }

        public TaskBase OnFinished(Action<TaskStatus> onTaskFinished)
        {
            _onTaskFinished = onTaskFinished;
            return this;
        }


    }
}