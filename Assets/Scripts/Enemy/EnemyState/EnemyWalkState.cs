using UnityEngine;

[CreateAssetMenu]
public class EnemyWalkState : State
{
    Vector2 point;
    public override void Init()
    {
        FindPoint();
    }

    private void FindPoint() => point = new Vector2(unit.transform.position.x, Random.Range(-2.1f ,- 4.5f));
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
        Debug.Log($"MMove {point} + {unit.gameObject.name}");
        unit.SetCharackterState("Walking");
        unit.transform.position = Vector2.MoveTowards(unit.transform.position, point, 0.5f * Time.deltaTime);
        if(unit.transform.position.y == point.y)
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
