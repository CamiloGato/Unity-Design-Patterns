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
            pauseButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(true);
        }

        public override void Close()
        {
            pauseButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(false);
        }
    }
}