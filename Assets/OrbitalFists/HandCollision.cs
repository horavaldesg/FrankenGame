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

    public float score;
    public Text scoreText;
    void Update()
    {
        

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //GameOver
            ResetPiston.Invoke(true);
            Respawn.Invoke(collision.collider.transform.parent.gameObject);
        }
    }
}
