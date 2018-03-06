using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(VoxelAnimator))]
public class VoxelAnimatorEditor : Editor 
{
	#region Variables (private)
	
	float paramViewWidth = 120;
	float paramViewHeight = 100;

	#endregion
	
	#region Properties (public)

	VoxelAnimator animator;

	#endregion
	
	#region Unity event functions
	
	public override void OnInspectorGUI()
	{	
		
	}

	public void OnEditorGUI()
	{
		animator = (VoxelAnimator)target;

		EditorGUILayout.BeginHorizontal(GUILayout.Width(paramViewWidth));
		ParameterView();
		EditorGUILayout.EndHorizontal();
	}
	
	#endregion
	
	#region Methods

	private void ParameterView()
	{
		EditorGUILayout.BeginVertical(GUILayout.Width(paramViewWidth));
		EditorGUILayout.LabelField("Animator Parmeters", GUILayout.Width(paramViewWidth));
		if(GUILayout.Button("Add Float"))
		{
			animator.AddFloatParam();
		}
		FloatParamListView();
		if(GUILayout.Button("Add Bool"))
		{
			animator.AddBoolParam();
		}
		BoolParamListView();
		if(GUILayout.Button("Add Trigger"))
		{
			animator.AddTriggerParam();
		}
		TriggerParamListView();
		EditorGUILayout.EndVertical();
	}

	private void FloatParamListView()
	{
		if(animator.FloatParameters.Count > 0)
		{
			EditorGUILayout.BeginScrollView(new Vector2(0, 0));
			for(int i = 0; i < animator.FloatParameters.Count; i++)
			{
				bool deleted = false;
				FloatParmView(animator.FloatParameters[i], ref deleted);
				if(deleted)
					i--;
			}
			EditorGUILayout.EndScrollView();
		}
	}
	private void BoolParamListView()
	{
		if(animator.BoolParameters.Count > 0)
		{
			EditorGUILayout.BeginScrollView(new Vector2(0, 0));
			for(int i = 0; i < animator.BoolParameters.Count; i++)
			{
				bool deleted = false;
				BoolParamView(animator.BoolParameters[i], ref deleted);
				if(deleted)
					i--;
			}
			EditorGUILayout.EndScrollView();
		}
	}
	private void TriggerParamListView()
	{
		if(animator.TriggerParameters.Count > 0)
		{
			EditorGUILayout.BeginScrollView(new Vector2(0, 0));
			for(int i = 0; i < animator.TriggerParameters.Count; i++)
			{
				bool deleted = false;
				TriggerParamView(animator.TriggerParameters[i], ref deleted);
				if(deleted)
					i--;
			}
			EditorGUILayout.EndScrollView();
		}
	}

	private void FloatParmView(FloatParameter param, ref bool deleted)
	{	
		EditorGUILayout.BeginHorizontal(GUILayout.Width(paramViewWidth));
		EditorGUILayout.LabelField("Name", GUILayout.Width(paramViewWidth - 15));
		if(GUILayout.Button("-", GUILayout.Width(15)))
		{
			animator.RemoveFloatParam(param);
			deleted = true;
		}
		EditorGUILayout.EndHorizontal();	
		param.Name = EditorGUILayout.TextField(param.Name);
		EditorGUILayout.LabelField("Value");
		param.Value = EditorGUILayout.FloatField(param.Value);
	}
	private void BoolParamView(BoolParameter param, ref bool deleted)
	{	
		EditorGUILayout.BeginHorizontal(GUILayout.Width(paramViewWidth));
		EditorGUILayout.LabelField("Name", GUILayout.Width(paramViewWidth - 15));
		if(GUILayout.Button("-", GUILayout.Width(15)))
		{
			animator.RemoveBoolParameter(param);
			deleted = true;
		}
		EditorGUILayout.EndHorizontal();	
		param.Name = EditorGUILayout.TextField(param.Name);
		EditorGUILayout.LabelField("Value");
		param.Value = EditorGUILayout.Toggle(param.Value);
	}
	private void TriggerParamView(TriggerParameter param, ref bool deleted)
	{	
		EditorGUILayout.BeginHorizontal(GUILayout.Width(paramViewWidth));
		EditorGUILayout.LabelField("Name", GUILayout.Width(paramViewWidth - 15));
		if(GUILayout.Button("-", GUILayout.Width(15)))
		{
			animator.RemoveTriggerParam(param);
			deleted = true;
		}
		EditorGUILayout.EndHorizontal();	
		param.Name = EditorGUILayout.TextField(param.Name);
		EditorGUILayout.LabelField("Value");
		param.Value = EditorGUILayout.Toggle(param.Value);
	}
	
	#endregion
}
