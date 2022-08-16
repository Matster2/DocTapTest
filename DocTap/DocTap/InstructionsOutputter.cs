namespace DocTap
{
    public interface IInstructionsOutputter
    {
        void Output(Instructions instructions);
    }

    public class InstructionsOutputter : IInstructionsOutputter
    {
        public void Output(Instructions instructions)
        {
            var groupedColourCodes = instructions.TubeColours.GroupBy(z => z);

            foreach (var group in groupedColourCodes)
            {
                Console.WriteLine($"{group.Count()}x {DataStore.TubeColours[group.Key].Name}");
            }

            if (!string.IsNullOrEmpty(instructions.TestType))
            {
                Console.WriteLine(DataStore.TestTypes[instructions.TestType].Name);
            }
        }
    }
}
