namespace Patterns.Structure.Adapter
{
    public class UnityInput : IInput
    {
        private readonly string _horizontal;
        private readonly string _fire;

        public UnityInput(string horizontal, string fire)
        {
            _horizontal = horizontal;
            _fire = fire;
        }

        public float Horizontal()
        {
            return UnityEngine.Input.GetAxis(_horizontal);
        }

        public bool Fire()
        {
            return UnityEngine.Input.GetButton(_fire);
        }
    }
}