using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyIdle m_IdleState;
    public EnemyChase ChaseState{private set; get;}

    private EnemyState m_CurrentState; // General

    private void Awake() 
    {
          m_IdleState = new EnemyIdle(this);
          ChaseState = new EnemyChase(this);
          //...
          m_CurrentState = m_IdleState;
    }

    private void Update() 
    {
        foreach (var transition in m_CurrentState.Transitions)
        {
            if (transition.IsValid())
            {
                m_CurrentState.OnFinish();
                m_CurrentState = transition.GetNextState();
                m_CurrentState.OnStart();
                break;
            }
        }
        m_CurrentState.OnUpdate();    
    }
}
