using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class PauseButtons : MonoBehaviour
    {
        [SerializeField] private Graphic pauseButton;
        [SerializeField] private Graphic resumeButton;
        private float _duration;
        private bool _ignoreTimeScale;

        public void Configure(float duration, bool ignoreTimeScale)
        {
            _duration = duration;
            _ignoreTimeScale = ignoreTimeScale;
        }

        public void Pause(bool isPause)
        {
            float alphaValuePause = isPause ? 1 : 0;
            float alphaValueResume = isPause ? 0 : 1;
            resumeButton.CrossFadeAlpha(alphaValuePause, _duration, _ignoreTimeScale);
            pauseButton.CrossFadeAlpha(alphaValueResume, _duration, _ignoreTimeScale);
        }
        
    }
}