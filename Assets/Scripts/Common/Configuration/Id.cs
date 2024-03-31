using System;
using UnityEngine;

namespace Common.Configuration
{
    [CreateAssetMenu(menuName = "Common/Id", fileName = "Id")]
    public class Id : ScriptableObject
    {
        public string Value;

        public override bool Equals(object other)
        {
            if (other is Id otherId)
            {
                return otherId.Value == Value;
            }

            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Value);
        }
    }
}