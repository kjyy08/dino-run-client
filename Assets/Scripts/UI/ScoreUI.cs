using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Animator anim;
    
    void Start()
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch(GameManager.Instance.State)
        {
            case GameManager.GAME_STATE.PLAYING:
                UpdateScore();
                break;

            case GameManager.GAME_STATE.GAMEOVER:
                UpdateHighScore();
                break;
        }

    }

    void UpdateScore()
    {
        scoreText.text = scoreData.Score.ToString("D5");

        if (scoreData.Score > 0 && scoreData.Score % 100 == 0)
        {
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.normalizedTime >= 1.0f)
            {
                anim.SetTrigger("doScoreEffect"); 
            }
        }
    }

    void UpdateHighScore()
    {
        highScoreText.text = "HI " + scoreData.HighScore.ToString("D5");
    }
}
