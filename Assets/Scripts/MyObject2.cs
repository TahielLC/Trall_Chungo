using UnityEngine;
using UnityEngine.Pool;

namespace Code
{
    public class MyObject2 : MonoBehaviour
    {
        private IObjectPool<MyObject2> _pool;
        public void Release()
        {

        }

        public void Init()
        {
            Invoke(nameof(Recycle), 20);
        }

        public void Configure(IObjectPool<MyObject2> pool)
        {
            _pool = pool;
        }

        public void Recycle()
        {
            _pool.Release(this);
        }

    }
}
