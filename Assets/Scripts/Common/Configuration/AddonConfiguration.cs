using System.Collections.Generic;
using Common.Addons;
using UnityEngine;

namespace Common.Configuration
{
    [CreateAssetMenu(menuName = "Configuration/AddonConfiguration", fileName = "AddonConfiguration")]
    public class AddonConfiguration : ScriptableObject
    {
        [SerializeField] private List<Addon> addons;

        public T GetAddon<T>(Id id) where T : Addon
        {
            return addons.Find( addon => addon.id == id ) as T;
        }
        
    }
}