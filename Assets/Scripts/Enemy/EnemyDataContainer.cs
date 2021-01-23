using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataContainer : MonoBehaviour
{
    public List<EnemyData> enemyDatas = new List<EnemyData>();
    public static EnemyDataContainer Singleton { get; set; }

    public void Awake()
    {
        Singleton = this;
    }
    public EnemyData GetEnemyData(int value)
    {
        return enemyDatas[value];
    }
}
