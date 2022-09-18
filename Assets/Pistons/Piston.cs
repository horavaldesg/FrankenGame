using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Piston : MonoBehaviour
{
    [Header("Piston Settings")]
    [SerializeField, Tooltip("Key used to select this piston")] private KeyCode selectKey;
    [SerializeField] private float _minLength, _maxLength, _extendSpeed, _retractSpeed;
    [SerializeField] private Color _activeColor, _defaultColor;

    private SpriteRenderer _sr;
    private void Start() => _sr = GetComponent<SpriteRenderer>();
    private void OnEnable()
    {
        PistonController.SelectPiston += SelectPiston;
        PistonController.ExtendPiston += ExtendPiston;
        PistonController.RetractPiston += RetractPiston;
        PistonController.ResetPiston += ResetPiston;
        HandCollision.ResetPiston += ResetPiston;
    }
    private void OnDisable()
    {
        PistonController.SelectPiston -= SelectPiston;
        PistonController.ExtendPiston -= ExtendPiston;
        PistonController.RetractPiston -= RetractPiston;
        PistonController.ResetPiston -= ResetPiston;
        HandCollision.ResetPiston -= ResetPiston;
    }

    //updates sprite renderer color based on whether this piston is currently selected or not
    private void SelectPiston(KeyCode currentKey) => _sr.color = (currentKey == selectKey) ? _activeColor : _defaultColor;

    //if piston is currently selected, extend it
    private void ExtendPiston(KeyCode currentKey)
    {
        if (currentKey != selectKey) return;

        //increase piston's y-scale (unless it's already at the max piston length)
        float y = Mathf.Min(transform.localScale.y + (_extendSpeed * Time.deltaTime), _maxLength);
        transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
    }

    //if piston is currently selected, retract it
    private void RetractPiston(KeyCode currentKey)
    {
        if (currentKey != selectKey) return;

        //decrease piston's y-scale (unless it's already at the min piston length)
        float y = Mathf.Max(transform.localScale.y - (_retractSpeed * Time.deltaTime), _minLength);
        transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
    }

    private void ResetPiston(bool reset)
    {
        if (reset)
        {
            transform.localScale = new Vector3(transform.localScale.x, _minLength, transform.localScale.z);
        }
    }

    
}