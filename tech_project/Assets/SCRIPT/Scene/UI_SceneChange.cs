using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_SceneChange : MonoBehaviour      // �� ��ȯ�Ҷ� ����ϴ� �ڵ� 
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("InGame");             // InGame �̶�� �̸��� ������ �̵� * �����ؾ� ����Ȯ�� ����
    }
}
