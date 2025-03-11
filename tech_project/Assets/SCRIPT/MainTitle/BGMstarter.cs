using sound.MainTitleBGM;
using sound.MainTitleSFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMstarter : MonoBehaviour
{
    protected void Start()
    {
        StartBGM();
    }
    private void StartBGM()
    {
        MainTitleBGM.instance.PlayBGMLoop(MainTitleBGM.BGMList.MainTitleBGM1);
        MainTitleSFX.instance.PlayUiSFXLoop(MainTitleSFX.UiSfx.fire);
    }
    
}
