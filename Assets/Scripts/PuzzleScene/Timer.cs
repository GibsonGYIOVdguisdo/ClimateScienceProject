using UnityEngine;

public class Timer: MonoBehaviour
{
    private float TimePassed = 0;
    void Update(){
      TimePassed = TimePassed += Time.deltaTime;
    }
}
