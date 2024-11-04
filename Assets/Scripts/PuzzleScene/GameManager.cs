using UnityEngine;

public class GameManager : MonoBehaviour
{
    Timer timer;

    private void Start()
    {
        timer = FindFirstObjectByType<Timer>();
    }
    public void StartGame()
    {
        timer.StartTimer();
    }
    public void EndGame()
    {

    }
}
