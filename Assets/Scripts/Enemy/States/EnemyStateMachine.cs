using System.Collections.Generic;
using WarIO.Enemy;
using WarIO.Enemy.States;
using WarIO.FSM;

namespace WarIO.States
{
    public class EnemyStateMachine : BaseStateMachine
    {
        private const float NavMeshTurnOffDistance = 5f;
        public EnemyStateMachine(EnemyDirectionController enemyDirectionController,
            NavMesher navMesher, EnemyTarget target)
        {
            var idleState = new IdleState();
            var findWaysState = new FindWayState(target, navMesher, enemyDirectionController);
            var moveForwardState = new MoveForwardState(target, enemyDirectionController);

            SetInitialState(idleState);

            AddState(state: idleState, transitions: new List<Transition>
                {
                    new Transition(findWaysState,
                        () => target.DistanceToClosestFromAgent() > NavMeshTurnOffDistance),
                    new Transition(moveForwardState,
                        () => target.DistanceToClosestFromAgent() <= NavMeshTurnOffDistance),
                }
            );

            AddState(state: findWaysState, transitions: new List<Transition>
                {
                    new Transition(idleState,
                        () => target.Closest == null),
                    new Transition(moveForwardState,
                        () => target.DistanceToClosestFromAgent() <= NavMeshTurnOffDistance),
                }
            );

            AddState(state: moveForwardState, transitions: new List<Transition>
                {
                    new Transition(idleState,
                        () => target.Closest == null),
                    new Transition(findWaysState,
                        () => target.DistanceToClosestFromAgent() > NavMeshTurnOffDistance),
                }
            );
        }
    }
}
