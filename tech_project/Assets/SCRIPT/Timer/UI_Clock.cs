using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DTO.TimerDTO;
using sound.backGroundSound;

public class UI_Clock : MonoBehaviour
{
    private TimerDTO tmr;
    public TextMeshProUGUI timeText; // GameObject로 변경
    private bool viewTime = true;
    public Button timerTouch;
    private bool _escpeShip = false; // 구조선 도착 여부
    private int hour;
    private int minute;
    private bool night = false;


    void Start()
    {
        tmr = TimerDTO.Instance;
        timerTouch.onClick.AddListener(switchTimeView);
        timeText.fontSize = 35f;
        hour = tmr.getHour();
        minute = tmr.getMinute()/10;
    }


    void FixedUpdate()
    {
        hour = tmr.getHour();
        minute = tmr.getMinute()/10;

        if(viewTime==true){
            timeText.text = hour.ToString("00") + " : " + minute + "0";
        }
        else if(viewTime==false){
            if(_escpeShip==true){
                timeText.text = "구조선 출발\n" + (24-hour).ToString("00") + " : " + (6-minute) + "0";
            }
            else{
                timeText.text = "구조선 도착까지 " + (7-tmr.getDate()%7) + "일";
            }
        }
        if(tmr.getDate()%7==0){_escpeShip = true;}
        else{_escpeShip = false;}

        
    }
    private void switchTimeView(){
        if(viewTime==true){
            viewTime = false;
            timeText.fontSize =30f;
        }
        else if(viewTime==false){
            viewTime = true;
            timeText.fontSize = 35f;
        }
    }
    
}