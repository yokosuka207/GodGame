using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text levelText;
    public Image expBar;
    public Image hpBar;

    void Update()
    {
        UpdateLevelText();
        UpdateExpBar();
        UpdateHpBar();
    }

    public void UpdateLevelText()
    {
        levelText.text = PlayerLevel.instance.level.ToString();
    }

    public void UpdateExpBar()
    {
        expBar.fillAmount = PlayerLevel.instance.experiencePoints / PlayerLevel.instance.levelUpBorder;
    }

    public void UpdateHpBar()
    {
        hpBar.fillAmount = PlayerHealth.instance.nowHealth / PlayerHealth.instance.maxHealth;
    }
}
