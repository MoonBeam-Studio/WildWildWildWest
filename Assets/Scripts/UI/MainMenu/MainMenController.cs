using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] AudioListener audioListener;
    [SerializeField] Image muteImage;
    [SerializeField] GameObject ControlsCanvas;
    [SerializeField] Sprite[] muteIcon;
    [SerializeField] AudioSource buttonSound;

    private MuteController mController;

    private void Start()
    {
        Cursor.visible = true;
        mController = GameObject.Find("MuteControl").GetComponent<MuteController>();
    }

    public void Quit()
    {
        ButtonPlaySound();
        Application.Quit();
    }

    public void StartGame()
    {
        ButtonPlaySound();
        gameController.StartGame();
    }

    public void Mute()
    {
        ButtonPlaySound();
        Debug.Log(mController.IsAudioEnabled);
        mController.IsAudioEnabled = !mController.IsAudioEnabled;
        if (mController.IsAudioEnabled) muteImage.overrideSprite = muteIcon[0];
        else muteImage.overrideSprite = muteIcon[1];

    }

    public void ControlsShow()
    {
        ButtonPlaySound();
        ControlsCanvas.SetActive(true);
    }

    public void ControlsHide()
    {
        ButtonPlaySound();
        ControlsCanvas.SetActive(false);
    }

    private void ButtonPlaySound() => buttonSound.Play();
}
