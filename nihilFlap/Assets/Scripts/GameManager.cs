using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject level;
    public GameObject mainMenu;
    public GameObject score;
    #region quotes
    string[] quotes = {"When one stares into the void\nThe void stares back\n-Abraham Lincoln",
        "Philosophy's hard\n -Fredrick Nietzsche",
        "But it's not fair\n -The Nihilists",
        "everything is possible\nnothing has any importance\n -Albert Camus"

    };
    #endregion

    public void LoadLevel()
    {
        level.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ManMenu()
    {
        level.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PickQuote()
    {
        score.GetComponent<Text>().text = quotes[Random.Range(0, quotes.Length-1)];
    }
}
