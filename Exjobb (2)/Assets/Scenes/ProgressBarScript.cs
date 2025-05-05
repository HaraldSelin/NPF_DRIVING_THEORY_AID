using UnityEngine;
using UnityEngine.UIElements;

public class ProgressBarScript : MonoBehaviour
{
    private ProgressBar progressBar;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        progressBar = root.Q<ProgressBar>("progressBar"); 
        setMax();
        changeValue();

    }

    public void setMax()
    {
        progressBar.lowValue = 0;
        progressBar.highValue = StaticValues.currentLevelLength;
    }
    public void changeValue()
    {
        progressBar.value = StaticValues.levelNumber;
    }

}
