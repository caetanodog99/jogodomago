using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class telaInGame : MonoBehaviour
{
    public TextMeshProUGUI textopontos;
    public barraDeVida barravida;

    private scriptmago player;

    
    private void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<scriptmago>();   
    }


    void Update()
    {
        this.barravida.ExibirVida(this.player.PerderVida);
        this.textopontos.text = "Pontos: " + pontuacao.Pontos.ToString();
    }
}
