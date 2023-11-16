using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public float targetTime = 30f;

    [SerializeField] float speed = 14f;

    [SerializeField] GameObject power;
    bool powerexists = false;

    public string sceneToLoad;

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

        targetTime -= Time.deltaTime;
        
        if (targetTime <= 0)
        {
            ToggleScene();
        }

        if (targetTime < 20 && !powerexists)
        {
            Instantiate(power);
            powerexists = true; 
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = rigidbody2d.position;
        pos.x += speed * horizontal * Time.deltaTime;
        pos.y += speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(pos);
    }

    void ToggleScene()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        SceneManager.LoadScene(sceneToLoad);

        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player != null)
        {
            player.transform.position = playerPosition;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
        } 
        else if (collision.gameObject.CompareTag("GreenBall"))
        {
            ScoreManager.Instance.IncreasePoints();
        }
    }
}
