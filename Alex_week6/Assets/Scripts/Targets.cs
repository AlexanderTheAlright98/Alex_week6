using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Targets : MonoBehaviour
{
    Rigidbody targetRb;

    public float xRange = 4.49f;
    public float despawnYRange = -1.85f;
    public int targetValue;
    public Vector2 randomForce, randomTorque;
    public ParticleSystem targetExplosion;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(Vector3.up * Random.Range(randomForce.x, randomForce.y), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xRange, xRange), -1, 0);
    }
    void Update()
    {
        if (transform.position.y < despawnYRange)
        {
            if (gameObject.CompareTag("Good"))
            {
                FindFirstObjectByType<GameManager>().updateScore(-1);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (FindFirstObjectByType<GameManager>().isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        FindFirstObjectByType<GameManager>().updateScore(targetValue);
        Destroy(Instantiate(targetExplosion, transform.position, targetExplosion.transform.rotation), 2);

        if (gameObject.CompareTag("Bad")) 
        {
            FindFirstObjectByType<GameManager>().updateLives(-1);
            FindFirstObjectByType<GameManager>().badSound();
            Destroy(gameObject);
        }
        else
        {
            FindFirstObjectByType<GameManager>().goodSound();
            Destroy(gameObject);
        }

    }
}
