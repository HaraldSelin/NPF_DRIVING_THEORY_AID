using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void GoToScene() 
    {
        StaticValues.levelNumber = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void NextScene()
    {
        SceneManager.LoadScene("GameScene");
    }



}
