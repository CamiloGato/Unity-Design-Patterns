using System.Collections.Generic;
using Patterns.Creation.Factory.Decorations;
using UnityEngine;

namespace Patterns.Creation.Factory.Configuration
{
    [CreateAssetMenu(menuName = "Configuration/DecorationConfiguration", fileName = "DecorationConfiguration")]
    public class DecorationConfiguration : ScriptableObject
    {
        public Dictionary<string, Decoration> decorations;
        
    }
}