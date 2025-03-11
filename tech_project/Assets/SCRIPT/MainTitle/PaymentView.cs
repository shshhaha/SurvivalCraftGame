using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaymentView : MonoBehaviour
{
    [SerializeField] private Button hartButton;
    [SerializeField] private Button dollarButton;
    [SerializeField] private Button medalButton;

    public Payment payment;

    void Start()
    {
        hartButton.onClick.AddListener(hartAddButton);
        dollarButton.onClick.AddListener(dollarAddButton);
        medalButton.onClick.AddListener(medalAddButton);
    }

    public void hartAddButton()
    {
        payment.AddHeart();
    }

    public void dollarAddButton()
    {
        payment.AddDollar(1000);
        
    }

    public void medalAddButton()
    {
        payment.AddMedal(1000);
       
    }
}
