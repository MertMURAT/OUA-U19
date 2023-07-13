using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour

{

    public static Cinematic instance;

    private PlayableDirector pd;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pd = GetComponent<PlayableDirector>();
    }
    

    public void EndCinematic()
    {
        pd.Play();
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
