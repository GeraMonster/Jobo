using UnityEngine;
using UnityEngine.SceneManagement;
public class MainScenee : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Salir()
    {

        Application.Quit();
    }

}
