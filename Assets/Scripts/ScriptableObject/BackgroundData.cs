using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundData", menuName = "Scriptable Objects/BackgroundData")]
public class BackgroundData : ScriptableObject
{
    [SerializeField][Range(1f, 200f)] private float backgroundSpeed = 3f;

    public float BackgroundSpeed
    {
        get => backgroundSpeed;
        set => backgroundSpeed = Mathf.Clamp(value, 1f, 200f); // 범위 제한
    }
}
