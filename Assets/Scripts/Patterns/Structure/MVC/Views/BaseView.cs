using UnityEngine;

namespace Patterns.Structure.MVC.Views
{
    public abstract class BaseView : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Close();
    }
}