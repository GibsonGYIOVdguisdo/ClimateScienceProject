using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
public class TileManager : MonoBehaviour
{
    public GameObject[] Tiles;
    public Vector2[] PossibleTileLocations = new Vector2[9];
    // Index is the Index used to identify the tile, value is the index of the space
    public int[] TileLocations = new int[9];

    private int SelectedImageIndex = 0;
    private string SelectedImage;
    private int EmptyTile;
    void Start()
    {
        LoadTileImages();
        RandomiseTiles();
    }

    private void Update()
    {
    }

    void LoadTileImages()
    {
        string spriteLocation = "Sprites/" + SelectedImage;
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteLocation);

        SelectedImage = "Solarpower";
        for (int i = 0; i < Tiles.Length; i++)
        {
            PossibleTileLocations[i] = Tiles[i].transform.position;
            Tiles[i].GetComponent<PuzzleTile>().SetSprite(sprites[i]);
        }
    }

    void RandomiseTiles()
    {
        List<int> availableLocationIndexes = Enumerable.Range(0, PossibleTileLocations.Length).ToList();

        for (int i = 0; i < Tiles.Length; i++)
        {
            int selectedIndex = UnityEngine.Random.Range(0, availableLocationIndexes.Count);
            Tiles[i].GetComponent<PuzzleTile>().SetPosition(PossibleTileLocations[availableLocationIndexes[selectedIndex]]);
            TileLocations[i] = availableLocationIndexes[selectedIndex];
            Debug.Log($"tile {i} was placed {availableLocationIndexes[selectedIndex]}");
            availableLocationIndexes.RemoveAt(selectedIndex);
        }
        Destroy(Tiles[8].gameObject);
    }

    public int FindTileSpaceIndex(int tileIndex)
    {
        if (tileIndex == -1) {
            // Tile 8 is the deleted tile
            return TileLocations[8];
        }
        return TileLocations[tileIndex];
    }

    public Vector2 GetLocationOfTileSpace(int index)
    {
        return PossibleTileLocations[index];
    }
    public void UpdateTileLocation(int tileIndex)
    {
        int emptySpaceIndex = FindTileSpaceIndex(-1);
        int tileSpaceIndex = FindTileSpaceIndex(tileIndex);
        Debug.Log($"{tileIndex} has moved from {tileSpaceIndex} to {emptySpaceIndex}");
        TileLocations[8] = tileSpaceIndex;
        TileLocations[tileIndex] = emptySpaceIndex;
    }
}
