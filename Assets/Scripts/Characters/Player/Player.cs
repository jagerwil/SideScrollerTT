using Ducksten.SideScrollerTT.Events;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Characters.Player {
    public class Player : MonoBehaviour {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private CharacterHealth _health;

        private void OnEnable() {
            _health.onCharacterDied += CharacterDied;
        }

        private void OnDisable() {
            _health.onCharacterDied -= CharacterDied;
        }

        private void CharacterDied() {
            GameEvents.onPlayerDied?.Invoke();
        }
    }
}

