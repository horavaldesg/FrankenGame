using System;
using UnityEngine;

public class PistonController : MonoBehaviour
{
    public static event Action<KeyCode> SelectPiston;
    public static event Action<KeyCode> ExtendPiston;
    public static event Action<KeyCode> RetractPiston;
    public static event Action<bool> ResetPiston;
    public static event Action<bool> LoadEndScene;
    public static event Action<float> UpdateScore;

    private void Start()
    {
        
    }
    private void Update()
    {
        KeyCode currentKey = KeyCodeUtil.GetCurrentKeyDown();
        SelectPiston.Invoke(currentKey); //update currently selected piston

        if (Input.GetMouseButton(0)) ExtendPiston.Invoke(currentKey); //extend pistons with LMB
        if (Input.GetMouseButton(1)) RetractPiston.Invoke(currentKey); //retract pistons with RMB
        if (Input.GetKeyDown(KeyCode.Space)) ResetPiston.Invoke(true);

        if (Input.GetKeyDown(KeyCode.Delete)) LoadEndScene.Invoke(true);

        UpdateScore.Invoke(Time.deltaTime);
        
    }
}