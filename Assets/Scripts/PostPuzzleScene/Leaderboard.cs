using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class Leaderboard : MonoBehaviour
{
    public GameObject TimeText;
    public GameObject PersonalPlacementText;
    public GameObject PersonalTimeText;

    void Start()
    {
        List<float> scores = GameManager.GetAllTimes();
        string newText = "";

        for (int i = 0; i < 10; i++)
        {
            if (i >= scores.Count)
            {
                newText += "0\n";
            }
            else
            {
                newText += Mathf.Floor(scores[i]) + "\n";
            }
        }
        TimeText.GetComponent<TMP_Text>().text = newText;
        PersonalTimeText.GetComponent<TMP_Text>().text = Mathf.Floor(GameManager.GetLastTime()).ToString();
        PersonalPlacementText.GetComponent<TMP_Text>().text = GameManager.GetLastPlacement().ToString();
    }
}
