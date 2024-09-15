using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownController : MonoBehaviour
{
    int CountDownTimmer = 10;
    bool PlayerShot;
    [SerializeField] WinnerController winnerController;
    [SerializeField] CountDownUIController countDownUIController;
    [SerializeField] PlayerUIController playerUIController;
    [SerializeField] AudioClip[] audioClips;

    private AudioSource audioSource;
    public int CountDownValue { get; private set; }

    private void Start()
    {
        CountDownValue = CountDownTimmer;
        StartCoroutine(CountDown(CountDownTimmer));
        audioSource = countDownUIController.gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClips[0];
    }
    private IEnumerator CountDown(int countDown)
    {
        while (true)
        {
            if (GameObject.Find("Player1") && GameObject.Find("Player2"))
            {
                yield return new WaitForSeconds(1.5f);
                Global.Instance.StartMatchEvent();
                for (int i = 0; i < countDown; i++)
                {
                    float time = Random.Range(1.5f, 3f);
                    yield return new WaitForSeconds(time);
                    audioSource.Play();
                    CountDownValue--;
                }
                winnerController.SetShootTime(Time.time);
                audioSource.clip = audioClips[1];
                audioSource.Play();
                StartCoroutine(DrawTimer());
                break;
            }
            yield return null;
        }
    }

    private IEnumerator DrawTimer()
    {
        yield return new WaitForSeconds(3);
        if (!PlayerShot)
        {
            audioSource.clip = audioClips[2];
            audioSource.Play();
            StartCoroutine(winnerController.WaitOtherPlayer());
        }
    }

    public void StopDraw() => PlayerShot = true;
}
