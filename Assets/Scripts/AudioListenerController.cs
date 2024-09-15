using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerController : MonoBehaviour
{
    private MuteController mController;
    private AudioListener audioListener;

    private void Start()
    {
        mController = GameObject.Find("MuteControl").GetComponent<MuteController>();
        audioListener = GetComponent<AudioListener>();
    }

    private void Update()
    {
        audioListener.GetComponent<AudioListener>().enabled = mController.IsAudioEnabled;
    }
}
