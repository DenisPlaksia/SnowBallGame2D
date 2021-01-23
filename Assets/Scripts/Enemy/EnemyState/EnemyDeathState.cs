using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyDeathState : State
{
    Vector2 point;
    Vector2 lastPosition;
    bool check = true;
    public State EnemyWalkState;
    public override void Init()
    {
        lastPosition = unit.transform.position;
        point = new Vector2(15f, unit.transform.position.y);
        Flip();
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }

        if(check)
        {
            MoveTo();
        }
        else
        {
            RemoveToBack();
        }
    }

    private void MoveTo()
    {
        Debug.Log($"MMove {point} + {unit.gameObject.name}");
        unit.SetCharackterState("Walking");
        unit.transform.position = Vector2.MoveTowards(unit.transform.position, point, 2f * Time.deltaTime);

        if (unit.transform.position.x == point.x)
        {

            check = false;
            Flip();
            unit.GetComponent<Enemy>().ChnageEnemyData(EnemyDataContainer.Singleton.GetEnemyData(Random.Range(0, EnemyDataContainer.Singleton.enemyDatas.Count)));
        }
    }

    public void RemoveToBack()
    {
        unit.SetCharackterState("Walking");
        unit.transform.position = Vector2.MoveTowards(unit.transform.position, lastPosition, 2f * Time.deltaTime);
        if (unit.transform.position.x == lastPosition.x)
        {

            Stop();
        }
    }

    private void Flip()
    {
        Vector3 Scaler = unit.transform.localScale;
        Scaler.x *= -1;
        unit.transform.localScale = Scaler;
    }

    public override void Stop()
    {
        IsFinished = true;
        unit.SetCharackterState("Idle");
        unit.StartCor();
    }
}
