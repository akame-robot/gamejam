using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float enemyVelocity;
    public GameObject windOn;
    private Player windControll;
    public GameObject enemySpot;
    public bool onCamera = false;
    public bool stickOn = false;
    public bool moveToSpot = true;

    // Start is called before the first frame update
    void Start()
    {
        windControll = GetComponent<Player>();
        windOn = GameObject.Find("sugador");
        
    }

    // Update is called once per frame
    void Update()
    {
        GhostSuck();
    }

    public void GhostSuck()
    {
        
        if (moveToSpot)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemySpot.transform.position, enemyVelocity * Time.deltaTime);
        }
        if (onCamera && windOn != null && windOn.gameObject.activeSelf == true)
        {
            stickOn = true;
            if (stickOn)
            {
                moveToSpot = false;
                transform.position = Vector2.MoveTowards(transform.position, windOn.transform.position, enemyVelocity * Time.deltaTime);
            }
            else
            {
                stickOn = false;
                moveToSpot = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("OnCamera"))
        {
            Debug.Log("entrei aqui");
            onCamera = true;
        }
    }

}

//    if (windLocal.gameObject.activeSelf == true)
//    {
//        isGoingToWindLocal = true;
//    }

//if (isGoingToWindLocal)
//{
//    // Movimentar o inimigo em direção a windLocal
//    transform.position = Vector2.MoveTowards(transform.position, windLocal.transform.position, enemyVelocity * Time.deltaTime);

//    // Verificar se chegou em windLocal
//    if (Vector2.Distance(transform.position, windLocal.transform.position) < 0.1f)
//    {
//        isGoingToWindLocal = false;
//    }
//}
//else
//{
//    // Movimentar o inimigo de volta para enemySpot
//    transform.position = Vector2.MoveTowards(transform.position, enemySpot.position, enemyVelocity * Time.deltaTime);

//    // Verificar se chegou em enemySpot
//    if (Vector2.Distance(transform.position, enemySpot.position) < 0.1f)
//    {
//        isGoingToWindLocal = true;
//    }
//}


