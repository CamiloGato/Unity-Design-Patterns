namespace Patterns.Structure.Adapter
{
    public class UnityInput : IInput
    {
        private readonly string _horizontal;
        private readonly string _fire;
        private readonly string _brake;

        public UnityInput(string horizontal, string fire, string brake)
        {
            _horizontal = horizontal;
            _fire = fire;
            _brake = brake;
        }

        public float Horizontal()
        {
            return UnityEngine.Input.GetAxis(_horizontal);
        }

        public bool Fire()
        {
            return UnityEngine.Input.GetButton(_fire);
        }

        public bool Brake()
        {
            return UnityEngine.Input.GetButton(_brake);
        }
    }
}