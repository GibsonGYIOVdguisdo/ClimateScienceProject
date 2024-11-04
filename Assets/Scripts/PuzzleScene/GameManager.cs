using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Timer timer;
    TileManager TileManager;

    static int SpriteIndex = 0;
    static List<string> SpriteFileNames = new List<string> {"Solarpower"};
    static List<string> SpriteTitles = new List<string> { "Solarpanels" };
    static List<string> SpriteDescriptions = new List<string> { "Solarpanels absorb light from the sun to generate electricity" };

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
}
