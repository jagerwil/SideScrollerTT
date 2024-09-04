using System;

namespace Ducksten.Core {
    public class SimpleTimer {
        private readonly float _timeBetweenTicks;
        private readonly Action _timerAction;
        private float _remainingTime;

        public SimpleTimer(float timeBetweenTicks, Action timerAction) {
            _timeBetweenTicks = timeBetweenTicks;
            _timerAction = timerAction;
        }
        
        public void Tick(float deltaTime) {
            if (_remainingTime > 0f)
                return;
            
            _timerAction?.Invoke();
            _remainingTime += _timeBetweenTicks;
        }
    }
}
