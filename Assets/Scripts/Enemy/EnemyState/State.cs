﻿using UnityEngine;

public abstract class State : ScriptableObject
{
    public bool IsFinished { get; protected set; }
    [HideInInspector] public Enemy unit;
    public virtual void Init() { }
    public abstract void Run();

    public virtual void Stop() { }
}
