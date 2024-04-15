using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Structure.MVC.Views
{
    public class PanelView : BaseView
    {
        [SerializeField] private Image panel;
        [SerializeField] private float time;
        
        public override void Initialize()
        {
            panel.gameObject.SetActive(true);
        }

        public void SetPause(bool isPaused)
        {
            float percent = (isPaused) ? 0 : 1;
            panel.DOFade(percent, time);
        }
        
        public override void Close()
        {
            panel.gameObject.SetActive(false);
        }
    }
}