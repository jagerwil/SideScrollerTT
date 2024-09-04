using Ducksten.SideScrollerTT.Events;
using UnityEngine;

namespace Ducksten.SideScrollerTT {
    public class GameOverView : MonoBehaviour {
        [SerializeField] private GameObject _viewRoot;

        private void Start() {
            _viewRoot.SetActive(false);
        }

        private void OnEnable() {
            GameEvents.onGameOver.Subscribe(ShowView);
        }

        private void OnDisable() {
            GameEvents.onGameOver.Unsubscribe(ShowView);
        }

        private void ShowView() {
            _viewRoot.SetActive(true);
        }
    }
}
