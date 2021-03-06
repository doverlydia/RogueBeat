using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ActivateGameObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void DeactivateGameObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
