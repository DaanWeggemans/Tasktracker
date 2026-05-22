using Tasktracker.Domain.Entities;

namespace Tasktracker.Tests.Factories
{
    public static class TTaskFactory
    {
        public static readonly string[] Title = [
            "Rain falls down.",
            "Fire burns bright.",
            "Wind blows cold.",
            "Stars shine far.",
            "Grass grows green.",
            "Fish swim deep.",
            "Ice feels cold.",
            "Trees stand tall.",
            "Cars go fast.",
            "Flowers bloom now."
        ];

        public static readonly string[] Description = [
            "Clouds turn dark before a storm.",
            "Flames consume wood in the fireplace.",
            "Gales rattle windows during winter.",
            "Galaxies glow in the night sky.",
            "Lawns require mowing during spring.",
            "Ocean creatures hide in coral reefs.",
            "Glaciers freeze solid in winter.",
            "Forest branches stretch toward heaven.",
            "Engines roar on the highway.",
            "Petals open under the morning sun."
        ];

        public static TTask Create()
        {
            return new TTask()
            {
                Id = Guid.NewGuid(),
                Title = Title[new Random().Next(Title.Length)],
                Description = Description[new Random().Next(Description.Length)],
                IsDone = new bool[] { true, false }[new Random().Next(2)]
            };
        }
    }
}
