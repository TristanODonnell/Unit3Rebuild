using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private NavMeshAgent agentToCommand;
    private Vector3 destination; 
    public override void ExecuteCommand()
    {
        //how to find the navmeshagent 
       //Vector3 destination
       //reference to NavMeshAgent
       agentToCommand.SetDestination(destination);
    }

    public override bool IsCompleted() //Checking every frame
    {
        return agentToCommand.remainingDistance < 0.2f;
        
    }

    public MoveCommand(NavMeshAgent agent, Vector3 targetPosition)
    {
        destination = targetPosition;
        agentToCommand = agent;
    }
}
