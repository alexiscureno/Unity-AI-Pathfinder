using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour {

	public NavMeshSurface surface;

	public int width = 10;
	public int height = 10;

	public GameObject wall;
	public GameObject player;

	private bool playerSpawned = false;

	// Use this for initialization
	void Start () {
		GenerateLevel();

		//Update navmesh
		surface.BuildNavMesh();

	}
	
	// Genera el nivel
	void GenerateLevel()
	{
		// Loop para spawnear grid
		for (int x = 0; x <= width; x+=2)
		{
			for (int y = 0; y <= height; y+=2)
			{
				
				if (Random.value > .7f)
				{
					// Spawnea paredes
					Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
					Instantiate(wall, pos, Quaternion.identity, transform);
				} else if (!playerSpawned) //si no hay lo Spawnea
				{
					// Spawnea al jugador
					Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
					Instantiate(player, pos, Quaternion.identity);
					playerSpawned = true;
				}
			}
		}
	}

}