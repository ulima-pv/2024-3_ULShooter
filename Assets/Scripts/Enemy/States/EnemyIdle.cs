using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyIdle(EnemyController controller) : base(controller)
    {
        Transition transitionIdleToChase = new Transition(
            isValid: () => {
                return false;
            },
            getNextState: () => {
                return m_Controller.ChaseState;
            }
        );
    }

    public override void OnFinish()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
