using System.Text;

const string AllatokTXT = "..\\..\\..\\data\\allatok.txt";

List<Gondozo> gondozok = [];
List<Reszleg> reszlegek = [];
List<Allat> allatok = [];

#region allatok.txt beolvasása
using StreamReader sr = new(AllatokTXT, Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    var tmp = sr.ReadLine().Split(';');

    int rID = int.Parse(tmp[4]);
    Reszleg? reszleg = reszlegek.SingleOrDefault(r => r.Id == rID);
    if (reszleg is null)
    {
        reszleg = new()
        {
            Id = rID,
            Nev = tmp[5],
            Meret = int.Parse(tmp[6]),
        };
        reszlegek.Add(reszleg);
    }

    int gID = int.Parse(tmp[7]);
    Gondozo? gondozo = gondozok.SingleOrDefault(g => g.Id == gID);
    if (gondozo is null)
    {
        gondozo = new()
        {
            Id = gID,
            Nev = tmp[8],
            Szakterulet = tmp[9],
        };
        gondozok.Add(gondozo);
    }

    allatok.Add(new()
    {
        Id = int.Parse(tmp[0]),
        Nev = tmp[1] == "NULL" ? null : tmp[1],
        Faj = tmp[2],
        Eletkor = float.Parse(tmp[3].Replace('.', ',')),
        Reszleg = reszleg,
        Gondozo = gondozo,
    });
}
#endregion

Console.WriteLine($"állatok száma: {allatok.Count}");
Console.WriteLine($"gondozók száma: {gondozok.Count}");
Console.WriteLine($"részlegek száma: {reszlegek.Count}");