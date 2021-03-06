﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FourrureChest : MonoBehaviour
{
    public GameObject player;
    public AudioSource audio;
    private GameObject baseChest;
    private GameObject openingChest;
    private GameObject light;

    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        baseChest = this.transform.GetChild(0).gameObject;
        openingChest = baseChest.transform.GetChild(0).gameObject;
        light = this.transform.GetChild(2).gameObject;
        open = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) 
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (player.GetComponent<PlayerController>().openingChest == true && open == false)
        {
            openingChest.transform.eulerAngles = new Vector3(-90, 0, 0);
            open = true;
            player.GetComponent<Inventory>().fourrure = true;
            audio.Play();
            light.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerController>().openingChest = false;
    }
}
