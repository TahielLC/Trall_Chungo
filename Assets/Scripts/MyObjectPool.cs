using UnityEngine;
using UnityEngine.Pool;

namespace Code
{
    public class MyObjectPool
    {
        private readonly RecyclableObject _prefab;
        private readonly IObjectPool<RecyclableObject> _pool;
        [SerializeField] float equis = 2f;
        PlayerController player;
        public RecyclableObject myObject;
        public MyObjectPool(RecyclableObject prefab)
        {
            _prefab = prefab;
            _pool = new ObjectPool<RecyclableObject>(CreateFunc,
                                                     OnTakeFromPool,
                                                     OnReturnedToPool);
        }

        public RecyclableObject CreateFunc()
        {


            for (int i = 0; i < 2; i++)
            {
                myObject = Object.Instantiate(_prefab, new Vector3(equis, 2, 0), Quaternion.identity);
                equis += 2;
            }
            // myObject = Object.Instantiate(_prefab, new Vector3(equis, 2, 0), Quaternion.identity);


            myObject.Configure(_pool);
            return myObject;
        }

        private void OnTakeFromPool(RecyclableObject myObject)
        {
            myObject.gameObject.SetActive(true);
            myObject.Init();
        }

        private void OnReturnedToPool(RecyclableObject myObject)
        {
            myObject.Release();
            myObject.gameObject.SetActive(true);
        }

        public TComponent Spawn<TComponent>()
        {
            var recyclableObject = _pool.Get();
            //recyclableObject.transform.position += new Vector3(2, 2, 0);
            return recyclableObject.GetComponent<TComponent>();
        }
    }
}
