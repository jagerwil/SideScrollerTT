using Ducksten.SideScrollerTT.Events;
using Ducksten.SideScrollerTT.Management;
using TMPro;
using UnityEngine;

namespace Ducksten.SideScrollerTT.UI {
    public class ScoreView : UiBehaviour {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _textFormat = "Score: {0}";
        [SerializeField] private bool _delayedInit;

        protected override void LateStart() {
            base.LateStart();
            UpdateScore();
        }

        private void OnEnable() {
            GameEvents.onScoreUpdated.Subscribe(UpdateScoreText);
        }

        private void OnDisable() {
            GameEvents.onScoreUpdated.Unsubscribe(UpdateScoreText);
        }

        private void UpdateScore() {
            var score = ScoreController.Instance.Score;
            UpdateScoreText(score);
        }

        private void UpdateScoreText(int score) {
            _text.text = string.Format(_textFormat, score);
        }
    }
}
