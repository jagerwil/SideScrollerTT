using System;

namespace Ducksten.Core {
    public class SimpleTimer {
        private readonly float _timeBetweenTicks;
        private readonly Action _timerAction;
        private float _remainingTime;

        public SimpleTimer(float timeBetweenTicks, Action timerAction, bool fireEventImmediately = true) {
            _timeBetweenTicks = timeBetweenTicks;
            _timerAction = timerAction;
            if (!fireEventImmediately)
                _remainingTime = _timeBetweenTicks;
        }
        
        public void Tick(float deltaTime) {
            _remainingTime -= deltaTime;
            if (_remainingTime > 0f)
                return;
            
            _timerAction?.Invoke();
            _remainingTime += _timeBetweenTicks;
        }
    }
}
