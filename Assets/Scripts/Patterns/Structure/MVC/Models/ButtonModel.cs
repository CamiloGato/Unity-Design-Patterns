using UnityEngine;

namespace Patterns.Structure.MVC.Models
{
    [CreateAssetMenu(menuName = "Models/Menu", fileName = "MenuModel")]
    public class MenuModel : BaseModel
    {
        public string textData;
    }
}