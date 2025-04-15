using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class LevelLoader : MonoBehaviour
{

    public TMP_Text question;
    public TMP_Text choice1;
    public TMP_Text choice2;
    public TMP_Text choice3;
    public TMP_Text choice4;
    public VideoPlayer videoPlayer;
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

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        string jsonFile = File.ReadAllText(Application.dataPath + "/Levels/level.json");
        Level level = JsonUtility.FromJson<Level>(jsonFile);
        var foundTextMeshObjects = FindObjectsByType(typeof(TextMesh), FindObjectsSortMode.None);

        question.text = level.level_question;
        choice1.text = level.choice1;
        choice2.text = level.choice2;
        choice3.text = level.choice3;
        choice4.text = level.choice4;
        videoPlayer.url = Application.dataPath + "/Scenes/testvideo.mp4";
        videoPlayer.Play();

        // Debug.Log(level.video_name);
        // Debug.Log(level.level_question);
        // foreach(Choice choice in level.choices)
        // {
        //     Debug.Log("In foreach loop");
        //     Debug.Log(choice.title);
        //     Debug.Log(choice.correct);
        // }
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
