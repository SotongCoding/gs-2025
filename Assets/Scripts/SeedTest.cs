using System.Linq;
using Cysharp.Threading.Tasks;
using System;
using NaughtyAttributes;
using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class SeedTest : MonoBehaviour
    {
        private IPlayerSeedService _seedDataService;
        private IBattleUnitManager _unitManager;
        private IBattleHelper _battleHelper;
        private string[] _noneOwned;
        private ISeedInventoryLogic _inventoryLogic;

        [Header("Test Behaviour")]
        [SerializeField]
        private SeedBehaviourCollection _seedBehaviourCollection;
        private SeedConfigCollection _seedConfigCollection;

        [Inject]
        private void Inject(IPlayerSeedService seedDataService,
                            IBattleUnitManager unitManager,
                            IBattleHelper battleHelper,
                            SeedBehaviourCollection seedBehaviourCollection,
                            SeedConfigCollection seedConfigCollection)
        {

            _seedDataService = seedDataService;
            _unitManager = unitManager;
            _battleHelper = battleHelper;
            _seedBehaviourCollection = seedBehaviourCollection;
            _seedConfigCollection = seedConfigCollection;

            _noneOwned = seedDataService.GetNonOwnedRegularSeedIds();
        }
        [Inject]
        private void OtherInject(ISeedInventoryLogic inventoryLogic)
        {
            _inventoryLogic = inventoryLogic;

            inventoryLogic.OnSelectSeed.AddListener(SelectSeed);
        }

        private void SelectSeed(ISeedData arg0)
        {
            Debug.Log($"Player Select Seed {arg0}");
        }

        [Button]
        public void Test()
        {
            var seedInventory = _seedDataService.GetOwnedSeeds();
            foreach (var item in seedInventory)
            {
                Debug.Log($"Owned Seed : {item}");
            }
        }

        [Button]
        public void TestAddSeedToInventory()
        {
            _seedDataService.AddRegularSeedToInventory("SEED-001");

            Debug.Log("Added Seed");
        }

        [Button]
        public void TestUnit()
        {
            _unitManager.SetEnemyUnit(new EnemyUnit(1, 2, 100));
            _unitManager.SetCharacterUnit(new CharacterUnit(2, 3, 200));

            Debug.Log($"Character Stat : " +
                        $"A : {_unitManager.Character.ModifiedStatus.Attack}|" +
                        $"D : {_unitManager.Character.ModifiedStatus.Defense}|" +
                        $"H : {_unitManager.Character.ModifiedStatus.Health}");

            Debug.Log($"Enemy Stat : " +
                $"A : {_unitManager.Enemy.ModifiedStatus.Attack}|" +
                $"D : {_unitManager.Enemy.ModifiedStatus.Defense}|" +
                $"H : {_unitManager.Enemy.ModifiedStatus.Health}");
        }
        [Button]
        public void TakeDamage()
        {
            _battleHelper.GiveDamageToEnemy(10);
            Debug.Log($"Enemy Health : {_unitManager.Enemy.ModifiedStatus.Health}");

            _battleHelper.GiveDamageToCharacter(5);
            Debug.Log($"Character Health : {_unitManager.Character.ModifiedStatus.Health}");
        }

        [Button]
        public void GiveStat()
        {
            _battleHelper.AddStatusToEnemy(new TestStatUp(4, 3, 6));
            Debug.Log($"Enemy Health : {_unitManager.Enemy.ModifiedStatus.Health}");

            _battleHelper.AddStatusToCharacter(new TestStatUp(7, 13, 9));
            Debug.Log($"Character Health : {_unitManager.Character.ModifiedStatus.Health}");
        }

        [Button]
        public void TestBehaviour()
        {
            var allItem = _seedBehaviourCollection.GetAllItems().Select(data => data.ItemId);
            foreach (var behevId in allItem)
            {
                var behaviour = _seedBehaviourCollection.GetItem(behevId);
                try
                {
                    Debug.Log($"Execute Use Behaviour {behevId}");
                    behaviour.UseLogic.ExecuteBehaviourAsync(_battleHelper).Forget();
                    Debug.Log($"Character Stat : " +
                        $"A : {_unitManager.Character.ModifiedStatus.Attack}|" +
                        $"D : {_unitManager.Character.ModifiedStatus.Defense}|" +
                        $"H : {_unitManager.Character.ModifiedStatus.Health}");

                    Debug.Log($"Enemy Stat : " +
                        $"A : {_unitManager.Enemy.ModifiedStatus.Attack}|" +
                        $"D : {_unitManager.Enemy.ModifiedStatus.Defense}|" +
                        $"H : {_unitManager.Enemy.ModifiedStatus.Health}");
                }
                catch (System.Exception)
                {
                    Debug.Log($"Unable Execute Use Behaviour : {behevId}");
                }

                try
                {
                    Debug.Log($"Execute Throw Behaviour {behevId}");
                    behaviour.ThrowLogic.ExecuteBehaviourAsync(_battleHelper).Forget();
                    Debug.Log($"Character Stat : " +
                        $"A : {_unitManager.Character.ModifiedStatus.Attack}|" +
                        $"D : {_unitManager.Character.ModifiedStatus.Defense}|" +
                        $"H : {_unitManager.Character.ModifiedStatus.Health}");

                    Debug.Log($"Enemy Stat : " +
                        $"A : {_unitManager.Enemy.ModifiedStatus.Attack}|" +
                        $"D : {_unitManager.Enemy.ModifiedStatus.Defense}|" +
                        $"H : {_unitManager.Enemy.ModifiedStatus.Health}");
                }
                catch (System.Exception)
                {

                    Debug.Log($"Unable Execute Throw Behaviour : {behevId}");
                }

            }
        }

        [Button]
        public void TestSeedBehaviour()
        {
            var allItem = _seedConfigCollection.GetAllItems();

            foreach (var item in allItem)
            {
                var useActionId = item.UseBehavioursIds;

                Debug.Log($"Execute Use Behaviour {useActionId} from {item.ItemId}");
                var useLogic = _seedBehaviourCollection.GetItem(useActionId).UseLogic;
                useLogic.ExecuteBehaviourAsync(_battleHelper).Forget();

                Debug.Log($"Character Stat : " +
                    $"A : {_unitManager.Character.ModifiedStatus.Attack}|" +
                    $"D : {_unitManager.Character.ModifiedStatus.Defense}|" +
                    $"H : {_unitManager.Character.ModifiedStatus.Health}");

                Debug.Log($"Enemy Stat : " +
                    $"A : {_unitManager.Enemy.ModifiedStatus.Attack}|" +
                    $"D : {_unitManager.Enemy.ModifiedStatus.Defense}|" +
                    $"H : {_unitManager.Enemy.ModifiedStatus.Health}");

                var throwActionId = item.ThrowBehavioursIds;

                Debug.Log($"Execute Throw Behaviour {throwActionId} from {item.ItemId}");
                var throwLogic = _seedBehaviourCollection.GetItem(throwActionId).ThrowLogic;
                throwLogic.ExecuteBehaviourAsync(_battleHelper).Forget();

                Debug.Log($"Character Stat : " +
                    $"A : {_unitManager.Character.ModifiedStatus.Attack}|" +
                    $"D : {_unitManager.Character.ModifiedStatus.Defense}|" +
                    $"H : {_unitManager.Character.ModifiedStatus.Health}");

                Debug.Log($"Enemy Stat : " +
                    $"A : {_unitManager.Enemy.ModifiedStatus.Attack}|" +
                    $"D : {_unitManager.Enemy.ModifiedStatus.Defense}|" +
                    $"H : {_unitManager.Enemy.ModifiedStatus.Health}");
            }
        }
        private class TestStatUp : IBasicStatusData
        {
            public int Attack { get; private set; }

            public int Defense { get; private set; }

            public int Health { get; private set; }

            public TestStatUp(int attack, int defense, int health)
            {
                Attack = attack;
                Defense = defense;
                Health = health;
            }
        }

        [Button]
        public void TestInventory()
        {
            _inventoryLogic.UpdateInventoryList();
        }
    }
}
