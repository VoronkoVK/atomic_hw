using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [SerializeField]
        private bool _isPlayer;
        
        [SerializeField]
        private int _damage;

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.DealDamage(collision.gameObject);
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void Init(BulletConfig config, Vector2 position, Vector2 direction)
        {
            transform.position = position;
            _rigidbody2D.velocity = direction * config.speed;
            _spriteRenderer.color = config.color;
            gameObject.layer = (int)config.physicsLayer;
            _damage = config.damage;
            _isPlayer = config.isPlayer;
        }
        
        private void DealDamage(GameObject other)
        {
            int damage = _damage;
            if (damage <= 0)
                return;
            
            if (other.TryGetComponent(out Unit unit))
            {
                if (_isPlayer != unit.IsPlayer)
                {
                    unit.TakeDamage(damage);
                }
            }
        }
    }
}