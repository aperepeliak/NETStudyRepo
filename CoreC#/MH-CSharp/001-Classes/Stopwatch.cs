using System;

namespace _001_Classes
{
    public class Stopwatch
    {
        private DateTime _startTime;
        private bool     _isRunning;

        public TimeSpan Duration { get; private set; }

        public void Start()
        {
            if (_isRunning)
                throw new InvalidOperationException("The stopwatch is already running.");

            _startTime = DateTime.Now;
            _isRunning = true;
        }

        public void Stop()
        {
            Duration = DateTime.Now - _startTime;
            _isRunning = false;
        }
    }
}
