﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guardia : MonoBehaviour
{
	public enum AgentState{Espera,Disparo,Patrullaje}
	public AgentState currentState;
	
	NavMeshAgent agent;
	
	public Transform[] waypoints;
	public int indexWaypoints = 0;
	
	public Transform currentDestination;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
