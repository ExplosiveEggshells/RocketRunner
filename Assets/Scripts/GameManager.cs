using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ResetLevel();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            ExitGame();
        }
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene("Runner");
    }

    private void ExitGame()
    {
        Application.Quit(0);
    }
}
