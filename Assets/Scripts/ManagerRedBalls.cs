using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ManagerRedBalls : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed = 6f;

    public static ManagerRedBalls instance; //pode ser chamado por todos enquanto estiver na cena

    protected Vector2 direction;

    [SerializeField] public GameObject player;

    GameObject BolaAdicionada;
    [SerializeField] GameObject RedSpawn;
    [SerializeField] GameObject RedSpawn2;
    private float RedSpawnRangeX = 10f;
    private float RedSpawnRangeY = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        direction = Random.insideUnitCircle.normalized;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;
    }

    void Awake()
    {
        // Ensure there is only one instance of ManagerRedBalls
        if (instance == null)
        {
            instance = this;
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.ResetScore();
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Menu");
        }
        else if (collision.gameObject.CompareTag("Balls") && collision.gameObject.CompareTag("GreenBall"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
    }


    public void SpawnObject()
    {
        int randomSpawn = Random.Range(0, 2);

        float randomX = Random.Range(-RedSpawnRangeX, RedSpawnRangeX);
        float randomY = Random.Range(-RedSpawnRangeY, RedSpawnRangeY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        if (randomSpawn == 0)
        {
            BolaAdicionada = Instantiate(RedSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            BolaAdicionada = Instantiate(RedSpawn2, spawnPosition, Quaternion.identity);
        }

    }

}

