using Ducksten.SideScrollerTT.Events;
using UnityEngine;

namespace Ducksten.SideScrollerTT.UI {
    public class InGameUi : MonoBehaviour {
        private void OnEnable() {
            GameEvents.onGameOver.Subscribe(HideUi);
        }
        
        private void OnDisable() {
            GameEvents.onGameOver.Subscribe(HideUi);
        }

        private void HideUi() {
            gameObject.SetActive(false);
        }
    }
}

