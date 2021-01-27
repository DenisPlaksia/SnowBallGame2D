using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContorller : MonoBehaviour
{
    [SerializeField] private VariableJoystick _variableJoystick;
    [SerializeField] private Button _shootButton;
    [SerializeField] private GameObject _snowBall;
    [SerializeField] private GameObject _spanwPoint;
    [SerializeField] private float _timeBetweenAttack = 1.5f;

    private ForceShowUI _forceForBullet;
    private string _currentAnimation;
    private float _movement;
    private Vector2 _direction;
    private bool _canAttack = false;

    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, run;
    public string currentState;
    public float speed;

    private void Start()
    {
        _forceForBullet = FindObjectOfType<ForceShowUI>();
        _forceForBullet.OnSnowPush += Shoot;
        currentState = "Idle";
        SetCharackterState(currentState);
    }

    private void Update()
    {
        Movement();
    }

    private void Shoot(float force)
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();

        if (bullet != null && !_canAttack)
        {
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().isKinematic = false;
            bullet.GetComponent<SnowBall>().player = gameObject.GetComponent<Player>();
            bullet.transform.position = _spanwPoint.transform.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * (force * 100));
            _canAttack = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttack);
        }
    }

    private void Movement()
    {
        _movement = _variableJoystick.Direction.y;
        _direction = new Vector2(0f, _movement);
        if (_movement != 0)
        {
            // -2.1f its up border for player
            if (transform.position.y <= -2.1f )
            {
                Move(_direction);
                SetCharackterState("Walking");
            }
            else
            {
                Vector2 newPosition = new Vector2(transform.position.x, -2.1f);
                transform.position = newPosition;
            }

            // -4.5f its up border for player
            if (transform.position.y >= -4.5f)
            {
                Move(_direction);
                SetCharackterState("Walking");
            }
            else
            {
                Vector2 newPosition = new Vector2(transform.position.x, -4.5f);
                transform.position = newPosition;
            }
        }
        else
        {
            SetCharackterState("Idle");
        }
    }

    private void ResetAttack() => _canAttack = false;
    private void Move(Vector2 vector) => transform.Translate(vector * speed * Time.deltaTime);

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if(animation.name.Equals(_currentAnimation))
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
        else if(state.Equals("Walking"))
        {
            SetAnimation(run, true, 1f);
        }
    }
}
