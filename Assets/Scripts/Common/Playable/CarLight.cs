using Common.Configuration;
using DG.Tweening;
using UnityEngine;

namespace Common.Playable
{
    public class CarLight : MonoBehaviour
    {
        public Id id;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float timeFade;

        private bool _lightsOn = true;
        
        public void TurnOn()
        {
            if (_lightsOn) return;
            _lightsOn = true;
            spriteRenderer.DOFade(1, timeFade);
        }

        public void TurnOff()
        {
            if (!_lightsOn) return;
            _lightsOn = false;
            spriteRenderer.DOFade(0, timeFade);
        }

    }
}