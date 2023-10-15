using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerVelocity, jumpForce;
    private Rigidbody2D rb;
    public GameObject player;
    private bool isGround = true;
    public GameObject windSuck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        windSuck.gameObject.SetActive(true); //quando for continuar o game coloca aqui como false e volta a enternder e achar a logica do inimigo 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Translate(new Vector2(-1, 0) * playerVelocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Translate(new Vector2(1, 0) * playerVelocity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            isGround = false;
        }

        if (transform.position.x <= -8.383f)
        {
            transform.position = new Vector2(-8.383f, transform.position.y);
        }
        if (transform.position.x >= 8.405f)
        {
            transform.position = new Vector2(8.405f, transform.position.y);
        }

        //if ((Input.GetKey(KeyCode.Space)))
        //{
        //    windSuck.gameObject.SetActive(true);
        //}
        //else if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    windSuck.gameObject.SetActive(false);
        //}

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
