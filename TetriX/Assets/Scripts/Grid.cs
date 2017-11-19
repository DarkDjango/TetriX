using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	public static int w = 10;
	public static int h = 20;
	public AudioClip soundLine;
	private static Flash flsh;
	private static Bubbles wtr;
	private static GameObject go;
	private static int[] specialblocks = new int[10];
	private static ScoreText gameScoreDisplay;
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
		gameScoreDisplay = GameObject.Find ("Score").GetComponent<ScoreText> ();
		gameScoreDisplay.score = gameScoreDisplay.score + 100;
		for (int x = 0; x < w; ++x) {
			if (grid [x, y] != null) {
				if (grid [x, y].gameObject.name == "blocklightning")
					specialblocks [x] = 1;
				else if (grid [x, y].gameObject.name == "blockfrost")
					specialblocks [x] = 2;
				Destroy (grid [x, y].gameObject);
				grid [x, y] = null;
			}
		}
	}
	public static void LightningStrike(int x, int y) {
		flsh =  GameObject.Find ("Flash").GetComponent<Flash> ();
		flsh.FlashBang ();
		for (int a = y + 3; a >= y - 3; a--)
			for (int b = x - (3 - abs(a - y)); b <= x + (3 - abs(a - y)); b++) {
				if (((b >= 0) && (b < w)) && (a >= 0) && (a < h) && (grid [b, a] != null)) {
					Destroy (grid [b, a].gameObject);
					grid [b, a] = null;
				}
			}
		}
	public static void AirBubbles() {
		int bubbles = Random.Range (1, 3);
		int[] valid4x4 = new int[9];
		int[] valid2x2 = new int[9];
		int validbubbles2, validbubbles4, position;
		for (int c = 0; c < bubbles; c++) {
			validbubbles2 = 0;
			validbubbles4 = 0;
			for (int xsearch = 0; xsearch < 9; xsearch++) {
				if ((grid [xsearch, 0] != null) && (grid [xsearch + 1, 0] != null)) {
					valid2x2 [xsearch] = 1;
					validbubbles2++;
					if ((grid [xsearch, 1] != null) && (grid [xsearch + 1, 1] != null)) {
						valid4x4 [xsearch] = 1;
						validbubbles4++;
					}
					else
						valid4x4 [xsearch] = 0;
				} else
					valid2x2 [xsearch] = 0;
			}
			if (validbubbles2 > 0) {
				if (validbubbles4 > 0) {
					position = Random.Range (0, 9);
					while (valid4x4 [position] != 1)
						position = Random.Range (0, 9);
					Instantiate(Resources.Load("Bubble"),grid[position,0].gameObject.transform.position, Quaternion.identity);
					Destroy (grid [position, 0].gameObject);
					grid [position, 0] = null;
					Instantiate(Resources.Load("Bubble"),grid[position+1,0].gameObject.transform.position, Quaternion.identity);
					Destroy (grid [position + 1, 0].gameObject);
					grid[position + 1, 0] = null;
					Instantiate(Resources.Load("Bubble"),grid[position,1].gameObject.transform.position, Quaternion.identity);
					Destroy (grid [position, 1].gameObject);
					grid [position, 1] = null;
					Instantiate(Resources.Load("Bubble"),grid[position+1,1].gameObject.transform.position, Quaternion.identity);
					Destroy (grid [position + 1, 1].gameObject);
					grid [position + 1, 1] = null;
				} else {
					position = Random.Range (0, 9);
					while (valid2x2 [position] != 1)
						position = Random.Range (0, 9);
					Instantiate(Resources.Load("Bubble"),grid[position,0].gameObject.transform.position, Quaternion.identity);
					Destroy (grid [position, 0].gameObject);
					grid [position, 0] = null;
					Instantiate (Resources.Load ("Bubble"), grid [position + 1, 0].gameObject.transform.position, Quaternion.identity);
					Destroy (grid [position + 1, 0].gameObject);
					grid [position + 1, 0] = null;
				}
			}
		}
		wtr =  GameObject.Find ("Water").GetComponent<Bubbles> ();
		wtr.BlueBubbles ();
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

				for (int x = 0; x < 10; x++) {
					
					if (specialblocks [x] == 1) {
						LightningStrike (x, y);
						specialblocks [x] = 0;
					} else if (specialblocks [x] == 2) {
						AirBubbles();
						specialblocks [x] = 0;
					}
				}
				--y;
			}
		}
	}

}
