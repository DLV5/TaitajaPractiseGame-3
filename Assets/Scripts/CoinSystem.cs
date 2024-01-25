using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public static CoinSystem instance;
    [SerializeField] private TMP_Text _coinsText;
    private int _coins;
    private void Awake()
    {
        instance = this;
        _coins = 0;
        UpdateCoinsText(_coins);
    }
    public void AddCoin()
    {
        _coins += 1;
        UpdateCoinsText(_coins);
    }
    private void UpdateCoinsText(int coins)
    {
        _coinsText.text = coins.ToString();
    }
}
