using UnityEngine;

namespace Patterns.Structure.MVC.Models
{
    [CreateAssetMenu(menuName = "Models/Button", fileName = "ButtonModel")]
    public class ButtonModel : BaseModel
    {
        public int amount;
    }
}