using Patterns.Structure.Facade;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class SimpleMenu : MonoBehaviour
    {
        [Header("Game Facade")]
        [SerializeField] private GamePauseFacade gamePauseFacade;

        [Header("Configurations")]
        [SerializeField] private float duration;
        [SerializeField] private bool ignoreTimeScale;
        
        [Header("UI Elements")]
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;

        [Header("UI Components")]
        [SerializeField] private PauseButtons pauseButtons;
        [SerializeField] private PausePanel pausePanel;

        public void Start()
        {
            pauseButtons.Configure(duration, ignoreTimeScale);
            pausePanel.Configure(duration, ignoreTimeScale);
            
            pauseButton.onClick.AddListener(Pause);
            resumeButton.onClick.AddListener(Resume);
            
            gamePauseFacade.ResumeGame();
        }

        private void Resume()
        {
            gamePauseFacade.ResumeGame();
        }

        private void Pause()
        {
            gamePauseFacade.PauseGame();
        }
    }
}