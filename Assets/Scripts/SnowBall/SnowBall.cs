using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnowBall : MonoBehaviour
{
    public Player player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObjectEnemy = collision.gameObject.GetComponent<Enemy>();
        var collisionObjectPlayer = collision.gameObject.GetComponent<Player>();
        if (collisionObjectEnemy != null && player != null)
        {
            TextMeshProUGUI text = FlyTextPool.SharedInstance.GetPooledObject();
            if(text != null)
            {
                text.gameObject.SetActive(true);
                text.GetComponent<FlyText>().PlayAnimation();
            }
            player.AddScore(collisionObjectEnemy.GetScore());
            collisionObjectEnemy.enemyBehaviour.BulletCollision();
            gameObject.SetActive(false);
        }
        else if(collisionObjectPlayer != null)
        {
            collisionObjectPlayer.HealthChange(1);
            gameObject.SetActive(false);
        }
    }
}
