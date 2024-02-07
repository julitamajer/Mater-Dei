using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
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

    public delegate void EndGame();
    public static event EndGame OnEndGame;

    [SerializeField] GameObject scorePanel;
    [SerializeField] TextMeshProUGUI socrePanelText;

    [SerializeField] GameObject deadPanel;

    bool timeStop;

    private void OnEnable()
    {
        LootBehaviour.OnCollectMoney += AddScoreMoney;
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

        if  (healthBar.value <= 0 && heartCount==0)
        {
            PlayerDeadth();
        }
    }

    public void AddScoreMoney(ILootable lootable, int worth)
    {
        scoreCount += worth;

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

    private void PlayerDeadth()
    {
        deadPanel.SetActive(true);
        OnEndGame?.Invoke();
    }

    private void DecreaseHeart()
    {
        if(healthBar.value <= 0 && heartCount > 0) 
        {
            heartCount--;
            heart.SetText(" " + heartCount.ToString());
            healthBar.value = 1;
        }
    }
    private void DecreaseTime()
    {
        if (!timeStop)
        {
            if (timeCount > 0)
            {
                timeCount--;
                time.SetText("0" + timeCount.ToString());
            }
        }
    }

    private void DecreaseHealth(GameObject tagObject)
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

    private void DecreaseHealthBoss()
    {
        healthBar.value -= 0.60f;
    }

    private void DecreaseBossHealth()
    {
        enemyHealthBar.value -= 0.10f;
    }

    private void EndGameScore()
    {
        timeStop = true; 

        if(!(heartCount == 0))     
            InvokeRepeating("HeartsToPoints", 0.2f, 0.2f);
    }

    private void HeartsToPoints()
    {
        heartCount--;
        heart.SetText(" " + heartCount.ToString());

        scoreCount++;
        score.SetText(scoreCount.ToString());

        if (heartCount == 0)
        {
            CancelInvoke("HeartsToPoints");
            InvokeRepeating("TimeToPoints", 0.05f, 0.05f);
        }
    }

    private void  TimeToPoints()
    {
        timeCount--;
        time.SetText("0" + timeCount.ToString());

        scoreCount += 100;
        score.SetText(scoreCount.ToString());

        if (timeCount == 0)
        {
            scorePanel.SetActive(true);
            socrePanelText.SetText("SCORE: " + scoreCount.ToString());

            PlayerPrefs.SetInt("Highscore", scoreCount);
            PlayerPrefs.SetInt("GamePlayed", 1);

            ResetUIValues();

            OnEndGame?.Invoke();

            CancelInvoke("TimeToPoints");
        }
    }

    private void ResetUIValues()
    {
        scoreCount = 0;
        score.SetText("00000");

        healthBar.value = 1;
        enemyHealthBar.value = 1;

        axeCount = 0;
        axe.SetText("A " + "0");

        timeStop = false;

        deadPanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    private void OnDisable()
    {

        PlayerCombat.onPlayerDamage -= DecreaseHealth;

        Bullet.OnBossDamage -= DecreaseBossHealth;

        EnemyBullet.OnBossDamageOnPlayer -= DecreaseHealthBoss;
    }
}
