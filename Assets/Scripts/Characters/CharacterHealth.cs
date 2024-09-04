using UnityEngine;

namespace Ducksten.SideScrollerTT.Characters {
    //In the future you could add health number, more sofisticated heal & damage & other stuff
    public class CharacterHealth : MonoBehaviour {
        [SerializeField] private HitDetector _hitDetector;

        private void OnEnable() {
            _hitDetector.onHitDetected += HitDetected;
        }

        private void OnDisable() {
            _hitDetector.onHitDetected -= HitDetected;
        }

        private void HitDetected() {
            Debug.Log("CHARACTER HURT! OMG");
        }
    }
}
