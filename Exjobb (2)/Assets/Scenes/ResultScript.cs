using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ResultScript : MonoBehaviour
{

    public TMP_Text ResultText;

    void OnEnable()
    {
        SceneManager.sceneLoaded += LoadFeedback;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadFeedback;

    }

    void LoadFeedback(Scene scene, LoadSceneMode mode)
    {
        if(StaticValues.isCorrect)
        {
            StaticValues.correctAnswers += 1;
            ResultText.text = "Du hade rätt \n" + StaticValues.posFeedback;


        }
        else
        {
            ResultText.text = "Du hade fel! \n" + StaticValues.negFeedback;
        }

        StaticValues.levelNumber += 1;
    }
}
