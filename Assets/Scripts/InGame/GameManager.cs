using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GAME_STATE state = GAME_STATE.PREGAME;
    [SerializeField] private float speedIncreaseInterval = 100f; // 100������ �ӵ� ����
    [SerializeField] private float speedMultiplier = 0.1f; // �ӵ� ������
    [SerializeField] private float maxSpeed = 2f; // �ִ� �ӵ� ����
    [SerializeField] private ScoreData scoreData;

    public CactusManager cactusManager;
    public enum GAME_STATE { PREGAME, PLAYING, PAUSED, GAMEOVER }

    private float currentTimeScale = 0.0f;

    void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            // disable WebGLInput.captureAllKeyboardInput so elements in web page can handle keabord inputs
            WebGLInput.captureAllKeyboardInput = false;
        #endif
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case GAME_STATE.PREGAME:
                StartGame();
                break;

            case GAME_STATE.PLAYING:
                UpdateGameSpeed();
                break;

            case GAME_STATE.PAUSED:
                PauseGame();
                break;

            case GAME_STATE.GAMEOVER:
                GameOver();
                break;
        }
    }

    public GAME_STATE State 
    {
        get { return state; }
    }

    public void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentTimeScale = 1f;
            Time.timeScale = currentTimeScale;
            cactusManager.StartSpawning();
            state = GAME_STATE.PLAYING;
        }
    }

    void UpdateGameSpeed()
    {
        // ������ ���� �������� ������ �� �ӵ� ����
        float newSpeed = 1f + (scoreData.Score / speedIncreaseInterval) * speedMultiplier;

        // �ִ� �ӵ� ���� ����
        currentTimeScale = Mathf.Clamp(newSpeed, 1f, maxSpeed);
        Time.timeScale = currentTimeScale;
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = currentTimeScale;
            state = GAME_STATE.PLAYING;
        }
        else
        {
            Time.timeScale = 0f;
            state = GAME_STATE.PAUSED;
        }
    }

    public void GameOver()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            RestartGame();
            return;
        }

        Time.timeScale = 0f;
        state = GAME_STATE.GAMEOVER;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
