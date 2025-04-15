using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelLoader : MonoBehaviour
{
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
        Debug.Log(jsonFile);
        Level level = JsonUtility.FromJson<Level>(jsonFile);
        Debug.Log(level.video_name);
        Debug.Log(level.level_question);
        Debug.Log(level.choices);
        // foreach(Choice choice in level.choices)
        // {
        //     Debug.Log("In foreach loop");
        //     Debug.Log(choice.title);
        //     Debug.Log(choice.correct);
        // }
    }
}

public class Choice
{
    public string title;
    public bool correct;
}

public class Level
{
    public string video_name;
    public string level_question;
    public Choice[] choices;
}
