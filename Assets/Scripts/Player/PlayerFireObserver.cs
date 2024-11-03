using UnityEngine;

namespace ShootEmUp
{
    public class PlayerFireObserver : MonoBehaviour
    {
        [SerializeField] private BulletManager _bulletManager;
        [SerializeField] private Unit _player;

        private void OnEnable()
        {
            _player.OnFire += OnFire;
        }

        private void OnDisable()
        {
            _player.OnFire -= OnFire;
        }

        private void OnFire(Vector2 position, Vector2 direction)
        {
            _bulletManager.SpawnBullet(
                position,
                Color.blue,
                (int)PhysicsLayer.PLAYER_BULLET,
                1,
                true,
                direction * 3
            );
        }
    }
}
