using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BolaVermelha : MonoBehaviour
{
    [SerializeField] float speed = 6f;

    Rigidbody2D rb;

    private Vector2 direction;

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
            Destroy(collision.gameObject);
        }
        else
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
    }



}
