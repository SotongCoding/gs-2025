using System;
using NaughtyAttributes;
using SotongStudio.SharedData.PlayerCollection;
using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class Test : MonoBehaviour
    {
        private IPlayerCollection<PlayerInfoData> _playerInfo;
        private IPlayerCollectionUpdate<PlayerInfoData> _playerInfoUpdate;

        [SerializeField] private TestPlayerInfoData testData;

        [Inject]
        private void Inject(IPlayerCollection<PlayerInfoData> playerInfo,
                            IPlayerCollectionUpdate<PlayerInfoData> playerInfoUpdate)
        {
            _playerInfo = playerInfo;
            _playerInfoUpdate = playerInfoUpdate;
        }

        [Button]
        private void UpdateData()
        {
            var data = new PlayerInfoData(testData.PlayerName);
            _playerInfoUpdate.UpdateItem(data);
        }

        [Button]
        private void RemoveData()
        {
            _playerInfoUpdate.RemoveItem(testData.ItemId);
        }

        [Button]
        private void PrintDataWithId()
        {
            var data = _playerInfo[testData.ItemId];
            Debug.Log($"ItemId: {data.ItemId}, PlayerName: {data.PlayerName}");
        }

        [Button]
        private void PrintAllData()
        {
            var allData = _playerInfo.GetAllData();
            foreach (var data in allData)
            {
                Debug.Log($"ItemId: {data.ItemId}, PlayerName: {data.PlayerName}");
            }
        }

        [Serializable]
        private class TestPlayerInfoData
        {
            [field: SerializeField]
            public string ItemId { get; private set; } = "DefaultPlayerInfo";
            [field: SerializeField]
            public string PlayerName { get; private set; }
        }
    }
}
