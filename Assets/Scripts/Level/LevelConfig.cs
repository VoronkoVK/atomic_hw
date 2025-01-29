using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig", order = 1)]
    public class LevelConfig : ScriptableObject
    {
        public int MaxLevel = 3;
        public int CoinsOnLevel = 2;
    }
}