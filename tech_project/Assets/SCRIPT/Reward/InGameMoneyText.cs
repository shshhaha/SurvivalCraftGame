using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTO.MoneyDTO;
using TMPro;

public class InGameMoneyText : MonoBehaviour
{
    private MoneyDTO moneyDTO;
    
    public TextMeshProUGUI moneyText;

    private int money;

    // Start is called before the first frame update
    void Start()
    {
        moneyDTO = MoneyDTO.Instance;
        moneyDTO.setMoney(50);
        moneyText.fontSize = 30f;
        moneyText.margin = new Vector4(0f,0f,10f,0f);
        money = (int)moneyDTO.getMoney();
        moneyText.text = money.ToString();
    }

    void FixedUpdate()
    {
        updateMoneyText();
    }
    void updateMoneyText(){
        money = (int)moneyDTO.getMoney();
        moneyText.text = money.ToString();
    }
}
