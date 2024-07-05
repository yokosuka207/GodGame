using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScreen : MonoBehaviour
{
    public Text killCountText;

    void OnEnable()
    {
        killCountText.text = "Enemies Defeated: " + GameManager.enemyKillCount;
    }
}
