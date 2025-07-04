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

        [field:SerializeField]
        public SeedInfoData InfoData { get; private set; }

        [field: SerializeField]
        public SeedVisualData VisualData { get; private set; }

        [field: SerializeField]
        public SeedBlessingData BlessingData { get; private set; }


        [field: SerializeField]
        public string UseBehavioursIds { get; private set; }

        [field: SerializeField]
        public string ThrowBehavioursIds { get; private set; }
    }

    [System.Serializable]
    public class SeedInfoData
    {
        [field: SerializeField]
        public string SeedName { get; private set; }

        [field: SerializeField]
        public SeedType SeedType { get; private set; }

    }

    [System.Serializable]
    public class SeedVisualData
    {
        [field: SerializeField]
        public SeedType TopPart { get; private set; }

        [field: SerializeField]
        public SeedType MiddlePart { get; private set; }

        [field: SerializeField]
        public SeedType BottomPart { get; private set; }

        public SeedVisualData(SeedType topPart, SeedType middlePart, SeedType bottomPart)
        {
            TopPart = topPart;
            MiddlePart = middlePart;
            BottomPart = bottomPart;
        }
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

        //[field: SerializeField]
        //public int PercentageAttack { get; private set; }

        //[field: SerializeField]
        //public int PercentageDefense { get; private set; }

        //[field: SerializeField]
        //public int PercentageHealth { get; private set; }
    }

    public enum SeedType
    {
        Valor,
        Wisdom,
        Life,
    }
}
