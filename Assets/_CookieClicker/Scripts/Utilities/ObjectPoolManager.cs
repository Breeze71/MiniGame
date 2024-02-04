using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace V.Utilities
{
    /// <summary>
    /// 簡易 Object Pool
    /// </summary>
    public class ObjectPoolManager : MonoBehaviour
    {
        public static List<PooledObjectInfo> objectPools = new List<PooledObjectInfo>();

        public static GameObject SpawnObject(GameObject _objectToSpawn, Transform _parentTransform)
        {
            // 找出 LookupString 和 _objectToSpawn.name 相同的
            PooledObjectInfo _pool = objectPools.Find(p => p.LookupString == _objectToSpawn.name);

            // 如果沒有該 Pool，創建
            if(_pool == null)
            {
                _pool = new PooledObjectInfo
                {
                    LookupString = _objectToSpawn.name,
                };

                objectPools.Add(_pool);
            }

            // 每次都取出第一個(如果沒有就創建一個)
            GameObject _inactiveObjectGO = _pool.InactiveObjects.FirstOrDefault(); // *** EnterPlayMode 會有 Bug ***
            Debug.Log("FirstOrDefault()   *** 於 EnterPlayMode 會有 Bug ***");
            if(_inactiveObjectGO == null)
            {
                _inactiveObjectGO = Instantiate(_objectToSpawn, _parentTransform);
                Debug.Log("Instantiate");
            }
            else
            {
                _pool.InactiveObjects.Remove(_inactiveObjectGO);
                _inactiveObjectGO.SetActive(true);
                Debug.Log("Pick One");
            }

            return _inactiveObjectGO;
        }


        public static void ReturnObjectToPool(GameObject _GO)
        {
            // 從 0 截取至 (Length - 7)    不要(Clone)
            string _GOName = _GO.name.Substring(0, _GO.name.Length - 7);

            PooledObjectInfo _pool = objectPools.Find(p => p.LookupString == _GOName);

            // 放回至 Pool
            if(_pool != null)
            {
                _GO.SetActive(false);
                _pool.InactiveObjects.Add(_GO);
            }
        }
    }

    public class PooledObjectInfo
    {
        public string LookupString;
        public List<GameObject> InactiveObjects = new List<GameObject>();
    }
}
