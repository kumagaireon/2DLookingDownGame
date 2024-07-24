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
        //SetCursorLock();
        PlayType();
        GameQuit();
    }
    private void PlayType()
    {
        switch (state)
        {
            case States.Title:
                break;
            case States.InGame:
                break;
            case States.Result:
                if (Input.GetMouseButtonDown(1))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                break;
        }
    }

    /// <summary>
    /// �Q�[���I������
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
    /// ���݂̃Q�[���X�e�[�g���r
    /// </summary>
    /// <param name="state">��r����X�e�[�g</param>
    /// <returns>�X�e�[�g�����:true/false</returns>
    public bool CompareState(States state)
    {
        return this.state == state;
    }
}
