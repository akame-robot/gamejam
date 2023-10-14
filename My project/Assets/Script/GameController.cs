using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool invoking = true;
    [SerializeField] private GameObject enemy, obstacle;

    public Transform enemySpawn, obstacleSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawnenemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawnenemy()
    {
        while (invoking)
        {
            yield return new WaitForSeconds(1);
            //Instantiate(obstacle, obstacleSpawn.transform.position, Quaternion.identity);
            Instantiate(enemy, enemySpawn.transform.position, Quaternion.identity);
        }
    }
}
