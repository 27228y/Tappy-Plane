using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5;
    public float offsetX = 1;
    public float offsetY = 2;

    void Start()
    {
        Vector3 pos = new();
        pos.x = Random.Range(-offsetX, offsetX);
        pos.y = Random.Range(-offsetY, offsetY);

        transform.position += pos;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
