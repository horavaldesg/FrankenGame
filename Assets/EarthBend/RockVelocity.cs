using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockVelocity : MonoBehaviour
{
    public Rigidbody2D Rock;

    // Update is called once per frame
    void Update()
    {
        Rock.velocity = new Vector2(0.0f, 3.0f);
    }
}
