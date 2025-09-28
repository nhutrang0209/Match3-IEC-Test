using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    internal class Pool
    {
        private readonly Queue<GameObject> _pool;
        private readonly GameObject _prefab;

        public Pool(GameObject prefab, int quantity)
        {
            _prefab = prefab;
            _pool = new Queue<GameObject>(quantity);
        }
        
        public GameObject Get(Vector3 position, Quaternion rotation, Transform parent)
        {
            var result = _pool.Count == 0 ? Spawn() : _pool.Dequeue();

            result.SetActive(true);
            
            var resultTransform = result.transform;
            
            resultTransform.localScale = Vector3.one;
            resultTransform.parent = parent;
            resultTransform.position = position;
            
            return result;
            
            GameObject Spawn()
            {
                var obj = Object.Instantiate(_prefab, position, rotation, parent);
                var poolMember = obj.AddComponent<PoolMember>();
                poolMember.pool = this;
                return obj;
            }
        }

        public void Return(GameObject obj)
        {
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}