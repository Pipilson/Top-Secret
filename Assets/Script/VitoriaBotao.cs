using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VitoriaBotao : MonoBehaviour
{
    public Button menu, sair;
    public Text menuT, sairT;
    Main main;

    void Start()
    {
        menuT.text = "";
        sairT.text = "";
        menu.enabled = false;
        sair.enabled = false;
        menu.GetComponent<Image>().enabled = false;
        sair.GetComponent<Image>().enabled = false;
        main = GameObject.Find("Tabuleiro").GetComponent<Main>();
    }

    void Update()
    {
        if (main.gameOver == true)
        {
            menuT.text = "Menu";
            sairT.text = "Sair";
            menu.enabled = true;
            sair.enabled = true;
            menu.GetComponent<Image>().enabled = true;
            sair.GetComponent<Image>().enabled = true;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Sair()
    {
        Application.Quit();
    }
}