using UnityEngine;
using System;
using System.Collections.Generic;
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
        timer = FindFirstObjectByType<Timer>();
        TileManager = FindFirstObjectByType<TileManager>();
        TileManager.LoadTileImages(SpriteFileNames[SpriteIndex]);
        TileManager.RandomiseTiles();
    }
    public void StartGame()
    {
        timer.StartTimer();
    }
    public void EndGame()
    {

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
    public static void SetSpriteIndex(int index)
    {
        SpriteIndex = index;
    }
}
