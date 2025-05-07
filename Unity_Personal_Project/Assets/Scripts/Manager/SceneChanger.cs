using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;
    public Animator fadeAnimation;
    public float fadeDruation = .5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fadeAnimation.Play("FadeToBlack");  
            StartCoroutine(DelayFade());
        }
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
