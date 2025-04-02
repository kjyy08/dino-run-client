using UnityEngine;

public class ScoreAudioControl : MonoBehaviour
{
    void Play()
    {
        AudioManager.Instance.PlayOneShotAudioClip("coin");
    }
}
