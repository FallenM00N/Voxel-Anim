#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
#endif

public class VoxelAnimator : MonoBehaviour
{
	#region Variables (private)

	#endregion
	
	#region Properties (public)
	public List<VoxelAnimation> Animations = new List<VoxelAnimation>();
	public List<FloatParameter> FloatParameters = new List<FloatParameter>();

	public List<BoolParameter> BoolParameters = new List<BoolParameter>();

	public List<TriggerParameter> TriggerParameters = new List<TriggerParameter>();

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
	public void AddFloatParam()
	{
		FloatParameters.Add(new FloatParameter());
	}
	public void AddBoolParam()
	{
		BoolParameters.Add(new BoolParameter());
	}
	public void AddTriggerParam()
	{
		TriggerParameters.Add(new TriggerParameter());
	}

	public void RemoveFloatParam(FloatParameter param)
	{
		FloatParameters.Remove(param);
	}
	public void RemoveBoolParameter(BoolParameter param)
	{
		BoolParameters.Remove(param);
	}
	public void RemoveTriggerParam(TriggerParameter param)
	{
		TriggerParameters.Remove(param);
	}
	
	#endregion
}
