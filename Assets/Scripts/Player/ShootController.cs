using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private CountDownController _countDownController;
    private WinnerController _winnerController;
    private PlayerUIController _playerUIController;
    private int CountDown;
    private bool AlreadyShooted = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Global").TryGetComponent<CountDownController>(out _countDownController);
        GameObject.Find("Global").TryGetComponent<WinnerController>(out _winnerController);
        GameObject.Find("PlayerUI").TryGetComponent<PlayerUIController>(out _playerUIController);

        CountDown = _countDownController.CountDownValue;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown = _countDownController.CountDownValue;
    }

    public void OnShoot()
    {
        if (CountDown > 0)
        {
            Debug.Log("Encasquillado!");
            return;
        }
        Shoot();
    }
    
    private void Shoot()
    {
        if (AlreadyShooted) return;
        Debug.Log("Disparo");
        string[] ShootData = {gameObject.name, Time.time.ToString()};
        AlreadyShooted = true;
        _winnerController.StoreShoot(ShootData);
    }

    private void OnJoinRematch()
    {
        if (Global.Instance._matchEnded)
        {
            _playerUIController.WaitPlayers(gameObject.name);
            Global.Instance.ReloadMatch(gameObject.name);
        }
    }
}
