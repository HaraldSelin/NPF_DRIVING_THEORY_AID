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
        Level level = JsonUtility.FromJson<Level>(jsonFile);
        var foundTextMeshObjects = FindObjectsByType(typeof(TextMesh), FindObjectsSortMode.None);
        Debug.Log(foundTextMeshObjects);
        Debug.Log(foundTextMeshObjects.Length);

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
