/*
    Objetivo criar base de relacionamento em uma rede social como Twitter.

    1) Criar classe Cidade com Nome e Estado.
    1.1) Criar classe Pessoa com Nome, Cidade, Lista de Seguidores e uma Lista de Pessoas Seguindo.
    1.2) Criar Método Seguir(Pessoa) na classe Pessoa 
     -Irá fazer de você um seguidor da outra Pessoa 
     -Você estará seguindo essa outra Pessoa
    1.3) Crie 4 pessoas "Marcio de Curitiba-PR", "Tiago de Curitiba-PR", "Wesley de Maringá-PR" e "Jonas de Rio de Janeiro-RJ"

    2) Faça as seguintes operações
    - Tiago segue os outros 3
    - Jonas segue os outros 3
    - Marcio segue Wesley
    - Wesley segue Jonas

    2.1) Mostre no console todas as pessoas que cada pessoa está seguindo.

    3) Crie método SeguidoresEmComum que recebe outra pessoa e deverá retornar todos os seguidores que são comuns entre as duas pessoas.
    3.1) Mostre no console os seguidores em comum entre Wesley e Marcio.

    4) Crie método SeguidoresDe que recebe um Cidade e deverá retornar todos os seguidores que são de determinada Cidade ordenados pelos nomes das Pessoas. 
    4.1) Mostre no Console os seguidores de Curitiba do Wesley.

*/


using System;
using System.Collections.Generic;
using System.Linq;

namespace SkypeInterview201911
{
    public class Person
    {
        public Person(string name, City address)
        {
            Id = Guid.NewGuid();
            Name = name;
            City = address;
            Followers = new List<Person>();
            Following = new List<Person>();
        }

        public Guid Id { get; }
        public string Name { get; }
        public City City { get; }
        public List<Person> Followers { get; }
        public List<Person> Following { get; }


        public void Follow(Person person)
        {
            person.Followers.Add(this);
            Following.Add(person);
        }

        public List<Person> GetCommonFolowers(Person person)
        {
            var common = new List<Person>();
            foreach (var myFollower in Followers)
            {
                foreach (var otherFollower in person.Followers)
                {
                    if (myFollower.Id == otherFollower.Id)
                    {
                        common.Add(myFollower);
                    }
                }
            }
            return common;

        }
        public override string ToString()
        {
            return $"{Name} de {City}";
        }

        public List<Person> GetFollowersFrom(City address)
        {
            return Followers.Where(t => t.City.Name == address.Name && t.City.State == address.State).OrderBy(t => t.Name).ToList();
        }
    }

    public class City
    {
        public City(string city, string state)
        {
            Name = city;
            State = state;
        }

        public string Name { get; }

        public string State { get; }

        public override string ToString()
        {
            return $"{Name}-{State}";
        }
    }


    public static class Program
    {
        public static void Main(string[] args)
        {
            var curitiba = new City("Curitiba", "PR");
            var maringa = new City("Maringa", "PR");
            var rio = new City("Rio de Janeiro", "RJ");
            var tiago = new Person("Tiago", curitiba);
            var marcio = new Person("Marcio", curitiba);
            var wesley = new Person("Wesley", maringa);
            var jonas = new Person("Jonas", rio);

            tiago.Follow(marcio);
            tiago.Follow(wesley);
            tiago.Follow(jonas);
            marcio.Follow(wesley);
            wesley.Follow(jonas);
            jonas.Follow(tiago);
            jonas.Follow(marcio);
            jonas.Follow(wesley);

            Console.WriteLine("\n----------------------------------------------------------------------");
            Console.WriteLine("2.1) Mostre no console todas as pessoas que cada pessoa está seguindo.\n");
            PrintPerson(tiago);
            PrintPerson(marcio);
            PrintPerson(wesley);
            PrintPerson(jonas);

            Console.WriteLine("\n----------------------------------------------------------------------");
            Console.WriteLine("3.1) Mostre no console os seguidores em comum entre Wesley e Marcio.\n");
            PrintCommon(marcio, wesley);

            Console.WriteLine("\n----------------------------------------------------------------------");
            Console.WriteLine("4.1) Mostre no Console os seguidores de Curitiba do Wesley.\n");
            PrintFollowersFrom(wesley, curitiba);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void PrintFollowersFrom(Person person, City address)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;            
            Console.WriteLine($"{person} é seguido pelas seguintes pessoas de {address}: \n -> {string.Join(", ", person.GetFollowersFrom(address).Select(t => t.ToString())) }");
            Console.WriteLine(" ");
            Console.ResetColor();
        }

        private static void PrintPerson(Person person)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{person} segue: \n -> {string.Join(", ", person.Following.Select(t => t.ToString())) }");
            Console.WriteLine(" ");
            Console.ResetColor();
        }

        private static void PrintCommon(Person personOne, Person personTwo)
        {   
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{personOne} e {personTwo} ambos são seguidos por: \n -> {string.Join(", ", personOne.GetCommonFolowers(personTwo).Select(t => t.ToString())) }");
            Console.WriteLine(" ");
            Console.ResetColor();
        }
    }
}