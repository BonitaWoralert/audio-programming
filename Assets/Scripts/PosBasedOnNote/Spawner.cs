using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float queueTime = 1.5f;
    private float time = 0;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float height;

    // Update is called once per frame
    void Update()
    {
        if (time > queueTime)
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            time = 0;
            Destroy(go, 15);
        }
        time += Time.deltaTime;
    }
}
