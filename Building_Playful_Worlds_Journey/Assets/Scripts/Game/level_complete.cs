using UnityEngine;
using UnityEngine.SceneManagement;

public class level_complete : MonoBehaviour
{
    public Score score;
    // Start is called before the first frame update

    void LoadNextLevel()
    {
        Score.scoreAmount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
