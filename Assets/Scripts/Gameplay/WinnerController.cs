using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WinnerController : MonoBehaviour
{
    [SerializeField] WinnerUIController winnerUIController;
    [SerializeField] PlayerUIController playerUIController;
    private Dictionary<string, float> ShootData = new Dictionary<string, float>();
    private float ShootTime;

    public void StoreShoot(string[] shoot)
    {
        if (ShootData.Count <= 0) StartCoroutine(WaitOtherPlayer());
        ShootData.Add(shoot[0], float.Parse(shoot[1]));
        Debug.Log($"{ShootData.First().Key} - {ShootData.First().Value}");
    }

    private void DeclareWinner()
    {
        string winnerName = ShootData.First().Key;
        string winnerTime = GetWinnerTime().ToString();
        string[] winnerData = { winnerName, winnerTime };

        GameObject.Find(winnerName).GetComponent<Animator>().SetTrigger("Shoot");
        StartCoroutine(DieAnimation());

        winnerUIController.ShowWinner(winnerData);
        playerUIController.ShowPlayers();
        Global.Instance.MatchEndedEvent();
    }

    private IEnumerator WaitOtherPlayer()
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
