using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BackgroundPanel : MonoBehaviour         // �޴���ư�� �������� ����ȭ����
                                                     // ������ ȸ������ ���� �޴� �г� �̿��� ��ư �������� ���� 

{
    public RectTransform uiGroup;
    public void OnBackground()                                           // �г� ��ġ�� �Űܼ� Ȱ��ȭ ��Ű�� ���
    {
        uiGroup.anchoredPosition = Vector3.zero;            
    }

    public void OffBackground()
    {
        uiGroup.anchoredPosition = Vector3.down * 1200;
    }
}
