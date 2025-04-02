using TMPro;
using UnityEngine;

public class GameStartUI : MonoBehaviour
{
    private TextMeshProUGUI pressToStartText;

    private void Awake()
    {
        pressToStartText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.State)
        {
            case GameManager.GAME_STATE.PLAYING:
            case GameManager.GAME_STATE.PAUSED:
            case GameManager.GAME_STATE.GAMEOVER:
                hideUI();
                break;

            default:
                showUI();
                break;
        }
    }

    void showUI()
    {
        pressToStartText.enabled = true;
    }

    void hideUI()
    {
        pressToStartText.enabled = false;
    }
}
