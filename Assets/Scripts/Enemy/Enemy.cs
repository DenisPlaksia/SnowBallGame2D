using UnityEngine;
using Spine.Unity;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private SkeletonAnimation _skeletonAnimation;
    public EnemyBehaviour enemyBehaviour { get; private set; }
    private void Awake()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        SetSkin(_enemyData.skin);
        SetTimeAttack(_enemyData.timeAttack);
    }

    public int GetScore() => _enemyData.score;

    public void ChnageEnemyData(EnemyData enemyData)
    {
        _enemyData = enemyData;
        SetTimeAttack(_enemyData.timeAttack);
        SetSkin(_enemyData.skin);
    }

    public void SetTimeAttack(float time)
    {
        enemyBehaviour.timeAttack = time;
    }

    public void SetSkin(string skinName)
    {
        _skeletonAnimation.Skeleton.SetSkin(skinName);
    }
}
