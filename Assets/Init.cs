﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour{
    public GameObject player;
    void Start(){
        Instantiate(player);
    }
}