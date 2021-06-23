using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    [SerializeField] private Wall _wallTemplate;
    [SerializeField] private float _wallSize;

    private Camera cameraMain;
    void Start()
    {
        cameraMain = Camera.main;
        Vector3 viewPortLeft = new Vector3(0, 0, 1);
        Vector3 viewPortRight = new Vector3(1, 0, 1);
        SpawnWall(viewPortLeft);
        SpawnWall(viewPortRight);
    }

    private void SpawnWall(Vector3 viewPortPosition)
    {
        Vector3 position = GetWallPosition(viewPortPosition);
        Wall wall = Instantiate(_wallTemplate, position, Quaternion.identity);
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, _wallSize, wall.transform.localScale.z);
    }

    private Vector3 GetWallPosition(Vector3 viewPortPosition)
    {
        return cameraMain.ViewportToWorldPoint(viewPortPosition);
    }
}
