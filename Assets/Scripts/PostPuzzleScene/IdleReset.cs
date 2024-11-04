using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleReset : MonoBehaviour
{
    public float TimeBeforeReset = 20;
    float TimeOnLeaderboardScreen = 0;
    
    void Update()
    {
        TimeOnLeaderboardScreen += Time.deltaTime;
        if (TimeOnLeaderboardScreen > TimeBeforeReset)
        {
            SceneManager.LoadScene("Puzzle");
        }
    }
}
