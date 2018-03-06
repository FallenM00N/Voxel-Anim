using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VoxelAnimatorWindow : EditorWindow 
{
	#region Variables (private)
	GameObject selected;
	VoxelAnimatorEditor editor;

	#endregion
	
	#region Properties (public)
	
	#endregion
	
	#region Unity event functions
	
	[MenuItem("VoxelAnimator/Animator")]
	public static void ShowWindow()
	{
		GetWindow<VoxelAnimatorWindow>(false, "VoxelAnimator", true);
	}

	void OnGUI()
	{
		EditorGUILayout.BeginVertical();
		selected = Selection.activeGameObject;
		if(selected != null)
		{
			VoxelAnimator animator = selected.GetComponent<VoxelAnimator>();
			if(animator != null)
			{
				editor = (VoxelAnimatorEditor)Editor.CreateEditor(animator);
				editor.OnEditorGUI();
			}
		}
		EditorGUILayout.EndVertical();
	}

	void OnSelectionChange()
	{
		Repaint();
	}

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
