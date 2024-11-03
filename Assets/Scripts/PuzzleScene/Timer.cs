using TMPro;
using UnityEngine;

public class Timer: MonoBehaviour
{
    private float TimePassed = 0;
    private bool IsRunning = true;
    private TMP_Text TMP;

    private void Start()
    {
        TMP = gameObject.GetComponent<TMP_Text>();
    }

    void Update(){
      if (IsRunning == true){
        TimePassed = TimePassed += Time.deltaTime;
        TMP.text = Mathf.Floor(TimePassed).ToString();
      }
    }

    public void StartTimer(){
      IsRunning = true;
    }

    public float GetCurrentTime(){
      return TimePassed;
    }
}
