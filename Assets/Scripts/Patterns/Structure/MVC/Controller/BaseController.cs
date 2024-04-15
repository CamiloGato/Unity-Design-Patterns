using Patterns.Structure.MVC.Models;
using Patterns.Structure.MVC.Views;
using UnityEngine;

namespace Patterns.Structure.MVC.Controller
{
    public abstract class BaseController<TM, TV> : MonoBehaviour
        where TM: BaseModel
        where TV: BaseView
    {
        [Header("Requirements")]
        [SerializeField] protected TM baseModel;
        [SerializeField] protected TV baseView;

        public virtual void Initialize()
        {
            baseView.Initialize();
        }

        public virtual void Close()
        {
            baseView.Close();
        }
    }
}