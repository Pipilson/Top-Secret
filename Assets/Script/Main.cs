using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;
//using Button = UnityEngine.UI.Button;

public class Main : MonoBehaviour
{
    //Declarando variáveis
    [HideInInspector] public GameObject[] jogador;
    [HideInInspector] public Vector3 pos0, pos1, pos2, pos3, pos4, pos5;
    [HideInInspector] public bool pegouEstrela, contarPontos, gameOver;
    [HideInInspector] public int dado, jogadorX;
    //public Tilemap tilemap;
    public Text pontoTxt1, pontoTxt2, pontoTxt3, pontoTxt4, pontoTxt5, pontoTxt6, fimTxt, suaVez;
    public GameObject jogo1336, jogo1920;
    GameObject[] teste;
    Grid grid;
    EstrelaBotao botao;
    MaxScore max;
    GameObject estrela;
    System.Random rnd;
    int ponto1, ponto2, ponto3, ponto4, ponto5, ponto6;

    void Start()
    {
        //Referenciando variáveis
        jogadorX = 1;
        rnd = new System.Random();
        grid = FindObjectOfType<Grid>();
        teste = new GameObject[6];
        jogador = new GameObject[6];
        estrela = GameObject.Find("Estrela");
        max = GameObject.Find("Winner").GetComponent<MaxScore>();

        if (Screen.width == 1920 && Screen.height == 1080)
        {
            jogo1920.SetActive(true);
            botao = GameObject.Find("Botões1920").GetComponent<EstrelaBotao>();
        }

        else
        {
            jogo1336.SetActive(true);
            botao = GameObject.Find("Botões1336").GetComponent<EstrelaBotao>();
        }    

        //Atribuindo características aos objetos
        for (int i = 0; i <= 5; i++)
        {
            teste[i] = GameObject.Find("teste" + i);
            jogador[i] = GameObject.Find("jogador" + i);
            jogador[i].transform.position = teste[i].transform.position;
            Destroy(teste[i]);
        }

        fimTxt.text = "";

        //Atribundo cores aos objetos
        jogador[0].GetComponent<SpriteRenderer>().color = Color.red;
        jogador[1].GetComponent<SpriteRenderer>().color = Color.blue;
        jogador[2].GetComponent<SpriteRenderer>().color = Color.green;
        jogador[3].GetComponent<SpriteRenderer>().color = Color.yellow;
        jogador[4].GetComponent<SpriteRenderer>().color = Color.cyan;
        jogador[5].GetComponent<SpriteRenderer>().color = Color.magenta;

        pontoTxt1.color = jogador[0].GetComponent<SpriteRenderer>().color;
        pontoTxt2.color = jogador[1].GetComponent<SpriteRenderer>().color;
        pontoTxt3.color = jogador[2].GetComponent<SpriteRenderer>().color;
        pontoTxt4.color = jogador[3].GetComponent<SpriteRenderer>().color;
        pontoTxt5.color = jogador[4].GetComponent<SpriteRenderer>().color;
        pontoTxt6.color = jogador[5].GetComponent<SpriteRenderer>().color;
    }

    public void Update()
    {
        //Escreve na tela a pontuação dos jogadores
        pontoTxt1.text = "Vermelho: " + ponto1;
        pontoTxt2.text = "Azul: " + ponto2;
        pontoTxt3.text = "Verde: " + ponto3;
        pontoTxt4.text = "Amarelo: " + ponto4;
        pontoTxt5.text = "Ciano: " + ponto5;
        pontoTxt6.text = "Magenta: " + ponto6;

        suaVez.text = "Sua vez, Jogador " + jogadorX;

        //Pega posição dos jogadores
        pos0 = grid.LocalToCell(jogador[0].transform.position);
        pos1 = grid.LocalToCell(jogador[1].transform.position);
        pos2 = grid.LocalToCell(jogador[2].transform.position);
        pos3 = grid.LocalToCell(jogador[3].transform.position);
        pos4 = grid.LocalToCell(jogador[4].transform.position);
        pos5 = grid.LocalToCell(jogador[5].transform.position);

        EstrelaPosicao(); //Verifica posição da estrela

        if (dado == 0 && contarPontos)
        {
            PegaEstrela(); //Verifica se alguem parou na casa da estrela

            if (pegouEstrela)
            {
                Pontuacao(); //Pontua jogadores
                contarPontos = false;
            }
        }

        //Joga dado
        if (Input.GetKeyUp(KeyCode.Space) && dado == 0 && !pegouEstrela && !gameOver)
        {
            dado = rnd.Next(1, 7);
            contarPontos = true;
        }

        if(jogadorX > max.jogadoresTotal)
        {
            jogadorX = 1;
        }

        GameOver(); //Termina jogo
    }

    void EstrelaPosicao()
    {
        switch (botao.casa)
        {
            case 0:
            estrela.transform.position = new Vector3(-6.48f, 5.04f, 0);
            break;

            case 1:
            estrela.transform.position = new Vector3(-3.6f, 5.04f, 0);
            break;

            case 2:
            estrela.transform.position = new Vector3(-0.7200003f, 5.04f, 0);
            break;

            case 3:
            estrela.transform.position = new Vector3(2.16f, 5.04f, 0);
            break;

            case 4:
            estrela.transform.position = new Vector3(5.04f, 5.04f, 0);
            break;

            case 5:
            estrela.transform.position = new Vector3(7.92f, 5.04f, 0);
            break;

            case 6:
            estrela.transform.position = new Vector3(7.92f, -5.04f, 0);
            break;

            case 7:
            estrela.transform.position = new Vector3(5.04f, -5.04f, 0);
            break;

            case 8:
            estrela.transform.position = new Vector3(2.16f, -5.04f, 0);
            break;

            case 9:
            estrela.transform.position = new Vector3(-0.7200003f, -5.04f, 0);
            break;

            case 10:
            estrela.transform.position = new Vector3(-3.6f, -5.04f, 0);
            break;

            case -3:
            estrela.transform.position = new Vector3(-6.48f, -5.04f, 0);
            break;

        }
    }

    void PegaEstrela()
    {
        //Estrela está na casa 0
        if (botao.casa == 0)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-6, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-5, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-6, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-5, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-6, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-5, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 1
        else if (botao.casa == 1)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-4, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-3, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-4, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-3, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-4, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-3, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 2
        else if (botao.casa == 2)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-2, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-1, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-2, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-1, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-2, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-1, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 3
        else if (botao.casa == 3)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(0, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(1, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(0, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(1, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(0, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(1, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 4
        else if (botao.casa == 4)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(2, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(3, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(2, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(3, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(2, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(3, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 5
        else if (botao.casa == 5)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(4, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(5, 2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(4, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(5, 1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(4, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(5, 0, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 6
        else if (botao.casa == 6)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(4, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(5, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(4, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(5, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(4, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(5, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 7
        else if (botao.casa == 7)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(2, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(3, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(2, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(3, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(2, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(3, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 8
        else if (botao.casa == 8)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(0, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(1, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(0, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(1, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(0, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(1, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 9
        else if (botao.casa == 9)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-2, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-1, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-2, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-1, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-2, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-1, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa 10
        else if (botao.casa == 10)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-4, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-3, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-4, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-3, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-4, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-3, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }

        //Estrela está na casa -3
        else if (botao.casa == -3)
        {
            if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-6, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-5, -1, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-6, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-5, -2, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-6, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }

            else if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-5, -3, 0))
            {
                pegouEstrela = true;
                jogadorX--;
            }
        }
    }

    void Pontuacao()
    {
        //Pontua quem está na casa 1
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-4, 2, 0))
        {
            ponto1 += 1;
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-3, 2, 0))
        {
            ponto2 += 1;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-4, 1, 0))
        {
            ponto3 += 1;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-3, 1, 0))
        {
            ponto4 += 1;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-4, 0, 0))
        {
            ponto5 += 1;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-3, 0, 0))
        {
            ponto6 += 1;
        }

        //Pontua quem está na casa 2
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-2, 2, 0))
        {
            ponto1 += 2;
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-1, 2, 0))
        {
            ponto2 += 2;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-2, 1, 0))
        {
            ponto3 += 2;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-1, 1, 0))
        {
            ponto4 += 2;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-2, 0, 0))
        {
            ponto5 += 2;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-1, 0, 0))
        {
            ponto6 += 2;
        }

        //Pontua quem está na casa 3
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(0, 2, 0))
        {
            ponto1 += 3;
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(1, 2, 0))
        {
            ponto2 += 3;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(0, 1, 0))
        {
            ponto3 += 3;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(1, 1, 0))
        {
            ponto4 += 3;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(0, 0, 0))
        {
            ponto5 += 3;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(1, 0, 0))
        {
            ponto6 += 3;
        }

        //Pontua quem está na casa 4
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(2, 2, 0))
        {
            ponto1 += 4;
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(3, 2, 0))
        {
            ponto2 += 4;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(2, 1, 0))
        {
            ponto3 += 4;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(3, 1, 0))
        {
            ponto4 += 4;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(2, 0, 0))
        {
            ponto5 += 4;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(3, 0, 0))
        {
            ponto6 += 4;
        }

        //Pontua quem está na casa 5
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(4, 2, 0))
        {
            ponto1 += 5;
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(5, 2, 0))
        {
            ponto2 += 5;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(4, 1, 0))
        {
            ponto3 += 5;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(5, 1, 0))
        {
            ponto4 += 5;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(4, 0, 0))
        {
            ponto5 += 5;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(5, 0, 0))
        {
            ponto6 += 5;
        }

        //Pontua quem está na casa 6
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(4, -1, 0))
        {
            ponto1 += 6;
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(5, -1, 0))
        {
            ponto2 += 6;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(4, -2, 0))
        {
            ponto3 += 6;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(5, -2, 0))
        {
            ponto4 += 6;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(4, -3, 0))
        {
            ponto5 += 6;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(5, -3, 0))
        {
            ponto6 += 6;
        }

        //Pontua quem está na casa 7
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(2, -1, 0))
        {
            ponto1 += 7;
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(3, -1, 0))
        {
            ponto2 += 7;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(2, -2, 0))
        {
            ponto3 += 7;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(3, -2, 0))
        {
            ponto4 += 7;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(2, -3, 0))
        {
            ponto5 += 7;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(3, -3, 0))
        {
            ponto6 += 7;
        }

        //Pontua quem está na casa 8
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(0, -1, 0))
        {
            ponto1 += 8;
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(1, -1, 0))
        {
            ponto2 += 8;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(0, -2, 0))
        {
            ponto3 += 8;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(1, -2, 0))
        {
            ponto4 += 8;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(0, -3, 0))
        {
            ponto5 += 8;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(1, -3, 0))
        {
            ponto6 += 8;
        }

        //Pontua quem está na casa 9
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-2, -1, 0))
        {
            ponto1 += 9;
        }

        else if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-1, -1, 0))
        {
            ponto2 += 9;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-2, -2, 0))
        {
            ponto3 += 9;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-1, -2, 0))
        {
            ponto4 += 9;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-2, -3, 0))
        {
            ponto5 += 9;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-1, -3, 0))
        {
            ponto6 += 9;
        }

        //Pontua quem está na casa 10
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-4, -1, 0))
        {
            ponto1 += 10;
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-3, -1, 0))
        {
            ponto2 += 10;
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-4, -2, 0))
        {
            ponto3 += 10;
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-3, -2, 0))
        {
            ponto4 += 10;
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-4, -3, 0))
        {
            ponto5 += 10;
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-3, -3, 0))
        {
            ponto6 += 10;
        }

        //Pontua quem está na casa -3
        if (grid.LocalToCell(jogador[0].transform.position) == new Vector3(-6, -1, 0))
        {
            if (ponto1 >= 4)
            {
                ponto1 += -3;
            }

            else
            {
                ponto1 = 0;
            }
        }

        if (grid.LocalToCell(jogador[1].transform.position) == new Vector3(-5, -1, 0))
        {
            if (ponto2 >= 4)
            {
                ponto2 += -3;
            }

            else
            {
                ponto2 = 0;
            }
        }

        if (grid.LocalToCell(jogador[2].transform.position) == new Vector3(-6, -2, 0))
        {
            if (ponto3 >= 4)
            {
                ponto3 += -3;
            }

            else
            {
                ponto3 = 0;
            }
        }

        if (grid.LocalToCell(jogador[3].transform.position) == new Vector3(-5, -2, 0))
        {
            if (ponto4 >= 4)
            {
                ponto4 += -3;
            }

            else
            {
                ponto4 = 0;
            }
        }

        if (grid.LocalToCell(jogador[4].transform.position) == new Vector3(-6, -3, 0))
        {
            if (ponto5 >= 4)
            {
                ponto5 += -3;
            }

            else
            {
                ponto5 = 0;
            }
        }

        if (grid.LocalToCell(jogador[5].transform.position) == new Vector3(-5, -3, 0))
        {
            if (ponto6 >= 4)
            {
                ponto6 += -3;
            }

            else
            {
                ponto6 = 0;
            }
        }
    }

    void GameOver()
    {
        if (Mathf.Max(ponto1, ponto2, ponto3, ponto4, ponto5, ponto6) >= max.vitoria)
        {
            fimTxt.text = "Fim de Jogo!";
            gameOver = true;
        }
    }
}