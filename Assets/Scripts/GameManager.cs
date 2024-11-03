using UnityEngine;

namespace ShootEmUp
{
    public class GameManager : MonoBehaviour
    {
        public void FinishGame()
        {
            Debug.Log("Finish game!");
            Time.timeScale = 0;
        }
    }
}
