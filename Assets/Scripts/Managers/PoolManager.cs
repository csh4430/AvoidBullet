using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PoolManager : Manager
{
    private readonly Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    
    public void CreatePool(GameObject prefab, int poolSize)
    {
        var poolKey = prefab.name;

        if (poolDictionary.ContainsKey(poolKey) is false)
            poolDictionary.Add(poolKey, new Queue<GameObject>());
    
        for (var i = 0; i < poolSize; i++)
        {
            var obj = GameObject.Instantiate(prefab);
            obj.name = poolKey;
            obj.SetActive(false);
            poolDictionary[poolKey].Enqueue(obj);
        }
    }
    
    public GameObject ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        var poolKey = prefab.name;
        
        if (poolDictionary.ContainsKey(poolKey))
        {
            if (poolDictionary[poolKey].Count <= 0)
            {
                CreatePool(prefab, 5);
            }
            var objectToReuse = poolDictionary[poolKey].Dequeue();
            objectToReuse.SetActive(true);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;
            objectToReuse.name = poolKey;
            return objectToReuse;
        }
        else
        {
            return null;
        }
    }
    
    public GameObject ReuseObject(GameObject prefab, Vector3 position)
    {
        return ReuseObject(prefab, position, Quaternion.identity);
    }
    
    public GameObject ReuseObject(GameObject prefab)
    {
        return ReuseObject(prefab, Vector3.zero, Quaternion.identity);
    }
    
    public GameObject ReuseObject(GameObject prefab, Transform parent)
    {
        var obj = ReuseObject(prefab, parent.position, parent.rotation);
        obj.transform.SetParent(parent);
        return obj;
    }
    
    public void EnqueueObject(GameObject obj)
    {
        var poolKey = obj.name;
        if (poolDictionary.ContainsKey(poolKey))
        {
            obj.SetActive(false);
            poolDictionary[poolKey].Enqueue(obj);
        }
    }
    
    public void DestroyPool(GameObject prefab)
    {
        var poolKey = prefab.name;

        if (!poolDictionary.ContainsKey(poolKey)) return;
        while (poolDictionary[poolKey].Count > 0)
        {
            var obj = poolDictionary[poolKey].Dequeue();
            GameObject.Destroy(obj);
        }
    
        poolDictionary.Remove(poolKey);
    }
}
