using Common.Configuration;
using Common.Decorations;
using UnityEngine;

namespace Patterns.Creation.Factory
{
    public class DecorationFactory
    {
        private readonly DecorationConfiguration _decorationConfiguration;
        
        public DecorationFactory(DecorationConfiguration decorationConfiguration)
        {
            _decorationConfiguration = decorationConfiguration;
        }
        
        public Decoration Create(Id id)
        {
            return Object.Instantiate(_decorationConfiguration.GetDecoration(id));
        }
        
    }
}