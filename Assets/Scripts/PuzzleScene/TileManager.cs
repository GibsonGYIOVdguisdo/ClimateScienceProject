using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
public class TileManager : MonoBehaviour
{
    public IdleReset IdleReset;
    public int RandomiseAmount = 20;
    private GameManager GameManager;
    public GameObject[] Tiles;
    public Vector2[] PossibleTileLocations = new Vector2[9];
    // Index is the Index used to identify the tile, value is the index of the space
    public int[] TileLocations = new int[9];

    private int SelectedImageIndex = 0;

    private int EmptyTile;
    bool FirstMove = true;
    bool Randomising = false;
    void Start()
    {
        GameManager = FindFirstObjectByType<GameManager>();
    }

    public void LoadTileImages(string imageToLoad)
    {
        string spriteLocation = "Sprites/" + imageToLoad;
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteLocation);
        for (int i = 0; i < Tiles.Length; i++)
        {
            TileLocations[i] = i;
            PossibleTileLocations[i] = Tiles[i].transform.position;
            Tiles[i].GetComponent<PuzzleTile>().SetSprite(sprites[i]);
            Tiles[i].GetComponent<PuzzleTile>().SetTileManager(gameObject.GetComponent<TileManager>());
        }
    }

    public void RandomiseTiles()
    {
        Randomising = true;
        Destroy(Tiles[8].gameObject);
        int lastMovedTile = -1;
        for (int i = 0; i < RandomiseAmount; i++)
        {
            List<int> movableTiles = new List<int>();
            for (int j = 0; j < Tiles.Length-1; j++)
            {
                if (lastMovedTile != j && CanTileMove(j))
                {
                    movableTiles.Add(j);
                }
            }
            int randomTile = UnityEngine.Random.Range(0, movableTiles.Count);
            Tiles[movableTiles[randomTile]].GetComponent<PuzzleTile>().MoveTile();
            lastMovedTile = movableTiles[randomTile];

        }
        Randomising = false;
    }

    public int FindTileSpaceIndex(int tileIndex)
    {
        if (tileIndex == -1)
        {
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
        TileLocations[8] = tileSpaceIndex;
        TileLocations[tileIndex] = emptySpaceIndex;
        if (IsPuzzleComplete() && Randomising == false)
        {
            GameManager.EndGame();
        }
        if (FirstMove && Randomising == false)
        {
            GameManager.StartGame();
            IdleReset.StartTimer();
        }
        IdleReset.ResetTimer();
    }

    bool IsPuzzleComplete()
    {
        for (int i = 0; i < TileLocations.Length; i++)
        {
            if (i != TileLocations[i])
            {
                return false;
            }
        }
        return true;
    }

    public bool CanTileMove(int tileIndex)
    {
        int SpaceOfTile = FindTileSpaceIndex(tileIndex);
        int SpaceOfEmpty = FindTileSpaceIndex(-1);
        // Checks vertical movement
        if (Mathf.Abs(SpaceOfTile - SpaceOfEmpty) == 3)
        {
            return true;
        }
        // Checks movement to the right
        if (Mathf.Abs(SpaceOfTile % 3) != 2)
        {
            if ((SpaceOfTile + 1) == SpaceOfEmpty){
                return true;
            }
        }
        // Checks movement to the left
        if (Mathf.Abs(SpaceOfTile % 3) != 0)
        {
            if ((SpaceOfTile - 1) == SpaceOfEmpty)
            {
                return true;
            }
        }
        return false;
    }
}
