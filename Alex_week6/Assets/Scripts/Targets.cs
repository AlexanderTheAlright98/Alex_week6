using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Targets : MonoBehaviour
{
    Rigidbody targetRb;

    public float xRange = 4.49f;
    public Vector2 randomForce, randomTorque;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(Vector3.up * Random.Range(randomForce.x, randomForce.y), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xRange, xRange), -1, 0);
    }
    void OnMouseDown()
    {
        if (gameObject.CompareTag("Good")) 
        {
            FindFirstObjectByType<GameManager>().score++;
            Destroy(gameObject);
        }

        else if (gameObject.CompareTag("Bad"))
        {
            FindFirstObjectByType<GameManager>().lives--;
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
