using Modules;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class CoinsPool : MonoMemoryPool<Vector2Int, Coin>
    {
        protected override void Reinitialize(Vector2Int pos, Coin coin)
        {
            coin.Position = pos;
            coin.Generate();
        }
    }
}