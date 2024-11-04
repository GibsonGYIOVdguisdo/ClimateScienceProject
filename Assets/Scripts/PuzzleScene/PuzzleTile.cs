using UnityEngine;
using UnityEngine.U2D;
public class PuzzleTile : MonoBehaviour
{
    public int TileIndex;
    private Vector2 OriginalPosition;

    private void Start()
    {
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
}
