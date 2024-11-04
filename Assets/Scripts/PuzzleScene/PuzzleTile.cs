using UnityEngine;
using UnityEngine.U2D;
public class PuzzleTile : MonoBehaviour
{
    public int TileIndex;
    private Vector2 OriginalPosition;
    private TileManager TileManager;

    private void Start()
    {
        TileManager = FindFirstObjectByType<TileManager>();
        OriginalPosition = transform.position;
    }

    public void SetSprite(Sprite sprite)
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
    }

    public bool IsInCorrectPosition()
    {
        Vector2 currentPosition = transform.position;
        return OriginalPosition == currentPosition;
    }

    public void SetPosition(Vector2 position)
    {
        gameObject.transform.position = position;
    }

    public void MoveTile()
    {
        if (TileManager.CanTileMove(TileIndex))
        {
            int EmptySpace = TileManager.FindTileSpaceIndex(-1);
            Vector2 EmptySpaceLocation = TileManager.GetLocationOfTileSpace(EmptySpace);
            SetPosition(EmptySpaceLocation);
            TileManager.UpdateTileLocation(TileIndex);
        }
    }
}
