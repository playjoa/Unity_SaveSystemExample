using System.Collections.Generic;

namespace PlayerDataSystem 
{
    [System.Serializable]
    public class PlayersData 
    {
        public List<PlayerData> playersDataList;
    }

    [System.Serializable]
    public class PlayerData 
    {
        public int playerID;

        public int moneyAmmount = 0;
        public int victoryCount = 0;

        public bool[] hasBulletItem = new bool[] { true, false, false, false, false };

        public int currentBulletLoaded = 0;
    }
}