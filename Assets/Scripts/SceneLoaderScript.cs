using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoaderScript : MonoBehaviour
{
    [SerializeField]private string sceneToLoad; // Назва сцени для завантаження
    [SerializeField]private GameObject loadingScreen; // Префаб для візуалізації загрузки
    [SerializeField]private Slider loadingProgressBar; // Прогрес-бар для візуалізації прогресу загрузки
    [SerializeField]private GameObject OffCanvas;
    public void LoadSceneWithLoading()
    {
        OffCanvas.SetActive(false);
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        loadingScreen.SetActive(true); // Відображаємо візуалізацію загрузки

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // Нормалізуємо прогрес (від 0 до 1)
            loadingProgressBar.value = progress; // Оновлюємо прогрес-бар

            yield return null; // Очікуємо один кадр
        }
    }
}
