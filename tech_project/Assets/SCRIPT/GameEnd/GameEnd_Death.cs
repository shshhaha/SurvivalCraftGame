using DG.Tweening;
using DTO.MoneyDTO;
using DTO.PlayerDTO;
using DTO.TimerDTO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameEnd_Death : MonoBehaviour
{
    private PlayerDTO playerDTO;
    private TimerDTO timerDTO;
    private MoneyDTO moneyDTO;
    private PlayerDTO pvo;

    [SerializeField] private GameObject PlayerSoundController;

    [SerializeField]
    private GameObject gameEndCanvas;

    [SerializeField]
    private GameObject gameEndPanel;

    [SerializeField]
    private TextMeshProUGUI youDiedText;

    [SerializeField]
    private TextMeshProUGUI endRewardText;

    [SerializeField]
    private GameObject buttonContainer;

    [SerializeField]
    private Button goMainTitleButton;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button revivalButton;

    [SerializeField]
    private P_AnimationController animationController;

    private int rewardDollar;

    


    void Start()
    {
        playerDTO = PlayerDTO.Instance;
        pvo = PlayerDTO.Instance;
        timerDTO = TimerDTO.Instance;
        moneyDTO = MoneyDTO.Instance;
        gameEndCanvas.SetActive(false);
        goMainTitleButton.onClick.AddListener(() => GoMainTitle());
        restartButton.onClick.AddListener(() => Restart());
        revivalButton.onClick.AddListener(() => Revival());

        //버튼 투명도 초기화
        UIDataInit();
    }
    void FixedUpdate() {
        DebugFunction();
    }


    public void GameEndDeath() // 사망 이벤트
    {
        PlayerSoundController.SetActive(false);
        gameEndPanel.SetActive(true);
        rewardDollar = UserDataController.GameEndReward((int)moneyDTO.getMoney(), 5);

        RewardTextUpdate();
        buttonContainer.SetActive(false);
        gameEndCanvas.SetActive(true);
        Image image = gameEndPanel.GetComponent<Image>();
        image.DOFade(1f, 1.5f).OnComplete(() => {
            youDiedText.DOFade(1f, 1.5f).OnComplete(() => {
                StartMoveAndResizeText();
                endRewardText.DOFade(1f, 2f);
                buttonContainer.SetActive(true);
                
                goMainTitleButton.GetComponent<Image>().DOFade(1f, 2f);
                restartButton.GetComponent<Image>().DOFade(1f, 2f);
                revivalButton.GetComponent<Image>().DOFade(1f, 2f).OnComplete(() => {
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

        PlayerSoundController.SetActive(true);

        SceneManager.LoadScene("mainTitle");
        Time.timeScale = 1;
    }
    private void Restart(){
        UserDataController.AddUserExp();
        UserDataController.AddUserDollar(rewardDollar);
        UserDataController.initData();
        PlayerPrefs.Save();

        PlayerSoundController.SetActive(true);
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

        animationController.playerRevive();
    }

    private void Revival(){
        playerDTO.setCurrentHp((int)(playerDTO.getMaxHp()*0.5f));
        playerDTO.setCurrentStamina(20f);
        playerDTO.setHunger(20f);
        Vector3 resetfontSize = youDiedText.transform.localScale * 2f;
        youDiedText.transform.DOScale(resetfontSize, 0);

        pvo.setDeath(false);
        gameEndPanel.GetComponent<Image>().DOFade(0, 1.5f);
        gameEndCanvas.SetActive(false);
        UIDataInit();
        Time.timeScale = 1;

        PlayerSoundController.SetActive(true);

        animationController.playerRevive();
    }
    #endregion

    #region //DOTween 함수
    void StartMoveAndResizeText()//텍스트 이동 및 사이즈 조절
    {
        Vector3 newPosition = youDiedText.transform.position + new Vector3(0, 400, 0);
        youDiedText.transform.DOMove(newPosition, 1f);
        
        Vector3 halfSize = youDiedText.transform.localScale * 0.5f;
        youDiedText.transform.DOScale(halfSize, 1f);
    }
    #endregion

    //데이터 초기화
    private void UIDataInit(){
        youDiedText.GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0, 0);;
        gameEndPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        RectTransform rectTransform = youDiedText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 0);
        endRewardText.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
        goMainTitleButton.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        restartButton.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        revivalButton.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        gameEndPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void RewardTextUpdate(){
        
            
        endRewardText.text = "__________________________\n" + "PLAY TIME" +"\n"+ (timerDTO.getDate() - 1) + "Day\n" + (TimeFix() + (timerDTO.getHour() - 16)) + "Hour \n" + timerDTO.getMinute() + "Minute" + "\n\n"
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
        if(Input.GetKeyDown(KeyCode.X)){
            GameEndDeath();
        }
    }
}
