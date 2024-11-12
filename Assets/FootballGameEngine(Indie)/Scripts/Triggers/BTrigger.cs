using Assets.FootballGameEngine_Indie_.Scripts.Tests.GoalkeeperTests;
using System;
using UnityEngine;

namespace Assets.FootballGameEngine_Indie_.Scripts.Triggers
{
    public class BTrigger : MonoBehaviour
    {
        public Action OnCollidedWithBall;

        public virtual void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Ball")
            {
                Debug.Log("Scored goal");
                GoalKeeperFullTest.onGoalScored?.Invoke();
                //invoke that the wall has collided with the ball
                Action temp = OnCollidedWithBall;
                if (temp != null)
                    temp.Invoke();
            }
        }
    }
}
