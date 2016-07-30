namespace PokeTools
{
    internal interface IIncubator
    {
        //TODO: how does an empty incubator look
        string ID { get; }
        string ItemID { get; }
        string IncubatorType { get; }
        string PokemonId { get; }
        double StartKmWalked { get; } 
        double TargetKmWalked { get; }
        int UsesRemaining { get; }
    }
}