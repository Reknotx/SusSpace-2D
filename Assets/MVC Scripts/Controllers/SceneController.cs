using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //public GameObject canvas;
    //public GameObject player;
    //public GameObject mainCamera;


    private AsyncOperation sceneAsync;

    public void LoadNextScene()
    {
        //StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    IEnumerator LoadScene(int index)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        sceneAsync = scene;

        //Wait until we are done loading the scene
        while (scene.progress < 0.9f)
        {
            Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }

        Debug.Log("Done Loading Scene");

        scene.allowSceneActivation = true;

        while (!scene.isDone)
        {
            // wait until it is really finished
            yield return null;
        }

        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);

        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            //SceneManager.MoveGameObjectToScene(this.gameObject, sceneToLoad);
            //SceneManager.MoveGameObjectToScene(player, sceneToLoad);
            //SceneManager.MoveGameObjectToScene(canvas, sceneToLoad);
            //SceneManager.MoveGameObjectToScene(mainCamera, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
            SceneManager.UnloadSceneAsync(index - 1);
        }

        //player.transform.position = GameObject.FindGameObjectWithTag("Spawn Point").transform.position;

        Debug.Log("Scene activated!");

        //player.SetActive(true);

    }
}
