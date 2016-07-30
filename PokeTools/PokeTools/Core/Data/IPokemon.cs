namespace PokeTools
{
    internal interface IPokemon
    {
        string ID { get; }
        string PokemonId { get; }
        int cp { get; }
        int stamina { get; } //HP
        int staminaMax { get; } //maxHP
        string Move1 { get; }
        string Move2 { get; }
        double HeightM { get; }
        double WeightKg { get; }
        int AttackIV { get; }
        int DefenseIV { get; }
        int StaminaIV { get; }
        double CpMultiplier { get; }
        string PokeballCaught { get; }
        string CaptureCellID { get; }
        string CaptureTimeMs { get; }
        int BattlesAttacked { get; }
        int FromFort { get; } //TODO was ist das? ob es mal verteidigt hat? oder ob es aus einem ei geschlüpft ist?
        int NumUpgrades { get; }
        double AdditionalCpMultiplier { get; }
        string Nickname { get; }
    }
}