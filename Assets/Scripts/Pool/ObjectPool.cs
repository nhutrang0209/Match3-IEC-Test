using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class ObjectPool
    {
        private const int DEFAULT_POOL_SIZE = 3;

        private static Dictionary<GameObject, Pool> s_pools;

        private readonly Queue<GameObject> _pool;

        public static GameObject Spawn(GameObject prefab, Vector3 position = default, Quaternion rotation = default
            , Transform parent = null)
        {
            if (!prefab) return null;

            CheckPool();

            return s_pools[prefab].Get(position, rotation, parent);

            void CheckPool()
            {
                s_pools ??= new Dictionary<GameObject, Pool>();
                if (!s_pools.ContainsKey(prefab))
                {
                    var newPool = new Pool(prefab, DEFAULT_POOL_SIZE);
                    s_pools.Add(prefab, newPool);
                }
            }
        }

        public static T Spawn<T>(T prefab, Vector3 position = default, Quaternion rotation = default
            , Transform parent = null) where T : Component
        {
            var obj = Spawn(prefab.gameObject, position, rotation, parent);
            return obj.GetComponent<T>();
        }

        public static void Despawn(GameObject obj)
        {
            if (!obj) return;
            
            var poolMember = obj.GetComponent<PoolMember>();
            if (!poolMember)
            {
                Object.Destroy(obj);
            }
            else
            {
                poolMember.Return();
            }
        }
    }
}