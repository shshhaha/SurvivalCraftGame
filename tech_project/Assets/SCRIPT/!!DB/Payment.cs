using UnityEngine;

public class Payment : UserData
{
    // 결제 시 하트 증가
    public void AddHeart()
    {
        //TODO : 하트는 메달로 구매 가능하도록 구현, 메달이 부족할 경우 하트가 증가하지 않도록 구현
        PlayerPrefs.SetInt("Heart", PlayerPrefs.GetInt("Heart") + 1);
        PlayerPrefs.Save();
    }

    // 결제 시 달러 증가
    public void AddDollar(int value)
    {
        //TODO : 달러는 메달로 구매 가능하도록 구현, 메달이 부족할 경우 달러가 증가하지 않도록 구현
        PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") + value);
        PlayerPrefs.Save();
    }

    // 결제 시 캐쉬 증가
    public void AddMedal(int value)
    {
        PlayerPrefs.SetInt("Medal", PlayerPrefs.GetInt("Medal") + value);
        PlayerPrefs.Save();
    }
    
}
