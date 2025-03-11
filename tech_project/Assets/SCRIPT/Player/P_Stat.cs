using UnityEngine;
using UnityEngine.UI;
using DTO.PlayerDTO;
using System.Collections;
public class P_Stat : MonoBehaviour
{
    [SerializeField]
    private P_AnimationController animationController;

    [SerializeField]
    private GameEnd_Death gameEnd_Death;
    private PlayerDTO pvo;
    public Image hpBar; // HP 바
    public Text hpText; // HP 텍스트
    public Image staminaBar; // 스테미너 바
    public Image hungerBar; // 허기 바
    private float currentHp;
    private float getMaxHp;

    private bool endFlag = false;
    void Start()
    {
        pvo = PlayerDTO.Instance;
        pvo.setHunger(pvo.getMaxStamina());
        StartCoroutine(DecreaseHunger());
    }
    void FixedUpdate()
    {
        UpdateHp();
        UpdateStamina();
    }

    private void UpdateHp()
    {
        if(pvo.getCurrentHp() <= 0){
            animationController.playerDead();
            pvo.setCurrentHp(0);
            pvo.setDeath(true);
            if(endFlag == false){
                endFlag = true;
                gameEnd_Death.GameEndDeath();
            }
        }
        else{ endFlag = false; }
        currentHp = pvo.getCurrentHp();
        getMaxHp = pvo.getMaxHp();

        if (pvo.getCurrentHp() > pvo.getMaxHp())
        {
            pvo.setCurrentHp((int)pvo.getMaxHp());
        }
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount , currentHp/getMaxHp, Time.deltaTime * 4);//현재 HP를 이전 HP 값 막대에 반영
        hpText.text = pvo.getCurrentHp().ToString() + " / " + pvo.getMaxHp().ToString(); // 생명력 텍스트 업데이트 
    }

    // 스테미너 업데이트
    private void UpdateStamina()
    {
        hungerBar.fillAmount = Mathf.Lerp(hungerBar.fillAmount , pvo.getHunger()/pvo.getMaxStamina(), Time.deltaTime * 4);
        if(pvo.getCurrentStamina() < pvo.getHunger() && pvo.isIsPlayerRun() == false)
        {
            pvo.setCurrentStamina(pvo.getCurrentStamina() + 0.1f);
        }
        else if(pvo.getCurrentStamina() > 0 && pvo.isIsPlayerRun() == true)
        {
            pvo.setCurrentStamina(pvo.getCurrentStamina() - 0.05f);

            if(pvo.getCurrentStamina() <= 0)
            {
                StartCoroutine(ChangeColor());
            }
        }
        else if(pvo.getCurrentStamina() > pvo.getHunger())
        {
            pvo.setCurrentStamina(pvo.getHunger());
        }
        
        staminaBar.fillAmount = Mathf.Lerp(staminaBar.fillAmount, pvo.getCurrentStamina() / pvo.getMaxStamina(), Time.deltaTime * 4);
        if(pvo.getHunger() <= pvo.getCurrentStamina()){pvo.setCurrentStamina(pvo.getHunger());}
    }

    IEnumerator DecreaseHunger()
    {
        while (true)
        {
            if(pvo.getHunger() >= pvo.getMaxStamina() * 0.2f)
            {  
                pvo.setHunger(pvo.getHunger() - 1f);
                Debug.Log("최대 배고픔 업데이트 "+pvo.getHunger());
            }
            yield return new WaitForSeconds(20f);
        }
    }

    IEnumerator ChangeColor()
    {
        Color originalColor = staminaBar.color;
        Color targetColor = Color.red;
        float duration = 0.3f; // 색상 변경에 걸리는 시간

        for (int i = 0; i < 7; i++)
        {
            // 빨간색으로 변경
            float startTime = Time.time;
            while (Time.time < startTime + duration)
            {
                float t = (Time.time - startTime) / duration;
                staminaBar.color = Color.Lerp(originalColor, targetColor, t);
                yield return null;
            }

            // 원래 색상으로 변경
            startTime = Time.time;
            while (Time.time < startTime + duration)
            {
                float t = (Time.time - startTime) / duration;
                staminaBar.color = Color.Lerp(targetColor, originalColor, t);
                yield return null;
            }
        }

        // 마지막으로 원래 색상으로 설정
        staminaBar.color = originalColor;
    }
}
