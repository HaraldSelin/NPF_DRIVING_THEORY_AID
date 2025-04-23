using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using System.Collections.Generic;
using Newtonsoft.Json;

public class LevelLoader : MonoBehaviour
{

    public TMP_Text question;
    public TMP_Text choice1;
    public TMP_Text choice2;
    public TMP_Text choice3;
    public TMP_Text choice4;
    public VideoPlayer videoPlayer;
    public Button Answer1;
    public Button Answer2;
    public Button Answer3;
    public Button Answer4;
    private int levelNumber = StaticValues.levelNumber;
    private int correctNumber;

    void Start()
    {
        Answer1.onClick.AddListener(() => ButtonClicked(1));
        Answer2.onClick.AddListener(() => ButtonClicked(2));
        Answer3.onClick.AddListener(() => ButtonClicked(3));
        Answer4.onClick.AddListener(() => ButtonClicked(4));
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    static List<Level> parseLevels(string json)
    {
        Wrapper wrapper = JsonConvert.DeserializeObject<Wrapper>(json);
        return wrapper.data;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        List<Level> data;
        string jsonFile = File.ReadAllText(Application.dataPath + "/Levels/level"+StaticValues.currentCategory+".json");
        data = parseLevels(jsonFile);
        StaticValues.currentLevelLength = data.Count;
        LevelInfo(data[levelNumber]);
    }

    void LevelInfo(Level level) 
    {
        var foundTextMeshObjects = FindObjectsByType(typeof(TextMesh), FindObjectsSortMode.None);
        question.text = level.level_question;
        choice1.text = level.choice1;
        choice2.text = level.choice2;
        choice3.text = level.choice3;
        choice4.text = level.choice4;
        correctNumber = level.correct;
        StaticValues.posFeedback = level.posFeedback;
        StaticValues.negFeedback = level.negFeedback;
        videoPlayer.url = Application.dataPath + "/Videos/" + level.video_name + ".mp4";
        videoPlayer.Play();
    }

    private void ButtonClicked(int ButtonId)
    {
        if(correctNumber == ButtonId)
        {
            StaticValues.isCorrect = true;
        }
        else
        {
            StaticValues.isCorrect = false;
        }
        
        SceneManager.LoadScene("ResultScene");
    }
}
public class Level
{
    public string video_name;
    public string level_question;
    public string choice1;
    public string choice2;
    public string choice3;
    public string choice4;
    public int correct;
    public string posFeedback;
    public string negFeedback;
}

public class Wrapper
{
    public List<Level> data;
}
