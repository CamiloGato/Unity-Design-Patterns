using System.Collections.Generic;
using Common.Decorations;
using UnityEngine;

namespace Common.Configuration
{
    [CreateAssetMenu(menuName = "Configuration/DecorationConfiguration", fileName = "DecorationConfiguration")]
    public class DecorationConfiguration : ScriptableObject
    {
        [SerializeField] private List<Decoration> decorations = new List<Decoration>();

        public Decoration GetDecoration(Id id)
        {
            return decorations.Find( (decoration) => decoration.id.value == id.value );
        }
        
    }
}