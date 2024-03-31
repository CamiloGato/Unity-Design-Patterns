using System.Collections.Generic;
using Common.Addons;
using UnityEngine;

namespace Common.Playable
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private List<Addon> addonsSpawned;
        [SerializeField] private List<Tyre> tyresSpawned;
        [SerializeField] private Chassis chassisSpawned;

        public void SetComponents(List<Addon> addons, List<Tyre> tyres, Chassis chassis)
        {
            addonsSpawned = addons;
            tyresSpawned = tyres;
            chassisSpawned = chassis;
        }
        
    }
}