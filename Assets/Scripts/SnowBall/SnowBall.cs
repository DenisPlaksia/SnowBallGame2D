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
            var text = FlyTextPool.SharedInstance.GetPooledObject();
            if (text != null)
            {
                text.gameObject.SetActive(true);
                text.GetComponent<FlyText>().PlayAnimation();
            }
            player.Score = collisionObjectEnemy.GetScore();
            collisionObjectEnemy.enemyBehaviour.BulletCollision();
            OffBall();
        }
        else if (collisionObjectPlayer != null)
        {
            // if enemy hit player we remove 1 point of health
            collisionObjectPlayer.HealthChange(1);
            OffBall();
        }
        else
        {
            OffBall();
        }
    }

    private void OffBall() => gameObject.SetActive(false);
}
