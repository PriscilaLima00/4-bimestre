using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public GameObject laserDoInimigo;
    public Transform localDoDisparo;
    public GameObject itemParaDoprar;
    
    public float velocidadeDoInimigo;
    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;
    public int pontosParaDar;
    public int chanceParaDoprar;

    public float tempoMaximoEntreOsLesers;
    public float tempoAtualDosLasers;

    public bool inimigoAtirador;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();
        if (inimigoAtirador == true)
        {
            AtirarLaser();
        }
    }
    
    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.down * velocidadeDoInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;
        
        if (tempoAtualDosLasers <= 0)
        {
            Instantiate(laserDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualDosLasers = tempoMaximoEntreOsLesers;
        }
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        
        vidaAtualDoInimigo -= danoParaReceber;
        
        if (vidaAtualDoInimigo <= 0)
        {
            GameManager.intance.AumentarPontuacao(pontosParaDar);

            int numeroAleatorio = Random.Range(0, 100);

            if (numeroAleatorio <= chanceParaDoprar)
            {
                Instantiate(itemParaDoprar, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            
            Destroy(this.gameObject);
        }
    }
}
