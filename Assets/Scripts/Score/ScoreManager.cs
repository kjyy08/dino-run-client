using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;
    private bool isHighScoreSent = false;

    [DllImport("__Internal")]
    private static extern void SendHighScoreToJS(int highScore);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreData.ResetScore();
        isHighScoreSent = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.State)
        {
            case GameManager.GAME_STATE.PLAYING:
                SetCurrentScore();
                isHighScoreSent = false;
                break;

            case GameManager.GAME_STATE.GAMEOVER:
                SetCurrentScore();
                SetHighScore();
                if (!isHighScoreSent)
                {
                    SendHighScore();
                    isHighScoreSent = true;
                }
                break;
        }

    }

    void SetCurrentScore()
    {
        float speedFactor = 1f + (Time.timeSinceLevelLoad / 100f);
        scoreData.AddScore(scoreData.ScoreMultiplier * speedFactor * Time.deltaTime);
    }

    void SetHighScore()
    {
        if (scoreData.HighScore < scoreData.Score)
        {
            scoreData.HighScore = scoreData.Score;
        }
    }

    void SendHighScore()
    {
        int highScore = scoreData.HighScore;

        #if UNITY_WEBGL && !UNITY_EDITOR
            SendHighScoreToJS(highScore);
        #endif
    }

}
