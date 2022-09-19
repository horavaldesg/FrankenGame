using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HandCollision : MonoBehaviour
{
    public static event Action<GameObject> Respawn;
    public static event Action<bool> ResetPiston; 
    public static event Action<int> UpdateDeaths;
    public static event Action<string> LoadEndScene;


    public float score;

  
    void Update()
    {
        

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {

            if (!collision.collider.gameObject.GetComponent<Piston>().CanKill)
            {
                //GameOver
                ResetPiston.Invoke(true);
                Respawn.Invoke(collision.collider.transform.parent.gameObject);
                UpdateDeaths.Invoke(1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadEndScene.Invoke("EndScreen");
        }
    }
}
