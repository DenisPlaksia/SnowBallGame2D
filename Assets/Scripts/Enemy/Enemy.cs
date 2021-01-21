using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    [SerializeField] private EnemyBehaviour enemyBehaviour;
    private void Awake()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        SetSkin(_enemyData.skin);
        SetTimeAttack(_enemyData.timeAttack);
    }

    public void ChnageEnemyData(EnemyData enemyData)
    {
        _enemyData = enemyData;
        SetTimeAttack(_enemyData.timeAttack);
        SetSkin(_enemyData.skin);
    }

    public void SetTimeAttack(float time)
    {
        enemyBehaviour.TimeAttack = time;
    }

    public void SetSkin(string skinName)
    {
        skeletonAnimation.skeleton.SetSkin(skinName);
    }
}
