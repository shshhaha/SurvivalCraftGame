using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BackgroundPanel : MonoBehaviour         // 메뉴버튼을 눌렀을때 바탕화면을
                                                     // 반투명 회색으로 덮고 메뉴 패널 이외의 버튼 못누르게 차단 

{
    public RectTransform uiGroup;
    public void OnBackground()                                           // 패널 위치를 옮겨서 활성화 시키는 방식
    {
        uiGroup.anchoredPosition = Vector3.zero;            
    }

    public void OffBackground()
    {
        uiGroup.anchoredPosition = Vector3.down * 1200;
    }
}
