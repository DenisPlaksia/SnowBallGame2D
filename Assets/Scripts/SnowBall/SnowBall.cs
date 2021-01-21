using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public Player player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBehaviour>() != null && player != null)
        {

            player.AddScore(collision.gameObject.GetComponent<EnemyBehaviour>().score);
            collision.gameObject.GetComponent<EnemyBehaviour>().BulletCollision();
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
