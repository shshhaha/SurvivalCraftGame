/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPController : MonoBehaviour
{
    public Slider hpSlider; // HP 막대
    public Text hpText; // HP 텍스트

    private int maxHp = 999; // 최대 HP
    private int currentHp; // 현재 HP

    void Start()
    {
        // 초기 생명력 설정 - 예를 들어 999로 시작
        currentHp = maxHp;
        UpdateHpUI();
    }

    // 생명력을 업데이트하는 메서드
    public void UpdateHp(int value)
    {
        currentHp = Mathf.Clamp(currentHp + value, 0, maxHp); // 생명력 변경
        UpdateHpUI(); // 생명력 UI 업데이트
    }

    // 생명력 UI를 업데이트하는 메서드
    private void UpdateHpUI()
    {
        hpSlider.value = (float)currentHp / maxHp; // 생명력 비율 계산
        hpText.text = currentHp.ToString(); // 생명력 텍스트 업데이트
    }
} */