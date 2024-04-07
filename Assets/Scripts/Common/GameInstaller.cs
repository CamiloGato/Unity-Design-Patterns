using Common.Addons;
using Common.Configuration;
using Common.Playable;
using Patterns.Creation.Builder;
using Patterns.Creation.Factory;
using Patterns.Creation.Singleton;
using Patterns.Structure.Adapter;
using UnityEngine;

namespace Common
{
    public class GameInstaller : MonoBehaviour
    {
        [Header("Configurations")]
        [SerializeField] private DecorationConfiguration decorationConfiguration;
        [SerializeField] private AddonConfiguration addonConfiguration;
        [SerializeField] private CarConfiguration carConfiguration;
        
        [Header("Spawns")]
        [SerializeField] private Id decorationToSpawnId;

        [Header("Spawn Car")]
        [SerializeField] private Vector2 position;
        [SerializeField] private Id chassisId;
        [SerializeField] private Id tyreId;
        [SerializeField] private Id addonCapeId;
        [SerializeField] private Id addonHatId;

        [Header("Input")]
        [SerializeField] private string horizontal;
        [SerializeField] private string fire;
        
        private void Start()
        {
            DecorationFactory decorationFactory = new DecorationFactory(decorationConfiguration);
            DecorationSpawner.Instance.SetUpDecorationFactory(decorationFactory);
            
            InvokeRepeating(nameof(Spawn), 3f, 3f);
            SpawnCar();
        }

        private void SpawnCar()
        {
            Cape cape = addonConfiguration.GetAddon<Cape>(addonCapeId);
            Hat hat = addonConfiguration.GetAddon<Hat>(addonHatId);
            Tyre tyre = carConfiguration.GetTyre(tyreId);
            Chassis chassis = carConfiguration.GetChassis(chassisId);
            
            Car car = new CarBuilder()
                .SetPosition(position)
                .WithCape(cape)
                .WithHat(hat)
                .WithChassis(chassis)
                .WithTyre(tyre)
                .Build();

            GameObject playerContainer = new GameObject
            {
                name = "Player"
            };
            car.transform.SetParent(playerContainer.transform);
            
            Player player = playerContainer.AddComponent<Player>();
            IInput input = new UnityInput(horizontal, fire);
            player.SetComponents(input,car);
            
        }

        public void Spawn()
        {
            DecorationSpawner.Instance.SpawnDecoration(decorationToSpawnId);
        }
        
    }
}