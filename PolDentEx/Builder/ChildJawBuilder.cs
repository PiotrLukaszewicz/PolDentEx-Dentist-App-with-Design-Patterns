using PolDentEx.Models;

namespace PolDentEx.Builder
{
    public class ChildJawBuilder : JawBuilder
    {
        
             
        public override void BuildJaw(int patientId)
        {
            for (int i = 1; i <= 32; i++)
            {
                Product.Add(new Tooth
                {
                    PatientCardId = patientId,
                    Extracted = true,
                    HumanToothId = i,
                    ToothId = i
                });
            }
            for (int i = 33; i <= 52; i++)
            {
                Product.Add(new Tooth
                {
                    PatientCardId = patientId,
                    Extracted = false,
                    HumanToothId = i,
                    ToothId = i
                });
            }
        }
    }
}