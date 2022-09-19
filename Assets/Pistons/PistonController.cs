using System;
using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PistonController : MonoBehaviour
{
    public static event Action<KeyCode> SelectPiston;
    public static event Action<KeyCode> ExtendPiston;
    public static event Action<KeyCode> RetractPiston;
    public static event Action<bool> ResetPiston;
    public static event Action<string> LoadEndScene;
    public static event Action<float> UpdateScore;
    public static event Action<GameObject> Respawn;

    [SerializeField] private RectTransform boostBar;

    private Rigidbody2D rb;
    bool boost;
    float lerpTime;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boost = true;

    }
    private void Update()
    {
        KeyCode currentKey = KeyCodeUtil.GetCurrentKeyDown();
        SelectPiston.Invoke(currentKey); //update currently selected piston

        if (Input.GetMouseButton(0)) ExtendPiston.Invoke(currentKey); //extend pistons with LMB
        if (Input.GetMouseButton(1)) RetractPiston.Invoke(currentKey); //retract pistons with RMB
        if (Input.GetKeyDown(KeyCode.Space)) ResetPiston.Invoke(true);

        if (Input.GetKeyDown(KeyCode.Escape)) Respawn.Invoke(this.gameObject);

        if (Input.GetKeyDown(KeyCode.LeftShift) && boost)
        {
            StartCoroutine(BoostPlayer());
        }
        if (!boost)
        {
            lerpTime = 1.5f * Time.deltaTime;
            boostBar.localScale = new Vector3(Mathf.Lerp(boostBar.localScale.x, 1, lerpTime), boostBar.localScale.y, boostBar.localScale.z);

        }
       // if (Input.GetKeyDown(KeyCode.Delete)) LoadEndScene.Invoke("EndScreen");

        UpdateScore.Invoke(Time.deltaTime);

    }

    IEnumerator BoostPlayer()
    {
        boost = false;
        rb.velocity = new Vector2(rb.velocity.x + Input.GetAxis("Horizontal") * 1000 * Time.deltaTime, rb.velocity.y);
        Debug.Log(rb.velocity.x + Mathf.Round(Input.GetAxis("Horizontal")) * 1000 * Time.deltaTime);
        boostBar.localScale = new Vector3(0, boostBar.localScale.y, boostBar.localScale.z);
        yield return new WaitForSeconds(3);
        boost = true;
    }
}