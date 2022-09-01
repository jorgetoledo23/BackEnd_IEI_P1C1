namespace ConsoleApp.Model
{
    public class Personaje
    {
        //prop => Propiedad => Atributo => Caracteristica
        //prop solo lectura { get; }
        //prop lectura y escritura { get; set;}

        public string Nombre { get; }
        public int Fuerza { get; set; } = 100;
        public int Vida { get; set; } = 100;

        //TODO: Incluir mas factores que influyen en los golpes (Evasion, Robo de Vida)
        public int Estamina { get; set; } = 100;
        public int Mana { get; set; }
        public int Defensa { get; set; }
        //public Item ItemEquipado { get; set; }
        public List<Item> ItemsEquipados { get; set; }
        public int Oro { get; set; } = 1000;

        public int Golpear(Personaje Objetivo)
        {
            Objetivo.Vida -= this.Fuerza / 15 + 10;
            return Objetivo.Vida;
        }

        public void Comprar(Item item)
        {
            Oro -= item.Coste;
            this.ItemsEquipados.Add(item);
            this.Vida += item.Vida;
            this.Fuerza += item.Fuerza;
            this.Mana += item.Mana;
        }

        public Personaje(string nombre)
        {
            Nombre = nombre;
            ItemsEquipados = new List<Item>();
        }


    }
    
}
