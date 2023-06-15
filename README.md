# tfg_daniel_colmenero_rodriguez
 Proyecto final DAM Daniel Colmenero Rodríguez
## Indice:
<ol>

## <li>Introducción</li>
<ul>

### <li>1.1 ¿Por qué un proyecto en Unity?</li>
### <li>1.2 ¿Cómo empezar un proyecto en Unity</li>
### <li>1.3 Requisitos</li>
</ul>

## <li>Desarrollo del juego</li>

<ul>

### <li>2.1 Personaje en primera persona</li>

<ul>

####  <li>2.1.1 Movimiento del personaje</li>

#### <li>2.1.2 Saltar y agacharse</li> 
#### <li>2.1.3 Cámara</li> 
</ul>

###   <li>2.2 Linterna</li> 

<ul>

#### <li>2.2.1 Colocación</li> 
#### <li>2.2.2 Iluminación</li> 
</ul>


### <li>2.3 Funcionalidad de la linterna</li>

<ul>

#### <li>2.3.1 Conseguir la linterna</li>
#### <li>2.3.2 Uso de la linterna</li>
#### <li>2.3.3 Baterías de la linterna</li>
#### <li>2.3.4 Iluminación de la linterna</li>
#### <li>2.3.5 Pilas para la linterna</li>
</ul>

### <li>2.4 Enemigo</li>
<ul>

#### <li>2.4.1 Perseguir al jugador</li>
#### <li>2.4.2 Sonidos del enemigo</li>
</ul>


### <li>2.5. Notas</li>

<ul>

#### <li>2.5.1 Creación de notas</li> 
#### <li>2.5.2 Conseguir y acumular notas</li>
</ul>


### <li>2.6. Sustos o Jumpscares</li>
### <li>2.7 Canvas</li>

<ul>

#### <li>2.7.1 Menús</li>
#### <li>2.7.2 Sustos</li>
#### <li>2.7.3 Mensajes de ayuda</li>
#### <li>2.7.4 Batería restante</li>
</ul>

### <li>2.8 Assets</li>
### <li>2.9 Finales del juego</li>

<ul>

#### <li>2.9.1 El jugador gana la partida</li>
#### <li>2.9.2 El jugador pierde la partida</li>
</ul>

</ul>

## <li>¿Cómo se exporta el juego?</li>
## <li>Mejoras del juego</li>
## <li>Problemas encontrados durante el desarrollo</li>
## <li>Resultado final</li>
</ol>

<br>
<br>

## 1. Introducción

Con el objetivo de mejorar los conocimientos sobre Unity que he adquirido este curso en la asignatura de Programación Multimedia, vi una buena oportunidad en desarrollar un videojuego como mi proyecto de fin de ciclo.

En este proyecto se desarrolla un videojuego en 3D llamado “Escape the asylum”. Es un juego de terror/supervivencia en el que el jugador debe encontrar 8 notas escondidas en un tenebroso asilo mientras es perseguido por un enemigo que intenta matarlo.

Teniendo lo anterior en cuenta, hay dos finales en este juego. El primero es que el jugador reúna las 8 notas y consiga volver a la puerta principal del asilo para escapar, y el segundo es que, mientras el jugador intenta encontrar las notas o escapar en caso de que ya las tenga todas, sea alcanzado por el enemigo, finalizando así la partida.

### 1.1 ¿Por qué un proyecto en Unity?

En mi caso, no tenía muy claro qué quería hacer para mi proyecto de fin de ciclo, pero en la última semana de clase instalamos Unity en la asignatura de Programación Multimedia y, aunque vimos cosas muy básicas, me dio bastante curiosidad, y además me encantan los videojuegos, así que tuve muy claro que mi proyecto iba a ser un juego en Unity.

### 1.2 ¿Cómo empezar un proyecto en Unity

Mis conocimientos sobre Unity eran muy básicos, así que lo primero que hice fue realizar el curso de Unity de la página OpenWebinars para saber un poco más sobre Unity.

Lo siguiente que necesité fue una idea sobre de qué iba a ir mi juego y pensar en el contenido que quería que hubiera en él. Después de decidir que mi juego iba a ser de terror, empecé a mirar assets en la asset store, y fui guardando los que más me gustaban para añadirlos a mi futuro proyecto.

### 1.3 Requisitos

El juego va a contener las siguientes funcionalidades:
<ul>
<li>Personaje controlable con las teclas “awsd”, que puede saltar, esprintar y agacharse.</li>
<li>Linterna que se enciende y se apaga con la tecla “f”, cuya batería se agota con el tiempo, por lo que hay que buscar pilas para que la linterna se mantenga encendida.</li>
<li>Enemigo que persigue al personaje constantemente.</li>
<li>Notas acumulables esparcidas por el mapa, de modo que una vez que todas sean encontradas, se pueda escapar del asilo.</li>
<li>Escenario importado desde la Asset Store.</li>
<li>Aparte de funcionar en PC, hacer que funcione también en dispositivos móviles.</li>
</ul>

## 2.Desarrollo del juego

En los siguientes puntos se van a explicar los pasos que he seguido para desarrollar el juego y para crear las funcionalidades mencionadas en el apartado anterior, empezando por lo que consideré más importante, que es un personaje controlable en primera persona.

### 2.1 Personaje en primera persona

El personaje lo he creado utilizando Rigidbody, que es un componente que permite a los GameObjects actuar bajo el control de la física.
En el script del personaje se maneja a través de valores númericos la velocidad de movimiento y la cantidad de notas que ha conseguido encontrar.
También se controla el movimiento de la cámara con el ratón, y la posibilidad de saltar, esprintar y agacharse.

#### 2.2.1 Colocación

En el script, dentro del método FixedUpdate de Unity, que es un método al que se recurre cuando queremos producir cambios en el tiempo y que estos cambios se apliquen en intervalos regulares, asigno la velocidad de movimiento, de forma que si el jugador está pulsando la tecla shift o la tecla alt, la velocidad del personaje es mayor.



<pre re><code>movementInput.x = Input.GetAxis("Horizontal");
movementInput.y = Input.GetAxis("Vertical");.
</code></pre>

<pre re><code>float speed = (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Fire2")) ? sprintSpeed : walkSpeed;
        rb.velocity = 
            transform.forward * speed * movementInput.y     //Y movement;
            + transform.right * speed * movementInput.x     //X movement;
            + new Vector3 (0, rb.velocity.y, 0);
</code></pre>

#### 2.2.2 Saltar y agacharse

-Para que el personaje se agache utilizo el método Lerp de Vector3, que  hace una transición entre una posición y otra. El primer parámetro es la posición inicial, el segundo es la posición a la que se pasa, y el tercero el tiempo que tarda en realizarse la transición.

<pre re><code>//crouch
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            crouched ? crouchedScale : normalScale,
            .1f
        );
</code></pre>

-Para el salto, simplemente hago que si el jugador pulsa la tecla “espacio”, y el personaje no está agachado, se le aplique una fuerza vertical al rigidbody del personaje, simulando un salto.

<pre re><code>if(Input.GetKeyDown(KeyCode.Space) && !crouched)  {
            rb.AddForce(0, jumpForce * 100, 0);
        }
</code></pre>

#### 2.1.3 Cámara

-Para la rotación de la cámara he utilizado Quaternion.Euler, ya que los quaternions se pueden usar para representar la orientación o rotación de un objeto.

-En la rotación horizontal, es normal que el personaje pueda dar vueltas sobre sí mismo, pero no es igual para la rotación vertical, así que busqué en internet y encontré el código inferior, que hace que cuando el valor de la rotación llega a un valor determinado, no pueda seguir rotando.

<pre re><code>//horizontal rotation
        transform.rotation *= Quaternion.Euler(0, rotationInput.x, 0);  

        //vertical camera
        rotationX -= rotationInput.y;
        rotationX = Mathf.Clamp(rotationX, -60, 60);
        camera.localRotation = Quaternion.Euler(rotationX, 0, 0);
</code></pre>

### 2.2 Linterna

Para la linterna, lo primero que hice fue buscar modelos 3D de una linterna y pilas para añadirlos al juego, e imágenes de pilas para la linterna y, a partir de ahí, empecé con la funcionalidad de la linterna.

#### 2.2.1 Colocación

Para la posición de la linterna, en la jerarquía de elementos del proyecto de Unity, simplemente he puesto la linterna como “hijo” de la cámara que, a su vez, es “hijo” del personaje, para simular que el personaje lleva la linterna en la mano. 

#### 2.2.2 Iluminación

Para la iluminación es lo mismo que para la colocación de la linterna, es decir, he colocado un objeto Light como “hijo” de la linterna, para que la luz siempre esté en la linterna, simulando que la luz proviene de ella.

### 2.3 Funcionalidad de la linterna.

A continuación se van a mostrar las distintas funcionalidades que tiene la linterna, ya que no es simplemente una linterna que está ahí siempre encencida sin más.

#### 2.3.1 Conseguir la linterna

En realidad, en el juego hay dos linternas, una que siempre tiene el personaje, y otra que es la que está en el suelo del mapa. La linterna que tiene el personaje está desactivada, y cuando el personaje pasa por encima de la linterna que está en el suelo, ésta se destruye, y se activa la que tiene en la mano, simulando que el personaje ha cogido la linterna del suelo.
Para ello, utilizo un script que tiene los métodos OnTriggerEnter y OnTriggerExit, con los que detecto si el personaje está dentro del rango para coger la linterna. Si el personaje entra en ese rango, se activa la linterna de la mano, y se destruye la del suelo.

#### 2.3.2 Uso de la linterna

La linterna tiene una batería que se va agotando poco a poco cuando está encendida, por lo que el jugador puede encender y apagar la linterna cuando quiera para ahorrar batería.
Para ello, si el jugador pulsa la tecla “F” una vez que ya ha encontrado la linterna, se enciende si está apagada, y se apaga si está encendida.

#### 2.3.3 Batería de la linterna

Para que la linterna vaya perdiendo batería, utilizo tres valores:
<ul>
    <li>Total de batería</li>
    <li>Batería que consume</li>
    <li>Tiempo de consumición</li>
</ul>

De este modo, si la linterna está encendida se le va restando el valor de la batería que consume cada cierto tiempo, que es el tiempo de consumición, hasta que la batería se agota.

<pre re><code>//If the flashlight is turned on, it loses battery
        if(isActive == true && remainingBattery > 0) {
            remainingBattery -= batteryLoss * Time.deltaTime;
        }
</code></pre>

#### 2.3.4 Iluminación de la linterna

La linterna empieza con un 100% de batería, y no se apaga completamente hasta que tiene 0% de batería.

Sin embargo, la luz sí que va perdiendo intensidad, según la batería restante. En este caso, cada 25% de batería que pierde, baja un poco la intensidad de la luz.

<pre re><code>//Turn off flashlight when it runs out of battery and change canvas images
        if(remainingBattery == 0) {
            lanternLight.intensity  = 0f;
            battery1.sprite = emptyBattery;
        }

        //Set flashlight intensity to 0.2 when it has less than 25% battery and change canvas images
        if(remainingBattery > 0 && remainingBattery <= 25) {
            lanternLight.intensity = 0.2f;
            battery1.sprite = loadedBattery;
            battery2.sprite = emptyBattery;
        }

        //Set flashlight intensity to 0.5 when it has less than 50% battery and change canvas images
        if(remainingBattery > 25 && remainingBattery <= 50) {
            lanternLight.intensity = 0.5f;
            battery2.sprite = loadedBattery;
            battery3.sprite = emptyBattery;
        } 

        //Set flashlight intensity to 0.8 when it has less than 75% and change canvas images
        if(remainingBattery > 50 && remainingBattery <= 75) {
            lanternLight.intensity = 0.8f;
            battery3.sprite =  loadedBattery;
            battery4.sprite = emptyBattery;
        }
        
        //Set flashlight intensity to 1 when it has less than 100% and change canvas images
        if(remainingBattery > 75 && remainingBattery <= 100) {
            lanternLight.intensity = 1f;
            battery4.sprite = loadedBattery;
        } 
</code></pre>

#### 2.3.5 Pilas para la linterna

Para que el personaje pueda recuperar batería de su linterna en caso de que haya utilizado mucha, hay varias pilas esparcidas por el mapa que suman batería a la linterna. Para realizar esto, he utilizado algo muy similar a lo que he hecho con la linterna. Se comprueba si el personaje entra en el rango de la pila, y en caso de que haya entrado, se le suma el valor de una pila a la cantidad restante de batería de la linterna.

<pre re><code>//Method that sets isInsideCollider to true when the player is inside the flashlight's collider
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            isInsideCollider = true;
        }
    }

    //Method that sets isInsideCollider to false when the player is not inside the flashlight's collider
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            isInsideCollider = false;
        }
    }
</code></pre>

### 2.4 Enemigo

Para el enemigo, he buscado en la Asset Store un modelo 3D de un zombie, ya que pensé que podía quedar muy bien en el entorno del juego.

Una vez lo encontré, le agregué varias funcionalidades:

<ul>
    <li>Perseguir al jugador constantemente.</li>
    <li>Sonidos aleatorios cada cierto tiempo.</li>
    <li>Si está muy cerca de nuestro personaje, lo mata y se acaba la partida.</li>
</ul>

#### 2.4.1 Perseguir al jugador

Para que el enemigo persiga al jugador, he utilizado un componente de Unity llamado NavMeshAgent, que esa una inteligencia artificial con la que ayudo al enemigo a encontrar rutas a través de espacios complicados. Le establezco una velocidad y un destino, que en este caso es la posición de su objetivo, que es el personaje.

<pre re><code>//Sets the enemy speed and target
    void Update()
    {
        IA.speed = speed;
        IA.SetDestination(target.position);        
    }
</code></pre>

#### 2.4.2 Sonidos del enemigo

No quería que el enemigo tuviera un simple sonido largo y ya está, por lo que he creado un método que utiliza a su vez el método Invoke, que sirve para posponer en el tiempo la ejecución de un método. Nada más iniciar el script ya se ejecuta el método Invoke de PlaySound, que reproduce un sonido aleatorio de un array de sonidos. Como al final también tiene el método invoke, el método se va a estar ejecutando en bucle.

<pre re><code>void Start()
    {
        Invoke("PlaySound", Random.Range(0, 5.0f));    
    }
</code></pre>

<pre re><code>//Selects a random sound and plays it, then call itself to produce a loop.
    void PlaySound()
    {
        int randomAudioIndex = Random.Range(0, zombieSounds.Length);
        audioSource.clip = zombieSounds[randomAudioIndex];
        audioSource.Play();

        Invoke("PlaySound", audioSource.clip.length + timeBetweenSounds);
    }
</code></pre>

Con lo que he mostrado en la anterior diapositiva, el enemigo ya tenía sonidos aleatorios, pero no me gustaba porque los sonidos se escuchaban igual por ambos auriculares, cuando sería mucho más realista que se escuchara más por que por otro según la posición del enemigo y la del jugador. Para mejorar esto, desde Unity, he puesto la opción Spatial Blend del componente Audio Source del enemigo al máximo para que sea 3D.

### 2.5 Notas

El objetivo del juego es que el personaje encuentre 8 notas para poder escapar del asilo, por lo que he creado un 3D Object de Unity para conseguir algo parecido a un papel, y con una foto de internet, he creado un Material, que se podría decir que es la textura que le doy al objeto para que parezca un papel.

A partir de este punto, los vídeos y fotos demostrativos van a estar mostrando el asilo que descargué de la Asset Store. Posteriormente  explicaré cómo lo he descargado e importado en mi proyecto.

#### 2.5.1 Creación de las notas

Primero descargué una foto de internet de papel cuadriculado, y posteriormente creé un Material al que le puse esa foto.

Después creé un 3D Object Plane, le di unas dimensiones parecidas a las de un folio, y le agregué el Material de la hoja.

#### 2.5.2 Obtener y acumular notas

Para que el jugador pueda recoger notas he utilizado el mismo método que para la linterna y las pilas. Si el jugador está dentro de un rango y pulsa la tecla “E” obtendrá la nota y ésta desaparecerá, simulando que la ha guardado.

Para que las notas se vayan acumulando, se accede a la variable pickedPapers del objeto del personaje y se incrementa su valor en 1, hasta encontrar las 8 notas.

<pre re><code>void Start() 
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSCamera>();
    }
</code></pre>

<pre re><code>if(isInsideCollider && Input.GetKeyDown(KeyCode.E) && character.pickedPapers < 8) {
            character.pickedPapers += 1;     
            paperMessage.text = "Has recogido una nota ";       
            displayTimer = Time.time + displayTime;
            paperMessage.enabled = true;
            isDisplayingText = true;
            helpLight.enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
</code></pre>

### 2.6 Sustos o Jumpscares

Para asustar al jugador de vez en cuando, he creado Cubos invisibles en ciertos lugares y, cuando el jugador los atraviese, saldrá una pantalla con una imagen de “terror” junto con un grito que haga que el jugador se asuste.

En cada partida puede salir un susto aleatorio, ya que se selecciona un susto aleatorio del array.

Estos sustos los muestro en pantalla con Canvas, que es el área sobre los que aparecen los elementos UI. Explicaré más adelante cómo he creado los sustos.

<pre re><code>//When the player is inside the object's collider, shows a jumpscare for a few seconds.
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Instantiate(jumpScare[Random.Range(0, jumpScare.Length)]);
            Destroy(gameObject);            
        }    
    }
</code></pre>

### 2.7 Canvas

Como he comentado anteriormente, con Canvas se crea todo lo que se muestra en la interfaz de usuario. En mi caso he utilizado Canvas para crear lo siguientes elementos:

<ul>
 <li>Menús</li>
 <li>Imágenes para las pilas y porcentaje de batería restante.</li>
 <li>Mensajes para dar información al jugador.</li>
 <li>Sustos</li>
</ul>

#### 2.7.1 Menús

En mi juego tengo 3 menús:

<ul>
    <li>Menú principal</li>
    <li>Menú para cuando el jugador pierda.</li>
    <li>Menú para cuando el jugador gana.</li>
</ul>

Cada uno de los menús está hecho en una escena distinta.

Para los 3 menús que hay en el juego utilizo la misma estructura, cambiando los textos y su posición.

Para la funcionalidad de los botones, cada botón tiene un script. Un botón sirve para cambiar a la escena del juego, y el otro para cerrar el juego.

<pre re><code>//Loads the scene with the name of the parameter. 
    public void changeScene(string name) {
        SceneManager.LoadScene(name);
    }
</code></pre>

<pre re><code>//Close the application
    public void closeGame() {
        Application.Quit();
    }
</code></pre>


#### 2.7.2 Sustos

Ya mostré antes cómo funcionaban los sustos y el script que los hacía mostrarse, pero no he mostrado cómo se han creado las pantallas de los sustos.
Para cada susto he creado un Prefab, que es un objeto reutilizable que me sirve de plantilla para cuando quiero crear más objetos similares.


#### 2.7.3 Mensajes de ayuda

Como se ha visto anteriormente, el jugador puede obtener e interactuar con varios objetos pero, por ejemplo, puede que haya cogido una pila y ni se haya dado cuenta. Para que el jugador sea consciente de todo lo que hace, he creado mensajes que se muestran en pantalla. Para ello, he añadido un código a todos los scripts que utilizan estos mensajes.

<pre re><code>//Close the application
    public void closeGame() {
        Application.Quit();
    }
</code></pre>

### 2.8 Assets

La creación de este juego ha sido posible gracias a los geniales assets gratuitos de la Asset Store pero, ¿cómo los he descargado e importado?
Para mostrarlo, voy a importar un asset cualquiera en un nuevo proyecto.


### 2.9 Finales del juego

El juego puede acabar de dos maneras:

- El jugador consigue encontrar las 8 notas escondidas y escapa del asilo sin ser alcanzado por el enemigo (El jugador gana la partida).

- El enemigo alcanza al jugador mientras está buscando las notas o escapando (El jugador pierde la partida).

#### 2.9.1 El jugador gana la partida

Cuando el jugador encuentra las 8 notas, se activa un cubo invisible en la entrada del asilo, el cual tiene una luz que hace ver al jugador que ya puede escapar, y si el jugador entra, se cambia a la escena de victoria.

#### 2.9.2 El jugador pierde la partida

El enemigo tiene un rango y, si el jugador entra en el rango del enemigo, aparece un susto y se cambia la escena, mostrándose el menú de cuando el jugador pierde la partida.

## 3. ¿Cómo se exporta el juego?

Exportar el juego es de lo más sencillo. Primero, en la esquina superior izquierda, selecciono File > Build Settings. Se me abrirá una pestaña en la que selecciono la plataforma del juego y otros parámetros y le doy a Build.

Se abrirá el explorador de archivos y seleccionamos la carpeta donde queremos montar el juego.

Después de un rato exportándose, el juego ya está en el directorio que hemos seleccionado, listo para probarlo.

## 4. Mejoras del juego

Después de haber llegado hasta este desarrollo del juego, ya tengo pensadas nuevas ideas para mejorar la funcionalidad y la calidad del juego. Entre ellas:
- Hacer que el juego se pueda jugar en dispositivos móviles.
- Añadir dificultades, por ejemplo, si el jugador decide jugar en ‘modo difícil’, en vez de 8 tendrá que encontrar 12 notas y aumentará la velocidad de persecución del enemigo.
- Hacer que, cuando empiece la partida, se active un cronómetro. De esta forma se almacenarían los tiempos en los que el jugador ha conseguido completar el juego.
- Crear una página web que muestre los tiempos en los que otros jugadores han conseguido completar el juego, para añadir competitividad.

## 5. Problemas encontrados durante el desarrollo

El único problema que he tenido al desarrollar el juego ha sido conseguir que el entorno de desarrollo funcionara con los métodos de Unity, ya que no podía autocompletar, ni tenía las útiles ayudas de Visual Studio Code. Para arreglar esto, tuve que ver varios tutoriales sobre cómo elegir el Entorno de desarrollo predeterminado de Unity para poder tener esas ayudas.

Por lo demás, ha ido bastante bien. Aunque el hecho de que haya sido mi primer proyecto en Unity, no me lo ha puesto fácil.

## 6. Resultado final:

<a href="https://youtu.be/wh6RxzRtraA">Enlace al vídeo aquí</a> 
