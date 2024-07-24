using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private bool isTimeStopped = false;
    [SerializeField] Button Title;
    [SerializeField] Button Result;

    private void Start()
    {
        Time.timeScale = 1f;
        isTimeStopped = false;
        Title.gameObject.SetActive(false);
        Result.gameObject.SetActive(false);
        Cursor.visible = false; // ゲーム開始時にカーソルを表示
        Cursor.lockState = CursorLockMode.None; // カーソルをロックしない
    }

    void Update()
    {
        // スペースキーが押されたら時間を止める/進める
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTimeStopped)
            {
                ResumeTime();
            }
            else
            {
                StopTime();
            }
        }
    }

    private void StopTime()
    {
        Time.timeScale = 0f;
        isTimeStopped = true;
        Title.gameObject.SetActive(true);
        Result.gameObject.SetActive(true);
        Cursor.visible = true; // カーソルを表示
        Cursor.lockState = CursorLockMode.None; // カーソルをロックしない
        Debug.Log("時間が止まりました");
    }

    private void ResumeTime()
    {
        Time.timeScale = 1f;
        isTimeStopped = false;
        Title.gameObject.SetActive(false);
        Result.gameObject.SetActive(false);
        Cursor.visible = false; // カーソルを非表示
        Cursor.lockState = CursorLockMode.Locked; // カーソルをロック
        Debug.Log("時間が進みました");
    }
}