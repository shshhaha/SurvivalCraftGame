using DG.Tweening;
using DTO.WeaponDTO.GunDTO;
using sound.MainTitleSFX;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button gameStartButton;//게임 시작 버튼
    [SerializeField] private Button upgradeButton;//상점 버튼
    /* [SerializeField] private Button settingButton;//설정 버튼 */
    [SerializeField] private Text title;//타이틀 제목
    [SerializeField] private GameObject maintitleUI;

    [SerializeField] private GameObject upgradeUI;//업그레이드 UI
    [SerializeField] private Button goBackButton;//뒤로가기 버튼
    [SerializeField] private GameObject ResourceUI;
    


    [SerializeField] public CardSpawner cardSpawner;

    void Start()
    {
        ResourceUI.SetActive(false);
        upgradeUI.SetActive(false);
        gameStartButton.onClick.AddListener(OnGameStartButtonClicked);
        upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
        /* settingButton.onClick.AddListener(OnSettingButtonClicked); */
        goBackButton.onClick.AddListener(OnGoBackButtonClicked);
    }

    public void OnGameStartButtonClicked()
    {
        MainTitleSFX.instance.PlayUiSFX(MainTitleSFX.UiSfx.ButtonClick);
        gameStartButton.gameObject.SetActive(false);
        /* settingButton.gameObject.SetActive(false); */
        upgradeButton.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        cardSpawner.SpawnRandomCard();
    }

    //================================================================================================
    public void OnGoBackButtonClicked()
    {
        TitleUIOn();
        // MoveChildObjectToOtherParentsObject(upgradeUI, maintitleUI, ResourceUI); //공하제때 사용할 코드 (이 코드를 사용하기 위해서 바로 아래의 주석처리 해제)
        upgradeUI.SetActive(false);
        //ResourceUI.SetActive(true);
        ResourceUI.SetActive(false);
    }

    public void OnUpgradeButtonClicked()
    {
        // MoveChildObjectToOtherParentsObject(upgradeUI, maintitleUI, ResourceUI); //공하제때 사용할 코드
        TitleUIOff();
        upgradeUI.SetActive(true);
        ResourceUI.SetActive(true);
    }

    public void OnSettingButtonClicked(){
        TitleUIOff();
        ResourceUI.SetActive(false);
    }

    public void TitleUIOn(){
        MainTitleSFX.instance.PlayUiSFX(MainTitleSFX.UiSfx.ButtonClick);
        gameStartButton.gameObject.SetActive(true);
        upgradeButton.gameObject.SetActive(true);
        /* settingButton.gameObject.SetActive(true); */
        upgradeButton.gameObject.SetActive(true);
        title.gameObject.SetActive(true);
    }
    public void TitleUIOff(){
        MainTitleSFX.instance.PlayUiSFX(MainTitleSFX.UiSfx.ButtonClick);
        gameStartButton.gameObject.SetActive(false);
        upgradeButton.gameObject.SetActive(false);
        /* settingButton.gameObject.SetActive(false); */
        upgradeButton.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
    }

    private void MoveChildObjectToOtherParentsObject(GameObject parentsObject1, GameObject parentsObject2, GameObject childObject)
    {
        // 자식 오브젝트의 현재 부모가 부모 오브젝트1이면
        if (childObject.transform.parent == parentsObject1.transform)
        {
            // 자식 오브젝트를 부모 오브젝트2로 이동
            childObject.transform.SetParent(parentsObject2.transform);
        }
        // 자식 오브젝트의 현재 부모가 부모 오브젝트2이면
        else if (childObject.transform.parent == parentsObject2.transform)
        {
            // 자식 오브젝트를 부모 오브젝트1로 이동
            childObject.transform.SetParent(parentsObject1.transform);
        }
    }
    //================================================================================================
}