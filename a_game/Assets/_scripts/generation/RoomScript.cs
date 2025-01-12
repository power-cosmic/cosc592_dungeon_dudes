﻿using UnityEngine;
using System.Collections;

public class RoomScript : MonoBehaviour
{
		public GameObject wallPrefab;
		public GameObject doorPrefab;
		public GameObject spawnerPrefab;
		public GameObject hunterPrefab;
		public GameObject bossPrefab;
		private GameObject[] walls = new GameObject[4];
		private GameObject[] doors = new GameObject[4];
		private float height;
		private float width;
		// Use this for initialization
		void Start ()
		{
				this.createWalls ();
				this.createDoors ();
				this.height = this.transform.GetChild (0).localScale.z;
				this.width = this.transform.GetChild (0).localScale.x;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown ("space")) {
						this.makeHunters ();
				}
		}

		private void createDoors ()
		{
				for (int i = 0; i < this.doors.Length; i++) {
						this.doors [i] = (GameObject)Instantiate (doorPrefab);
						this.doors [i].transform.localScale = new Vector3 (this.transform.localScale.x / 2,
			                                                   this.transform.localScale.y * 2.5f,
			                                                   this.transform.localScale.z / 2);
						this.doors [i].transform.parent = this.transform;
			
				}
				this.doors [0].transform.localScale += new Vector3 (this.transform.GetChild (0).localScale.x / 4, 0, 0);
				this.doors [1].transform.localScale += new Vector3 (0, 0, this.transform.GetChild (0).localScale.z / 3);
				this.doors [2].transform.localScale += new Vector3 (this.transform.GetChild (0).localScale.x / 4, 0, 0);
				this.doors [3].transform.localScale += new Vector3 (0, 0, this.transform.GetChild (0).localScale.z / 3);
				

				this.doors [0].transform.position = new Vector3 (this.transform.position.x, 
		                                                 0, 
		                                                 this.transform.position.z + this.transform.GetChild (0).localScale.z / 2);
				this.doors [1].transform.position = new Vector3 (this.transform.position.x + this.transform.GetChild (0).localScale.x / 2, 
		                                                 0, 
		                                                 this.transform.position.z);
				this.doors [2].transform.position = new Vector3 (this.transform.position.x, 
		                                                 0, this.transform.position.z - this.transform.GetChild (0).localScale.z / 2);
				this.doors [3].transform.position = new Vector3 (this.transform.position.x - this.transform.GetChild (0).localScale.x / 2, 
		                                                 this.transform.position.y, 
		                                                 this.transform.position.z);
		
				
		
				for (int i = 0; i < this.doors.Length; i++) {
						this.doors [i].renderer.material.mainTextureScale = 
							new Vector2 (this.doors [i].transform.localScale.x * 2, 
							             this.doors [i].transform.localScale.z * 2);
				}
		}

		private void createWalls ()
		{
				for (int i = 0; i < this.walls.Length; i++) {
						this.walls [i] = (GameObject)Instantiate (wallPrefab);
						this.walls [i].transform.localScale = new Vector3 (this.transform.localScale.x / 2,
			                                                   this.transform.localScale.y * 2,
			                                                   this.transform.localScale.z / 2);
						this.walls [i].transform.parent = this.transform;
				}
		
				this.walls [0].transform.position = new Vector3 (this.transform.position.x, 
		                                                 0, 
		                                                 this.transform.position.z + this.transform.GetChild (0).localScale.z / 2);
				this.walls [1].transform.position = new Vector3 (this.transform.position.x + this.transform.GetChild (0).localScale.x / 2, 
		                                                 0, 
		                                                 this.transform.position.z);
				this.walls [2].transform.position = new Vector3 (this.transform.position.x, 
		                                                 0, this.transform.position.z - this.transform.GetChild (0).localScale.z / 2);
				this.walls [3].transform.position = new Vector3 (this.transform.position.x - this.transform.GetChild (0).localScale.x / 2, 
		                                                 this.transform.position.y, 
		                                                 this.transform.position.z);
		
				this.walls [0].transform.localScale += new Vector3 (this.transform.GetChild (0).localScale.x, 0, 0);
				this.walls [1].transform.localScale += new Vector3 (0, 0, this.transform.GetChild (0).localScale.z);
				this.walls [2].transform.localScale += new Vector3 (this.transform.GetChild (0).localScale.x, 0, 0);
				this.walls [3].transform.localScale += new Vector3 (0, 0, this.transform.GetChild (0).localScale.z);
		
				for (int i = 0; i < this.walls.Length; i++) {
						this.walls [i].renderer.material.mainTextureScale = 
										new Vector2 (this.walls [i].transform.localScale.x * 2, 
				             							this.walls [i].transform.localScale.z * 2);
				}
		}

		public void makeHunters ()
		{
				GameObject[] hunters = new GameObject[3];
				for (int i = 0; i < hunters.Length; i++) {
						hunters [i] = (GameObject)Instantiate (this.hunterPrefab);
						hunters [i].transform.parent = this.transform;
//						hunters [i].transform.position = new Vector3 (Random.Range (hunters [i].transform.localScale.x, 
//			                                                           this.width - hunters [i].transform.localScale.x * 2),
//			                                          0.1f,
//			                                             Random.Range (hunters [i].transform.localScale.z, 
						//			              this.height - hunters [i].transform.localScale.z * 2));
						hunters [i].transform.position = new Vector3 (Random.Range (-(this.width / 2) + hunters [i].transform.localScale.x, 
			                                                            this.width / 2 - hunters [i].transform.localScale.x),
			                                          0.1f,
			                                              Random.Range (-(this.height / 2) + hunters [i].transform.localScale.x, 
			              this.height / 2 - hunters [i].transform.localScale.x));
				}
		}

		public void makeSpawner ()
		{
				GameObject spawner = (GameObject)Instantiate (this.spawnerPrefab);
				spawner.transform.parent = this.transform;
//				spawner.transform.position = new Vector3 (Random.Range (spawner.transform.localScale.x, 
//		                                                        this.width - spawner.transform.localScale.x * 2),
//		                                          0.1f,
//		                                          Random.Range (spawner.transform.localScale.z, 
//		              this.height - spawner.transform.localScale.z * 2));
				spawner.transform.position = new Vector3 (Random.Range (-(this.width / 2) + spawner.transform.localScale.x, 
		                                                        this.width / 2 - spawner.transform.localScale.x),
		                                          0.1f,
		                                          Random.Range (-(this.height / 2) + spawner.transform.localScale.x, 
		              											this.height / 2 - spawner.transform.localScale.x));
		}

		public void makeRandom ()
		{
				switch (Random.Range (1, 3)) {
				case 1:
						this.makeHunters ();
						break;
				case 2:
						this.makeSpawner ();
						this.makeSpawner ();
						break;
				case 3:
						this.makeBossman ();
						break;
				}
		}

		public void makeBossman ()
		{

		}

		public void removeTopDoor ()
		{
				this.removeDoor (0);
		}

		public void removeRightDoor ()
		{
				this.removeDoor (1);
		
		}

		public void removeBottomDoor ()
		{
				this.removeDoor (2);
		}

		public void removeLeftDoor ()
		{
				this.removeDoor (3);
		}

		private void removeDoor (int door)
		{
				Destroy (this.doors [door]);
		}
}
