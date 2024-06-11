using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBotton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit button pressed."); // デバッグログを追加
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタで再生中は停止
#else
        Application.Quit(); // アプリケーションを終了
#endif
    }
}
