using Assets.FootballGameEngine_Indie.Scripts.Entities;
using Assets.FootballGameEngine_Indie_.Scripts.Entities;
using System;
using UnityEngine;

namespace Assets.FootballGameEngine_Indie_.Scripts.Tests.GoalkeeperTests
{
    public class GoalKeeperFullTest : MonoBehaviour
    {
        public static Action onGoalScored;

        [SerializeField]
        float _power = 15;
        private bool isShotted;
        [SerializeField]
        Player _goalKeeper;

        private bool isGoalScored;

        public float timeBeforeEnd;
        public float timeBeforeStart;

        public GameObject scoredCanvas;
        public GameObject loseCanvas;
        private void Awake()
        {
            //// inti the goalkeeper
            //_goalKeeper.Init(0.5f, 
            //    15f, 
            //    5f, 
            //    15f, 
            //    1f, 
            //    5f, 
            //    1f,
            //    0.5f,
            //    15f, // max wonder distance
            //    15f,
            //    10f,
            //    20f,
            //    3f,
            //    3f,
            //    4f,
            //    0.5f,
            //    0.6f, 
            //    0.1f,
            //    0.5f,
            //    30f,
            //    0.1f,
            //    5f,
            //    null,
            //    null,
            //    new Data.Dtos.InGame.Entities.InGamePlayerDto()
            //    {
            //        Accuracy = 1f,
            //        GoalKeeping = 1f,
            //        JumpHeight = 1f,
            //        DiveDistance = 1f,
            //        DiveSpeed = 1f,
            //        Power = 1f,
            //        Reach = 1f,
            //        Speed = 1f,
            //        Tackling = 1f
            //    });

            // enable tje keeper
            _goalKeeper.gameObject.SetActive(true);
            onGoalScored += GoalScored;
            //Invoke("OnInstructedToWait", 1f);
            
        }
        private void OnDisable()
        {
            onGoalScored -= GoalScored;
        }
        private void Update()
        {
            if(Input.GetMouseButtonDown(0) && !isShotted)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if(Physics.Raycast(ray, out hitInfo))
                {
                    float flightTime = Vector3.Distance(Ball.Instance.Position,
                        hitInfo.point)
                        / _power;

                    Ball.Instance.LaunchToPoint(hitInfo.point,
                        _power);

                    Shot shot = new Shot()
                    {
                        BallTimeToTarget = flightTime,
                        KickPower = _power,
                        FromPosition = Ball.Instance.Position,
                        ToPosition = hitInfo.point
                    };

                    _goalKeeper.Invoke_OnShotTaken(shot);
                    isShotted = true;
                    Invoke("CheckIsGoalScored", 5);
                    //_goalKeeper.Invoke_OnShotTaken(flightTime,
                    //    _power,
                    //    Ball.Instance.Position,
                    //    hitInfo.point);

                    //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //obj.transform.position = hitInfo.point;
                    //GameObject.Destroy(obj, 1f);
                }
            }

            if (Input.GetKeyDown(KeyCode.P))
                _goalKeeper.Invoke_OnInstructedToPutBallBackIntoPlay();
        }
        private void GoalScored()
        {
            isGoalScored = true;
        }

        private void CheckIsGoalScored()
        {
            if (isGoalScored)
            {
                Debug.Log("Win");
                scoredCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Lose");
                loseCanvas.SetActive(true);
            }
        }
        private void OnInstructedToWait()
        {
            // go to tend goal state
            _goalKeeper.Invoke_OnInstructedToWait();

            Invoke("OnInstructedGoToHome", 1f);
        }

        private void OnInstructedGoToHome()
        {
            // go to tend goal state
            _goalKeeper.Invoke_OnInstructedGoToHome();
        }
    }
}
