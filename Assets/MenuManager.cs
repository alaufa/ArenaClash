using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void StartGame()
    {
        // Replace "MainScene" with the name of your main scene
        SceneManager.LoadScene("SampleScene");
    }
}
