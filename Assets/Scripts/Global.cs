using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public static Global Instance { get; private set; }
    private void Awake() => Instance = this;

    public void MatchEndedEvent() => _matchEnded = true;

    public delegate void StartMatch();
    public event StartMatch OnStartMatch;

    public void StartMatchEvent() => OnStartMatch?.Invoke();

    public bool _matchEnded { get; private set; }

    bool P1 = false, P2 = false;
    public void ReloadMatch(string player)
    {

        switch (player)
        {
            case "Player1":
                P1 = true; break;
            case "Player2":
                P2 = true; break;
            default:
                P1 = false; P2 = P1; break;
        }
        if (P1 && P2)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    

}
