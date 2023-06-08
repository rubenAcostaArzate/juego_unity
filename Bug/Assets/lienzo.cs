using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class lienzo : MonoBehaviour
{
    public int coins;

    public TMP_Text texto;

    public GameObject mario;

    public void setCoins(TMP_Text text){
       text.text="monedas:"+ mario.GetComponent<MovForceAnim>().coins;
    }
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
      if(coins!=mario.GetComponent<MovForceAnim>().coins){
        setCoins(texto);
      }
    }
}
