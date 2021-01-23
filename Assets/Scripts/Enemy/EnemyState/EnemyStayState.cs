using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStayState : State
{

    public override void Init()
    {
        unit.SetCharackterState("Idle");
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }
    }

    public override void Stop()
    {
        IsFinished = true;
        unit.SetCharackterState("Walking");
    }
}
