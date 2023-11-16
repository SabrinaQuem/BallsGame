using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BolaVerde : MonoBehaviour
{

    [SerializeField] float speed = 6f;

    private Vector2 direction;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 newPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-4f, 4f));
            transform.position = newPosition;

            Camera mainCamera = Camera.main;
            mainCamera.backgroundColor = Random.ColorHSV();


            ManagerRedBalls.instance.SpawnObject();
        }
        else if (collision.gameObject.CompareTag("Walls"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
        else if (collision.gameObject.CompareTag("Balls"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
        
    }

}
