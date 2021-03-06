﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChestManager : MonoBehaviour
{
    public GameObject player;
    private GameObject baseChest;
    private GameObject openingChest;
    private GameObject light;

    private float rotation;
    private float rotationSpeed = 10;
    private bool open;
    private float cooldown = 20;
    private float timer;
    public float Quantity = 10;

    // Start is called before the first frame update
    void Start()
    {
        baseChest = this.transform.GetChild(0).gameObject;
        openingChest = baseChest.transform.GetChild(0).gameObject;
        light = this.transform.GetChild(2).gameObject;
        open = false;
        timer = cooldown;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = cooldown;
                open = false;
                light.SetActive(true);
            }
        }
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
            light.SetActive(false);
            player.transform.GetChild(5).GetComponent<LightManager>().IncreaseLightQty(Quantity);
        }
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerController>().openingChest = false;
        openingChest.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
