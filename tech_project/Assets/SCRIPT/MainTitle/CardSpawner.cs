using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
using sound.MainTitleSFX;

public class CardSpawner : MonoBehaviour
{

    [SerializeField] private FadeUI fadeUI;
    [SerializeField] private GameObject ResourceUI;

    [SerializeField] private GameObject[] cardPrefabs; // 카드 프리팹 배열
    [SerializeField] private GameObject[] cardSpawnPoint; // 카드 생성 위치

    private List<GameObject> spawnedCards = new List<GameObject>(); // 생성된 카드 리스트

    public void SpawnRandomCard()
    {
        fadeUI.AllScreenFadeOutLoadNextScene();

        //아래의 주석 코드는 공학제때 사용할 코드이며 이번 프로젝트에서는 사용하지 않도록 한다. 따라서 바로 위 코드를 사용하여 바로 게임에 진입한다.
        /* // 카드 프리팹 리스트 생성
        List<GameObject> cardPrefabsList = new List<GameObject>();

        // 랜덤한 카드 프리팹 선택 및 리스트에 추가
        for (int i = 0; i < cardSpawnPoint.Length; i++)
        {
            int randomIndex = Random.Range(0, cardPrefabs.Length);
            cardPrefabsList.Add(cardPrefabs[randomIndex]);
        }

        float delay = 0f;
        // 리스트의 순서에 따라 카드 생성
        for (int i = 0; i < cardSpawnPoint.Length; i++)
        {
            
            GameObject spawnPoint = cardSpawnPoint[i];
            GameObject cardPrefab = cardPrefabsList[i];
            GameObject spawnedCard = Instantiate(cardPrefab, spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform);
            spawnedCards.Add(spawnedCard);

            spawnedCard.transform.DOMoveY(300f, 1f).OnStart(() => MainTitleSFX.instance.PlayUiSFX(MainTitleSFX.UiSfx.CardShow)).SetDelay(delay);

            delay += 0.5f;

            Button cardButton = spawnedCard.GetComponent<Button>();
            cardButton.onClick.AddListener(() => OnCardClicked(cardPrefab));
        } */
    }

    public void OnCardClicked(GameObject card)
    {
        switch (card.name)
        {
            case "card0":
                // Card1에 대한 이벤트
                Debug.Log("Card1 Clicked");

                break;
            case "card1":
                // Card2에 대한 이벤트
                Debug.Log("Card2 Clicked");

                break;
            case "card2":
                // Card3에 대한 이벤트
                Debug.Log("Card3 Clicked");

                break;
            case "card3":
                // Card4에 대한 이벤트
                Debug.Log("Card4 Clicked");

                break;
            case "card4":
                // Card5에 대한 이벤트
                Debug.Log("Card5 Clicked");

                break;
            case "card5":
                // Card6에 대한 이벤트
                Debug.Log("Card6 Clicked");

                break;
            default:
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
                break;
        }
        fadeUI.AllScreenFadeOutLoadNextScene();
        //ResourceUI.SetActive(false);
    }
}