using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Unit _player;

        private bool _fireRequired;
        private float _moveDirection;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                _fireRequired = true;

            if (Input.GetKey(KeyCode.LeftArrow))
                _moveDirection = -1;
            else if (Input.GetKey(KeyCode.RightArrow))
                _moveDirection = 1;
            else
                _moveDirection = 0;
        }

        private void FixedUpdate()
        {
            if (_fireRequired)
            {
                _player.Fire();
                _fireRequired = false;
            }
            
            _player.Move(new Vector2(_moveDirection, 0));
        }
    }
}
