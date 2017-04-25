using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class TestSerialization : MonoBehaviour
{
	public bool someBool;
	public float someFloat;
	[Range(2, 3)]
	public float someFloatWithSlider = 2.5f;

	[Serializable]
	public class Nested
	{
		[Range(0, 10)]
		public int someInt;
		public string someString;
	}
	public Nested nested;
	public Nested[] arrayOfNested;

	[Header("Another Section")]
	public bool someBoolInAnotherSection;
	public float someFloatInAnotherSection;
	public GameObject someGO;
	public Transform someTransform;
	public Light someLight;
	public MonoBehaviour someMonoBehaviour;
	public TestSerialization someSpecificBehaviour;


	[Serializable]
	public class CustomClass
	{
		public TestDatabase database;
		public int itemIndex;
	}

	[Header("Custom Drawer")]
	public CustomClass customClass;
	[CustomClassDrawerAttribute]
	public CustomClass customClassWithDrawer;
}

public class CustomClassDrawerAttribute : PropertyAttribute
{
}

//[CustomPropertyDrawer(typeof(TestSerialization.CustomClass))]
[CustomPropertyDrawer(typeof(CustomClassDrawerAttribute))]
public class CustomClassDrawer : PropertyDrawer
{
	const float defaultPropertyHeight = 16;

	public override float GetPropertyHeight( SerializedProperty property, GUIContent label )
	{
		return defaultPropertyHeight * 3;
	}

	public override void OnGUI( Rect rect, SerializedProperty property, GUIContent label )
	{
		//base.OnGUI(rect, property, label);

		SerializedProperty propDatabase = property.FindPropertyRelative("database");
		SerializedProperty propItemIndex = property.FindPropertyRelative("itemIndex");

		rect.height = defaultPropertyHeight;
		EditorGUI.PrefixLabel(rect, label);
		rect.y += defaultPropertyHeight;

		EditorGUI.indentLevel++;
		{
			EditorGUI.PropertyField(rect, propDatabase);
			rect.y += defaultPropertyHeight;

			//EditorGUI.PropertyField(rect, propItemIndex);
			//rect.y += defaultPropertyHeight;

			TestDatabase database = (TestDatabase)propDatabase.objectReferenceValue;
			if (database)
			{
				propItemIndex.intValue = EditorGUI.Popup(rect, propItemIndex.displayName, propItemIndex.intValue, database.items);
			}
			else
			{
				GUI.enabled = false;
				EditorGUI.PropertyField(rect, propItemIndex);
				//EditorGUI.LabelField(rect, propItemIndex.displayName, "N/A");
				GUI.enabled = true;
			}
			rect.y += defaultPropertyHeight;
		}
		EditorGUI.indentLevel--;
	}
}
