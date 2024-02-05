using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.SlayTheSpire.Data
{
    public class GameConfigManager
    {
        public static GameConfigManager Instance = new GameConfigManager();

        private const string CardDataPath = "TxtData/card";
        private const string EnemyDataPath = "TxtData/enemy";
        private const string LevelDataPath = "TxtData/level";

        private GameConfigData cardData; // 卡牌表
        private GameConfigData enemyData; // 敵人表
        private GameConfigData levelData; // 關卡表

        private TextAsset textAsset;
        


        // 初始化配置文件，存至內存(txt)
        public void InitConfig()
        {
            textAsset = Resources.Load<TextAsset>(CardDataPath);
            cardData = new GameConfigData(textAsset.text);

            textAsset = Resources.Load<TextAsset>(EnemyDataPath);
            enemyData = new GameConfigData(textAsset.text);

            textAsset = Resources.Load<TextAsset>(LevelDataPath);
            levelData = new GameConfigData(textAsset.text);
        }



        public List<Dictionary<string, string>> GetCardLines()
        {
            return cardData.GetLines();
        }
        public List<Dictionary<string, string>> GetEnemyLines()
        {
            return enemyData.GetLines();
        }
        public List<Dictionary<string, string>> GetLevelLines()
        {
            return levelData.GetLines();
        }        



        public Dictionary<string, string> GetCardById(string _id)
        {
            return cardData.GetDataById(_id);
        }
        public Dictionary<string, string> GetEnemyById(string _id)
        {
            return enemyData.GetDataById(_id);
        }
        public Dictionary<string, string> GetLevelById(string _id)
        {
            return levelData.GetDataById(_id);
        }
    }
}
