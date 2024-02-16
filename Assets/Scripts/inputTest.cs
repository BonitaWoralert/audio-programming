using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputTest : MonoBehaviour
{
    [SerializeField] InputAction growAction = null;
    [SerializeField] InputAction shrinkAction = null;
    [SerializeField] GameObject _shape = null;

    void OnEnable()
    {
        growAction.performed += OnPerformed;
        growAction.Enable();
    }

    void OnPerformed(InputAction.CallbackContext ctx)
    {
        Debug.Log("played?");
        _shape.transform.localScale += Vector3.one; 
    }
      //=> Debug.Log("played?");
}
