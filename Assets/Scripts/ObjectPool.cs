using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ObjectPool
{
    private readonly RecyclableObject _prefab;
    private readonly HashSet<RecyclableObject> _instantiateObjects;

    private Queue<RecyclableObject> _recycledObjects;

    public ObjectPool(RecyclableObject prefab)
    {
        _prefab = prefab;
        _instantiateObjects = new HashSet<RecyclableObject>();
    }

    public void Init(int numberOfInitialObjects)
    {
        _recycledObjects = new Queue<RecyclableObject>(numberOfInitialObjects);

        for (var i = 0; i < numberOfInitialObjects; i++)
        {
            var instance = IntantiateNewInstance();
            instance.gameObject.SetActive(false);
            _recycledObjects.Enqueue(instance);
        }

    }

    private RecyclableObject IntantiateNewInstance()
    {
        var instance = Object.Instantiate(_prefab);
        instance.Configure(this);
        return instance;

    }

    public T Spawn<T>()
    {
        var recycledObjects = GetInstance();
        _instantiateObjects.Add(recycledObjects);
        recycledObjects.gameObject.SetActive(true);
        recycledObjects.Init();
        return recycledObjects.GetComponent<T>();

    }

    private RecyclableObject GetInstance()
    {
        if (_recycledObjects.Count > 0)
        {
            return _recycledObjects.Dequeue();
        }
        //Debug.LogWarning();
        var instance = IntantiateNewInstance();
        return instance;

    }
    public void RecycleGameObject(RecyclableObject gameObjectToRecycle)
    {
        var wasIstantiated = _instantiateObjects.Remove(gameObjectToRecycle);
        Assert.IsTrue(wasIstantiated, $"{gameObjectToRecycle.name}was not instantiate ");

        gameObjectToRecycle.gameObject.SetActive(false);
        gameObjectToRecycle.Release();
        _recycledObjects.Enqueue(gameObjectToRecycle);
    }




}
