using Common.Addons;
using Common.Configuration;
using Common.Enemies;
using Common.Playable;
using Common.Weapons;
using Patterns.Behaviour.Strategy;
using Patterns.Creation.Builder;
using Patterns.Creation.Factory;
using Patterns.Creation.Singleton;
using Patterns.Structure.Adapter;
using Patterns.Structure.Composite;
using UnityEngine;

namespace Common
{
    public class GameInstaller : MonoBehaviour
    {
        [Header("Configurations")]
        [SerializeField] private DecorationConfiguration decorationConfiguration;
        [SerializeField] private EnemyConfiguration enemyConfiguration;
        [SerializeField] private AddonConfiguration addonConfiguration;
        [SerializeField] private CarConfiguration carConfiguration;
        [SerializeField] private BulletConfiguration bulletConfiguration;

        [Header("Spawns")]
        [SerializeField] private float time;
        [SerializeField] private Id decorationToSpawnId;
        [SerializeField] private Id enemyToSpawnId;
        [SerializeField] private Id enemyToHordeId;

        [Header("Spawn Car")]
        [SerializeField] private Vector2 position;
        [SerializeField] private Id chassisId;
        [SerializeField] private Id tyreId;
        [SerializeField] private Id addonCapeId;
        [SerializeField] private Id addonHatId;

        [Header("Input")]
        [SerializeField] private string horizontal;
        [SerializeField] private string fire;

        [Header("Another Features")]
        [SerializeField] private Vector2 enemyDirection;
        [SerializeField] private Id bulletId;

        private Enemy _enemy;
        private HordeEnemyComposite _hordeEnemyComposite;
        
        private void Start()
        {
            SpawnEnemy();

            SpawnDecoration();

            SpawnCar();
        }

        private void SpawnEnemy()
        {
            EnemyFactory enemyFactory = new EnemyFactory(enemyConfiguration);
            EnemySpawner enemySpawner = new EnemySpawner(enemyFactory);
            
            _enemy = enemySpawner.Spawn(enemyToSpawnId);
            _hordeEnemyComposite = 
                new GameObject()
                    {
                        name = "Horde"
                    }
                .AddComponent<HordeEnemyComposite>();

            Enemy enemy1 = Instantiate(enemyConfiguration.GetEnemy(enemyToHordeId));
            enemy1.transform.position += new Vector3(1,1,0);
            Enemy enemy2 = Instantiate(enemyConfiguration.GetEnemy(enemyToHordeId));
            enemy2.transform.position += new Vector3(0,1,0);
            Enemy enemy3 = Instantiate(enemyConfiguration.GetEnemy(enemyToHordeId));
            enemy3.transform.position += new Vector3(1,0,0);
            
            _hordeEnemyComposite.AddEnemy(enemy1);
            _hordeEnemyComposite.AddEnemy(enemy2);
            _hordeEnemyComposite.AddEnemy(enemy3);
            
            Vector2 direction = enemyDirection.normalized;
            _hordeEnemyComposite.Move(direction);
            _enemy.Move(-direction);
        }

        private void SpawnDecoration()
        {
            Transform decorationPoolTransform = new GameObject("Decoration Pool").transform;
            DecorationFactory decorationFactory = new DecorationFactory(decorationConfiguration, decorationPoolTransform);
            DecorationSpawner.Instance.SetUpDecorationFactory(decorationFactory, time, decorationToSpawnId);
            DecorationSpawner.Instance.ChangeDecorationId(decorationToSpawnId);
            DecorationSpawner.Instance.StartSpawn();
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
            Transform playerContainerTransform = playerContainer.transform;
            
            car.transform.SetParent(playerContainerTransform);
            
            Player player = playerContainer.AddComponent<Player>();
            IInput input = new UnityInput(horizontal, fire);
            IAttack attackSimple = new AttackSimple(playerContainerTransform, 2f);
            Transform bulletPoolTransform = new GameObject("Bullet Pool").transform;
            BulletFactory bulletFactory = new BulletFactory(bulletConfiguration, bulletPoolTransform);
            IAttack attackBullet = new AttackBullet(playerContainerTransform, bulletFactory, bulletId, 2f);
            player.SetComponents(input, attackBullet, car);
        }
        
    }
}