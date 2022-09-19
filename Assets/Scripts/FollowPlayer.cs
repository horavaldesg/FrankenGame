using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float offset;
    private void Update()
    {
        this.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + offset, transform.position.z);
    }
}
