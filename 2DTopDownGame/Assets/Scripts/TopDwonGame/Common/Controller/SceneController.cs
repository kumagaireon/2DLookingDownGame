using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Text resultText;

    
    public void Title()
    {
        GameManager.Instance.state = GameManager.States.Title;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/TitleScene");
    }
    public void InGame()
    {
        GameManager.Instance.state = GameManager.States.InGame;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/InGameScene");
    }
    public void Result()
    {
        GameManager.Instance.state = GameManager.States.Result;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Scenes/ResultScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "ResultScene")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            resultText = GameObject.Find("ResultText").GetComponent<Text>();
            if (resultText != null)
            {
                DisplayResults();
            }
        }
    }

    private void DisplayResults()
    {
        resultText.text = $"ÉNÉäÉAéûä‘: {TimeAndKill.GameTimer:F2} \nì|ÇµÇΩêî: {TimeAndKill.EnemyKill}";
        Debug.Log(resultText.text);
    }
}