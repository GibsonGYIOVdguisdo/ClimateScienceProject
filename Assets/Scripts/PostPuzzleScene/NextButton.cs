using UnityEngine;

using UnityEngine.SceneManagement;
public class NextButton : MonoBehaviour
{
    public GameManager GameManager;
    private void Start()
    {
        GameManager.ItterateSpriteIndex();
    }
    public void GoToNextPuzzle()
    {
        SceneManager.LoadScene("Puzzle");
    }
}
