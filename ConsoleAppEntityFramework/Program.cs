﻿using ConsoleAppEntityFramework.Model;

do
{
    Console.Clear();
    Console.WriteLine("[1] - Insertar Producto");
    Console.WriteLine("[2] - Ver Productos");
    Console.Write("Selecciona una Opcion: ");
    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":

            Console.Clear();

            Console.Write("Nombre: "); var name = Console.ReadLine();
         
            Console.Write("Precio: "); var precio = Convert.ToInt32(Console.ReadLine());

            Console.Write("Stock: "); var stock = Convert.ToInt32(Console.ReadLine());

            Console.Write("Url: "); var url = Console.ReadLine();


            Producto P = new Producto()
            {
                Name = name,
                Precio = precio,
                Stock = stock,
                UrlImagen = url
            };

            using (var context = new AppDbContext())
            {
                context.Add(P);
                context.SaveChanges();
            }

            Console.WriteLine("Producto Agregado");
            Console.ReadLine();


            break;


        case "2":
            Console.Clear();
            using (var context = new AppDbContext())
            {
                var ProductosGuardados = context.tblProductos.ToList();
                foreach (var item in ProductosGuardados)
                {
                    Console.WriteLine($"Id: {item.Id} | Name: {item.Name} | " +
                        $"Precio: {item.Precio} | Stock: {item.Stock} | " +
                        $"Url: {item.UrlImagen}");
                }
                Console.WriteLine("Productos Listados...");
                Console.ReadLine();
            }
            
            break;

        default:
            break;
    }





} while (true);