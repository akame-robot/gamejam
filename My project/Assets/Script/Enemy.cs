using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemyVelocity;
    public GameObject windLocal;
    public GameObject enemySpot;
    public bool onCamera = true;
    public bool stickOn = true;

    // Start is called before the first frame update
    void Start()
    {
        onCamera = false;
        stickOn = false;
        windLocal = GameObject.Find("sugador");
    }

    // Update is called once per frame
    void Update()
    {
        GhostSuck();
    }

    public void GhostSuck()
    {

        if (enemySpot.gameObject.activeSelf == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemySpot.transform.position, enemyVelocity * Time.deltaTime);
        }
        if (windLocal.gameObject.activeSelf == true && onCamera == true)
        {
            stickOn = true;
        }
        if (stickOn)
        {
            enemySpot.gameObject.SetActive(false);
            transform.position = Vector2.MoveTowards(transform.position, windLocal.transform.position, enemyVelocity * Time.deltaTime);
        }
        else
        {
            enemySpot.gameObject.SetActive(true);
            transform.position = Vector2.MoveTowards(transform.position, enemySpot.transform.position, enemyVelocity * Time.deltaTime);
        }
        if(windLocal.gameObject.activeSelf == false)
        {
            stickOn = false;
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


