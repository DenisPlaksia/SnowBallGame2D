using UnityEngine;

[CreateAssetMenu]
public class EnemyDeathState : State
{
    private Vector2 _point;
    private Vector2 _lastPosition;
    private bool _check = true;
    public State EnemyWalkState;
    public override void Init()
    {
        _lastPosition = unit.transform.position;

        //15f position x where should go enemy after "death";
        _point = new Vector2(15f, unit.transform.position.y);
        Flip();
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }

        if(_check)
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
        unit.SetCharackterState("Walking");
        unit.transform.position = Vector2.MoveTowards(unit.transform.position, _point, 2f * Time.deltaTime);

        if (unit.transform.position.x == _point.x)
        {
            _check = false;
            Flip();
            unit.GetComponent<Enemy>().ChnageEnemyData(EnemyDataContainer.Singleton.GetEnemyData(Random.Range(0, EnemyDataContainer.Singleton.enemyDatas.Count)));
        }
    }

    public void RemoveToBack()
    {
        unit.SetCharackterState("Walking");
        unit.transform.position = Vector2.MoveTowards(unit.transform.position, _lastPosition, 2f * Time.deltaTime);
        if (unit.transform.position.x == _lastPosition.x)
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
