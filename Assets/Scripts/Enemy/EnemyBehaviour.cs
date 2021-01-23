using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class EnemyBehaviour : MonoBehaviour, IBulletCollision
{
    [SerializeField] private State StartState;
    [SerializeField] private State EnemyShootingState;
    [SerializeField] private State WalkState;
    [SerializeField] private State StayState;
    [SerializeField] private State EnemyDathState;

    [Header("Actual state")]
    [SerializeField] private State currentStatePattern;


    private Rigidbody2D rigidbody2D;

    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, run;
    public string currentState;
    private string currentAnimation;
    public int score;
    public GameObject _spanwPoint;
    public float TimeAttack;
    public float speedMovement = 0.5f;
    private void Start()
    {
        SetState(StartState);
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCor();
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

        currentStatePattern = Instantiate(state);
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

    public void StartCor() => StartCoroutine(TimeToStop());

    private IEnumerator TimeToStop()
    {
        Debug.Log("Curotina");
        SetState(StayState);
        rigidbody2D.simulated = true;
        yield return new WaitForSeconds(2f);
        SetState(WalkState);
        yield return new WaitForSeconds(TimeAttack);
        SetState(EnemyShootingState);
        
        StartCoroutine(TimeToStop());
    }

    public void BulletCollision()
    {
        StopAllCoroutines();
        rigidbody2D.simulated = false;
        SetState(EnemyDathState);
    }
}
