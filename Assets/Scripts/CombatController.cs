﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the flow of combat.
/// </summary>
public class CombatController : MonoBehaviour {

	/// <summary>
	/// The instance of this singleton.
	/// </summary>
	public static CombatController _instance;

	Dungeon currentDungeon;
	Enemy currentEnemy;
	public Player player;

	/// <summary>
	/// Makes it a singleton.
	/// </summary>
	void Awake () {
		if (_instance == null) {
			_instance = this;
		} else {
			Debug.Log ("There are 2 combat controllers in the scene");
		}
	}

	public void NewDungeon(Dungeon newD){
		currentDungeon = newD;
	}

	/// <summary>
	/// Creates a new enemy, gives the player the turn.
	/// </summary>
	/// <param name="newE">New e.</param>
	public void NewEnemy(Enemy newE){
		currentEnemy = newE;
		Debug.Log ("has an enemy");
		player.MyTurn ();
	}

	/// <summary>
	/// Attacks the enemy.
	/// </summary>
	/// <param name="dp">Dp.</param>
	public void AttackEnemy(DamagePackage dp){
		if (currentEnemy.TakeDamage (dp)) {
			Debug.Log ("Enemey Died!");
			currentDungeon.NextEncounter ();
		} else {
			//Says it is the enemies turn.
			currentEnemy.MyTurn ();
		}
	}

	/// <summary>
	/// Attacks the player.
	/// </summary>
	/// <param name="dp">Dp.</param>
	public void AttackPlayer(DamagePackage dp){
		if (player.TakeDamage (dp)) {
			Debug.Log ("Player died!");
		} else {
			//Says it is the players turn.
			player.MyTurn ();
		}
	}
}