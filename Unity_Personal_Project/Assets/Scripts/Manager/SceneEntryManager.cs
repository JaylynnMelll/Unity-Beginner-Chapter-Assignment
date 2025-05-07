using UnityEngine;

public class SceneEntryManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject miniGameUI;
    public TotalPointsUI totalPointsUi;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("TotalPoints"))
        {
            totalPointsUi.LoadScore();
        }
    }
    void Start()
    {
        mainMenuUI.SetActive(true);
        miniGameUI.SetActive(false);
    }
}