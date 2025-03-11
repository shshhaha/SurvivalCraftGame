using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StopController : MonoBehaviour
{
    [SerializeField] private GameObject StopPanel;
    [SerializeField] private Button StopButton;

    private bool isStop = false;

    public void Start()
    {
        StopPanel.SetActive(false); // 게임 오브젝트 비활성화
        StopButton.onClick.AddListener(() => StopButtonClick());
    }


    private void StopButtonClick()
    {
        if (isStop)
        {
            StopPanel.SetActive(false);
            StartGame();
            isStop = false;
        }
        else
        {
            StopPanel.SetActive(true);
            StopGame();
            isStop = true;
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }
}
