using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IdleReset : MonoBehaviour
{
    public float MaxIdleTime = 20;
    float CurrentIdleTime = 0;
	public bool Running = false;

    private void Update()
	{
		if (Running)
		{
			CurrentIdleTime += Time.deltaTime;
			if (CurrentIdleTime > MaxIdleTime)
			{
				SceneManager.LoadScene("Puzzle");
			}
		}
	}

	public void StartTimer()
	{
		Running = true;
	}
	public void ResetTimer()
	{
		CurrentIdleTime = 0;
    }

}
