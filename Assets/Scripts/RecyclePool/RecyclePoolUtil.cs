using System;
using UnityEngine;

namespace MizukiTool.RecyclePool
{
    public class RecyclePoolUtil : RecyclePool
    {
        //注册所有回收物
        //格式:RigisterOnePrefab(Enum,GameObject)
        public static new void RigisterAllPrefab()
        {

        }

        public static new void Request<T>(T id, Action<RecycleCollection> hander = null, Transform parent = null) where T : Enum
             => RecyclePool.Request(id, hander, parent);

        public static new void ReturnToPool(GameObject go)
            => RecyclePool.ReturnToPool(go);
    }
}

