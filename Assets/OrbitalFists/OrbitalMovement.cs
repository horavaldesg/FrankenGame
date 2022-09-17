using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMovement : MonoBehaviour
{
    public float Clockwise_roatationSpeed;
    public float Counterclockwise_roatationSpeed;
 
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject Body;



    void Update()
    {

        rightHand.transform.RotateAround(Body.transform.position, Vector3.forward, Counterclockwise_roatationSpeed * Time.deltaTime);



        leftHand.transform.RotateAround(Body.transform.position, Vector3.forward, Counterclockwise_roatationSpeed * Time.deltaTime);
    }
}
