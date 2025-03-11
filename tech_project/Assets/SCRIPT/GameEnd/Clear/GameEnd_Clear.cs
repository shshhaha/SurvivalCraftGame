using DG.Tweening;
using DTO.MoneyDTO;
using DTO.PlayerDTO;
using DTO.TimerDTO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd_Clear : MonoBehaviour
{
    private PlayerDTO playerDTO;
    private TimerDTO timerDTO;
    private MoneyDTO moneyDTO;
    private PlayerDTO pvo;

    [SerializeField]
    private GameObject gameClearCanvas;

    [SerializeField]
    private GameObject gameClearPanel;

    [SerializeField]
    private TextMeshProUGUI ClearText;

    [SerializeField]
    private TextMeshProUGUI clearRewardText;

    [SerializeField]
    private GameObject buttonContainer;

    [SerializeField]
    private Button goMainTitleButton;

    [SerializeField]
    private GameObject DestroyTargetObject;

    [SerializeField]
    private P_AnimationController animationController;

    private int rewardDollar;

    


    void Start()
    {
        playerDTO = PlayerDTO.Instance;
        pvo = PlayerDTO.Instance;
        timerDTO = TimerDTO.Instance;
        moneyDTO = MoneyDTO.Instance;
        gameClearCanvas.SetActive(false);
        goMainTitleButton.onClick.AddListener(() => GoMainTitle());
        //버튼 투명도 초기화
        UIDataInit();
    }
    void FixedUpdate() {
        DebugFunction();
    }


    public void GameEndClear() // 사망 이벤트
    {
        gameClearPanel.SetActive(true);
        rewardDollar = UserDataController.GameEndReward((int)moneyDTO.getMoney(), 5);
        RewardTextUpdate();
        buttonContainer.SetActive(false);
        gameClearCanvas.SetActive(true);
        Image image = gameClearPanel.GetComponent<Image>();
        image.DOFade(1f, 1.5f).OnComplete(() => {
            ClearText.DOFade(1f, 1.5f).OnComplete(() => {
                StartMoveAndResizeText();
                clearRewardText.DOFade(1f, 2f);
                buttonContainer.SetActive(true);
                
                goMainTitleButton.GetComponent<Image>().DOFade(1f, 2f).OnComplete(() => {
                    Time.timeScale = 0;
                });
            });
        });
    }

    

    #region //버튼 이벤트
    private void GoMainTitle(){
        UserDataController.AddUserExp();
        UserDataController.AddUserDollar(rewardDollar);
        UserDataController.initData();
        PlayerPrefs.Save();
        
        SceneManager.LoadScene("mainTitle");
        Time.timeScale = 1;
    }
    #endregion

    #region //DOTween 함수
    void StartMoveAndResizeText()//텍스트 이동 및 사이즈 조절
    {
        Vector3 newPosition = ClearText.transform.position + new Vector3(0, 400, 0);
        ClearText.transform.DOMove(newPosition, 1f);
        
        Vector3 halfSize = ClearText.transform.localScale * 0.5f;
        ClearText.transform.DOScale(halfSize, 1f);
    }
    #endregion

    //데이터 초기화
    private void UIDataInit(){
        ClearText.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 0, 0);;
        gameClearPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        RectTransform rectTransform = ClearText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 0);
        clearRewardText.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
        goMainTitleButton.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        gameClearPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void RewardTextUpdate(){
        clearRewardText.text = "__________________________\n" + "PLAY TIME" +"\n"+ (timerDTO.getDate() - 1) + "Day\n" + (TimeFix() + (timerDTO.getHour() - 16)) + "Hour \n" + timerDTO.getMinute() + "Minute" + "\n\n"
        + "REWARD : " + rewardDollar +"\n" + "__________________________\n"
        + "EXP HP: " + UserDataController.healthExp + "\n" 
        + "EXP ATK: " + UserDataController.atkExp + "\n" 
        + "EXP RS: " + UserDataController.reloadSpeedExp + "\n"
        + "EXP CR: " + UserDataController.criticalRNGExp + "\n"
        + "EXP CD: " + UserDataController.criticalDamageExp;
    }

    private int TimeFix()
    {
        int time = 0;
        if(timerDTO.getDate() >= 2){
            time = 16;
        }
        return time;
    }
    //디버깅용 함수
    private void DebugFunction(){
        if(Input.GetKeyDown(KeyCode.C)){
            //Debug.Log("Space");
            GameEndClear();
        }
    }
}
