using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Timer timer;
    TileManager TileManager;

    static int SpriteIndex = 0;
    static List<string> SpriteFileNames = new List<string> { "Solarpower", "Windpower" };
    static List<string> SpriteTitles = new List<string> { "Solarpanels", "Wind turbines" };
    static List<string> SpriteDescriptions = new List<string> { "Solarpanels absorb light from the sun to generate electricity", "Wind turbines use the wind to generate electricity" };
    static List<float> Times = new List<float>();
    static float LastTime = 0;

    private void Start()
    {
        if (gameObject.name == "GameManager")
        {
            timer = FindFirstObjectByType<Timer>();
            TileManager = FindFirstObjectByType<TileManager>();
            TileManager.LoadTileImages(SpriteFileNames[SpriteIndex]);
            TileManager.RandomiseTiles();
        }
    }
    public void StartGame()
    {
        timer.StartTimer();

    }
    public void EndGame()
    {
        float currentTime = timer.GetCurrentTime();
        Times.Add(currentTime);
        LastTime = currentTime;
        Times.Sort();
        SceneManager.LoadScene("PostPuzzle");
    }

    public static string GetImageLocation()
    {
        return $"Sprites/{SpriteFileNames[SpriteIndex]}";
    }
    public static string GetSpriteTitle()
    {
        return SpriteTitles[SpriteIndex];
    }
    public static string GetSpriteDescription()
    {
        return SpriteDescriptions[SpriteIndex];
    }
    public static void ItterateSpriteIndex()
    {
        SpriteIndex += 1;
        if (SpriteIndex >= SpriteFileNames.Count)
        {
            SpriteIndex = 0;
        }
    }
    public static float GetLastTime()
    {
        return LastTime;
    }

    public static int GetLastPlacement()
    {
        return Times.IndexOf(LastTime) + 1;
    }

    public static List<float> GetAllTimes()
    {
        return Times;
    }
}
