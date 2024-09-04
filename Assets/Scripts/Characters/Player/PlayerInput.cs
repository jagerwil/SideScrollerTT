using System;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Characters.Player {
    public class PlayerInput : MonoBehaviour {
        [SerializeField] private string _horizontalAxis = "Horizontal";
        [SerializeField] private string _verticalAxis = "Vertical";
        [SerializeField] private bool _normalizeMovement = true;

        private Vector2 _moveVector;
        
        public event Action<Vector2> OnMoveVectorChanged;

        private void Update() {
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
    }
}
