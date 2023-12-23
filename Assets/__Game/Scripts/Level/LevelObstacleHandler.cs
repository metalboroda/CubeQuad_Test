using System.Collections.Generic;
using UnityEngine;

namespace CubeQuad
{
  public class LevelObstacleHandler : MonoBehaviour
  {
    [SerializeField] private List<GameObject> _obstacles = new();
    [SerializeField] private List<ObstaclePoint> _obstaclePoints = new();

    [Header("")]
    [SerializeField] private int _maxObstacles = 5;

    private HashSet<int> spawnedObstacleIndices = new();

    private void Start()
    {
      GenerateRandomObstacles();
    }

    public void GenerateRandomObstacles()
    {
      int obstaclesToGenerate = Mathf.Min(_maxObstacles, _obstaclePoints.Count);

      List<ObstaclePoint> shuffledPoints = new(_obstaclePoints);

      shuffledPoints.Shuffle();

      spawnedObstacleIndices.Clear();

      for (int i = 0; i < obstaclesToGenerate; i++)
      {
        int randomObstacleIndex;

        do
        {
          randomObstacleIndex = Random.Range(0, _obstacles.Count);
        } while (spawnedObstacleIndices.Contains(randomObstacleIndex));

        GameObject obstaclePrefab = _obstacles[randomObstacleIndex];
        Transform obstaclePoint = shuffledPoints[i].transform;

        if (!shuffledPoints[i].Occupied)
        {
          Instantiate(obstaclePrefab, obstaclePoint.position, obstaclePoint.rotation);

          shuffledPoints[i].Occupied = true;
          spawnedObstacleIndices.Add(randomObstacleIndex);
        }
        else
        {
          i--;
        }
      }
    }
  }

  public static class ListExtensions
  {
    public static void Shuffle<T>(this IList<T> list)
    {
      int n = list.Count;

      while (n > 1)
      {
        n--;

        int k = Random.Range(0, n + 1);

        (list[n], list[k]) = (list[k], list[n]);
      }
    }
  }
}