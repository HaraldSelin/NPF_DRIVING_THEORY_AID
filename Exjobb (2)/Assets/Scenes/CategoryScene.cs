using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CategoryScene : MonoBehaviour
{

    public Button Category1;
    public Button Category2;

    void Start()
    {
        Category1.onClick.AddListener(() => CategoryChoice(0));
        Category2.onClick.AddListener(() => CategoryChoice(1));
    }

    void CategoryChoice(int ButtonId)
    {
        StaticValues.currentCategory = ButtonId;
        SceneManager.LoadScene("GameScene");
    }
}
