using UnityEngine;
using System.IO;
using PlayerDataSystem;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaveLoadSystem
{
    public static class DataStorer
    {
        private static string fileName = "PlayersData.data";

        public static void SaveData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(SaveDataPath, FileMode.Create);

            binaryFormatter.Serialize(fileStream, PlayersDataManager.AllPlayersData);
            fileStream.Close();


            //string playersDataInString = JsonUtility.ToJson(PlayersDataManager.AllPlayersData);

            //try
            //{
            //    System.IO.File.WriteAllText(Application.persistentDataPath + "/" + fileName, playersDataInString);
            //}
            //catch (System.Exception e)
            //{
            //    Debug.Log("Error Saving Data:" + e);
            //    throw;
            //}
        }

        public static void LoadData()
        {
            if (!SaveFileExists())
            {
                PlayersDataManager.CreateFirstTimeData();
                SaveData();
                return;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(SaveDataPath, FileMode.Open);

            PlayersData dataLoaded = binaryFormatter.Deserialize(fileStream) as PlayersData;
            PlayersDataManager.SetPlayersData(dataLoaded);

            fileStream.Close();

            //try
            //{
            //    string playersDataInString = System.IO.File.ReadAllText(Application.persistentDataPath + "/" + fileName);
            //    PlayersDataManager.SetPlayersData(JSonStringToPlayersData(playersDataInString));
            //}
            //catch (System.Exception e)
            //{
            //    Debug.Log("Error Loading Data:" + e);
            //    throw;
            //}
        }

        static string SaveDataPath => Application.persistentDataPath + "/" + fileName;

        static PlayersData JSonStringToPlayersData(string JSonString)
        {
            return JsonUtility.FromJson<PlayersData>(JSonString);
        }

        static bool SaveFileExists()
        {
            if (System.IO.File.Exists(SaveDataPath))
                return true;

            return false;
        }
    }
}