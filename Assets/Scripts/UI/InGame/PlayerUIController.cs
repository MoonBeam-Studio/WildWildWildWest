using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Player1UI, Player2UI;

    private void Start()
    {
        ShowPlayers();
        Global.Instance.OnStartMatch += MatchStart;
    }
    
    private void OnDisable() => Global.Instance.OnStartMatch -= MatchStart;

    private void MatchStart() => gameObject.SetActive(false);

    public void WaitPlayers(string player)
    {
        switch (player)
        {
            case "Player1":
                Player1UI.text = Player1UI.text + "\nReady!"; break;
            case "Player2":
                Player2UI.text = Player2UI.text + "\nReady!"; break;
        }
    }

    public void ShowPlayers()
    {
        gameObject.SetActive(true);
        Player1UI.text = "Player 1";
        Player2UI.text = "Player 2";
    }
}
