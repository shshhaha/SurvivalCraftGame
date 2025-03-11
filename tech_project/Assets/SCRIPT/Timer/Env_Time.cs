using UnityEngine;
using DTO.TimerDTO;
public class Env_Time : MonoBehaviour
{
    private TimerDTO tmr;
    public float rotationSpeed = 2.0f; // 초당 회전 속도 (n도, n = 6이면 초당 6도 회전, 1분당 360도)
    int tensPlaceMinutes = 0;
    float sunAngle = 150f; //
    private int minute; // 분 변수
    private int hour; // 시간 변수, 시작 시간을 16시로 설정
    private int date = 1; // 날짜 변수
    private bool dateFlag = true;
    void Start()
        {
            tmr = TimerDTO.Instance;
        }
    void FixedUpdate()
    {
        setTime();
        tmr.setMinute(minute);
        tmr.setHour(hour);
        tmr.setDate(date);
    }
    public void setTime()
    {
         // Time.deltaTime을 사용하여 초당 회전 각도를 구하고, sunAngle을 갱신합니다.
        sunAngle += Time.deltaTime * rotationSpeed;

        // 시간과 분을 계산합니다.
        hour = Mathf.FloorToInt((sunAngle / 15) + 6); // 1시간은 15도 회전
        minute = Mathf.FloorToInt((sunAngle * 4) % 60); // 60분을 넘어가면 0부터 다시 시작하도록 보정

        // 10분 단위로 분 표기하기
        tensPlaceMinutes = (minute / 10) * 10;

        // 시간과 날짜를 업데이트합니다.
        if (tensPlaceMinutes >= 60)
        {
            hour += 1;
            tensPlaceMinutes = 0;
        }
        hour = hour % 24; // 24시 넘으면 0시로 표기되도록

        transform.rotation = Quaternion.Euler(sunAngle, 30f, 0f);
        
        //dateFlag 재활성화
        if(hour==23)
        {
            dateFlag=true;
        }

        //24시 넘으면 일수 추가
        if (dateFlag==true && hour==0)
        {
            date += 1;
            dateFlag=false;
        }
    }

}
