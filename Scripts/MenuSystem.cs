using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSystem : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Salir()
    {
   
        Application.Quit();
    }
}

