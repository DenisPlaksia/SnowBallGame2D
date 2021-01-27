using UnityEngine;

[CreateAssetMenu]
public class EnemyWalkState : State
{
    private Vector2 _point;
    public override void Init()
    {
        FindPoint();
    }


    // -2.1f min and -4.5f max position y for enemy movement
    private void FindPoint() => _point = new Vector2(unit.transform.position.x, Random.Range(-2.1f ,- 4.5f));
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }
        MoveTo();
    }

    private void MoveTo()
    {
        unit.SetCharackterState("Walking");
        unit.transform.position = Vector2.MoveTowards(unit.transform.position, _point, unit.speedMovement * Time.deltaTime);
        if(unit.transform.position.y == _point.y)
        {
            FindPoint();
        }
    }

    public override void Stop()
    {
        IsFinished = true;
        unit.SetCharackterState("Idle");
    }
}
