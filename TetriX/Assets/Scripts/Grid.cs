using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	public static int w = 10;
	public static int h = 20;
	public AudioClip soundLine;
	private static Flash flsh;
	public static Transform[,] grid = new Transform[w, h];
	public static Vector2 roundVec2(Vector2 v) {
		return new Vector2(Mathf.Round(v.x),
			Mathf.Round(v.y));
	}

	public static int abs(int i) {
		if (i < 0)
			return -i;
		else
			return i;
	}
	public static bool insideBorder(Vector2 pos) {
		return ((int)pos.x >= 0 &&
			(int)pos.x < w &&
			(int)pos.y >= 0);
	}
	public static bool isRowFull(int y) {
		for (int x = 0; x < w; ++x)
			if (grid[x, y] == null)
				return false;
		return true;
	}
	public static void deleteRow(int y) {
		for (int x = 0; x < w; ++x) {
			if (grid [x, y] != null) {
				if (grid [x, y].gameObject.name == "blocklightning") {
					Destroy (grid [x, y].gameObject);
					grid [x, y] = null;
					LightningStrike (x, y);
				} else {
					Destroy (grid [x, y].gameObject);
					grid [x, y] = null;
				}
			}
		}
	}
	public static void LightningStrike(int x, int y) {
		flsh =  GameObject.Find ("Flash").GetComponent<Flash> ();
		flsh.FlashBang ();
		for (int a = y + 3; a >= y - 3; a--)
			for (int b = x - (3 - abs(a - y)); b <= x + (3 - abs(a - y)); b++) {
				if (((b > 0) && (b < w)) && (a > 0) && (a < h) && (grid [b, a] != null)) {
					Destroy (grid [b, a].gameObject);
					grid [b, a] = null;
				}
			}
		}
	public static void decreaseRow(int y) {
		for (int x = 0; x < w; ++x) {
			if (grid[x, y] != null) {
				// Move one towards bottom
				grid[x, y-1] = grid[x, y];
				grid[x, y] = null;

				// Update Block position
				grid[x, y-1].position += new Vector3(0, -1, 0);
			}
		}
	}
	public static void decreaseRowsAbove(int y) {
		for (int i = y; i < h; ++i)
			decreaseRow(i);
	}
	public static void deleteFullRows() {
		for (int y = 0; y < h; ++y) {
			if (isRowFull(y)) {
				deleteRow(y);
				decreaseRowsAbove(y+1);
				--y;
			}
		}
	}
}
