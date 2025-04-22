using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ResultScript : MonoBehaviour
{

    public TMP_Text ResultText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

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
        Debug.Log("Jag kom hit!");
        if(StaticValues.isCorrect)
        {
            ResultText.text = "Du hade rätt!";
        }
        else
        {
            ResultText.text = "Du hade fel!";
        }

        StaticValues.levelNumber += 1;
    }
}
