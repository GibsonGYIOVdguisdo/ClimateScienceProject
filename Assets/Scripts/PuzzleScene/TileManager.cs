using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class TileManager : MonoBehaviour
{
    public GameObject[] Tiles;
    public Vector2[] TileLocations = new Vector2[9];
    private int SelectedImageIndex = 0;
    private string SelectedImage;
    void Start()
    {
        LoadTileImages();
        RandomiseTiles();
    }

    void LoadTileImages()
    {
        string spriteLocation = "Sprites/" + SelectedImage;
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteLocation);

        SelectedImage = "Solarpower";
        for (int i = 0; i < Tiles.Length; i++)
        {
            TileLocations[i] = Tiles[i].transform.position;
            Tiles[i].GetComponent<PuzzleTile>().SetSprite(sprites[i]);
        }
    }

    void RandomiseTiles()
    {
        List<int> availableLocationIndexes = Enumerable.Range(0, TileLocations.Length).ToList();

        for (int i = 0; i < Tiles.Length - 1; i++)
        {
            int selectedIndex = Random.Range(0, availableLocationIndexes.Count);
            Tiles[i].GetComponent<PuzzleTile>().SetPosition(TileLocations[availableLocationIndexes[selectedIndex]]);
            availableLocationIndexes.RemoveAt(selectedIndex);
        }
    }
}
