using Common.Configuration;
using UnityEngine;

namespace Common.Playable
{
    public class Tyre : MonoBehaviour
    {
        public Id id;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void Spin(float angle)
        {
            _transform.eulerAngles += Vector3.forward * angle;
        }
    }
}