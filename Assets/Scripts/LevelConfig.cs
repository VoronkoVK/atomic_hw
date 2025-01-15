using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig", order = 1)]
    public class LevelConfig : ScriptableObject
    {
        public int StartLevel = 1;
        public int FinishLevel = 3;
        public int CoinsOnLevel = 2;
    }
}