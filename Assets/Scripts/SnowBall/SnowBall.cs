using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public Player player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.gameObject.GetComponent<Enemy>();
        if (collisionObject != null && player != null)
        {

            player.AddScore(collisionObject.GetScore());
            collisionObject.enemyBehaviour.BulletCollision();
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
