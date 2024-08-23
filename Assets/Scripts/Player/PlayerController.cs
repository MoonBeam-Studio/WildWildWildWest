using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    void Start()
    {
        if (!GameObject.Find("Player1")) gameObject.name = "Player1";
        else gameObject.name = "Player2";

        PlayerUIController playerUIController = GameObject.Find("PlayerUI").GetComponent<PlayerUIController>();
        playerUIController.WaitPlayers(gameObject.name);

        string positionName = gameObject.name+"Pos";
        if(!GameObject.Find(positionName)) return;
        GameObject PositionPH = GameObject.Find(positionName);

        transform.position = PositionPH.transform.position;
        transform.rotation = PositionPH.transform.rotation;
        PositionPH.GetComponent<MeshRenderer>().enabled = false;
    }

    public void GunshotSFX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    public void DieSFX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[1];
        audioSource.Play();
    }
}
