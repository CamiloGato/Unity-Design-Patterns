using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Structure.MVC.Views
{
    public class ButtonsView : BaseView
    {
        [SerializeField] private float time;
        [SerializeField] private Button pauseButton;
        [SerializeField] private TMP_Text pauseButtonText;
        [SerializeField] private Button continueButton;
        [SerializeField] private TMP_Text continueButtonText;

        public override void Initialize()
        {
            pauseButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(true);
        }

        public void SetPause(bool isPaused)
        {
            float percent = (isPaused) ? 0f : 1f;
            pauseButton.image.DOFade(percent, time);
            pauseButtonText.DOFade(percent, time);
            percent = (isPaused) ? 1f : 0f;
            continueButton.image.DOFade(percent, time);
            continueButtonText.DOFade(percent, time);
        }
        
        public override void Close()
        {
            pauseButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(false);
        }
    }
}