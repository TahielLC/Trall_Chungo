using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Consumer : MonoBehaviour
{
    //[SerializeField] private Button _spawnButton;
    [SerializeField] private Enemy _prefab;
    private ObjectPool _objectPool;

    private void Awake()
    {
        _objectPool = new ObjectPool(_prefab);
        _objectPool.Init(5);

        //_spawnButton.onClick.AddListener(Spawn);
    }

    private void Spawn()
    {
        var myObject = _objectPool.Spawn<Enemy>();
    }
    private void Start()
    {
        Spawn();
    }
}
