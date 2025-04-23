using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void GoToScene() 
    {
        StaticValues.levelNumber = 0;
        SceneManager.LoadScene("CategoryScene");
    }

    public void NextScene()
    {
        if(StaticValues.levelNumber < StaticValues.currentLevelLength)
        {
            SceneManager.LoadScene("GameScene");
        }
        else if(StaticValues.levelNumber == 0)
        {
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            SceneManager.LoadScene("EndScene");
        }
    }



}
