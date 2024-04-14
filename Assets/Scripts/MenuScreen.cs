using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject controlsPicture;
    public GameObject creditsPicture;

    void Start()
    {
        // Disable pictures at the start
        controlsPicture.SetActive(false);
        creditsPicture.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleControlsPicture()
    {
        // Toggle the visibility of the controls picture
        controlsPicture.SetActive(!controlsPicture.activeSelf);
    }

    public void ToggleCreditsPicture()
    {
        // Toggle the visibility of the credits picture
        creditsPicture.SetActive(!creditsPicture.activeSelf);
    }
}
