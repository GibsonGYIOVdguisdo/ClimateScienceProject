using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class LoadImageInfo : MonoBehaviour
{
    public GameObject ImageParent;
    public GameObject ImageTitleText;
    public GameObject ImageDescriptionText;
    private GameManager GameManager;
    private GameObject[] Tiles = new GameObject[9];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager = gameObject.GetComponent<GameManager>();
        Tiles = GetImageTiles();
        LoadImage();
        ImageTitleText.GetComponent<TMP_Text>().text = GameManager.GetSpriteTitle();
        ImageDescriptionText.GetComponent<TMP_Text>().text = GameManager.GetSpriteDescription();
    }

    void LoadImage()
    {
        string spriteLocation = GameManager.GetImageLocation();
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteLocation);
        for (int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i].GetComponent<PuzzleTile>().SetSprite(sprites[i]);
        }
    }

    GameObject[] GetImageTiles()
    {
        GameObject[] tiles = new GameObject[9];
        for (int i = 0; i < tiles.Length; i ++)
        {
            tiles[i] = ImageParent.transform.GetChild(i).gameObject;
        }
        return tiles;
    }

}
