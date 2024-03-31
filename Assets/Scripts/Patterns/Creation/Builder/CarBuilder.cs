using System.Collections.Generic;
using Common.Addons;
using Common.Playable;
using UnityEngine;

namespace Patterns.Creation.Builder
{
    public class CarBuilder
    {
        private Cape _cape;
        private Chassis _chassis;
        private Hat _hat;
        private Tyre _tyre;
        private Car _car;
        private Vector2 _position;

        public CarBuilder WithTyre(Tyre tyre)
        {
            _tyre = tyre;
            return this;
        }

        public CarBuilder WithCape(Cape cape)
        {
            _cape = cape;
            return this;
        }

        public CarBuilder WithHat(Hat hat)
        {
            _hat = hat;
            return this;
        }

        public CarBuilder WithChassis(Chassis chassis)
        {
            _chassis = chassis;
            return this;
        }

        public CarBuilder SetPosition(Vector2 position)
        {
            _position = position;
            return this;
        }
        
        public Car Build()
        {
            GameObject carContainer = Object.Instantiate(new GameObject());
            carContainer.gameObject.name = "Car";
            
            _car = carContainer.AddComponent<Car>();
            
            Chassis chassis = Object.Instantiate(_chassis, carContainer.transform);
            List<Tyre> tyres = new List<Tyre>();
            List<Addon> addons = new List<Addon>();
            
            Transform capePosition = chassis.GetPositionFromAddon(AddonType.Cape);
            Transform hatPosition = chassis.GetPositionFromAddon(AddonType.Hat);
            
            Cape cape = Object.Instantiate(_cape, capePosition);
            Hat hat = Object.Instantiate(_hat, hatPosition);
            addons.Add(cape);
            addons.Add(hat);
            
            List<Transform> tyresPosition = chassis.TyresPositions;
            for (int i = 0; i < chassis.TyresAmount; i++)
            {
                tyres.Add(Object.Instantiate(_tyre, tyresPosition[i]));
            }
            
            _car.SetComponents(addons, tyres, chassis);
            _car.gameObject.transform.position = _position;
            
            return _car;
        }
        
    }
}