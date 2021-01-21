using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private ForceShowUI uI;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}
