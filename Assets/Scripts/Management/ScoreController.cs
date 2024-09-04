using Ducksten.Core;
using Ducksten.SideScrollerTT.Events;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Management {
    public class ScoreController : Singleton<ScoreController> {
        [SerializeField] private int _initialScore = 0;
        [SerializeField] private float _addScorePerSecond = 500f;
        [SerializeField] private float _scoreUpdateInterval = 0.5f;

        private bool _isActive = true; //Можно использовать встроенный enabled, но про него легче забыть, т.к. в коде не будет явно видно что он Update отключает
        private SimpleTimer _timer;

        public int Score { get; private set; }

        private void Awake() {
            Score = _initialScore;
            _timer = new SimpleTimer(_scoreUpdateInterval, UpdateScore, false);
        }

        private void OnEnable() {
            GameEvents.onGameOver.Subscribe(GameOver);
        }

        private void OnDisable() {
            GameEvents.onGameOver.Subscribe(GameOver);
        }

        private void Update() {
            if (!_isActive)
                return;
            
            _timer.Tick(Time.deltaTime);
        }

        private void UpdateScore() {
            Score += Mathf.RoundToInt(_addScorePerSecond * _scoreUpdateInterval);
            GameEvents.onScoreUpdated?.Invoke(Score);
        }

        private void GameOver() {
            _isActive = false;
        }
    }
}

