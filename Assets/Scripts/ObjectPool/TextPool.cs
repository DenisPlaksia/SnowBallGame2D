using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPool : MonoBehaviour
{
    public static TextPool SharedInstance;
    public List<TextMeshProUGUI> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public Transform _parent;
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
            tmp = Instantiate(objectToPool, _parent).GetComponent<TextMeshProUGUI>();
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
