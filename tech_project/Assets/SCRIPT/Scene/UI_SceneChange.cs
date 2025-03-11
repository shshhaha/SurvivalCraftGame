using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_SceneChange : MonoBehaviour      // 씬 전환할때 사용하는 코드 
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("InGame");             // InGame 이라는 이름의 씬으로 이동 * 빌드해야 적용확인 가능
    }
}
