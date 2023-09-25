using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private float loadingDelay = 2f; 

      void Start()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
 
   IEnumerator LoadYourAsyncScene()
    {
        yield return new WaitForSeconds(loadingDelay);
 
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");
 
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}