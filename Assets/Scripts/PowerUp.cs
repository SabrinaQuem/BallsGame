using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float powerUpDuration = 10f;
    [SerializeField] float scaleFactor = 0.5f;

    private bool isActivated = false;
    Rigidbody2D rb;

    private Dictionary<GameObject, Vector3> originalScales = new Dictionary<GameObject, Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActivated)
        {
            Destroy(gameObject);
            isActivated = true;
            PowerUpAtive();
        }
    }

    void PowerUpAtive()
    {
        ScaleDownGameObjectWithTag("Balls");

        StartCoroutine(ReactivatePowerUp());
    }

    void ScaleDownGameObjectWithTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {
            originalScales[obj] = obj.transform.localScale;

            obj.transform.localScale *= scaleFactor;

        }
    }

    void ScaleUpGameObjectWithTag(string tag)
    {
        Debug.Log("ScaleUp started");
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {
            if (originalScales.TryGetValue(obj, out Vector3 originalScale))
            {
                obj.transform.localScale = originalScale;
            }
        }

        originalScales.Clear(); // Clear the dictionary after scaling up all objects.
    }

    IEnumerator ReactivatePowerUp()
    {
        Debug.Log("ReactivatePowerUp coroutine started");
        float timer = 0f;

        while (timer < powerUpDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        ScaleUpGameObjectWithTag("Balls");
        isActivated = false;
    }
}
