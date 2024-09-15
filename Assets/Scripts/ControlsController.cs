using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsController : MonoBehaviour
{
    PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        //if (!PlayerPrefs.HasKey("Test"))
        //{
        //    PlayerPrefs.SetString("Test", "Creada");
        //    Debug.Log(PlayerPrefs.GetString("Test"));
        //}
        //else
        //{
        //    PlayerPrefs.SetString("Test", "Eliminada");
        //    Debug.Log(PlayerPrefs.GetString("Test"));
        //    PlayerPrefs.DeleteKey("Test");
        //}
        Debug.Log(playerInput.actions["Shoot"].bindings);
    }
}
