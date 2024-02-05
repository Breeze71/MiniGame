using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.SlayTheSpire.Data
{
    /// <summary>
    /// 每個對象對應一個 txt 配置表
    /// </summary>
    public class GameConfigData
    {
        public List<Dictionary<string, string>> DataDic; // 存儲配置表中所有數據

        public GameConfigData(string _str)
        {
            DataDic = new List<Dictionary<string, string>>();

            // 換行切割
            string[] _lines = _str.Split('\n');

            // 第一行為類型(不是數據)
            string[] _title = _lines[0].Trim().Split('\t'); // tab 切割

            // 從第三行開始(第二行為中文解釋，避免某人看不懂 :))
            for(int _i = 2; _i < _lines.Length; _i++)
            {
                Dictionary<string, string> _dataDic = new Dictionary<string, string>();

                string[] _datas = _lines[_i].Trim().Split('\t');

                for(int _j = 0; _j < _datas.Length; _j++)
                {
                    _dataDic.Add(_title[_j], _datas[_j]); // 將標題(類型) 和數據存儲(可用類型查表)
                }

                // 每張牌用一個 Dictionary 存
                DataDic.Add(_dataDic);
            }
        }

        public List<Dictionary<string, string>> GetLines()
        {
            return DataDic;
        }

        public Dictionary<string, string> GetDataById(string _id)
        {
            for(int _i = 0; _i < DataDic.Count; _i++)
            {
                Dictionary<string, string> _dataLineDic = DataDic[_i];

                // 用 Id 類型查找
                if(_dataLineDic["Id"] == _id)
                {
                    return _dataLineDic;
                }
            }

            return null;
        }
    }
}
