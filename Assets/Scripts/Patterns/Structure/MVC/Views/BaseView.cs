using UnityEngine;

namespace Patterns.Structure.MVC.Views
{
    public abstract class BaseView : MonoBehaviour
    {
        public abstract void Initialize();

        public virtual void Subscribe() {}
        public virtual void UnSubscribe() {}
        public abstract void Close();
    }
}