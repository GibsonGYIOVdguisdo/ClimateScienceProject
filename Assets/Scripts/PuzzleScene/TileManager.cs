using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class TileManager : MonoBehaviour
{
    public GameObject[] Tiles;
    public Vector2[] PossibleTileLocations = new Vector2[9];
    public int[] TileLocations = new int[9];

    private int SelectedImageIndex = 0;
    private string SelectedImage;
    private int EmptyTile;
    void Start()
    {
        LoadTileImages();
        RandomiseTiles();
        Debug.Log(GetEmptySpace());
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

        for (int i = 0; i < Tiles.Length - 1; i++)
        {
            int selectedIndex = Random.Range(0, availableLocationIndexes.Count);
            Tiles[i].GetComponent<PuzzleTile>().SetPosition(PossibleTileLocations[availableLocationIndexes[selectedIndex]]);
            TileLocations[i] = availableLocationIndexes[selectedIndex];
            availableLocationIndexes.RemoveAt(selectedIndex);
        }
        Destroy(Tiles[8].gameObject);
        TileLocations[availableLocationIndexes[0]] = -1;
    }

    int GetEmptySpace()
    {
        for (int i = 0; i < TileLocations.Length; i++)
        {
            if (TileLocations[i] == -1)
            {
                return i;
            }
        }
        return -1;
    }
}
