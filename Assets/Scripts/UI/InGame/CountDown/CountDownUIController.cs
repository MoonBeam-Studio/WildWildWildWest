using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUIController : MonoBehaviour
{
    [SerializeField] private CountDownController CountDownController;
    [SerializeField] private TextMeshProUGUI text;
    private int CountDown;

    private void Start()
    {
        gameObject.SetActive(false);
        text.text = "";
        Global.Instance.OnStartMatch += ShowCountDown;
    }

    private void OnDisable() => Global.Instance.OnStartMatch -= ShowCountDown;

    private void Update() 
    {
        CountDown = CountDownController.CountDownValue;

        if (CountDown == 0)
        {
            text.SetText("Its High Noon!");
            return;
        }

        text.SetText(CountDown.ToString());
    }

    private void ShowCountDown() => gameObject.SetActive(true);

}
