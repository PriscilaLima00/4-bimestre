using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoSonoros : MonoBehaviour
{

    public static EfeitoSonoros instance;
    
    public AudioSource somDaExplosao, somDoLaserDoJogador, somDoImpacto;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
