using UnityEngine;
using System;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    Timer timer;
    TileManager TileManager;

    static int SpriteIndex = 0;
    public List<string> SpriteFileNames;
    public List<string> SpriteTitles;
    public List<string> SpriteDescriptions;

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
}
