using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timeRemainingDisplayText;
    private float timeRemaining=300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeRemainingDisplay();
        timeRemaining -= Time.deltaTime;
        UpdateTimeRemainingDisplay();

        if (timeRemaining <= 0f)
        {
            EndRound();
        }
    }
    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }
    private void EndRound()
    {
        SceneManager.LoadScene("QuizScene");
    }
}
