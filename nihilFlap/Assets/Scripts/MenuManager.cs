using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public GameObject main, options, unlock;
    public GameObject currentMenu;
    public GameObject bloodCount;
    public int blood;
    public void Start()
    {
        blood = 0;
        if (PlayerPrefs.HasKey("TOTALBLOOD"))
            blood = PlayerPrefs.GetInt("TOTALBLOOD");
        bloodCount.GetComponent<Text>().text += " " + blood;
    }
    public void SwitchMain()
    {
        currentMenu.SetActive(false);
        currentMenu = main;
        currentMenu.SetActive(true);
    }
    public void SwitchOptions()
    {
        currentMenu.SetActive(false);
        currentMenu = options;
        currentMenu.SetActive(true);
    }
    public void SwitchUnlock()
    {
        currentMenu.SetActive(false);
        currentMenu = unlock;
        currentMenu.SetActive(true);
    }

}
