using UnityEngine;

using UnityEngine.SceneManagement;
public class NextButton : MonoBehaviour
{
    public GameManager GameManager;
    private void Start()
    {
        Invoke("ChangeSpriteIndex", (float)0.2);
    }

    void ChangeSpriteIndex()
    {
        GameManager.ItterateSpriteIndex();
    }

    public void GoToNextPuzzle()
    {
        SceneManager.LoadScene("Puzzle");
    }
}
