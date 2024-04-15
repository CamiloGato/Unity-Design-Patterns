using System.Collections.Generic;
using Common.Decorations;
using UnityEngine;

namespace Common.Configuration
{
    [CreateAssetMenu(menuName = "Configuration/DecorationConfiguration", fileName = "DecorationConfiguration")]
    public class DecorationConfiguration : ScriptableObject
    {
        [SerializeField] private List<Decoration> decorations = new List<Decoration>();
        public List<Decoration> Decorations => decorations;
        
        public Decoration GetDecoration(Id id)
        {
            return decorations.Find( (decoration) => decoration.id == id );
        }
        
    }
}