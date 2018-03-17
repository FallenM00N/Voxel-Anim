using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VoxelAnimatorWindow : EditorWindow
{
    #region Variables (private)
	GameObject selected;
    VoxelAnimator animator;
	VoxelAnimatorEditor editor;

	bool TransitionsDrawn = false;

	float paramViewHeight = 100;

	List<Rect> windows = new List<Rect>();
	List<int> animationsToAttach = new List<int>();
	List<int> attachedAnimations = new List<int>();

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
		EditorGUILayout.BeginHorizontal();
		ParameterColumn();
		NodeEditor();
		EditorGUILayout.EndHorizontal();
    }

    void ParameterColumn()
    {

		bool recreateEditor = false;
        EditorGUILayout.BeginVertical(GUILayout.Width(paramViewHeight));
		if(Selection.activeGameObject != selected)
		{
			recreateEditor = true;
			selected = Selection.activeGameObject;
		}
        if (selected != null)
        {
            animator = selected.GetComponent<VoxelAnimator>();
            if (animator != null)
            {
                if(recreateEditor)
					editor = (VoxelAnimatorEditor)Editor.CreateEditor(animator);
                editor.OnEditorGUI();
            }
        }
        EditorGUILayout.EndVertical();
    }
	
	void NodeEditor()
	{

		EditorGUILayout.BeginVertical();

		//Make windows for each Animation
		if(animator.Animations.Count != windows.Count)
		{
			windows.Clear();
			attachedAnimations.Clear();
			animationsToAttach.Clear();
			foreach (VoxelAnimation animation in animator.Animations)
			{
				windows.Add(new Rect(10, 10, 100, 40));
			}
		}

		//if(!TransitionsDrawn)
		{
			foreach (VoxelAnimation animation in animator.Animations)
			{
				foreach (VoxelTransition transition in animation.Transitions)
				{
					int from = animator.Animations.IndexOf(animation);
					int to = animator.Animations.IndexOf(transition.TargetAnimation);
					DrawNodeCurve(windows[from], windows[to]);
				}
			}
			TransitionsDrawn = true;
		}
		
		if (animationsToAttach.Count == 2)
		{
			attachedAnimations.Add(animationsToAttach[0]);
			attachedAnimations.Add(animationsToAttach[1]);
			animationsToAttach = new List<int>();
		}
		if(attachedAnimations.Count >= 2)
		{
			for(int i = 0; i < attachedAnimations.Count; i += 2)
			{
				VoxelTransition transition = new VoxelTransition();
				transition.TargetAnimation = animator.Animations[attachedAnimations[i + 1]];
				animator.Animations[attachedAnimations[i]].Transitions.Add(transition);
				TransitionsDrawn = false;
				//DrawNodeCurve(windows[attachedAnimations[i]], windows[attachedAnimations[i+1]]);
			}
			attachedAnimations.Clear();
			animationsToAttach.Clear();
		}
		

		BeginWindows();

		if(GUILayout.Button("Create Animation"))
		{
			animator.AddAnimation();
			windows.Add(new Rect(150, 50, 100, 100));
		}

		for(int i = 0; i < windows.Count; i++)
		{
			windows[i] = GUI.Window(i, windows[i], DrawNodeWindow, animator.Animations[i].Name);
		}

		EndWindows();
		
		//TODO: Add ability to delete animations individually.
		if(GUILayout.Button("Clear"))
		{
			animator.Animations.Clear();
			attachedAnimations.Clear();
			animationsToAttach.Clear();
		}
		EditorGUILayout.EndVertical();
	}

	void DrawNodeWindow(int id)
	{
		if(GUILayout.Button("Attach"))
		{
			animationsToAttach.Add(id);
		}
		GUI.DragWindow();
	}

	void DrawNodeCurve(Rect start, Rect end) {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);
 
        for (int i = 0; i < 3; i++) {// Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
        }
 
        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
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
