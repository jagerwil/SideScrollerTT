using System;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Characters {
    //In the future you could add health number, more sophisticated heal & damage & other stuff
    public class CharacterHealth : MonoBehaviour {
        [SerializeField] private HitDetector _hitDetector;

        private bool _hasHealth = true; //Temp replacement for actual health numbers

        public event Action onCharacterDied;

        private void OnEnable() {
            _hitDetector.onHitDetected += HitDetected;
        }

        private void OnDisable() {
            _hitDetector.onHitDetected -= HitDetected;
        }

        private void HitDetected() {
            if (!_hasHealth)
                return;

            onCharacterDied?.Invoke();
            _hasHealth = false;
        }
    }
}
