using Patterns.Structure.MVC.Models;
using Patterns.Structure.MVC.Views;
using UnityEngine;

namespace Patterns.Structure.MVC.Controller
{
    public abstract class BaseController : MonoBehaviour
    {
        [Header("Requirements")]
        [SerializeField] protected BaseModel baseModel;
        [SerializeField] protected BaseView baseView;

        public virtual void Initialize()
        {
            
        }

        public virtual void Close()
        {
            
        }
    }
}