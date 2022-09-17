using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private void OnEnable()
    {
        HandCollision.Respawn += Respawn;
    }

    private void OnDisable()
    {
        HandCollision.Respawn -= Respawn;
    }

    void Respawn(GameObject player)
    {
        player.transform.position = this.transform.position;
    }

    
}
