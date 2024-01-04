using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    int moneyWorth = 1000;
    int scoreCount = 0;

    private void OnEnable()
    {
        LootBehaviour.collectMoney += AddScoreMoney;
    }

    private void Start()
    {
        score.SetText(scoreCount.ToString());
    }

    private void AddScoreMoney()
    {
        scoreCount += moneyWorth;
        score.SetText(scoreCount.ToString());
    }

    private void OnDisable()
    {
        LootBehaviour.collectMoney -= AddScoreMoney;
    }
}
