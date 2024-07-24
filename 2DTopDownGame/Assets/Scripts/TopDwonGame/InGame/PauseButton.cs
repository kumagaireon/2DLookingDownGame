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
        Cursor.visible = false; // �Q�[���J�n���ɃJ�[�\����\��
        Cursor.lockState = CursorLockMode.None; // �J�[�\�������b�N���Ȃ�
    }

    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ�玞�Ԃ��~�߂�/�i�߂�
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
        Cursor.visible = true; // �J�[�\����\��
        Cursor.lockState = CursorLockMode.None; // �J�[�\�������b�N���Ȃ�
        Debug.Log("���Ԃ��~�܂�܂���");
    }

    private void ResumeTime()
    {
        Time.timeScale = 1f;
        isTimeStopped = false;
        Title.gameObject.SetActive(false);
        Result.gameObject.SetActive(false);
        Cursor.visible = false; // �J�[�\�����\��
        Cursor.lockState = CursorLockMode.Locked; // �J�[�\�������b�N
        Debug.Log("���Ԃ��i�݂܂���");
    }
}