using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour {
	float lastFall = 0;
	public AudioClip line; 
	private Controller m_Controller;
	bool isValidGridPos() {        
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);

			// Not inside Border?
			if (!Grid.insideBorder(v))
				return false;

			// Block in grid cell (and not part of same group)?
			if (Grid.grid[(int)v.x, (int)v.y] != null &&
				Grid.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}
	public int abs( int i) {
		if (i < 0)
			return -i;
		else
			return i;
	}
	void updateGrid() {
		// Remove old children from grid
		for (int y = 0; y < Grid.h; ++y)
			for (int x = 0; x < Grid.w; ++x)
				if (Grid.grid[x, y] != null)
				if (Grid.grid[x, y].parent == transform)
					Grid.grid[x, y] = null;

		// Add new children to grid
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			Grid.grid[(int)v.x, (int)v.y] = child;
		}        
	}
	// Use this for initialization
	void Start() {
		if (!isValidGridPos()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
		}
		m_Controller = GameObject.Find ("Controller").GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update() {
		// Move Left
		if (Input.GetKeyDown (KeyCode.LeftArrow) || m_Controller.Left) {
			// Modify position
			transform.position += new Vector3 (-1, 0, 0);
			m_Controller.Left = false;
			// See if valid
			if (isValidGridPos ())
				// Its valid. Update grid.
				updateGrid ();
			else
				// Its not valid. revert.
				transform.position += new Vector3 (1, 0, 0);
		}
		// Move Right
		else if (Input.GetKeyDown (KeyCode.RightArrow) || m_Controller.Right) {
			// Modify position
			transform.position += new Vector3 (1, 0, 0);
			m_Controller.Right = false;
			// See if valid
			if (isValidGridPos ()) {
				// It's valid. Update grid.
				updateGrid ();
			} else
				// It's not valid. revert.
				transform.position += new Vector3(-1, 0, 0);
		}
		// Rotate
		else if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.UpArrow)|| m_Controller.Up) {
			transform.Rotate (0, 0, 90);
			m_Controller.Up = false;
			if (isValidGridPos ()) {
				updateGrid ();
			}
		}
		// Move Downwards and Fall
		else if (Input.GetKeyDown(KeyCode.DownArrow) || m_Controller.Down ||
			Time.time - lastFall >= 1) {
			// Modify position
			transform.position += new Vector3(0, -1, 0);
			m_Controller.Down = false;
			// See if valid
			if (isValidGridPos()) {
				// It's valid. Update grid.
				updateGrid();
			} else {
				// It's not valid. revert.
				transform.position += new Vector3(0, 1, 0);

				// Clear filled horizontal lines
				Grid.deleteFullRows();

				// Spawn next Group
				FindObjectOfType<SpawnBlock>().spawnNext();

				// Disable script
				enabled = false;
			}

			lastFall = Time.time;
		}
	}
}
