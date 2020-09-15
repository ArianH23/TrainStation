﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class NavMeshNavigator : MonoBehaviour
{

	private NavMeshAgent agent;
	public NavMeshPoints targets;
	public bool destroyWhenOnDestination;
	public bool idle;
	private float timeToConsiderStuck;
	private float stuckDistance;
	private float stuckTimer;
	private Vector3 stuckPosition;
	private bool panicking;

	public void ActivatePanicking() {
		panicking=true;
	}

	public void SetDestination(Vector3 dest) {
		agent.SetDestination(dest);
	}

	public void SetSpeed(float speed) {
		agent.speed=speed;
	}

	private void CheckIfStuck() {
		if (Vector3.Distance(transform.position, stuckPosition)<stuckDistance) {
			if (stuckTimer>=timeToConsiderStuck) {
				stuckTimer=0;
				stuckPosition=transform.position;
				GetOppositeDestination();
			}
			else stuckTimer+=Time.deltaTime;
		} else {
			stuckTimer=0;
			stuckPosition=transform.position;
		}
	}

	private void SetRandomDestination() {
		agent.SetDestination(targets.GetRandomPoint());
	}

	private void GetOppositeDestination() {
		Vector3 dest = agent.destination;
		//agent.SetDestination(new Vector3(-dest.x, dest.y, -dest.z));
		agent.SetDestination(transform.position-(transform.forward*3));
	}

    // Start is called before the first frame update
    void Start()
    {
		agent=GetComponent<NavMeshAgent>();
		destroyWhenOnDestination=false;
		stuckTimer=0;
		timeToConsiderStuck=0.5f;
		stuckDistance=0.2f;
		stuckPosition=transform.position;
		panicking=false;
    }

    // Update is called once per frame
    void Update()
    {
		if (!idle && !agent.pathPending) {
			if (destroyWhenOnDestination && agent.remainingDistance<=0.4) Destroy(gameObject);
			else if (agent.remainingDistance<=0.2) SetRandomDestination();
			else if (!panicking) CheckIfStuck();
		}
    }
}
