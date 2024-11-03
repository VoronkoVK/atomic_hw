using System;
using ShootEmUp;
using UnityEngine;

namespace ShootEmUp
{
    public class Unit : MonoBehaviour
    {
        public event Action<Unit, int> OnHealthChanged;
        public event Action<Unit> OnHealthEmpty;
        
        public delegate void FireHandler(Vector2 position, Vector2 direction);
        public event FireHandler OnFire;

        public bool IsPlayer => _isPlayer;
        [SerializeField]
        private bool _isPlayer;
        
        public Transform FirePoint => _firePoint;
        [SerializeField]
        private Transform _firePoint;
        
        [SerializeField]
        private int _health;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _speed = 5.0f;

        public void Move(Vector2 direction)
        {
            Vector2 moveStep = direction * Time.fixedDeltaTime * _speed;
            Vector2 targetPosition = _rigidbody.position + moveStep;
            _rigidbody.MovePosition(targetPosition);
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            OnHealthChanged?.Invoke(this, _health);

            if (_health <= 0)
            {
                OnHealthEmpty?.Invoke(this);
            }
        }

        public void Fire()
        {
            OnFire?.Invoke(_firePoint.position, _firePoint.rotation * Vector3.up);
        }
        
        public void Fire(Vector2 direction)
        {
            OnFire?.Invoke(_firePoint.position, direction);
        }
    }
}
