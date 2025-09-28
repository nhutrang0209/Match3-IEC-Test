using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class LevelData
    {
        [NonSerialized]
        public const string PREVIOUS_LEVEL_KEY = "PREVIOUS_LEVEL";

        public static LevelData Default
        {
            get
            {
                var jsonData = PlayerPrefs.GetString(LevelData.PREVIOUS_LEVEL_KEY);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonUtility.FromJson<LevelData>(jsonData);
                }
                var levelData = new LevelData();
                levelData.Save();
                return levelData;
            }
        }

        public int previousMode;
        public int[] previousLevelMap;

        public void Save()
        {
            var jsonData = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(PREVIOUS_LEVEL_KEY, jsonData);
            PlayerPrefs.Save();
        }
    }
}