using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Redirecionamento das cenas
    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
    }
     public void Quit()
    {
        Application.Quit();

    }
}
