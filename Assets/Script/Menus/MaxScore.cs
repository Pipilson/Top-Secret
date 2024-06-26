using UnityEngine;

public class MaxScore : MonoBehaviour
{
    [HideInInspector] public int vitoria, jogadoresTotal;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}