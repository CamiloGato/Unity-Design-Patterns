using System.Collections.Generic;
using Common.Addons;
using Common.Playable;
using Patterns.Behaviour.Mediator;
using UnityEngine;

namespace Patterns.Creation.Builder
{
    public class CarBuilder
    {
        private Chassis _chassis;
        private Cape _cape;
        private Hat _hat;
        private Tyre _tyre;
        private CarLight _carLight;
        private CarMediator _carMediator;
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

        public CarBuilder WithLights(CarLight light)
        {
            _carLight = light;
            return this;
        }

        public CarBuilder SetPosition(Vector2 position)
        {
            _position = position;
            return this;
        }
        
        public CarMediator Build()
        {
            GameObject carContainer = new GameObject
            {
                gameObject =
                {
                    name = "Car"
                }
            };
            _carMediator = carContainer.AddComponent<CarMediator>();
            
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

            Transform carLightPosition = chassis.CarLight;
            CarLight carLight = Object.Instantiate(_carLight, carLightPosition);
            
            _carMediator.SetComponents(addons, tyres, chassis, carLight);
            _carMediator.gameObject.transform.position = _position;
            
            return _carMediator;
        }
        
    }
}