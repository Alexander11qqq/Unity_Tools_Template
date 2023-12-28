using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnumTabsExample : MonoBehaviour
{
    public int health;
    public float speed;
    public int agility;
    public enum TabType
    {
        Tab1,
        Tab2,
        Tab3
    }

    private TabType selectedTab;

    //���������� ���� Enum ��� ����������� � ���� �������

#if UNITY_EDITOR
       // Editor ����� ��� �������������� ����������� Enum
       [CustomEditor(typeof(EnumTabsExample))]
        public class EnumTabsExampleEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            EnumTabsExample enumTabsExample = (EnumTabsExample)target;

            // ���������� Enum � ���� �������
            enumTabsExample.selectedTab = (TabType)GUILayout.Toolbar((int)enumTabsExample.selectedTab, new string[] { "Mouse", "Touch", "Mouse&Touch" });

            // � ����������� �� ��������� �������, ���������� ��������������� ����������
            switch (enumTabsExample.selectedTab)
            {
                case TabType.Tab1:
                    EditorGUILayout.LabelField("�������������� � ������", EditorStyles.boldLabel);
                    enumTabsExample.agility = EditorGUILayout.IntField("Agility", enumTabsExample.agility);
                    break;
                case TabType.Tab2:
                    EditorGUILayout.LabelField("�������������� � �����", EditorStyles.boldLabel);
                    enumTabsExample.speed = EditorGUILayout.FloatField("Speed", enumTabsExample.speed);
                    break;
                case TabType.Tab3:
                    EditorGUILayout.LabelField("��� �������� �����", EditorStyles.boldLabel);
                    enumTabsExample.health = EditorGUILayout.IntField("Health", enumTabsExample.health);
                    break;
            }
        }
    }
#endif
}
