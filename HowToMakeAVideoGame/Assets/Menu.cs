
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
  public void StatGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
