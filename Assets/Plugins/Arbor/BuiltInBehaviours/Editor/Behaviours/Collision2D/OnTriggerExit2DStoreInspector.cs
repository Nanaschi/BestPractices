﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEditor;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(OnTriggerExit2DStore))]
	internal sealed class OnTriggerExit2DStoreInspector : CheckTagBehaviourBaseInspector
	{
		protected override void OnFieldGUI()
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Parameter"));
		}
	}
}
