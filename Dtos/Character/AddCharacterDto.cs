using rpgTest_2.Models;

namespace rpgTest_2.Dtos.Character
{

    // this is to receive data from the client to the server
    public class AddCharacterDto
    {

        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}