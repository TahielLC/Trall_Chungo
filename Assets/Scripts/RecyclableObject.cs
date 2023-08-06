using UnityEngine;
using UnityEngine.Pool;

namespace Code
{
    public abstract class RecyclableObject : MonoBehaviour
    {
        private IObjectPool<RecyclableObject> _objectPool;

        internal void Configure(IObjectPool<RecyclableObject> objectPool)
        {
            _objectPool = objectPool;
        }

        public void Recycle()
        {
            _objectPool.Release(this);
        }
        internal abstract void Init();
        internal abstract void Release();
    }
}
