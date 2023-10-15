using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public object image;
    public float velocity;
    public Transform destiny;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ParallaxImages();
    }

    public void ParallaxImages()
    {
        Vector3 position = transform.position;
        position.x -= velocity * Time.deltaTime;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parallax"))
        {
            transform.position = new Vector3(destiny.transform.position.x, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Parallax"))
        {
            transform.position = new Vector3(destiny.transform.position.x, transform.position.y);
        }
    }
}
