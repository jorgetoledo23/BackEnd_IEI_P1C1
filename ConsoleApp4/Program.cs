using ConsoleApp.Model;

Personaje P1 = new Personaje("Player 1");
Personaje P2 = new Personaje("Player 2");

List<Item> listItems = new List<Item>()
{
    new Item("Espada", 120, 0, 0, 200),
    new Item("Escudo", 0, 120, 0, 300),
    new Item("Cuchillo", 50, 0, 0, 100),
    new Item("Posion", 25, 25, 25, 150),
    new Item("Lanza", 80, 0, 0, 150)
};

bool Turno = true; 
//True = Turno Player 1 --- False Turno Player 2
do
{
    Console.Clear();

    Console.WriteLine("===Juego PVP===");

    if (Turno) Console.WriteLine("Turno del Jugador 1");
    else Console.WriteLine("Turno del Jugador 2");

    //Stats de los Jugadores
    Console.WriteLine($"Stats Jugador 1: Vida:{P1.Vida}, Fuerza: {P1.Fuerza}");
    Console.WriteLine($"Stats Jugador 2: Vida:{P2.Vida}, Fuerza: {P2.Fuerza}");

    //Accion
    Console.WriteLine("1-Atacar");
    Console.WriteLine("2-Comprar");
    Console.WriteLine("3-Pasar");
    Console.WriteLine("0-Terminar Juego");

    Console.Write("Selecciona tu Jugada: ");
    string Opcion = Console.ReadLine();

    Console.Clear();
    switch (Opcion)
    {
        case "1": //Atacar
            if (Turno) P1.Golpear(P2);
            else P2.Golpear(P1);
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

            Item? compra = listItems.Find(x => x.Nombre == itemSeleccionado);

            if(Turno) P1.Comprar(compra);
            else P2.Comprar(compra);

            Console.WriteLine($"{compra.Nombre} comprado! " +
                $"Presiona una tecla para Continuar...");
            Console.ReadLine();


            break;
    }

    Turno = !Turno;

} while (true);