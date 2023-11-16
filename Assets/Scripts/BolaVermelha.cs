using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaVermelha : ManagerRedBalls
{

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision); // Call the base class method

        if (collision.gameObject.CompareTag("Walls"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
    }


}
