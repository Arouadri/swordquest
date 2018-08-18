using UnityEngine;
using System.Collections;
//poniendo estos 2 metodos nos ajustara los botones en las pantallas
//de la misma manera independientemente de la resolucion
public class GUI2 : GUI {
	//cambiar estas 2 variables si la resoluccion de la pantalla es mayor
	public static float baseWidth = 1024;
	public static float baseHeight = 768;

	//ponerlo antes del boton
	public static void ScaleGUI(){
		Vector2 ratio = new Vector2( Screen.width/baseWidth, Screen.height/baseHeight);
		Matrix4x4 guiMatrix = Matrix4x4.identity;
		guiMatrix.SetTRS ( Vector3.zero, Quaternion.identity,new Vector3(ratio.x , ratio.y , 1));
		GUI.matrix = guiMatrix;
	}
	//ponerlo despues del boton
	public static void ResetGUI(){
		GUI.matrix = Matrix4x4.identity;
	}
}
