using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FadeController : MonoBehaviour
{
    private CanvasGroup cg;
    public double fadeTime = 1f;
    double accumTime = 0f;
    private Coroutine fadeCor;

    private void Awake()           // �⺻������ canvasGroup ������Ʈ�� Alpha ���� �����Ͽ� ���̵��ξƿ��� ǥ��
    {
        // Alpha ���� ����
        cg = gameObject.GetComponent<CanvasGroup>();  // CanvasGroup ������Ʈ ���� ������
        StartFadeIn();
    }

    public void StartFadeIn()
    {
        if(fadeCor != null)
        {
            StopAllCoroutines();
            fadeCor = null;
        }
        fadeCor = StartCoroutine(FadeIn());   // ���̵��� �ڷ�ƾ ����
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.2f); // ��ȣ �ȿ� �ð� �� ������ ���� �κ� ����
        accumTime = 0f;
        while (accumTime < fadeTime)            
        {
            cg.alpha = Mathf.Lerp(0.1f, 1f,(float) (accumTime / fadeTime));
            yield return 0;
            accumTime += Time.deltaTime;
        }
        cg.alpha = 1f;

        StartCoroutine(FadeOut());  // ���̵� �ƿ� �ڷ�ƾ ����
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.0f); // ��ȣ �ȿ� �ð� �� ������ ���� �κ� ����
        accumTime = 0f;
        while (accumTime < fadeTime)
        {
            cg.alpha = Mathf.Lerp(1f, 0.1f, (float)(accumTime / fadeTime));
            yield return 0;
            accumTime += Time.deltaTime;
        }
        cg.alpha = 0.05f;

        StartCoroutine(FadeIn());   // ���̵�ƿ��� ������ �ٽ� ���̵��� �ڷ�ƾ �����ϸ� �ݺ�
    }

}
