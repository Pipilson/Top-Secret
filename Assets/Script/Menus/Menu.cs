using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject jogadorMax, pontoMax, jogar;
    public Text p30, p40, p50, p60;
    MaxScore max;

    void Start()
    {
        max = GameObject.Find("Winner").GetComponent<MaxScore>();
        pontoMax.SetActive(false);
        jogadorMax.SetActive(false);
        p30.enabled = false;
        p40.enabled = false;
        p50.enabled = false;
        p60.enabled = false;
    }

    public void Jogar()
    {
        jogar.SetActive(false);
        pontoMax.SetActive(true);
    }

    #region Pontuação Máxima
    public void Pontos30()
    {
        max.vitoria = 30;
        p30.enabled = true;
        pontoMax.SetActive(false);
        jogadorMax.SetActive(true);
    }

    public void Pontos40()
    {
        max.vitoria = 40;
        p40.enabled = true;
        pontoMax.SetActive(false);
        jogadorMax.SetActive(true);
    }

    public void Pontos50()
    {
        max.vitoria = 50;
        p50.enabled = true;
        pontoMax.SetActive(false);
        jogadorMax.SetActive(true);
    }

    public void Pontos60()
    {
        max.vitoria = 60;
        p60.enabled = true;
        pontoMax.SetActive(false);
        jogadorMax.SetActive(true);
    }
    #endregion

    #region Jogadores Humanos
    public void Jogadores2()
    {
        max.jogadoresTotal = 2;
        SceneManager.LoadScene("Jogo");
    }

    public void Jogadores3()
    {
        max.jogadoresTotal = 3;
        SceneManager.LoadScene("Jogo");
    }

    public void Jogadores4()
    {
        max.jogadoresTotal = 4;
        SceneManager.LoadScene("Jogo");
    }

    public void Jogadores5()
    {
        max.jogadoresTotal = 5;
        SceneManager.LoadScene("Jogo");
    }

    public void Jogadores6()
    {
        max.jogadoresTotal = 6;
        SceneManager.LoadScene("Jogo");
    }
    #endregion

    public void ComoJogar()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Sair()
    {
        Application.Quit();
    }
}