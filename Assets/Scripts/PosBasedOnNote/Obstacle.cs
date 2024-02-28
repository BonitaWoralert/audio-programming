using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float speed = 4f;

    // Update is called once per frame
    void Update()
    {
        transform.position += ((Vector3.left * speed) * Time.deltaTime);
    }
}
