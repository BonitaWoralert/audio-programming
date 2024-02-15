using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputTest : MonoBehaviour
{
    [SerializeField] InputAction _action = null;
    [SerializeField] GameObject _shape = null;

    void OnEnable()
    {
        _action.performed += OnPerformed;
        _action.Enable();
    }

    void OnDisable()
    {
        _action.performed -= OnPerformed;
        _action.Disable();
    }

    void OnPerformed(InputAction.CallbackContext ctx)
    {
        Debug.Log("played?");
        _shape.transform.localScale += Vector3.one; 
    }
      //=> Debug.Log("played?");
}
