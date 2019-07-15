using Newtonsoft.Json;
using PolDentEx.DAL;
using PolDentEx.Models;
using System.Collections.Generic;
using System.Linq;

namespace PolDentEx.JawAdapter
{
    public class JawAdapter
    {
        /// <summary>
        /// Funkcja generująca JSON ze wszystkimi zębami danego pacjenta
        /// </summary>
        /// <param name="patientcardId"></param>
        /// <returns>string JSON</returns>
        public string GenerateJawData(int patientcardId)
        {
            ToothRepository toothRepository = new ToothRepository();
            List<Tooth> jaw =
                toothRepository.GetAll().ToList().Where(t => t.PatientCard.PatientCardId == patientcardId).Select(tt=> new Tooth()
                {
                    ToothId = tt.ToothId,
                    HumanToothId = tt.HumanToothId,
                    HumanTooth = tt.HumanTooth,
                    Note1 = tt.Note1,
                    Note2 = tt.Note2,
                    Note3 = tt.Note3,
                    Note4 = tt.Note4,
                    Extracted = tt.Extracted,
                    PatientCardId = tt.PatientCardId,
                }).ToList();


            var output = JsonConvert.SerializeObject(jaw);
            return output;
        }
    }
}

//Offtopic => deserializacja takiego cuda
//Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);