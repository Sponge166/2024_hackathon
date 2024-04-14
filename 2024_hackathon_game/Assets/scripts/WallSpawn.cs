using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject hallwayPrefab;
    public int floorLength = 100;
    public int numberOfFloors = 3; // Number of floors to keep active at once

    private GameObject[] floors;
    private int currentFloorIndex = 0;

    private void Start()
    {
        floors = new GameObject[numberOfFloors];
        for (int i = 0; i < numberOfFloors; i++)
        {
            SpawnFloor(i);
        }
    }

    private void Update()
    {
        if (player.transform.position.z > floors[currentFloorIndex].transform.position.z + floorLength)
        {
            RecycleFloor();
            SpawnFloor(currentFloorIndex);
        }
    }

    private void SpawnFloor(int index)
    {
        GameObject floor = Instantiate(hallwayPrefab, Vector3.forward * floorLength * index, Quaternion.identity);
        floors[index] = floor;
    }

    private void RecycleFloor()
    {
        Destroy(floors[currentFloorIndex]);
        currentFloorIndex = (currentFloorIndex + 1) % numberOfFloors;
    }
}
