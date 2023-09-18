using clases_Heredadas;
using Clases_Principales;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication;
using static System.Net.Mime.MediaTypeNames;

namespace Clases_Principales
{
     
    abstract class Entities
    {   //Los pongo en ingles pa ponerle mas crema a los tacos
        private string name, type, weak_To;
        private double physical_Attack, magic_Attack, magic_Resistance, armor,
                      ability_Power, mana, health_Points, experience;
        private int level;
        public Entities() { }
        public Entities(string _name, string _type, string _weak_To, double _physical_Attack, double _magic_Attack,
                        double _magic_Resistance, double _armor, double _ability_Power, double _mana, double _health_Points,
                        double _experience, int _level) 
        {
            this.name = _name;
            this.type = _type;
            this.weak_To = _weak_To;
            this.physical_Attack = _physical_Attack;
            this.magic_Attack = _magic_Attack;
            this.magic_Resistance = _magic_Resistance;
            this.armor = _armor;
            this.ability_Power = _ability_Power;
            this.mana = _mana;
            this.health_Points = _health_Points;
            this.experience = _experience;
            this.level = _level;

        }
        public void setType(string _type)
        {
            this.type = _type;
        }
        public void setWeakTo(string weakness)
        {
            this.weak_To = weakness;
        }
        public void setPhysicalA(double Ad)
        {
            this.physical_Attack = Ad;
        }
        public void setMagicA(double Ap)
        {
            this.magic_Attack = Ap;
        }
        public void setMr(double Mr)
        {
            this.magic_Resistance = Mr;
        }
        public void setArmor(double Armor)
        {
            this.armor = Armor;
        }
        public void setAbilityP(double AbilityP)
        {
            this.ability_Power = AbilityP;
        }
        public void setMana(double Mana)
        {
            this.mana = Mana;
        }
        public void setHp(double Hp)
        {
            this.health_Points = Hp;
        }
        public void setExperience(double Experience)
        {
            this.experience = Experience;
        }
        public void setLvl(int lvl)
        {
            this.level = lvl;
        }
        public string getStats()
        {
            return ("=============Stats=========\nNombre ["
                              +name+"]\nClase["
                              +type+"]\nHP["
                              +health_Points+"]\nNivel["
                              +level+"]\nDaño Fisico["
                              +physical_Attack+"]\nDaño Magico["
                              +magic_Attack+"]\nPoder De Habilidad["
                              +ability_Power+"]\nMR["
                              +magic_Resistance+"]\nArmadura["
                              +armor+"]\nMana["
                              +mana+"]\nExperiencia["
                              +experience+ "]\n===========================");
        }


        public void walk()
        {
            Console.WriteLine("Caminanding");
        }
        public abstract double Attack(double enemy_Hp, int ataque);
        public abstract double Attack(double enemy_Hp);


        public bool isAlive() => health_Points > 0;
        public string getType() => this.type;
        public double getAp() => this.ability_Power;
        public double getHp() => this.health_Points;
        public double getAd() => this.physical_Attack;
        public double getMana() => this.mana;
        public void getDamage(double damage)
        {
            setHp(getHp() - damage);
        }
        public bool isHalf()
        {
            switch (getType())
            {
                case "Mago":
                    return getHp() <= 800 / 2;
                    break;
                case "Espadachin":
                    return getHp() <= 1000 / 2;

                    break;
                case "Peleador":
                    return  getHp() <= 1200 / 2;
                    break;
            }
            return false;
        }



    }
    /*
    class Item
    {
        private string name, type, description;
        private int usage;
        public Item(string _name,string _type, string _description, int _usage) {
            this.name = _name;
            this.type = _type;
            this.description = _description;
            this.usage = _usage;
        }
        
    }
    class Weapon
    {
        private string name, extra_Effect;
        private float damage, durability;
        public Weapon(string _name, string _extra_Effect, float _damage, float _durability) { 
            this.name = _name;
            this.extra_Effect = _extra_Effect;
            this.damage = _damage;
            this.durability = _durability;
        }
        public bool isBroken() => durability <= 0;
        public void damageWarning()
        {
            if (isBroken())
            {
                Console.WriteLine("El arma " + name + " esta rota asi que puede que su daño se vea reducido");
                this.damage /= 2;
            }
        }

    }
     */
}
namespace clases_Heredadas
{
    class Character : Entities
    {
        public Character(string _name, string _type, string _weak_To, double _physical_Attack, double _magic_Attack, double _magic_Resistance, double _armor, double _ability_Power, double _mana, double _health_Points, double _experience, int _level) : base(_name, _type, _weak_To, _physical_Attack, _magic_Attack, _magic_Resistance, _armor, _ability_Power, _mana, _health_Points, _experience, _level)
        {

        }
        public Character() { }
        public void class_Selection(int opc)
        {
            double physical = 20, magicA = 0, MR = 10, armor = 10, AP = 0, mana = 20, HP = 800, XP = 0;
            int lvl = 20;
            switch (opc)
            {
                case 1:
                    AP = 80;
                    setType("Mago");
                    setWeakTo("Ataques cuerpo a cuerpo");
                    setPhysicalA(physical + lvl * 2);
                    setAbilityP(AP);
                    setMagicA(20.0 + (AP * 0.80));
                    setMr(MR + Convert.ToDouble((lvl * 1.5)));
                    setArmor(armor + Convert.ToDouble((lvl * 1.8)));
                    setMana(500);
                    setHp(HP);
                    setExperience(XP);
                    setLvl(lvl);
                    break;
                case 2:
                    AP = 0;
                    setType("Espadachin");
                    setWeakTo("Daño Magico");
                    setPhysicalA(physical + lvl * 3);
                    setAbilityP(AP);
                    setMagicA(20.0 + (AP * 0.80));
                    setMr(MR + lvl * 2);
                    setArmor(armor + lvl * 3);
                    setMana(100);
                    setHp(1000);
                    setExperience(XP);
                    setLvl(lvl);
                    break;
                case 3:
                    setType("Peleador");
                    setWeakTo("Ataques a rango");
                    setPhysicalA(physical + lvl * 2);
                    setAbilityP(AP);
                    setMagicA(20.0 + (AP * 0.80));
                    setMr(MR + lvl*3);
                    setArmor(armor + lvl * 3);
                    setMana(100);
                    setHp(1200);
                    setExperience(XP);
                    setLvl(lvl);
                    break;
            }
        }
        public override double Attack(double enemy_Hp, int ataque)
        {
            double damage = 0;
            switch (getType())
            {
                case "Mago":
                    Console.WriteLine("Elige un Ataque\n[1]Ataque Simple\n200Dmg + 50% Ap\n[2]Ejecutor:\nMata al enemigo si tiene la mitad de la vida");
                    switch (ataque)
                    {
                        case 1:
                            setMana(getMana() - 50);
                            return 200 + (getAp() / 2);
                            break;
                        case 2:
                            if (isHalf())
                            {
                                return 10000;
                            }
                             break;
                    }
                    break;
                case "Espadachin":
                    Console.WriteLine("Elige un Ataque\n[1]Ataque Simple\n200Dmg + 50% Ad\n[2]Estocada:\n 5 Golpes de 100 de daño + 40% del Ad");
                    ataque = Convert.ToInt16(Console.ReadLine());
                    switch (ataque)
                    {
                        case 1:
                            setMana(getMana() - 50);
                            return 200 + ((getAd() / 2));
                            break;
                        case 2:
                            return 5 * (100 + getAd() * 0.40);
                            break;
                    }
                    break;
                case "Peleador":
                    Console.WriteLine("Elige un Ataque\n[1]Ataque Simple\n200Dmg + 50% Ap\n[2]Guillotina:\nHace un corte al enemigo que le causa un 50% de su vida actual como daño");
                    ataque = Convert.ToInt16(Console.ReadLine());
                    switch (ataque)
                    {
                        case 1:
                            return 200 + ((getAd() / 2));
                            break;
                        case 2:
                            return enemy_Hp/2 + 50 +(getAd() / 0.1);
                            break;
                    }
                    break;
            }
            return damage;
        }
        public override double Attack(double enemy_Hp)
        {
            double damage = 0;
            int ataque;

            switch (getType())
            {
                case "Mago":
                    Console.WriteLine("Elige un Ataque\n[1]Ataque Simple\n200Dmg + 50% Ap\n[2]Ejecutor:\nMata al enemigo si tiene la mitad de la vida");
                    ataque = Convert.ToInt16(Console.ReadLine());
                    switch (ataque)
                    {
                        case 1:
                            setMana(getMana() - 50);
                            return 200 + (getAp() / 2);
                            break;
                        case 2:
                            if (isHalf())
                            {
                                return 10000;
                            }
                            break;
                    }
                    break;
                case "Espadachin":
                    Console.WriteLine("Elige un Ataque\n[1]Ataque Simple\n200Dmg + 50% Ad\n[2]Estocada:\n 5 Golpes de 100 de daño + 40% del Ad");
                    ataque = Convert.ToInt16(Console.ReadLine());
                    switch (ataque)
                    {
                        case 1:
                            setMana(getMana() - 50);
                            return 200 + ((getAd() / 2));
                            break;
                        case 2:
                            return 5 * (100 + getAd() * 0.40);
                            break;
                    }
                    break;
                case "Peleador":
                    Console.WriteLine("Elige un Ataque\n[1]Ataque Simple\n200Dmg + 50% Ap\n[2]Guillotina:\nHace un corte al enemigo que le causa un 50% de su vida actual como daño");
                    ataque = Convert.ToInt16(Console.ReadLine());
                    switch (ataque)
                    {
                        case 1:
                            return 200 + ((getAd() / 2));
                            break;
                        case 2:
                            return enemy_Hp / 2 + 50 + (getAd() / 0.1);
                            break;
                    }
                    break;
            }
            return damage;
        }
        //ataque maquina
        public void Action_Selector(double enemy_Hp, int ataque)
        {
            Attack(enemy_Hp, ataque);

        }
        //ataque jugador
        public Double action_Selector(double enemy_Hp, int opc)
        {
            switch (opc)
            {
                case 1:
                    return Attack(enemy_Hp);
                    break;
                case 2:
                     setHp(0);
                    break;
            }
            return 0;
        }

    }

}


namespace Rolgame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Falta hacer las funciones de recibir daño y atacar 👍
            Character player = new Character("Chuas", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Character enemy = new Character("Malo Maloso","", "", 0, 0, 0, 0, 0, 0, 0, 0, 0);
            player.class_Selection(2);
            enemy.class_Selection(2);
            double damage = 0;
            int opc = 0;
            Random random = new Random();
            do
            {
                Console.Clear();
                Console.WriteLine("Elige tu siguiente accion\n[1]Pelear\n[2]Acabar Juego");
                opc = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                enemy.getDamage(player.action_Selector(enemy.getHp(), opc));
                if (!player.isAlive() || !enemy.isAlive()) break;
                Console.WriteLine("Vida Jugador: " + player.getHp() + "Vida Enemigo: " + enemy.getHp());
                Console.WriteLine("Turno del enemigo");
                player.getDamage(enemy.action_Selector(player.getHp(), opc = random.Next(1, 2)));
                Console.Clear();
            } while (player.isAlive() && enemy.isAlive());
            if (player.isAlive())
            {
                Console.WriteLine("=========Ganador=========\n"+ player.getStats());
            }
            else
            {
                Console.WriteLine("=========Ganador=========\n" + enemy.getStats());
            }
        }
    }
}