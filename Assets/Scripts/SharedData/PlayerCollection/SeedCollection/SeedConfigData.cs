using SotongStudio.SharedData.PredefinedData;
using UnityEngine;

namespace SotongStudio
{
    [CreateAssetMenu(fileName = "SDC-000", menuName = "Predefine Item / Seed Config")]
    public class SeedConfigData : ScriptableObject, IPredefinedItem
    {
        public string ItemId => SeedId;

        [SerializeField]
        private string SeedId;

        [field: SerializeField]
        public string SeedName { get; private set; }

        [field: SerializeField]
        public SeedType SeedType { get; private set; }

        [field: SerializeField]
        public SeedVisualData VisualData { get; private set; }

        [field: SerializeField]
        public SeedBlessingData BlessingData { get; private set; }


        //[field: SerializeField]
        //public SeedUseBehaviour[] UseBehaviours { get; private set; }

        //[field: SerializeField]
        //public SeedThrowBehaviour[] ThrowBehaviours { get; private set; }
    }

    [System.Serializable]
    public class SeedVisualData
    {
        [field: SerializeField]
        public Sprite FirtsPart { get; private set; }

        [field: SerializeField]
        public Sprite SecondPart { get; private set; }

        [field: SerializeField]
        public Sprite ThirdPart { get; private set; }
    }

    [System.Serializable]
    public class SeedBlessingData : IStatusData
    {
        [field: SerializeField]
        public int Attack { get; private set; }

        [field: SerializeField]
        public int Defense { get; private set; }

        [field: SerializeField]
        public int Health { get; private set; }

        [field: SerializeField]
        public int PercentageAttack { get; private set; }

        [field: SerializeField]
        public int PercentageDefense { get; private set; }

        [field: SerializeField]
        public int PercentageHealth { get; private set; }
    }

    public enum SeedType
    {
        Valor,
        Wisdom,
        Life,
    }
}
