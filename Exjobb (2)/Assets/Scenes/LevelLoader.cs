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
    private int levelNumber = 0;
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
        string jsonFile = File.ReadAllText(Application.dataPath + "/Levels/level.json");
        Debug.Log(jsonFile);
        data = parseLevels(jsonFile);
        Debug.Log(data);
        LevelInfo(data[levelNumber]);
    }

    void LevelInfo(Level level) 
    {
       Debug.Log(level);
        //Level level = JsonUtility.FromJson<Level>(jsonFile);
        var foundTextMeshObjects = FindObjectsByType(typeof(TextMesh), FindObjectsSortMode.None);

        question.text = level.level_question;
        choice1.text = level.choice1;
        choice2.text = level.choice2;
        choice3.text = level.choice3;
        choice4.text = level.choice4;
        videoPlayer.url = Application.dataPath + "/Videos/" + level.video_name + ".mp4";
        videoPlayer.Play();
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
}

public class Wrapper
{
    public List<Level> data;
}
