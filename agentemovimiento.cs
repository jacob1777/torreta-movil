using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgenteMovimiento : MonoBehaviour
{
    NavMeshAgent agent;
	
	public Transform[] waypoints;
	public int indexwaypoints = 0;
	
	public transform currentDestination;
   
   
   [Header("Elementos del sensor")]
   public LayerMask playerMask;        //Para la detección del target a quien queremos atacar
   public float radiusDetection = 2f;  //Un radio de deteccción.
   public Transform sensorPosition;    //La posición del sensor
   public bool playerDetected = false;
   
   public GameObject player;
   public Vector3 TempPositionPlayer;
   bool once = false;
   
   // Start is called before the first frame update
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
		
		currentDestination = waypoints[indexWaypoints];
		
		agent.SetDestination(currentDestination.position);
    }
    // Update is called once per frame
    void Update()
    
	{
	   if(playerDetected == false) //si no detecta al jugador
       {
       float distance = Vector3.Distance(transform.position, currentDestination.position);
	   //Debug.Log(distance);
	   
	   if(transform.position.x == currentDestination.position.x)
	   {
		   Debug.Log("Ya llegue!");
		   indexWaypoints = (indexWaypoints + 1) % waypoints.Length;
		   
		   currentDestination = waypoints[indexWaypoints];
		   
	   }
        agent.SetDestination(currentDestination.position);	
	   }
	   else //cuando detecta al jugagor
	   {
		  currentDestination.position = tempPositionPlayer;
		  
		  agent.SetDestination(currentDestination.position);
	   }   
    }
	
	private void FixedUpdate()
	{
	    TargetDetected();	
	}	
	
	
	public virtual void TargetDetected()
	{
		Collider[] colliders = Physics.OverlapSphere(sensorPosition.position, radiusDetection, playerMask); //El colisionador guarda en un arreglo los objetos que este detectando y que tengan el layer
        if (colliders.Length == 0) //Si no hay objetos en los colisionadore
        {
            playerDetected = false; //No hay target
			agent.stoppingDistant = 0f;
			once = false;
        }
        else //Si no
        {
            playerDetected = true; //El target ha sido detectado
			agent.stoppingDistant = 3f;
			SetTempPosition();
        }
	}
	void SetTempPosition()
	{
		if(once == flase)
		{
			tempPositionPlayer = player.transform.position;
			once = true;
		}			
		tempPositionPlayer = player.transform.position;	
	}	
	
	private void OnDrawGizmos()
	{
		Gizmos.Color = Color.red;
		Gizmos.DrawWireSphere(sensorPosition.position, radiusDestection);
	}	
}


