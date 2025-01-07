using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinX, spinY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinX * Time.deltaTime, spinY * Time.deltaTime, 0);
    }
}
