using Ducksten.SideScrollerTT.Events;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Management {
    public class GameController : MonoBehaviour {
        private void OnEnable() {
            GameEvents.onPlayerDied.Subscribe(PlayerDied);
        }

        private void OnDisable() {
            GameEvents.onPlayerDied.Unsubscribe(PlayerDied);
        }

        private void PlayerDied() {
            GameEvents.onGameOver?.Invoke();
        }
    }
}
