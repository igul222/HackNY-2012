using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathManager : MonoBehaviour {
	
	public List<HealthController> entities;
	public ProgressBar[] progressBars;
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<entities.Count; i++) {
			HealthController hc = entities[i];
			if (hc == null)
				continue;
			
			if (hc.gameObject.active && hc.health <= 0) {
				entities[i] = null;
				hc.gameObject.SendMessage("Die");
				if (hc.tag == "Player")
					StartCoroutine(PrepareRestart(false));
				else {
					//StartCoroutine(PrepareRestart(true));
				}
			}
		}
	}
	
	IEnumerator PrepareRestart (bool won) {
		if (won) {
			yield return new WaitForSeconds (11);
			Screen.lockCursor = false;
		}
		else {
			yield return new WaitForSeconds (5);
		}
		Application.LoadLevel(0);
	}
}
// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Filename: AISpawn.cs
//  
// Author: Garth "Corrupted Heart" de Wet <mydeathofme[at]gmail[dot]com>
// Website: www.CorruptedHeart.co.cc
// 
// Copyright (c) 2010 Garth "Corrupted Heart" de Wet
//  
// Permission is hereby granted, free of charge (a donation is welcome at my website), to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
public class AISpawn : MonoBehaviour
{
private GameObject objSpawn;
private int SpawnerID;
// Used to find the parent spawner object
void Start () {
	objSpawn = (GameObject) GameObject.FindWithTag ("Spawner");
}
// Call this when you want to kill the enemy
void removeMe ()
{
	objSpawn.BroadcastMessage("killEnemy", SpawnerID);
	Destroy(gameObject);
}
// this gets called in the beginning when it is created by the spawner script
void setName(int sName)
{
	SpawnerID = sName;
}
}