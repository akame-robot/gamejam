using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private bool invoking = true;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] obstacle;

    public Transform enemySpawn, obstacleSpawn, enemySpot;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawnenemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null && enemy.transform.position == enemySpot.transform.position)
        {
            invoking = false;
        }
        else if (enemy == null && enemy.transform.position != enemySpot.transform.position)
        {
            invoking = true;
        }
    }

    IEnumerator Spawnenemy()
    {
        while (invoking)
        {
            yield return new WaitForSeconds(Random.Range(1,3));
            Instantiate(obstacle[(Random.Range(0,obstacle.Length))], obstacleSpawn.transform.position, Quaternion.identity);
            Instantiate(enemy, enemySpawn.transform.position, Quaternion.identity);
        }

    }
}
