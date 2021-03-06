﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VoxelAnimation 
{
	#region Variables (private)
	
	#endregion
	
	#region Properties (public)
	
	public string Name = "Animation";
	public List<Mesh> Frames;
	public List<float> KeyFrames;
	public List<VoxelTransition> Transitions = new List<VoxelTransition>();

	public int CurFrame;
	
	public bool IsPlaying = false;

	public float AnimationTime = 0;

	#endregion
	
	#region Unity event functions
	
	void Start()
	{
		
	}
	
	void Update() 
	{
		
	}
	
	#endregion
	
	#region Methods
	
	#endregion
}
