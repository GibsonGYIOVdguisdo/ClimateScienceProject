using UnityEngine;

public class Timer: MonoBehaviour
{
    private float TimePassed = 0;
    private bool IsRunning = false;
    void Update(){
      if (isRunning == true){
        TimePassed = TimePassed += Time.deltaTime;
      }
    }

    public void StartTimer(){
      IsRunning = true;
    }

    public float GetCurrentTime(){
      return TimePassed;
    }
}
