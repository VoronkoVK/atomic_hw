using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Bullets/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        public Color color;
        public PhysicsLayer physicsLayer;
        public int damage;
        public bool isPlayer;
        public float speed;
    }
}