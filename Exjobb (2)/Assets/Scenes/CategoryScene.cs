using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CategoryScene : MonoBehaviour
{

    public Button Category1;
    public Button Category2;
    public Button MenuButton;

    void Start()
    {
        Category1.onClick.AddListener(() => CategoryChoice(0));
        Category2.onClick.AddListener(() => CategoryChoice(1));
        MenuButton.onClick.AddListener(() => ChangeScene());
    }

    void CategoryChoice(int ButtonId)
    {
        StaticValues.currentCategory = ButtonId;
        SceneManager.LoadScene("GameScene");
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
