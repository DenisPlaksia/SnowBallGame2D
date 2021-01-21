using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Enemy : MonoBehaviour
{
    [SerializeField] private State StartState;
    [SerializeField] private State EnemyShootingState;
    [SerializeField] private State WalkState;
    [SerializeField] private State StayState;

    [Header("Actual state")]
    [SerializeField] private State currentStatePattern;


    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, run;
    public string currentState;
    private string currentAnimation;

    private void Start()
    {
        SetState(StartState);
        StartCoroutine(TimeToStop());
    }

    private void Update()
    {
        if (!currentStatePattern.IsFinished)
        {
            currentStatePattern.Run();
        }
    }

    public void SetState(State state)
    {

        currentStatePattern = state;
        currentStatePattern.unit = this;
        currentStatePattern.Init();
    }

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if (animation.name.Equals(currentAnimation))
        {
            return;
        }
        skeletonAnimation.state.SetAnimation(0, animation, loop).timeScale = timeScale;
        currentAnimation = animation.name;
    }

    public void SetCharackterState(string state)
    {
        if (state.Equals("Idle"))
        {
            SetAnimation(idle, true, 1f);
        }
        else if (state.Equals("Walking"))
        {
            SetAnimation(run, true, 1f);
        }
    }

    private IEnumerator TimeToStop()
    {
        Debug.Log("Curotina");
        SetState(StayState);
        yield return new WaitForSeconds(2f);
        SetState(WalkState);

        yield return new WaitForSeconds(4f);
        StartCoroutine(TimeToStop());
    }
}
