using System.Diagnostics;

namespace VortexGames.EngineCore.Profile
{
    public class LogStopwatch
    {
        private readonly Stopwatch _stopWatch = new Stopwatch();
        private readonly string _color = "green";
        
        public LogStopwatch()
        {
        }

        public LogStopwatch(string color)
        {
            _color = color;
        }
        
        public void Start()
        {
            _stopWatch.Reset();
            _stopWatch.Start();
        }

        public void StopLog(string log)
        {
            _stopWatch.Stop();
            string content = string.Format("<color={0}>{1} in {2}ms", _color, log, _stopWatch.ElapsedMilliseconds);
            content += "</color>";
            UnityEngine.Debug.LogFormat(content);
            _stopWatch.Reset();
        }
        
        public void StopLogRestart(string log)
        {
            StopLog(log);
            Start();
        }
    }
}