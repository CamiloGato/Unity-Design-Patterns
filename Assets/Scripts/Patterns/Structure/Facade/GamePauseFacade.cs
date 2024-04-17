using System;
using Patterns.Creation.Singleton;
using Patterns.Structure.MVC.Controller;
using UnityEngine;

namespace Patterns.Structure.Facade
{
    public class GamePauseFacade : MonoBehaviour
    {

        [SerializeField] private ButtonsController buttonsController;
        [SerializeField] private PanelController panelController;

        private void Start()
        {
            ResumeGame();
        }

        public void PauseGame()
        {
            buttonsController.Pause();
            panelController.Pause();
            DecorationSpawner.Instance.StopSpawn();
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            buttonsController.Continue();
            panelController.Continue();
            DecorationSpawner.Instance.StartSpawn();
            Time.timeScale = 1f;
        }
    }
}