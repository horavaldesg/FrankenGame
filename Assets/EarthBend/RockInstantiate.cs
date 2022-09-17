using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInstantiate : MonoBehaviour
{
    public GameObject RockPrefab;

    Vector2 ClickPosition;
    Camera MainCam;

    private void Awake()
    {
        MainCam = Camera.main;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 clickPoint = Input.mousePosition;
            clickPoint.z = Mathf.Abs(MainCam.transform.position.z);
            Vector3 mouseClickPosition = MainCam.ScreenToWorldPoint(clickPoint);
            mouseClickPosition.z = 0f;
            Instantiate(RockPrefab, mouseClickPosition, Quaternion.identity);
        }
    }

}


