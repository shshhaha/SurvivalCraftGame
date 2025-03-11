using ES3Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftResultPanel : MonoBehaviour
{
    public static CraftResultPanel instance;
    public GameObject CraftTure_Panel;
    public GameObject CraftFail_Panel;
    public GameObject CraftHave_Panel;
    public GameObject CraftNoUnder_Panel;
    public GameObject CraftNoSet_Panel;
    public float CraftResultPanelTime= 0.0005f;

    void Start()
    {
        instance = this;

        CraftTure_Panel.SetActive(false);
        CraftFail_Panel.SetActive(false);
        CraftHave_Panel.SetActive(false);
        CraftNoUnder_Panel.SetActive(false);
        CraftNoSet_Panel.SetActive(false);
    }

    public void ShowCraftResultPanel(int isCraftSuccess)
    {
        if (isCraftSuccess == 1)
        {
            StartCoroutine(ShowCraftTruePanel());
        }
        else if (isCraftSuccess == 0)
        {
            StartCoroutine(ShowCraftFailPanel());
        }
        else if (isCraftSuccess == -1)
        {
            StartCoroutine(ShowCraftHavePanel());
        }
        else if (isCraftSuccess == -2)
        {
            StartCoroutine(ShowCraftNoUnderPanel());
        }
        else if (isCraftSuccess == -3)
        {
            StartCoroutine(ShowCraftNoSetPanel());
        }
        else
        {
            Debug.Log("ItemCraft.cs에 리턴값이 1,0,-1이 아님.");
        }
        

    }

    public IEnumerator ShowCraftTruePanel()
    {
        CraftTure_Panel.SetActive(true);
        yield return new WaitForSeconds(CraftResultPanelTime);
        //yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began); //모바일 터치 인식
        CraftTure_Panel.SetActive(false);
    }

    public IEnumerator ShowCraftFailPanel()
    {
        CraftFail_Panel.SetActive(true);
        yield return new WaitForSeconds(CraftResultPanelTime);
        //yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began); //모바일 터치 인식
        CraftFail_Panel.SetActive(false);
    }

    public IEnumerator ShowCraftHavePanel()
    {
        CraftHave_Panel.SetActive(true);
        yield return new WaitForSeconds(CraftResultPanelTime);
        //yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began); //모바일 터치 인식
        CraftHave_Panel.SetActive(false);
    }

    public IEnumerator ShowCraftNoUnderPanel()
    {
        CraftNoUnder_Panel.SetActive(true);
        yield return new WaitForSeconds(CraftResultPanelTime);
        //yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began); //모바일 터치 인식
        CraftNoUnder_Panel.SetActive(false);
    }

    public IEnumerator ShowCraftNoSetPanel()
    {
        CraftNoSet_Panel.SetActive(true);
        yield return new WaitForSeconds(CraftResultPanelTime);
        //yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began); //모바일 터치 인식
        CraftNoSet_Panel.SetActive(false);
    }

}
