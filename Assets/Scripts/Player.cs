using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    [SerializeField] float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 pos = rigidbody2d.position;
        pos.x += speed * horizontal * Time.deltaTime;
        pos.y += speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(pos);
    }
}
