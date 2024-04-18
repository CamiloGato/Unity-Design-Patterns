using System.Collections.Generic;
using Common.Addons;
using Common.Playable;
using UnityEngine;

namespace Patterns.Behaviour.Mediator
{
    public class CarMediator : MonoBehaviour, ICar
    {
        [SerializeField] private List<Addon> addonsSpawned;
        [SerializeField] private List<Tyre> tyresSpawned;
        [SerializeField] private Chassis chassisSpawned;
        [SerializeField] private CarLight carLight;

        private float _currentSpinValue = 0;
        
        public void SetComponents(List<Addon> addons, List<Tyre> tyres, Chassis chassis, CarLight backLight)
        {
            addonsSpawned = addons;
            tyresSpawned = tyres;
            chassisSpawned = chassis;
            carLight = backLight;
        }
        
        public void Move()
        {
            _currentSpinValue += Time.deltaTime;
            _currentSpinValue = _currentSpinValue >= 360 ? 0 : _currentSpinValue;
            
            foreach (Tyre tyre in tyresSpawned)
            {
                tyre.Spin(_currentSpinValue);
            }
            
            carLight.TurnOff();
        }

        public void Brake()
        {
            carLight.TurnOn();
        }
        
    }
}