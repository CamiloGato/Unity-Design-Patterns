using Common.UI;
using Patterns.Creation.Singleton;
using UnityEngine;

namespace Patterns.Structure.Facade
{
    public class GamePauseFacade : MonoBehaviour
    {
        [SerializeField] private PauseButtons pauseButtons;
        [SerializeField] private PausePanel pausePanel;
        
        public void PauseGame()
        {
            pauseButtons.Pause(true);
            pausePanel.Pause(true);
            DecorationSpawner.Instance.StopSpawn();
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            pauseButtons.Pause(false);
            pausePanel.Pause(false);
            DecorationSpawner.Instance.StartSpawn();
            Time.timeScale = 1f;
        }
    }
}