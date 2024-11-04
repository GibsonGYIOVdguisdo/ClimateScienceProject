using UnityEngine;

using UnityEngine.SceneManagement;
public class NextButton : MonoBehaviour
{
    public GameManager GameManager;
    public void GoToNextPuzzle()
    {
        GameManager.ItterateSpriteIndex();
        SceneManager.LoadScene("Puzzle");
    }
}
