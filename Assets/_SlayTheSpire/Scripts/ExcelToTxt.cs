using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Data;
using Excel;


namespace V.SlayTheSpire.EditorTool
{
    public static class ExcelToTxt
    {
        private const string ExcelPath = "/_SlayTheSpire/_Excel";
        private const string TxtStorePath = "/Resources/TxtData/";


        [MenuItem("ExcelTool/ExcelToTxt")]
        public static void ExportExcelToTxt()
        {
            // Excel Folder path
            string _assestPath = Application.dataPath + ExcelPath;

            // get all excel
            string[] _excelFiles = Directory.GetFiles(_assestPath, "*.xlsx");

            for(int i = 0; i < _excelFiles.Length; i++)
            {
                _excelFiles[i] = _excelFiles[i].Replace('\\', '/'); // 將反斜換斜
                
                // 讀取 
                using (FileStream _fileStream = File.Open(_excelFiles[i], FileMode.Open, FileAccess.Read))
                {
                    var _excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(_fileStream); // excel reader

                    // 獲取 excel data
                    DataSet _dataSet = _excelDataReader.AsDataSet();

                    // 獲取 excel 第一張表
                    DataTable _excelTable = _dataSet.Tables[0];

                    // 讀表並存入 txt
                    ReadTableToTxt(_excelFiles[i], _excelTable);
                }
            }

            // 刷新 Editor
            AssetDatabase.Refresh();
        }

        private static void ReadTableToTxt(string _filePath, DataTable _dataTable)
        {
            // 獲取文件名(排除後綴)
            string _fileName = Path.GetFileNameWithoutExtension(_filePath);

            // txt 存儲位置
            string _txtStorePath = Application.dataPath + TxtStorePath + _fileName + ".txt";

            // 若存在刪除(因為可能頻繁修改)
            if(File.Exists(_txtStorePath))
            {
                File.Delete(_txtStorePath);
            }

            using (FileStream _fileStream = new FileStream(_txtStorePath, FileMode.Create)) // FileStream
            {
                using (StreamWriter _streamWriter = new StreamWriter(_fileStream)) // streamWriter
                {
                    // 遍歷 Table
                    for(int _row = 0; _row < _dataTable.Rows.Count; _row++)
                    {
                        DataRow _dataRow = _dataTable.Rows[_row];

                        string _str = "";
                        for(int _col = 0; _col < _dataTable.Columns.Count; _col++)
                        {
                            string _val = _dataRow[_col].ToString();

                            _str = _str + _val + "\t"; // 將每項用 Tab 分割
                        }

                        // 寫入
                        _streamWriter.Write(_str);

                        // 若不是最後一行，輸入行結束符(換行)
                        if(_row != _dataTable.Rows.Count - 1)
                        {
                            _streamWriter.WriteLine();
                        }   
                    }
                }
            }
        }
    }
}
