namespace ConsoleApp.Model
{
    public class Item
    {
        public Item(string nombre, int fuerza, int vida, int mana, int coste)
        {
            Nombre = nombre;
            Fuerza = fuerza;
            Vida = vida;
            Mana = mana;
            Coste = coste;
        }


        public string Nombre { get; }
        public int Fuerza { get; }
        public int Vida { get; }
        public int Mana { get; }
        public int Coste { get; }
           
    }
}
