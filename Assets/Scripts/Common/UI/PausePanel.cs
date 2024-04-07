using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private Image panel;
        private float _duration;
        private bool _ignoreTimeScale;

        public void Configure(float duration, bool ignoreTimeScale)
        {
            _duration = duration;
            _ignoreTimeScale = ignoreTimeScale;
        }

        public void Pause(bool isPause)
        {
            float alphaValue = isPause ? 1 : 0;
            panel.CrossFadeAlpha(alphaValue, _duration, _ignoreTimeScale);
        }
        
    }
}