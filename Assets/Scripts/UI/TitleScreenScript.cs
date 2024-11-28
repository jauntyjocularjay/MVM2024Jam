using UnityEngine;

public class TitleScreenScript : MonoBehaviour
{

    public void clickNewGame()
    {
        GameManager.GM.newGame();
    }

    public void clickLoadGame()
    {
        GameManager.GM.loadGame();
    }

    public void clickQuit()
    {
        Application.Quit();
    }


}
