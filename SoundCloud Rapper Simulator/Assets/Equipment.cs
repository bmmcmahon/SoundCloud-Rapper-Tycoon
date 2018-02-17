using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment {

	private int level;
	private double cost;

	public int Level { get { return level; } }
	public double Cost { get { return cost; } }

	public Equipment()
	{
		level = 1;
		cost = 50;
	}

	public int levelUp(GameState gameState)
	{
		this.level += 1;
		gameState.Level += 1;
		this.cost *= 1.5;
		return level;
	}

}
