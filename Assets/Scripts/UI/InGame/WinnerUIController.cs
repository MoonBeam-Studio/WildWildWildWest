using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI WinnerName, WinnerTime, RematchUI;

    private void Start()
    {
        WinnerName.text = "";
        WinnerTime.text = "";
        WinnerName.gameObject.SetActive(false);
        WinnerTime.gameObject.SetActive(false);
        RematchUI.gameObject.SetActive(false);
    }

    public void ShowWinner(string[] winnerData)
    {
        if (winnerData[0] == null)
        {
            WinnerName.text = $"No one has shot!";

        }
        else
        {
            WinnerName.text = $"Winner is {winnerData[0]}!";
            WinnerTime.text = $"{winnerData[1]} s!";
        }
        StartCoroutine(ShowUI());
    }

    private IEnumerator ShowUI()
    {
        yield return new WaitForSeconds(1.3f);

        WinnerName.gameObject.SetActive(true);
        WinnerTime.gameObject.SetActive(true);
        RematchUI.gameObject.SetActive(true);
    }
}
