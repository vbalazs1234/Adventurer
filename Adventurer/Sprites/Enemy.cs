using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adventurer;
using System.Threading.Tasks;
using Adventurer.Sprites.Map;

namespace Adventurer.Sprites
{
    internal class Enemy : Sprite
    {
        private List<Vector2> path;
        private int currentPathIndex;
        private float speed = 1f;
        public int gridSize = 8;
        private readonly AStarPathfinder pathfinder;
        private float waitTime = 10f; // Set the wait time in seconds
        private float elapsedTime = 0f;
        private EnemyState currentState = EnemyState.Moving;

        public Enemy(Texture2D texture, Vector2 position) : base(texture, position)
        {
            path = new List<Vector2>();
            currentPathIndex = 0;
            pathfinder = new AStarPathfinder(gridSize);
            Origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
        }

        public override void Update(GameTime gameTime, GraphicsDeviceManager graphics, List<Sprite> sprites)
        {
            base.Update(gameTime, graphics, sprites);


            if (path.Count > 0 && currentPathIndex < path.Count)
            {
                // Move towards the next point in the path
                Vector2 direction = path[currentPathIndex] - Position;
                direction.Normalize();
                Position += direction * speed;

                // Check if the enemy has reached the current path point
                if (Vector2.Distance(Position, path[currentPathIndex]) < 1f)
                {
                    currentPathIndex++;
                }
            }
            else
            {
                // Calculate a new path to the player
                //CalculatePathToPlayer(sprites);
            }
            switch (currentState)
            {
                case EnemyState.Moving:
                    UpdateMovingState(gameTime, sprites);
                    break;

                case EnemyState.Waiting:
                    UpdateWaitingState(gameTime, sprites);
                    break;

                    // Add more states as needed...
            }
        }

        private void CalculatePathToPlayer(List<Sprite> sprites)
        {
            Player player = sprites.OfType<Player>().FirstOrDefault();

            if (player == null)
                return; // Player not found

            int mapWidth = 720 / gridSize;
            int mapHeight = 720 / gridSize;

            // Cache obstacle positions
            List<Vector2> obstaclePositions = sprites
                .Where(sprite => sprite != this && sprite.Texture.Name == "wall")
                .Select(sprite => sprite.Position)
                .ToList();

            // Use A* pathfinding with obstacle positions
            path = pathfinder.FindPathWithObstacles(Position, player.Position, obstaclePositions);

            // Smooth the path
            path = SmoothPath(path, obstaclePositions);

            // Reset path index
            currentPathIndex = 0;
        }

        private List<Vector2> SmoothPath(List<Vector2> originalPath, List<Vector2> obstaclePositions)
        {
            if (originalPath.Count < 3)
                return originalPath;

            List<Vector2> smoothedPath = new List<Vector2>();
            smoothedPath.Add(originalPath[0]);

            for (int i = 1; i < originalPath.Count - 1; i++)
            {
                Vector2 start = smoothedPath.Last();
                Vector2 end = originalPath[i + 1];

                if (!IsObstacleBetween(start, end, obstaclePositions))
                {
                    smoothedPath.Add(originalPath[i]);
                }
            }

            smoothedPath.Add(originalPath.Last());
            return smoothedPath;
        }

        private bool IsObstacleBetween(Vector2 start, Vector2 end, List<Vector2> obstaclePositions)
        {
            foreach (var obstacle in obstaclePositions)
            {
                if (IsPointInLine(start, end, obstacle))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsPointInLine(Vector2 lineStart, Vector2 lineEnd, Vector2 point)
        {
            float distance = Vector2.Distance(lineStart, lineEnd);
            float distanceToPoint = Vector2.Distance(lineStart, point) + Vector2.Distance(lineEnd, point);
            return Math.Abs(distance - distanceToPoint) < 0.1f;
        }

        private void UpdateMovingState(GameTime gameTime, List<Sprite> sprites)
        {
            if (path.Count > 0 && currentPathIndex < path.Count)
            {
                // Move towards the next point in the path
                Vector2 direction = path[currentPathIndex] - Position;
                direction.Normalize();
                Position += direction * speed;

                // Check if the enemy has reached the current path point
                if (Vector2.Distance(Position, path[currentPathIndex]) < 1f)
                {
                    currentPathIndex++;

                    // Check if the enemy has reached the end of the path
                    if (currentPathIndex >= path.Count)
                    {
                        currentState = EnemyState.Waiting;
                        elapsedTime = 0f; // Reset the elapsed time
                    }
                }
            }
            else
            {
                // Calculate a new path to the player
                CalculatePathToPlayer(sprites);
            }
        }

        private void UpdateWaitingState(GameTime gameTime, List<Sprite> sprites)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= waitTime)
            {
                currentState = EnemyState.Moving;
                CalculatePathToPlayer(sprites);
            }
        }
    }

}
