using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToTitleButton : MonoBehaviour
{
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title Scene"); // タイトルシーンに遷移
    }
}
