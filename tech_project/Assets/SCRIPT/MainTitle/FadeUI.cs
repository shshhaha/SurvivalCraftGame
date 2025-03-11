using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using sound.MainTitleSFX;

public class FadeUI : MonoBehaviour
{
    [SerializeField]
    private Button tapToStartButton;

    [SerializeField]
    private Image gameStartButtonImage;
    [SerializeField]
    private TextMeshProUGUI gameStartButtonText;

    [SerializeField]
    private Image shopButtonImage;
    [SerializeField]
    private TextMeshProUGUI shopButtonText;

    [SerializeField]
    private Image settingButtonImage;

    [SerializeField]
    private Image fadeScreen;
    [SerializeField] private GameObject ResourceUI;


    void Start(){
        tapToStartButton.onClick.AddListener(OnTapToStartButtonClicked);
        
        Color transparentColor = new Color(gameStartButtonImage.color.r, gameStartButtonImage.color.g, gameStartButtonImage.color.b, 0);
        gameStartButtonImage.color = transparentColor;
        
        transparentColor = new Color(shopButtonImage.color.r, shopButtonImage.color.g, shopButtonImage.color.b, 0);
        shopButtonImage.color = transparentColor;
        
        transparentColor = new Color(settingButtonImage.color.r, settingButtonImage.color.g, settingButtonImage.color.b, 0);
        settingButtonImage.color = transparentColor;
        
        transparentColor = new Color(gameStartButtonText.color.r, gameStartButtonText.color.g, gameStartButtonText.color.b, 0);
        gameStartButtonText.color = transparentColor;
        
        transparentColor = new Color(shopButtonText.color.r, shopButtonText.color.g, shopButtonText.color.b, 0);
        shopButtonText.color = transparentColor;
        
        transparentColor = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 0);
        fadeScreen.color = transparentColor;

        fadeScreen.gameObject.SetActive(false);
    }

    public void OnTapToStartButtonClicked()
    {
        MainTitleSFX.instance.PlayUiSFX(MainTitleSFX.UiSfx.TapToStartButtonClicked);
        // ResourceUI.SetActive(true); //공학제때 사용할 코드
        Debug.Log("Tap to Start Button Clicked");
        tapToStartButton.gameObject.SetActive(false);

        gameStartButtonImage.DOFade(1.5f, 1f);
        shopButtonImage.DOFade(1.5f, 1f);
        gameStartButtonText.DOFade(1.5f, 1f);
        shopButtonText.DOFade(1.5f, 1f).OnComplete(() => settingButtonImage.DOFade(1f, 1f));
    }

    public void AllScreenFadeOutLoadNextScene(){
        MainTitleSFX.instance.PlayUiSFX(MainTitleSFX.UiSfx.GameStart_FadeOut);
        fadeScreen.gameObject.SetActive(true);
        fadeScreen.DOFade(1f, 4f).OnComplete(() => LoadingSceneController.LoadScene("inGame"));
    }
}
