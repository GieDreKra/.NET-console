//Sukurkite 4 kintamuosius, kurie saugotų jūsų vardą, pavardę, gimimo metus ir šiuos metus (nebūtinai tikrus). Parašykite kodą, kuris pagal gimimo metus paskaičiuotų jūsų amžių ir naudodamas vardo ir pavardės kintamuosius atspausdintų tokį sakinį :
//"Aš esu Vardenis Pavardenis. Man yra XX metai(ų)".
var name = "Giedrė";
var surname = "Krasauskė";
var birthdayYear = 1983;
var year = 2021;
Console.WriteLine("Aš esu " + name + " " + surname + ". Man yra "+(year-birthdayYear).ToString()+" metai(ų)");



// Sukurkite tuščią masyvą (array, ne list).
//Užpildykite jį 7-iais kursiokų vardais.
//Atspausdinkite visus masyve esančius vardus.
string[] arrayNames = { "Vytautas", "Vaidas", "Rima", "Ramūnas", "Vilma", "Simonas","Auksė" };
foreach (string n in arrayNames)
    Console.WriteLine(n);

//Sukurkite tuščią masyvą (array, ne list).
//Užpildykite jį 5-iais atsitiktiniais skaičiais nuo 5 iki 10. (Naudokite ciklą masyvo užpildymui).
//Atspausdinkite visus masyve esančius skaičius.
//Papildykite masyvą dar 5-iais atsitiktiniais skaičiais nuo 5 iki 10.(Naudokite ciklą masyvo papildymui).
//Atspausdinkite visus masyve esančius skaičius.
int[] arrayNumbers = new int[10];
Random random = new Random();
for (int i = 0; i < 5; i++)
    arrayNumbers[i] = random.Next(5, 11);
for (int i = 0; i < 5; i++)
    Console.Write(arrayNumbers[i] + " ");
Console.WriteLine();

for (int i = 5; i < 10; i++)
    arrayNumbers[i] = random.Next(5, 11);
foreach (int n in arrayNumbers)
    Console.Write(n + " ");

//Sukurkite dvimatį masyvą 10x10.
//Naudodamiesi ciklais užpildykite jį daugybos lentele nuo 0 iki 9.
//Pasinaudoję ciklais atspausdinkite dvimatį masyvą taip, kad Consolėje matytume daugybos lentelę.  
//HINT:  Spaustina toje pačioje eilutėje.Console.Write("");
//Spausdina sekančioje eilutėje. Console.WriteLine("");
int[,] multiplicationTable = new int[10,10];
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        multiplicationTable[i, j] = i * j;
        Console.WriteLine(i + " x " + j + " = " + multiplicationTable[i, j]);
    }
    Console.WriteLine();
}



//Įvedami skaičiai -a, b, c –kraštinių ilgiai, trys kintamieji (naudojame int)
//(naudokite random nuo 1 iki 10). Parašykite Java programą, kuri nustatytų,
//ar galima sudaryti trikampį ir atsakymą atspausdintų. Naudokite Console.ReadLine()
//priimti įvestis.
try
{
    Console.WriteLine("Pirma trikampio kraštinė");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Antra trikampio kraštinė");
    int b = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Trečia trikampio kraštinė");
    int c = Convert.ToInt32(Console.ReadLine());


    if (a + b > c && a + c > b && b + c > a)
        Console.WriteLine("Trikampį sudaryti galima.");
    else
        Console.WriteLine("Trikampį sudaryti negalima.");
}
catch { Console.WriteLine("Kraštinės gali būti tik sveiki skaičiai."); }
//Įmonė parduoda žvakes po 1 EUR. Perkant daugiau kaip už 1000 EUR taikoma 3 % nuolaida, 
//    daugiau kaip už 2000 EUR - 4 % nuolaida. Parašykite programą, kuri skaičiuos žvakių
//    kainą ir atspausdintų atsakymą kiek žvakių ir kokia kaina perkama. Žvakių kiekį
//    generuokite ​random​ funkcija nuo 5 iki 3000.

int cRandom = random.Next(5,3000);
double price = 1;
if (cRandom>1000 && cRandom<2000) {
    price = price * 0.97;
} else if (cRandom>=2000) price = price * 0.96;
Console.WriteLine("Perkama " + cRandom + " žvakių. Vienos kaina "+price);


//Padarykite skaitmeninį laikrodį, rodantį valandas, minutes ir sekundes.
//Valandom, minutėm ir sekundėm sugeneruoti panaudokite funkciją random.
//Sugeneruokite skaičių nuo 0 iki 300. Tai papildomos sekundės. Skaičių pridėkite
//prie jau sugeneruoto laiko. Atspausdinkite laikrodį prieš ir po sekundžių pridėjimo
//ir pridedamų sekundžių skaičių.
int h = random.Next(0, 24);
int min = random.Next(0, 60);
int s=random.Next(0, 60);
//int h = 23;
//int min = 59;
//int s = 59;
int x =random.Next(0, 301);
int sAfter = min*60+s + x;
int minAfter=min;
int hAfter = h;
Console.WriteLine("Sugeneruotas laikas: " + h + ":" + min + ":" + s);
Console.WriteLine("Pridėti sekundes: " + x);
if (sAfter / 60 < 60)
{
    minAfter=sAfter / 60;
    sAfter = sAfter % 60;
}
else
{
    if ((sAfter / 60) > 60)
    {
        minAfter = sAfter / 60 - 60;
        hAfter = hAfter + 1;
    }
    else
    {
        minAfter = sAfter / 60;
    }
    sAfter = sAfter % 60;
    if (hAfter == 24) hAfter = 0;
}
Console.WriteLine("Pridėtos sekundės: " + hAfter + ":" + minAfter + ":" + sAfter);

