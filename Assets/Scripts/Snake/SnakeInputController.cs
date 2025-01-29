using Modules;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class SnakeInputController : ITickable
    {
        private readonly ISnake _snake;

        public SnakeInputController(ISnake snake)
        {
            _snake = snake;
        }

        public void Tick()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");
            
            if (y > 0)
            {
                _snake.Turn(SnakeDirection.UP);
            } 
            else if (y < 0)
            {
                _snake.Turn(SnakeDirection.DOWN);
            }
            else if (x < 0)
            {
                _snake.Turn(SnakeDirection.LEFT);
            }
            else if (x > 0)
            {
                _snake.Turn(SnakeDirection.RIGHT);
            }
        }
    }
}