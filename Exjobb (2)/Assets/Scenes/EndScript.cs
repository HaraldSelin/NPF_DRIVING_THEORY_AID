using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class EndScript : MonoBehaviour
{

    public TMP_Text EndText;

    void OnEnable()
    {
        SceneManager.sceneLoaded += ResultScreen;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= ResultScreen;

    }

    void ResultScreen(Scene scene, LoadSceneMode mode)
    {
        EndText.text = "Du hade " + StaticValues.correctAnswers + " av " + StaticValues.currentLevelLength + " rätt!";
        StaticValues.isCorrect = false;
        StaticValues.levelNumber = 0;
        StaticValues.currentLevelLength = 0;
        StaticValues.correctAnswers = 0;
    }
}
