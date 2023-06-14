using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consumer : MonoBehaviour
{
    [SerializeField] private Button _spawnButoon;
    [SerializeField] private MyObject _prefab;
    private ObjectPool _objectPool;

    private void Awake()
    {
        _objectPool = new ObjectPool(_prefab);
        _objectPool.Init(10);
        _spawnButoon.onClick.AddListener(Spawn);
    }
    private void Spawn()
    {
       var myObject = _objectPool.Spawn<MyObject>();
    }



}
