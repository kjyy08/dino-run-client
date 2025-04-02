using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject restartUI;

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.State)
        {
            case GameManager.GAME_STATE.PLAYING:
                hideGameOverUI();
                break;

            case GameManager.GAME_STATE.GAMEOVER:
                showGameOverUI();
                break;
        }
    }

    void hideGameOverUI()
    {
        restartUI.SetActive(false);
    }

    void showGameOverUI()
    {
        restartUI.SetActive(true);
    }
}
