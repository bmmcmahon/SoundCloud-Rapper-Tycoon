using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment {

	private int level;

	public int Level { get { return level; } }

	public Equipment()
	{
		level = 1;
	}

	public int levelUp(GameState gameState)
	{
		level += 1;
		gameState.Level += 1;
		return level;
	}

}
