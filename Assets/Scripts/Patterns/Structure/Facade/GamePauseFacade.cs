using Patterns.Creation.Singleton;
using UnityEngine;

namespace Patterns.Structure.Facade
{
    public class GamePauseFacade : MonoBehaviour
    {
        
        public void PauseGame()
        {
            DecorationSpawner.Instance.StopSpawn();
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            DecorationSpawner.Instance.StartSpawn();
            Time.timeScale = 1f;
        }
    }
}