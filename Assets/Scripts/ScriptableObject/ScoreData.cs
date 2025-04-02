using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Scriptable Objects/ScoreData")]
public class ScoreData : ScriptableObject
{
    [SerializeField] private float score = 0f;
    [SerializeField] private float highScore = 0f;
    [SerializeField] private float scoreMultiplier = 10f; // 점수 증가 속도

    public void ResetScore()
    {
        score = 0f;
    }

    public void AddScore(float amount)
    {
        score += amount;
    }

    public int Score
    {
        get { return (int)score; }
    }

    public int HighScore
    {
        get { return (int)highScore; } 
        set { highScore = value; } 
    }

    public float ScoreMultiplier
    {
        get { return scoreMultiplier; }
        set { scoreMultiplier = value; }
    }
}
