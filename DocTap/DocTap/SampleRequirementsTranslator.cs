namespace DocTap
{
    public interface ISampleRequirementsTranslator
    {
        Instructions Translate(string input);
    }

    public class SampleRequirementsTranslator : ISampleRequirementsTranslator
    {
        public Instructions Translate(string input)
        {
            var inputParts = input.Split(' ').Where(x => !string.IsNullOrEmpty(x));

            var intructions = new Instructions();

            foreach (var part in inputParts)
            {
                if (DataStore.TubeColours.ContainsKey(part))
                {
                    intructions.TubeColours.Add(part);
                }
                else if (DataStore.TestTypes.ContainsKey(part))
                {
                    if (!string.IsNullOrEmpty(intructions.TestType))
                    {
                        throw new Exception();
                    }

                    intructions.TestType = part;
                }
                else
                {
                    throw new InvalidSampleRequirementCode();
                }
            }

            return intructions;
        }
    }
}
