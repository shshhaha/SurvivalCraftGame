using DTO.MoneyDTO;
using DTO.TimerDTO;
using UnityEditor;

using UnityEngine;

public class KillReward : MonoBehaviour
{
    private MoneyDTO moneyDTO;//게임 플레이중 사용하는 돈 이것은 메인타이틀 머니와는 무관함
    private TimerDTO timerDTO;

    #region .몬스터 보상
        [Tooltip("기본 보상 값")]
        public float reward_Basic;
        [Tooltip("1일마다 추가로 적용할 킬 보상 값 | 계산공식 : 기본 킬 보상에 1일마다 n%씩 추가됨.")]
        public float reward_Bonus = 1;
        #endregion

    void Start()
    {
        moneyDTO = MoneyDTO.Instance;
        timerDTO = TimerDTO.Instance;
    }

    public void killReward(){
        moneyDTO.setMoney(moneyDTO.getMoney() + (int)(reward_Basic * Mathf.Pow(1 + reward_Bonus / 100, timerDTO.getDate())));
    }

}
