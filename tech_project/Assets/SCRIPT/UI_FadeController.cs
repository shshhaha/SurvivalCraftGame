using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FadeController : MonoBehaviour
{
    private CanvasGroup cg;
    public double fadeTime = 1f;
    double accumTime = 0f;
    private Coroutine fadeCor;

    private void Awake()           // 기본적으로 canvasGroup 컴포넌트의 Alpha 값을 조정하여 페이드인아웃을 표현
    {
        // Alpha 값을 조정
        cg = gameObject.GetComponent<CanvasGroup>();  // CanvasGroup 컴포넌트 정보 가져옴
        StartFadeIn();
    }

    public void StartFadeIn()
    {
        if(fadeCor != null)
        {
            StopAllCoroutines();
            fadeCor = null;
        }
        fadeCor = StartCoroutine(FadeIn());   // 페이드인 코루틴 실행
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.2f); // 괄호 안에 시간 이 지나면 밑의 부분 실행
        accumTime = 0f;
        while (accumTime < fadeTime)            
        {
            cg.alpha = Mathf.Lerp(0.1f, 1f,(float) (accumTime / fadeTime));
            yield return 0;
            accumTime += Time.deltaTime;
        }
        cg.alpha = 1f;

        StartCoroutine(FadeOut());  // 페이드 아웃 코루틴 실행
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.0f); // 괄호 안에 시간 이 지나면 밑의 부분 실행
        accumTime = 0f;
        while (accumTime < fadeTime)
        {
            cg.alpha = Mathf.Lerp(1f, 0.1f, (float)(accumTime / fadeTime));
            yield return 0;
            accumTime += Time.deltaTime;
        }
        cg.alpha = 0.05f;

        StartCoroutine(FadeIn());   // 페이드아웃이 끝나면 다시 페이드인 코루틴 실행하며 반복
    }

}
