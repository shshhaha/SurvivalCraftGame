/* using UnityEngine;
using DTO.TimerDTO;
using DTO.MoneyDTO;

namespace Reward.KillMonster
{
    public class RewardKillMonster : MonoBehaviour
    {
        //사용방법 : 복사할 몬스터의 프리펩에 이 스크립트를 넣고, 보상을 설정하시오
        private GameObject monsterKind;
        [Tooltip("기본 보상 값")]
        public float reward_Basic;
        [Tooltip("1일마다 추가로 적용할 킬 보상 값 | 계산공식 : 기본보상 * ((보너스 값)^일수)")]
        public float reward_Bonus = 1;
        
        private TimerDTO tim;
        private MoneyDTO moneyDTO;
        private bool isGetReword = false;


        void Start()
        {
            tim = TimerDTO.Instance;
            moneyDTO = MoneyDTO.Instance;
            monsterKind = this.gameObject;
        }
        void HandleMonsterKillReward()
        {
            if(isGetReword == false){
                isGetReword = true;
                // 몬스터가 사망했을 때의 보상 처리
                moneyDTO.setMoney(moneyDTO.getMoney() + (int)(reward_Basic * Mathf.Pow(reward_Bonus, tim.getDate())));
            }
        }
    }
}

 */