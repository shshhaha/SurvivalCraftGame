using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuBtn : MonoBehaviour
{
    public RectTransform uiGroup;
    public void ClickMenu()
    {
        uiGroup.anchoredPosition = Vector3.zero;
    }

    public void ExitMenu()
    {
        uiGroup.anchoredPosition = Vector3.down * 1000;
    }
}
