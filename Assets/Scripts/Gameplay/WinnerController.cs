using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WinnerController : MonoBehaviour
{
    [SerializeField] WinnerUIController winnerUIController;
    [SerializeField] PlayerUIController playerUIController;
    [SerializeField] PlayerController playerController1 = null, playerController2 = null;
    private Dictionary<string, float> ShootData = new Dictionary<string, float>();
    private float ShootTime;
    //string[] winnerData;
    bool PlayerShot;


    private void Update()
    {
        if (playerController1 == null) playerController1 = GameObject.Find("Player2").GetComponent<PlayerController>();
        if (playerController2 == null) playerController2 = GameObject.Find("Player2").GetComponent<PlayerController>();
    }
    public void StoreShoot(string[] shoot)
    {
        if (ShootData.Count <= 0) StartCoroutine(WaitOtherPlayer());
        ShootData.Add(shoot[0], float.Parse(shoot[1]));
        PlayerShot = true;
    }

    private void DeclareWinner()
    {
        string winnerName = null;
        string winnerTime = null;

        if (PlayerShot)
        {
            winnerName = ShootData.First().Key;
            winnerTime = GetWinnerTime().ToString();

            GameObject.Find(winnerName).GetComponent<Animator>().SetTrigger("Shoot");
            StartCoroutine(DieAnimation());
        }
        string[] winnerData = { winnerName, winnerTime };
        Debug.Log(winnerData);
        playerController1.MatchEnded = true;
        playerController2.MatchEnded = true;
        winnerUIController.ShowWinner(winnerData);
        playerUIController.ShowPlayers();
        Global.Instance.MatchEndedEvent();
    }

    public IEnumerator WaitOtherPlayer()
    {
        yield return new WaitForSeconds(1f);
        DeclareWinner();
    }

    private IEnumerator DieAnimation()
    {
        yield return new WaitForSeconds(2.07f);
        if (ShootData.Count > 1) GameObject.Find(ShootData.Last().Key).GetComponent<Animator>().SetTrigger("Die");
        else
        {
            switch (ShootData.Last().Key) 
            {
                case "Player1":
                    GameObject.Find("Player2").GetComponent<Animator>().SetTrigger("Die");
                    break;
                case "Player2":
                    GameObject.Find("Player1").GetComponent<Animator>().SetTrigger("Die");
                    break;
            }
        }
        
    }

    private float GetWinnerTime() { float time = ShootData.First().Value - ShootTime; return MathF.Round(time,3); }

    public void SetShootTime (float _shootTime) => ShootTime = _shootTime;
}
