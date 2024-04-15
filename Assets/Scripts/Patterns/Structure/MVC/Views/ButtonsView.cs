using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Structure.MVC.Views
{
    public class ButtonsView : BaseView
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button continueButton;

        public override void Initialize()
        {
            
        }

        public void SetPause(bool isPaused)
        {
            pauseButton.gameObject.SetActive(!isPaused);
            continueButton.gameObject.SetActive(isPaused);
        }
        
        public override void Close()
        {
            pauseButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(false);
        }
    }
}