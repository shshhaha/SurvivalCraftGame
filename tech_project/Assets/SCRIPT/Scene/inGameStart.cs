using UnityEngine;
using DTO.MoneyDTO;

public class inGameStart : MonoBehaviour
{
    private MoneyDTO point;
    void Start()
    {
        point = MoneyDTO.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
