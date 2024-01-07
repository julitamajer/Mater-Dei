using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    int moneyWorth = 1000;
    int bossLootWorth = 8000;
    int scoreCount = 0;

    [SerializeField] TextMeshProUGUI heart;
    int heartCount = 0;

    public TextMeshProUGUI axe;
    public int axeCount = 0;
    [SerializeField] GameObject axeImage;

    [SerializeField] TextMeshProUGUI time;
    [SerializeField] int timeCount;

    [SerializeField] Slider healthBar;
    [SerializeField] Slider enemyHealthBar;

    [SerializeField] Enemy nun;
    [SerializeField] Enemy priest;

    public delegate void BossKilled();
    public static event BossKilled OnBossKilled;

    private void OnEnable()
    {
        LootBehaviour.collectMoney += AddScoreMoney;
        LootBehaviour.collectHeart += AddHeart;
        LootBehaviour.collectAxe += AddAxe;
        LootBehaviour.collectBossLoot += AddScoreBossLoot;

        PlayerCombat.onPlayerDamage += DecreaseHealth;

        Bullet.OnBossDamage += DecreaseBossHealth;

        EnemyBullet.OnBossDamageOnPlayer += DecreaseHealthBoss;


    }

    private void Start()
    {
        score.SetText("00000");
        InvokeRepeating("DecreaseTime", 1f, 1f);
    }

    private void Update()
    {
        ShowAxe();
        DecreaseHeart();

        if(enemyHealthBar.value <= 0)
        {
            OnBossKilled?.Invoke();
        }
    }

    private void AddScoreMoney()
    {
        scoreCount += moneyWorth;

        if(scoreCount <= 9999)
            score.SetText("0" + scoreCount.ToString());

        if(scoreCount >= 10000)
            score.SetText(scoreCount.ToString());
    }

    private void AddScoreBossLoot()
    {
        scoreCount += bossLootWorth;

        if (scoreCount <= 9999)
            score.SetText("0" + scoreCount.ToString());

        if (scoreCount >= 10000)
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

    void DecreaseHeart()
    {
        if(healthBar.value <= 0) 
        {
            heartCount--;
            heart.SetText(" " + heartCount.ToString());
            healthBar.value = 1;
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

    void DecreaseHealth(GameObject tagObject)
    {
        switch (tagObject.tag)
        {
            case "Nun":
                healthBar.value -= nun.damage;
                break;
            case "Priest":
                healthBar.value -= priest.damage;
                break;
        }
    }

    void DecreaseHealthBoss()
    {
        healthBar.value -= 0.60f;
    }

    void DecreaseBossHealth()
    {
        enemyHealthBar.value -= 0.10f;
    }

    private void OnDisable()
    {
        LootBehaviour.collectMoney -= AddScoreMoney;
        LootBehaviour.collectHeart -= AddHeart;
        LootBehaviour.collectAxe -= AddAxe;

        PlayerCombat.onPlayerDamage -= DecreaseHealth;

        Bullet.OnBossDamage -= DecreaseBossHealth;

        EnemyBullet.OnBossDamageOnPlayer -= DecreaseHealthBoss;
    }
}
