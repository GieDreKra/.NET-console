// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Collections.Generic;


List<string> names = new List<string>() { "Tautvydas","Vaidas"};
names.Add("Ramūnas");
names.Add("Vilma");

List<string> first = new List<string>() { "One", "Two" };

names.AddRange(first);

foreach(string name in names)
{
    Console.WriteLine(name);
}

names.ForEach(name => Console.WriteLine(name));
Console.WriteLine(names.Count());

names.Remove("Vaidas");
names.RemoveAt(3);
names.ForEach((name) => Console.WriteLine(name));

//Sugeneruokite masyvą iš 30 elementų, kurių reikšmės yra atsitiktiniai skaičiai nuo 5 iki 25.
//Atsispausdinate, pasižiūrite ką gavote.
Random Random = new Random();   
List<int> numbers = new List<int>();
for (int i = 0; i< 30; i++)
    numbers.Add(Random.Next(5,26));

numbers.ForEach((name) => Console.Write(name+" "));

//Naudodamiesi 1 uždavinio masyvu:
//Suskaičiuokite kiek masyve yra reikšmių didesnių už 10;
//Raskite didžiausią masyvo reikšmę ir jos indeksą arba indeksus jeigu yra keli ir atspausdinkite.
//Suskaičiuokite visų porinių (lyginių) indeksų reikšmių sumą;
//Sukurkite naują masyvą, kurio reikšmės yra 1 uždavinio masyvo reikšmes minus tos reikšmės indeksas; PVZ -
//Indeksai   0, 1, 2, 3
//Reiksmes 1, 17, 40, 3
//Rezultatas 1, 16, 38, 0
//Iš masyvo elementų sukurkite du naujus masyvus. Vienas turi būti sudarytas iš neporinių indekso reikšmių, o kitas iš porinių;
//Pirminio masyvo elementus su poriniais indeksais padarykite lygius 0 jeigu jie didesni už 15;
//Suraskite pirmą(mažiausią) indeksą, kurio elemento reikšmė didesnė už 10;
int count = 0;
numbers.ForEach(name => { if (name > 10) count++; });
Console.WriteLine("Reikšmių daugiau 10 yra: "+count);

int max = numbers.Max();
for( int i = 0; i< 30;i++)
   if (numbers[i]==max) Console.WriteLine("Didžiausia masyvo reikšmė yra: "+numbers[i]+", jos indeksas: "+i);

int sum=0;
for (int i = 0; i < 30;i +=2 )
    sum = sum + numbers[i];
Console.WriteLine("Porinių indeksų suma: " + sum);

List<int> numbers2 = new List<int>();
for(int i = 0; i < 30; i++)
    numbers2.Add(numbers[i]-i);
numbers2.ForEach((name) => Console.Write(name + " "));
Console.WriteLine();

List<int> numbers3 = new List<int>();
List<int> numbers4=new List<int>();
for (int i = 0; i < 30; i += 2)
{
    numbers3.Add(numbers2[i]);
    numbers4.Add(numbers2[i + 1]);
}
numbers3.ForEach(name => Console.Write(name + " " ));
Console.WriteLine();
numbers4.ForEach(name => Console.Write(name + " "));
Console.WriteLine();

List<int> numbers5 = new List<int>(numbers);
for (int i = 0; i < 30; i += 2)
{
    if (numbers[i] > 15) numbers5[i] = 0;
}
numbers5.ForEach(name => Console.Write(name + " "));
Console.WriteLine();

for (int i = 0; i < numbers.Count; i ++)
{
    if (numbers[i] > 10)
    {
        numbers[i] = 0;
        Console.WriteLine("Pirmas skaičiaus kuris yra didesnis už 10 indeksas yra: "+i);
        break;
    }
}



//3.Sugeneruokite masyvą, kurio reikšmės atsitiktinės raidės A, B, C ir D, o ilgis 200.
//    Suskaičiuokite kiek yra kiekvienos raidės.
List<char> letters = new List<char>();
const string chars = "ABCD";
Random rnd = new Random();
for(int i = 0;i<200;i++)
    letters.Add(chars[rnd.Next(0,chars.Length)]);
letters.ForEach(letter=>Console.Write(letter+" "));
int sumA=0, sumB=0, sumC=0, sumD = 0;
for(int i = 0; i < 200; i++)
{
    if (letters[i] == 'A') sumA++;
    if (letters[i] == 'B') sumB++;
    if (letters[i] == 'C') sumC++;
    if (letters[i] == 'D') sumD++;
}
Console.WriteLine();
Console.WriteLine("A: " + sumA);
Console.WriteLine("B: " + sumB);
Console.WriteLine("C: " + sumC);
Console.WriteLine("D: " + sumD);


//4. Išrūšiuokite 3 uždavinio masyvą pagal abecėlę
letters.Sort();
Console.WriteLine(string.Join(",", letters));



//5.Sugeneruokite 3 masyvus pagal 3 uždavinio sąlygą. Sudėkite masyvus, sudėdami atitinkamas reikšmes.
//Paskaičiuokite kiek unikalių (po vieną, nesikartojančių) reikšmių ir kiek unikalių kombinacijų gavote.
//A, C, B, D, A
//C, C, B, B, C
//A, A, D, D, A
//ACA, CCA, BBD, DBD, ACA - TRYS UNIKALIOS, 4 KOMBINACIJOS
List<char> letters1 = new List<char>();
List<char> letters2 = new List<char>();
List<char> letters3 = new List<char>();
List<string> lettersSum = new List<string>();
for (int i = 0; i < 200; i++)
{
    letters1.Add(chars[rnd.Next(0, chars.Length)]);
    letters2.Add(chars[rnd.Next(0, chars.Length)]);
    letters3.Add(chars[rnd.Next(0, chars.Length)]);
}
letters1.ForEach(letter => Console.Write(letter + " "));
Console.WriteLine();
letters2.ForEach(letter => Console.Write(letter + " "));
Console.WriteLine();
letters3.ForEach(letter => Console.Write(letter + " "));
Console.WriteLine();
for (int i = 0; i < 200; i++)
{
     lettersSum.Add(letters1[i].ToString()+letters2[i].ToString()+letters3[i].ToString());
}
lettersSum.ForEach(letter => Console.Write(letter + " "));
Console.WriteLine();
var DistinctItems = lettersSum.GroupBy(x => x).Select(y => y.First());
List<string> distinct = new List<string>();
List<string> unique = new List<string>();
distinct =lettersSum.Distinct().ToList();
Console.WriteLine("Galimų kombinacijų yra: "+distinct.Count());
for (int i = 0;i < distinct.Count(); i++)
{
    sum = 0;
    for(int j = 0; j < lettersSum.Count(); j++){
        if (distinct[i] == lettersSum[j]) sum++;
    }
    if (sum>1) unique.Add(distinct[i]);
}
Console.WriteLine("Unikalių kombinacijų yra: " + unique.Count());


//5.Sugeneruokite 10 skaičių masyvą pagal taisyklę: Du pirmi skaičiai- atsitiktiniai nuo 5 iki 25. 
//    Trečias, pirmo ir antro suma. Ketvirtas- antro ir trečio suma. Penktas trečio ir ketvirto suma ir t.t.