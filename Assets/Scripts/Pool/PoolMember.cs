using UnityEngine;

namespace Pool
{
    internal class PoolMember : MonoBehaviour
    {
        public Pool pool;

        public void Return()
        {
            pool.Return(gameObject);
        }
    }
}