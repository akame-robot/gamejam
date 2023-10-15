using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Random.Range(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-velocity * Time.deltaTime, 0, 0);
        Destroy(gameObject, 5);
    }
}
