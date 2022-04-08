using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    private Animator FadeSystem;
    public float LoadingSceneDelay = 1f;

    private void Awake()
    {
        FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(loadNextScene());
            
        }
    }

    public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        FadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(LoadingSceneDelay);
        SceneManager.LoadScene(sceneName);

    }
}
