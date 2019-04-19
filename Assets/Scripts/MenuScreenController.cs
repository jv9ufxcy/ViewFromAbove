using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScreenController : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "SampleScene", quizSceneName = "QuizScene", menuSceneName = "MenuScene";
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void StartQuiz()
    {
        SceneManager.LoadScene(quizSceneName);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
