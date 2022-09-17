using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVelocity : MonoBehaviour
{
    public Rigidbody2D Enemy;

    // Update is called once per frame
    void Update()
    {
        Enemy.velocity = new Vector2(-5.0f, 0.0f);
    }

}
