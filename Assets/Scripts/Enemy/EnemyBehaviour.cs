using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private State _StartState;
    [SerializeField] private State _EnemyShootingState;
    [SerializeField] private State _WalkState;
    [SerializeField] private State _StayState;
    [SerializeField] private State _EnemyDathState;

    [Header("Actual state")]
    [SerializeField] private State _currentStatePattern;

    private Rigidbody2D _rigidbody2D;
    private string _currentAnimation;


    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, run;
    public GameObject _spanwPoint;
    public string currentState;
    public int score;
    public float timeAttack;
    public float speedMovement = 0.5f;

    private void Start()
    {
        SetState(_StartState);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCor();
    }

    private void Update()
    {
        if (!_currentStatePattern.IsFinished)
        {
            _currentStatePattern.Run();
        }
    }

    public void SetState(State state)
    {

        _currentStatePattern = Instantiate(state);
        _currentStatePattern.unit = this;
        _currentStatePattern.Init();
    }

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if (animation.name.Equals(_currentAnimation))
        {
            return;
        }
        skeletonAnimation.state.SetAnimation(0, animation, loop).timeScale = timeScale;
        _currentAnimation = animation.name;
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
        SetState(_StayState);
        _rigidbody2D.simulated = true;
        yield return new WaitForSeconds(2f);
        SetState(_WalkState);
        yield return new WaitForSeconds(timeAttack);
        SetState(_EnemyShootingState);
        
        StartCoroutine(TimeToStop());
    }

    public void BulletCollision()
    {
        StopAllCoroutines();
        _rigidbody2D.simulated = false;
        SetState(_EnemyDathState);
    }
}
