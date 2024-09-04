using System;
using Ducksten.SideScrollerTT.Events;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Characters.Player {
    public class PlayerInput : MonoBehaviour {
        [SerializeField] private string _horizontalAxis = "Horizontal";
        [SerializeField] private string _verticalAxis = "Vertical";
        [SerializeField] private bool _normalizeMovement = true;

        private bool _isActive = true; //Можно использовать встроенный enabled, но про него легче забыть, т.к. в коде не будет явно видно что он Update отключает
        private Vector2 _moveVector;
        
        public event Action<Vector2> OnMoveVectorChanged;

        private void OnEnable() {
            GameEvents.onGameOver.Subscribe(DisableInput);
        }

        private void OnDisable() {
            GameEvents.onGameOver.Unsubscribe(DisableInput);
        }

        private void Update() {
            if (!_isActive)
                return;

            var moveVector = Vector2.zero;
            moveVector.x = Input.GetAxis(_horizontalAxis);
            moveVector.y = Input.GetAxis(_verticalAxis);
            if (_normalizeMovement) {
                moveVector.Normalize();
            }

            if (_moveVector.IsApproximate(moveVector)) {
                return;
            }

            _moveVector = moveVector;
            OnMoveVectorChanged?.Invoke(moveVector);
        }

        private void DisableInput() {
            OnMoveVectorChanged?.Invoke(Vector2.zero);
            _isActive = false;
        }
    }
}
