using System;
using ShootEmUp;
using UnityEngine;

namespace ShootEmUp
{
    public class Unit : MonoBehaviour
    {
        public event Action<Unit, int> OnHealthChanged;
        public event Action<Unit> OnHealthEmpty;
        
        public bool IsPlayer => _isPlayer;
        [SerializeField]
        private bool _isPlayer;
        
        [SerializeField]
        private Transform _firePoint;
        public Transform FirePoint => _firePoint;
        
        [SerializeField]
        private int _health;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _speed = 5.0f;
        
        [SerializeField]
        private BulletConfig _bulletConfig;
        public BulletConfig BulletConfig => _bulletConfig;
        
        [SerializeField]
        private BulletManager _bulletManager;
        public BulletManager BulletManager => _bulletManager;

        public void SetBulletManager(BulletManager bulletManager)
        {
            _bulletManager = bulletManager;
        }

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
        
        public virtual void Fire()
        {
            _bulletManager.SpawnBullet(_bulletConfig, _firePoint.position, _firePoint.rotation * Vector3.up);
        }
    }
}
