using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnowBall : MonoBehaviour
{
    public Player player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.gameObject.GetComponent<Enemy>();
        if (collisionObject != null && player != null)
        {
            TextMeshProUGUI text = FlyTextPool.SharedInstance.GetPooledObject();
            if(text != null)
            {
                text.gameObject.SetActive(true);
                text.GetComponent<FlyText>().PlayAnimation();
            }
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
