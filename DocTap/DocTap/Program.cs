
namespace DocTap
{
    // THINGS TO IMPROVE
    /*
     * Data store to database
     * Split data between concept and translation
     * add invalid code to exception
     * type case values
     * test
     */

    public static class DataStore
    {
        public static readonly Dictionary<string, TubeColour> TubeColours = new Dictionary<string, TubeColour>
        {
            { "A", new TubeColour{ Code = "A", Name = "Lavender" } },
            { "B", new TubeColour{ Code = "B", Name = "Gold" } },
            { "C", new TubeColour{ Code = "C", Name = "Light Blue" } }
        };

        public static readonly Dictionary<string, TestType> TestTypes
            = new Dictionary<string, TestType>
        {
            { "RF", new TestType{ Code = "RF", Name = "Random Faeces" } },
            { "FCRU", new TestType{ Code = "FCRU", Name = "First Catch Random Urine" } }
        };
    }

    public class Program
    {
        public static void Main()
        {
            var sampleRequirementsTranslator = new SampleRequirementsTranslator();
            var instructionsOutputter = new InstructionsOutputter();

            while (true)
            {
                Console.WriteLine("Please enter a set of sample requirements: ");
                string? input = Console.ReadLine();

                try
                {
                    var instructions = sampleRequirementsTranslator.Translate(input);
                    instructionsOutputter.Output(instructions);
                }
                catch (InvalidSampleRequirementCode)
                {
                    Console.WriteLine($"Sample requirements contains an invalid code");
                }
                catch (SampleRequirementsContainMultipleTestCodes)
                { 
                    Console.WriteLine("Sample test cannot contain multiple test types");
                }

                Console.WriteLine("");
            }
        }
    }

    public class TubeColour
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class TestType
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class Instructions
    {
        public string? TestType { get; set; }
        public List<string> TubeColours { get; set; } = new List<string>();
    }

    public class InvalidSampleRequirementCode : Exception
    {
        public InvalidSampleRequirementCode()
        {
        }
    }

    public class SampleRequirementsContainMultipleTestCodes : Exception
    {
        public SampleRequirementsContainMultipleTestCodes()
        {
        }
    }
}



//public static void Main()
//{
//    while (true)
//    {
//        Console.WriteLine("Please enter a set of sample requirements: ");
//        string? input = Console.ReadLine();

//        var inputParts = input.Split(' ').Where(x => !string.IsNullOrEmpty(x));

//        var testTranslation = "";
//        var colourTranslations = new List<string>();

//        foreach (var part in inputParts)
//        {
//            if (TubeColours.ContainsKey(part))
//            {
//                colourTranslations.Add(TubeColours[part].Name);
//            }
//            else if (TestTypes.ContainsKey(part))
//            {
//                if (!string.IsNullOrEmpty(testTranslation))
//                {
//                    Console.WriteLine("Sample test cannot contain multiple test types");
//                    continue;
//                }

//                testTranslation = TestTypes[part].Name;
//            }
//            else
//            {
//                Console.WriteLine($"Sample test contains an invalid code: {input}");
//                continue;
//            }
//        }

//        var groupedColourTranslations = colourTranslations.GroupBy(z => z);

//        foreach (var group in groupedColourTranslations)
//        {
//            if (TestTypes.ContainsKey(group.Key))
//            {
//                Console.WriteLine(group.Key);
//            }
//            else
//            {
//                Console.WriteLine($"{group.Count()}x {group.Key}");
//            }
//        }

//        if (!string.IsNullOrEmpty(testTranslation))
//        {
//            Console.WriteLine(testTranslation);
//        }

//        Console.WriteLine("");
//    }
//}
//    }