using UnityEngine;

namespace Common.Configuration
{
    [CreateAssetMenu(menuName = "Common/Id", fileName = "Id")]
    public class Id : ScriptableObject
    {
        public string value;
    }
}