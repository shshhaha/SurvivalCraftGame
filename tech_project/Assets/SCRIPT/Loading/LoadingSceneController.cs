using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image progressBar;

    [SerializeField] Button startButton;

    [SerializeField] TextMeshProUGUI startText;


    private AsyncOperation operation;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private void Start()
    {
        startButton.onClick.AddListener(OnClickStartButton);
        StartCoroutine(LoadSceneProcess());
    }

    private void OnClickStartButton(){ operation.allowSceneActivation = true; }

    IEnumerator LoadSceneProcess()
    {
        operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;
        startText.gameObject.SetActive(false);

        float timer = 0.0f;
        while(!operation.isDone)
        {
            yield return null;

            if(operation.progress < 0.9f)
            {
                progressBar.fillAmount = operation.progress;
            }
            else
            {
                timer += Time.deltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.4f, 1.0f, timer);
                if(progressBar.fillAmount >= 1.0f)
                {
                    startText.gameObject.SetActive(true);
                    TextMeshProUGUI text = startText.GetComponent<TextMeshProUGUI>();
                    text.DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo);
                    yield break;
                }
            }
        }
    }

    
}
