using ConsoleApp.Model;

Personaje P1 = new Personaje("Player 1");
Personaje P2 = new Personaje("Player 2");

List<Item> listItems = new List<Item>() // Tienda
{
    new Item("Espada", 120, 0, 0, 200),
    new Item("Escudo", 0, 120, 0, 300),
    new Item("Cuchillo", 50, 0, 0, 100),
    new Item("Posion", 25, 25, 25, 150),
    new Item("Lanza", 80, 0, 0, 150)
};

int turno = 2;
bool Turno = true;
Personaje Ganador = null;
//True = Turno Player 1 --- False Turno Player 2
do
{
    Console.Clear();

    Console.WriteLine("===Juego PVP===");
    //TODO: Tipos de Personaje
    if (Turno) Console.WriteLine("Turno del Jugador 1");
    else Console.WriteLine("Turno del Jugador 2");

    //Stats de los Jugadores
    //TODO: Mostrar los items comprados por cada jugador
    Console.WriteLine($"Stats Jugador 1: Vida:{P1.Vida}, Fuerza: {P1.Fuerza}, Oro: {P1.Oro}");
    Console.WriteLine($"Stats Jugador 2: Vida:{P2.Vida}, Fuerza: {P2.Fuerza}, Oro: {P2.Oro}");

    //Accion
    Console.WriteLine("1-Atacar");
    Console.WriteLine("2-Comprar");
    Console.WriteLine("3-Pasar");
    Console.WriteLine("0-Terminar Juego");

    Console.Write("Selecciona tu Jugada: ");
    string Opcion = Console.ReadLine();

    Console.Clear();
    int vidaRestante = 1 ;
    switch (Opcion)
    {
     
        case "1": //Atacar

            if (Turno) vidaRestante = P1.Golpear(P2);
            else vidaRestante = P2.Golpear(P1);
            break;

        case "2": //Comprar
            foreach (var item in listItems)
            {
                Console.WriteLine($"{item.Nombre} - Coste: {item.Coste}");
                Console.WriteLine($"Vida + {item.Vida} : Fuerza + {item.Fuerza}");
                Console.WriteLine("------------------------");    
            }

            Console.Write("Escribe el Nombre del Item: ");
            string itemSeleccionado = Console.ReadLine();

            //Escribir de manera correcta el Nombre del Item o se error!
            //TODO: Validar el ingreso para evitar errores
            Item? compra = listItems.Find(x => x.Nombre == itemSeleccionado);

            if (Turno)
            {
                if (P1.Oro >= compra.Coste) P1.Comprar(compra);
                else Console.WriteLine($"{P1.Nombre} no tiene fondos para realizar la compra!");
            }
            else {
                if (P2.Oro >= compra.Coste) P2.Comprar(compra);
                else Console.WriteLine($"{P2.Nombre} no tiene fondos para realizar la compra!");
            }

            Console.WriteLine($"{compra.Nombre} comprado! " +
                $"Presiona una tecla para Continuar...");
            Console.ReadLine();


            break;


        case "3":
            //TODO: Pasar el turno
            break;
    }

    


    if(vidaRestante <= 0)
    {
        //Ganador
        if(Turno == true) Ganador = P1;
        else Ganador = P2;
        break;
    }

    Turno = !Turno;
    //if(Turno == true)
    //{
    //    Turno = false;
    //}


} while (true);

Console.WriteLine($"{Ganador.Nombre} gana la partida!");