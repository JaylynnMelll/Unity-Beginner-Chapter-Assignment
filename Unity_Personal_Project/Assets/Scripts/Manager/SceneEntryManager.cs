using UnityEngine;

public class SceneEntryManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject miniGameUI;

    void Start()
    {
        mainMenuUI.SetActive(true);
        miniGameUI.SetActive(false);
    }
}