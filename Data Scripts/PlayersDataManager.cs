using System.Collections.Generic;
using UnityEngine;
using PlayerDataSystem;
using SaveLoadSystem;

public static class PlayersDataManager
{
    public static PlayersData AllPlayersData { get; private set; } = null;

    public static void SetPlayersData(PlayersData newPlayersData) 
    {
        AllPlayersData = newPlayersData;
    }

    public static void CreateFirstTimeData()
    {
        List<PlayerData> playersList = new List<PlayerData>();

        PlayerData player0Data = new PlayerData();
        PlayerData player1Data = new PlayerData();

        player0Data.playerID = 0;
        player1Data.playerID = 1;

        playersList.Add(player0Data);
        playersList.Add(player1Data);

        AllPlayersData = PlayerDataConstructor(playersList);
    }

    static PlayersData PlayerDataConstructor(List<PlayerData> listToAdd)
    {
        PlayersData tempPlayersData = new PlayersData();

        tempPlayersData.playersDataList = listToAdd;

        return tempPlayersData;
    }

    static void RequestLoadData() 
    {
        if (AllPlayersData != null)
            return;

        DataStorer.LoadData();
    }

    public static int PlayerMoneyAmmout(int playerID) 
    {
        RequestLoadData();

        return AllPlayersData.playersDataList[playerID].moneyAmmount;
    }

    public static void SetNewPlayerMoneyAmmout(int playerID, int newValueToSet)
    {
        RequestLoadData();

        AllPlayersData.playersDataList[playerID].moneyAmmount = newValueToSet;

        DataStorer.SaveData();
    }

    public static int PlayerVictoryCount(int playerID)
    {
        RequestLoadData();

        return AllPlayersData.playersDataList[playerID].victoryCount;
    }

    public static void SetNewPlayerVictoryAmmout(int playerID, int newValueToSet)
    {
        RequestLoadData();

        AllPlayersData.playersDataList[playerID].victoryCount = newValueToSet;

        DataStorer.SaveData();
    }

    public static bool PlayerHasBulletItem(int playerID, int bulletIndexToCheck)
    {
        RequestLoadData();

        return AllPlayersData.playersDataList[playerID].hasBulletItem[bulletIndexToCheck];
    }

    public static void SetNewPlayerNewBulletItemValue(int playerID, int bulletIndex, bool newValueToSet)
    {
        RequestLoadData();

        AllPlayersData.playersDataList[playerID].hasBulletItem[bulletIndex] = newValueToSet;

        DataStorer.SaveData();
    }

    public static int PlayerCurrentBulletLoaded(int playerID)
    {
        RequestLoadData();

        return AllPlayersData.playersDataList[playerID].currentBulletLoaded;
    }

    public static void SetNewPlayerCurrentBullet(int playerID, int newValueToSet)
    {
        RequestLoadData();

        AllPlayersData.playersDataList[playerID].currentBulletLoaded = newValueToSet;

        DataStorer.SaveData();
    }
}