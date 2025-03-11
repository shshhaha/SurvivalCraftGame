using sound.backGroundSound;
using UnityEngine;
using DTO.TimerDTO;

public class StartBGMService : MonoBehaviour
{

    private TimerDTO tmr;
    private bool flag = true;

    void Start()
    {
        tmr = TimerDTO.Instance;
        _backGroundSound.instance.PlayBGMLoop(_backGroundSound.BGMList.wind);
        _backGroundSound.instance.PlayBGM(_backGroundSound.BGMList.GameIntro);
    }

    void Update()
    {
        PlayBGMByTime();
    }

    public void PlayBGMByTime()
    {
        int currentHour = tmr.getHour();
    
        if (currentHour == 19 && flag == true)
        {
            StartNightBGM();
            flag = false;
        }
        else if (currentHour == 6 && flag == false)
        {
            StartDayBGM();
            flag = true;
        }
    }

    
    

    private void StartNightBGM(){
        _backGroundSound.instance.StopPlayingAllThisBGMList();
        _backGroundSound.instance.PlayRandomBGM(1,4);
    }
    private void StartDayBGM(){
        _backGroundSound.instance.StopPlayingAllThisBGMList();
        _backGroundSound.instance.PlayBGM(_backGroundSound.BGMList.wind);
    }
    
}
