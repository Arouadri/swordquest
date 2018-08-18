using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {

    public bool tieneNavMesh = false;
    public bool atacaADistancia = false;
    public UnityEngine.AI.NavMeshAgent agente;
    public Animator animator;

    public GameObject objetivo;
    public GameObject prefabDestino;
    public GameObject destinoDeambular;
    public GameObject destinoPorDefecto;

    public float velocidadDeambular = 3f;
    public float velocidadPerseguir = 5f;

    public Vector3 distanciaObjetivo;
    public Vector3 distanciaDestinoDeambular;
    public float distanciaVision = 40f;
    public float distanciaAtaque = 2f;

    public float tiempoCambioComportamientoMax = 2f;
    public float tiempoCambioComportamiento = 2f;

    public float tiempoCambioDestinoMax = 2f;
    public float tiempoCambioDestino = 2f;

    public int numComprobacionesDeambular = 4;

    public enum TpComportamiento { Deambular , Perseguir , Atacar };
    public TpComportamiento comportamientoActual = TpComportamiento.Deambular;

    void Start() {
        destinoDeambular = Instantiate(prefabDestino);
        destinoPorDefecto = Instantiate(prefabDestino);
        destinoPorDefecto.transform.position = transform.position;
        destinoPorDefecto.transform.rotation = transform.rotation;
        tiempoCambioComportamientoMax += Random.Range(-1f, 1f);
        tiempoCambioDestinoMax += Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update() {

        CalcularDistancias();

        // Decidimos el comportamiento
        tiempoCambioComportamiento += Time.deltaTime;
        if ( tiempoCambioComportamiento > tiempoCambioComportamientoMax ) {
            comportamientoActual = DecidirComportamiento();
            tiempoCambioComportamiento = 0f;
        }

        // Deambular
        if (comportamientoActual == TpComportamiento.Deambular) {
            tiempoCambioDestino += Time.deltaTime;
            if ( tiempoCambioDestino > tiempoCambioDestinoMax )
            {
                tiempoCambioDestino = 0f;
                CalcularDestinoAleatorio();
            }
            Deambular();
        }
        // Perseguir
        else if (comportamientoActual == TpComportamiento.Perseguir) {
            Perseguir();
        }
        // Atacar
        else if (comportamientoActual == TpComportamiento.Atacar){
            Atacar();
        }
    }

    public bool ObjetivoVisible () {
        // Tiramos un rayo hacia el objetivo para ver si está a la vista
        RaycastHit infoImpacto;
        if (Physics.Raycast(transform.position, distanciaObjetivo, out infoImpacto, distanciaVision)) {
            return (infoImpacto.transform.gameObject == objetivo);
        }
        // Si tiramos el rayo y no toca nada, es que no está a la vista
        else {
            return false;
        }
    }

    public void CalcularDestinoAleatorio ( ) {
        float distanciaImpacto = 0f;
        float distanciaImpactoMax = 0f;
        // Tiramos varios rayos para intentar poner como destino el lugar más alejado posible
        for (int i = 0; i < numComprobacionesDeambular; i++){
            // Calculamos una dirección aleatoria
            Vector3 direccionAleatoria = Random.onUnitSphere;
            if (tieneNavMesh) {
                direccionAleatoria.y = 0f;
            }
            // Tiramos rayo hacia esa dirección
            RaycastHit infoImpacto;
            if ( Physics.Raycast ( transform.position , direccionAleatoria , out infoImpacto ) ){
                distanciaImpacto = infoImpacto.distance;
                // Comprobamos si el rayo actual es el más alejado de todos
                if (distanciaImpacto > distanciaImpactoMax) {
                    distanciaImpactoMax = distanciaImpacto;
                    destinoDeambular.transform.position = infoImpacto.point;
                }
            }
        }
        // Si ninguno de los rayos ha tocado un objeto, ponemos el destino por defecto
        if ( distanciaImpactoMax == 0f ) {
            destinoDeambular.transform.position = destinoPorDefecto.transform.position;
        }
    }

    public void Deambular () {
        if (tieneNavMesh) {
            agente.SetDestination(destinoDeambular.transform.position);
        }
        else {
            transform.Translate(distanciaDestinoDeambular.normalized * velocidadDeambular * Time.deltaTime, Space.World);
            transform.forward = distanciaDestinoDeambular.normalized;
            //transform.Translate( Vector3.forward * velocidadDeambular * Time.deltaTime );
        }
    }

    public void Perseguir ( ) {
        if (tieneNavMesh) {
            agente.SetDestination(objetivo.transform.position);
        }
        else {
            transform.Translate(distanciaObjetivo.normalized * velocidadPerseguir * Time.deltaTime, Space.World);
            transform.forward = distanciaObjetivo.normalized;
            //transform.Translate(Vector3.forward * velocidadDeambular * Time.deltaTime);
        }
    }

    public void Atacar ( ) {
        // animator.SetTrigger("Atacar");
        print("PUM PUM PUM");
    }

    public TpComportamiento DecidirComportamiento ( ) {
        if ( distanciaObjetivo.magnitude < distanciaAtaque ) {
            return TpComportamiento.Atacar;
        }
        else if ( ObjetivoVisible ( ) ) {
            return TpComportamiento.Perseguir;
        }
        else {
            return TpComportamiento.Deambular;
        }
    }

    public void CalcularDistancias() {
        distanciaObjetivo = objetivo.transform.position - transform.position;
        distanciaDestinoDeambular = destinoDeambular.transform.position - transform.position;
    }

}
