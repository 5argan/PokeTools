namespace PokeTools
{
    internal interface IPokemonEgg
    {
        string ID { get; }
        int MaxKm { get; }
        string ReceivedCellId { get; }
        string ReceivedTimeMs { get; }
        string EggIncubatorID { get; }
        bool IsIncubating { get; }
    }
}