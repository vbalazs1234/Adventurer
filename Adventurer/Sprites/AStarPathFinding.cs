using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Adventurer
{
    public class AStarPathfinder
    {
        private readonly int gridSize;

        public AStarPathfinder(int gridSize)
        {
            this.gridSize = gridSize;
        }

        public List<Vector2> FindPathWithObstacles(Vector2 start, Vector2 goal, List<Vector2> obstaclePositions)
        {
            // Convert positions to grid coordinates
            Point startGrid = ConvertToGridCoordinates(start);
            Point goalGrid = ConvertToGridCoordinates(goal);

            // Initialize open and closed sets
            HashSet<Point> openSet = new HashSet<Point>();
            HashSet<Point> closedSet = new HashSet<Point>();

            openSet.Add(startGrid);

            // Initialize cost and parent dictionaries
            Dictionary<Point, float> gScore = new Dictionary<Point, float>();
            Dictionary<Point, Point> parent = new Dictionary<Point, Point>();

            gScore[startGrid] = 0;

            while (openSet.Count > 0)
            {
                Point current = GetLowestFScore(openSet, gScore);

                if (current == goalGrid)
                    return ReconstructPath(parent, goalGrid);

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var neighbor in GetNeighbors(current, obstaclePositions))
                {
                    if (closedSet.Contains(neighbor))
                        continue;

                    float tentativeGScore = gScore[current] + 1; // Assuming each step costs 1

                    if (!openSet.Contains(neighbor) || tentativeGScore < gScore[neighbor])
                    {
                        parent[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;

                        if (!openSet.Contains(neighbor))
                            openSet.Add(neighbor);
                    }
                }
            }

            // No path found
            return new List<Vector2>();
        }

        private Point GetLowestFScore(HashSet<Point> openSet, Dictionary<Point, float> gScore)
        {
            Point minPoint = default(Point);
            float minScore = float.MaxValue;

            foreach (var point in openSet)
            {
                if (gScore.TryGetValue(point, out float score) && score < minScore)
                {
                    minScore = score;
                    minPoint = point;
                }
            }

            return minPoint;
        }

        private List<Vector2> ReconstructPath(Dictionary<Point, Point> parent, Point goal)
        {
            List<Vector2> path = new List<Vector2>();

            while (parent.ContainsKey(goal))
            {
                path.Add(ConvertToVector2(goal));
                goal = parent[goal];
            }

            path.Reverse();
            return path;
        }

        private IEnumerable<Point> GetNeighbors(Point point, List<Vector2> obstaclePositions)
        {
            List<Point> neighbors = new List<Point>();

            // Assuming 4-connected grid (no diagonal movement)
            Point[] possibleNeighbors = {
        new Point(point.X, point.Y - 1), // Up
        new Point(point.X, point.Y + 1), // Down
        new Point(point.X - 1, point.Y), // Left
        new Point(point.X + 1, point.Y)  // Right
    };

            foreach (var neighbor in possibleNeighbors)
            {
                // Check if the neighbor is within the grid bounds and not an obstacle
                if (IsPointValid(neighbor, obstaclePositions))
                    neighbors.Add(neighbor);
            }

            return neighbors;
        }


        private bool IsPointValid(Point point, List<Vector2> obstaclePositions)
        {
            return point.X >= 0 && point.Y >= 0 &&
                   !obstaclePositions.Any(obstacle => IsPointInGridCell(point, obstacle));
        }

        private bool IsPointInGridCell(Point gridCell, Vector2 point)
        {
            int xMin = gridCell.X * gridSize;
            int xMax = xMin + gridSize;
            int yMin = gridCell.Y * gridSize;
            int yMax = yMin + gridSize;

            return point.X >= xMin && point.X < xMax &&
                   point.Y >= yMin && point.Y < yMax;
        }

        private Point ConvertToGridCoordinates(Vector2 position)
        {
            return new Point((int)(position.X / gridSize), (int)(position.Y / gridSize));
        }

        private Vector2 ConvertToVector2(Point point)
        {
            return new Vector2(point.X * gridSize, point.Y * gridSize);
        }
    }
}
