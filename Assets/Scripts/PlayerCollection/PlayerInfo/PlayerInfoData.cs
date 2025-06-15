using Newtonsoft.Json;
using SotongStudio.SharedData.PlayerCollection;
using UnityEngine;

namespace SotongStudio
{
    public interface IPlayerInfoData : IPlayerCollectionItem
    {
        string PlayerName { get; }
    }

    public class PlayerInfoData : IPlayerInfoData
    {
        public string ItemId => "DefaultPlayerInfo";
        public string PlayerName { get; private set; }

        public PlayerInfoData(string playerName)
        {
            PlayerName = playerName;
        }
    }
}
