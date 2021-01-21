using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContorller : MonoBehaviour
{
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private Button _shootButton;
    [SerializeField] private GameObject _snowBall;
    [SerializeField] private GameObject _spanwPoint;
    private ForceShowUI uI;

    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, run;
    public string currentState;
    private string currentAnimation;

    private float movement;
    private Vector2 direction;
    public float speed;

    private void Start()
    {
        uI = FindObjectOfType<ForceShowUI>();
        uI.OnSnowPush += Shoot;
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

        if(bullet != null)
        {
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().isKinematic = false;
            bullet.transform.position = _spanwPoint.transform.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 500f);
        }
    }

    // CHANGE IF STATEMENT!!!!
    private void Movement()
    {
        movement = variableJoystick.Direction.y;
        direction = new Vector2(0f, movement);
        if (movement != 0)
        {
            if(transform.position.y <= -2.1f )
            {
                Move(direction);
                SetCharackterState("Walking");
            }
            else
            {
                Vector2 newPosition = new Vector2(transform.position.x, -2.1f);
                transform.position = newPosition;
            }

            if(transform.position.y >= -4.5f)
            {
                Move(direction);
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


    private void Move(Vector2 vector)
    {
        transform.Translate(vector * speed * Time.deltaTime);
    }


    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if(animation.name.Equals(currentAnimation))
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
        else if(state.Equals("Walking"))
        {
            SetAnimation(run, true, 1f);
        }
    }
}
