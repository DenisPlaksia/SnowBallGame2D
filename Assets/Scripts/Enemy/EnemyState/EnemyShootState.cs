using UnityEngine;

[CreateAssetMenu]
public class EnemyShootState : State
{
    public override void Init()
    {
        Shoot();
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }        
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();

        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().isKinematic = false;
            bullet.GetComponent<SnowBall>().player = null;
            bullet.transform.position = unit._spanwPoint.transform.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 250f);
        }
    }

    public override void Stop()
    {
        IsFinished = true;
        unit.SetCharackterState("Idle");
    }
}
