using NUnit.Framework;
using SotongStudio.SharedData.PredefinedData;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio
{
    [CreateAssetMenu(fileName = "EDC-000", menuName = "Predefine Item / Enemy Config")]
    public class EnemyConfigData : ScriptableObject, IPredefinedItem 
    {
        public string ItemId => EnemyId;

        [SerializeField]
        private string EnemyId;

        [field:SerializeField]
        public EnemyInfoData InfoData { get; private set; }

        [field: SerializeField]
        public EnemyVisualData VisualData { get; private set; }

        [field: SerializeField]
        public EnemyStatusData StatusData { get; private set; }

        [field: SerializeField]
        public EnemyQAData QAData { get; private set; }

    }

    [System.Serializable]
    public class EnemyInfoData
    {
        [field: SerializeField]
        public string EnemyName { get; private set; }
    }

    [System.Serializable]
    public class EnemyVisualData
    {
        [field: SerializeField]
        public GameObject VisualPart;
    }

    [System.Serializable]
    public class EnemyStatusData
    {
        [field: SerializeField]
        public int Attack { get; private set; }

        [field: SerializeField]
        public int Health { get; private set; }

        [field: SerializeField]
        public int Defense { get; private set; }
    }

    [System.Serializable]
    public class EnemyQAData
    {
        [field: SerializeField]
        public List<KeyCode> QADirection { get; private set; }

        [field: SerializeField]
        public int QAAmount { get; private set; }

        [field: SerializeField]
        public float QADuration { get; private set; }
    }
}
