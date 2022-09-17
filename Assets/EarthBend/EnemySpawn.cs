using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    public float Timer;
    public GameObject EnemyPrefab;
    public int score;
    GameObject EnemyClone;
    public Rigidbody2D Enimies;

    // Update is called once per frame
    void Update()
    {
        Timer += 1 * Time.deltaTime;

        if(Timer >= 2)
        {
           EnemyClone = Instantiate(EnemyPrefab, transform.position + (transform.right* 10), transform.rotation);
            Timer = 0;
        }
    }

}
