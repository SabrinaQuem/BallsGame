using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine.UI;
using UnityEngine;

public class BolaVerde : MonoBehaviour
{

    [SerializeField] float speed = 6f;

    [SerializeField] GameObject RedSpawn;
    [SerializeField] GameObject RedSpawn2;
    private float RedSpawnRangeX = 10f;
    private float RedSpawnRangeY = 4f;

    private Vector2 direction;

    Rigidbody2D rb;

    [SerializeField] private int points = 0;
    [SerializeField] private Text pointsText;

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

            SpawnObject();

           points += 1;
           pointsText.text = points.ToString();

        }
        else
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
    }

    private void SpawnObject()
    {
        int randomSpawn = Random.Range(0, 2);

        if (randomSpawn == 0)
        {
            float randomX = Random.Range(-RedSpawnRangeX, RedSpawnRangeX);
            float randomY = Random.Range(-RedSpawnRangeY, RedSpawnRangeY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            Instantiate(RedSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            float randomX = Random.Range(-RedSpawnRangeX, RedSpawnRangeX);
            float randomY = Random.Range(-RedSpawnRangeY, RedSpawnRangeY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            Instantiate(RedSpawn2, spawnPosition, Quaternion.identity);
        }
        

    }

}
