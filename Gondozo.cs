class Gondozo
{
    public int Id { get; set; }
    public string Nev { get; set; }
    public string Szakterulet { get; set; }

    public override string ToString() => 
        $"{Nev} (szakrerület: {Szakterulet})";
}
