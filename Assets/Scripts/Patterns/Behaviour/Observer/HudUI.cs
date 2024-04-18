using TMPro;
using UnityEngine;

namespace Patterns.Behaviour.Observer
{
    public class HudUI : MonoBehaviour
    {
        [SerializeField] private ReactiveVariables variables;
        [SerializeField] private TMP_Text health;
        [SerializeField] private TMP_Text score;

        private void OnEnable()
        {
            variables.HealthNotify += HealthNotify;
            variables.ScoreNotify += ScoreNotify;
        }

        private void ScoreNotify(int value)
        {
            score.text = value.ToString();
        }

        private void HealthNotify(int value)
        {
            health.text = value.ToString();
        }

        private void OnDisable()
        {
            variables.HealthNotify -= HealthNotify;
            variables.ScoreNotify -= ScoreNotify;
        }
    }
}