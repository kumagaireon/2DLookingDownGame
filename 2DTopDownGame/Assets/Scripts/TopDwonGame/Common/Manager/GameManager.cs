using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehehaviour<GameManager>
{
    public enum States
    {
        Title,
        InGame,
        Result
    }
    public States state = States.Title;
    private void Update()
    {
        PlayType();
        GameQuit();
    }
    private void PlayType()
    {
        switch (state)
        {
            case States.Title:
                MouseCursorOn();
                break;
            case States.InGame:
                break;
            case States.Result:
                MouseCursorOn();
                break;
        }
    }


    private void MouseCursorOn()
    {
        Cursor.visible = true; // カーソルを表示
        Cursor.lockState = CursorLockMode.None;
    }
    /// <summary>
    /// ゲーム終了処理
    /// </summary>
    private void GameQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void SetState(States nextState)
    {
        state = nextState;
    }

    /// <summary>
    /// 現在のゲームステートを比較
    /// </summary>
    /// <param name="state">比較するステート</param>
    /// <returns>ステートが一定:true/false</returns>
    public bool CompareState(States state)
    {
        return this.state == state;
    }
}
