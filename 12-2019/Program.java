import java.util.List;
import java.util.Arrays;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.stream.Collectors;

public class Program {
    public static void main(String args[]) {

        City curitiba = new City("Curitiba", "PR");
        City maringa = new City("Maringá", "PR");
        City rio = new City("Rio de Janeiro", "RJ");

        Person marcio = new Person("Marcio", curitiba);
        Person tiago = new Person("Tiago", curitiba);
        Person wesley = new Person("Wesley", maringa);
        Person jonas = new Person("Jonas", rio);

        tiago.follow(marcio);
        tiago.follow(wesley);
        tiago.follow(jonas);
        jonas.follow(marcio);
        jonas.follow(tiago);
        jonas.follow(wesley);
        marcio.follow(wesley);
        wesley.follow(jonas);

        System.out.println("2.1) Mostre no console todas as pessoas que cada pessoa está seguindo.\n");
        printPerson(tiago);
        printPerson(marcio);
        printPerson(wesley);
        printPerson(jonas);

        System.out.println("\n----------------------------------------------------------------------");
        System.out.println("3.1) Mostre no console os seguidores em comum entre Wesley e Marcio.\n");
        printCommon(marcio, wesley);

        System.out.println("\n----------------------------------------------------------------------");
        System.out.println("4.1) Mostre no Console os seguidores de Curitiba do Wesley.\n");
        printFollowersFrom(wesley, curitiba);

    }

    private static void printPerson(Person person) {
        System.out.println(person.getName() + " segue: " + Arrays.toString(person.getFollowing().toArray()));
    }

    private static void printCommon(Person personOne, Person personTwo) {
        System.out.println(personOne.getName() + " e " + personTwo.getName() + " são seguidos por: "
                + Arrays.toString(personOne.getCommonFollowers(personTwo).toArray()));
    }

    private static void printFollowersFrom(Person person, City city) {
        System.out.println(person.getName() + " é seguido pelas seguintes pessoas de " + city.getName() + ": "
                + Arrays.toString(person.getFollowersFrom(city).toArray()));
    }

}

class City {
    String name;
    String state;

    public City(String city, String state) {
        this.name = city;
        this.state = state;
    }

    public String getName() {
        return this.name;
    }

    public String getState() {
        return this.state;
    }

    @Override
    public String toString() {
        return this.name + "-" + this.state;
    }
}

class Person {
    String name;
    City city;
    List<Person> followers;
    List<Person> following;

    public Person(String name, City city) {
        this.name = name;
        this.city = city;
        followers = new ArrayList<Person>();
        following = new ArrayList<Person>();
    }

    public void follow(Person person) {
        this.following.add(person);
        person.followers.add(this);
    }

    public String getName() {
        return this.name;
    }

    public City getCity() {
        return this.city;
    }

    public List<Person> getFollowers() {
        return this.followers;
    }

    public List<Person> getFollowing() {
        return this.following;
    }

    public List<Person> getCommonFollowers(Person person) {
        List<Person> commonFollowers = new ArrayList<Person>();

        for (Person myFollower : this.followers) {
            for (Person otherFollower : person.getFollowers()) {
                if (myFollower.equals(otherFollower)) {
                    commonFollowers.add(myFollower);
                }
            }
        }
        return commonFollowers;
    }

    public List<Person> getFollowersFrom(City city) {
        return this.followers.stream()
        .filter(follower -> city.equals(follower.getCity()))
        .sorted(Comparator.comparing(Person::getName))
        .collect(Collectors.toList());
    }

    @Override
    public String toString() {
        return this.name + " de " + this.city;
    }

}