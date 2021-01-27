using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyTextPool : MonoBehaviour
{
    public static FlyTextPool SharedInstance;
    public List<TextMeshProUGUI> pooledObjects;
    public TextMeshProUGUI objectToPool;
    public int amountToPool;
    public Transform parentForText;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<TextMeshProUGUI>();
        TextMeshProUGUI tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, parentForText).GetComponent<TextMeshProUGUI>();
            tmp.gameObject.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public TextMeshProUGUI GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
