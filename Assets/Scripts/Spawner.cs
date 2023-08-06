using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace Code
{
    public class Spawner : MonoBehaviour
    {
        // [SerializeField] private Button _spawnButton;
        [SerializeField] private MyObject _prefab;
        private MyObjectPool _pool;
        private MyObjectPool _pool2;
        private static MyObject myObject;

        private Enemy suPos;

        private void Awake()
        {
            _pool = new MyObjectPool(_prefab);

            Spawn();

        }

        private void Spawn()
        {

            myObject = _pool.Spawn<MyObject>();

            Debug.Log(myObject.transform.position);




        }
    }
}
