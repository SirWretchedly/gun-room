using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Print : MonoBehaviour
{
    public int scrap, flesh;

    private Text scrapText, fleshText;

    private void Start()
    {
        scrapText = GameObject.Find("Inventory").transform.Find("ScrapText").GetComponent<Text>();
        fleshText = GameObject.Find("Inventory").transform.Find("FleshText").GetComponent<Text>();
    }

    void Update()
    {
        scrapText.text = "" + scrap;
        fleshText.text = "" + flesh;
    }
}
