using System.Collections.Generic;
using Common.Playable;
using UnityEngine;

namespace Common.Configuration
{
    [CreateAssetMenu(menuName = "Configuration/CarConfiguration", fileName = "CarConfiguration")]
    public class CarConfiguration : ScriptableObject
    {
        [SerializeField] private List<Chassis> chassis;
        [SerializeField] private List<Tyre> tyres;
        [SerializeField] private List<CarLight> lights;

        public Chassis GetChassis(Id id)
        {
            return chassis.Find(chassisObject => chassisObject.id == id);
        }
        
        public Tyre GetTyre(Id id)
        {
            return tyres.Find(tyre => tyre.id == id);
        }

        public CarLight GetLight(Id id)
        {
            return lights.Find(light => light.id == id);
        }
    }
}