using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum Estados {novia, caja, crucifijo, habilidad};
	private Estados miEstado;
	// Use this for initialization
	void Start () {
		miEstado = Estados.novia;
	}
	
	// Update is called once per frame
	void Update () {
		print (miEstado);
		if 		(miEstado == Estados.novia) 	{estado_novia();} 
		else if (miEstado == Estados.caja) 		{estado_caja();} 
		else if (miEstado == Estados.crucifijo) {estado_crucifijo();} 		
		else if (miEstado == Estados.habilidad) {estado_habilidad();}	
	}
	
	#region Estados
	void estado_novia () {
		text.text = "Vas a visitar a tu novia, en seguida notas algo raro en ella," +
					" parece molesta por algo, comienzas a preocuparte; hay una caja" +
					" sobre la mesa, un crucifijo en la pared y tu habilidad verbal.\n\n" +
					"Presiona S para ver que hay dentro de la caja.\n" +
					"Presiona M para tomar el crucifijo.\n" +
					"Presiona L para usar tu habilidad verbal.";
					
		if 		(Input.GetKeyDown(KeyCode.S)) 	{miEstado = Estados.caja;} 
		else if (Input.GetKeyDown(KeyCode.M)) 	{miEstado = Estados.crucifijo;} 
		else if (Input.GetKeyDown(KeyCode.L)) 	{miEstado = Estados.habilidad;}
	}
	
	void estado_caja () {
		text.text = "La caja parece contener un pastel, pero necesitas algo filoso para" +
					" poder abrirlo.\n\n" +
					"Presiona R para regresar a tu novia.";
		
		if (Input.GetKeyDown(KeyCode.R)) {miEstado = Estados.novia;}
	}
	
	void estado_crucifijo () {
		text.text = "El crucifijo esta demasiado lejos y tu novia lanza una mirada mortal, " +
					"no podras llegar a tiempo a el y vivir para contarlo.\n\n" +
					"Presiona R para regresar a tu novia.";
					
		if (Input.GetKeyDown(KeyCode.R)) {miEstado = Estados.novia;}
	}
	
	void estado_habilidad () {
		text.text = "Le preguntas que si tiene algo, ella te dice que no tiene NADA, te das cuenta " +
					"que todo esta perdido a no ser que intentes algo mas que tus palabras.\n\n" +
					"Presiona R para regresar a tu novia.";
					
		if (Input.GetKeyDown(KeyCode.R)) {miEstado = Estados.novia;}
	}
	#endregion
}
