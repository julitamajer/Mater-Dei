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

    [SerializeField] TextMeshProUGUI heart;
    int heartCount = 0;

    public TextMeshProUGUI axe;
    public int axeCount = 0;
    [SerializeField] GameObject axeImage;

    [SerializeField] TextMeshProUGUI time;
    [SerializeField] int timeCount;

    private void OnEnable()
    {
        LootBehaviour.collectMoney += AddScoreMoney;
        LootBehaviour.collectHeart += AddHeart;
        LootBehaviour.collectAxe += AddAxe;
    }

    private void Start()
    {
        score.SetText("00000");
        InvokeRepeating("DecreaseTime", 1f, 1f);
    }

    private void Update()
    {
        ShowAxe();
    }

    private void AddScoreMoney()
    {
        scoreCount += moneyWorth;

        if(scoreCount <= 9999)
            score.SetText("0" + scoreCount.ToString());

        if(scoreCount >= 10000)
            score.SetText(scoreCount.ToString());
    }

    private void AddHeart()
    {
        heartCount++;
        heart.SetText(" " + heartCount.ToString());
    }

    private void AddAxe()
    {
        axeCount++;
        axe.SetText("A " + axeCount.ToString());
    }

    private void ShowAxe()
    {
        if(axeCount > 0) 
        {
            axeImage.SetActive(true);
        }
        else
        {
            axeImage.SetActive(false);
        }
    }

    private void DecreaseTime()
    {
            if (timeCount > 0)
            {
                timeCount--;
                time.SetText("0" + timeCount.ToString());
            }
    }

    private void OnDisable()
    {
        LootBehaviour.collectMoney -= AddScoreMoney;
        LootBehaviour.collectHeart -= AddHeart;
        LootBehaviour.collectAxe -= AddAxe;
    }
}
