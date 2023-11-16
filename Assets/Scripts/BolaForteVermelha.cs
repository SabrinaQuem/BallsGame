using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaForteVermelha : ManagerRedBalls   
{

     public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision); // Call the base class method

        if (collision.gameObject.CompareTag("Walls"))
        {
            Vector2 playerPosition = player.transform.position;
            direction = (playerPosition - (Vector2)transform.position).normalized;
        }
    }


}
