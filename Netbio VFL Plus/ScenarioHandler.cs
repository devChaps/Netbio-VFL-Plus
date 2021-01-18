using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netbio_VFL_Plus
{
    public static class ScenarioHandler
    {


        public static string ARC2_SCE(string archive_string)
        {
            string SCE_NAME = archive_string.Substring(2, 2);

            switch (SCE_NAME.ToLower())
            {
                case "01": return "Outbreak"; break;
                case "02": return "Hellfire"; break;
                case "28": return "The Hive"; break;
                case "35": return "Below Freezing Point"; break;
                case "41": return "Decisions, Decisions"; break;
                case "06": return "End of the Road"; break;
                case "15": return "Desperate Times"; break;
                case "10": return "Underbelly"; break;
                case "26": return "Flashback"; break;
                case "40": return "Wild Things"; break;
                case "20": return "Training Ground"; break;
                case "21": return "Showdown 1"; break;
                case "22": return "Showdown 2"; break;
                case "23": return "Showdown 3"; break;
                case "27": return "Elimination 1"; break;
                case "29": return "Elimination 2"; break;
                case "30":
                    return "Elimination 3"; break;
            }


            return string.Empty;

        }

        public static string ARC2_VAL(string archive_string)
        {          
            return archive_string.Substring(2, 2); 
        }


        public static byte GAME_CHECK(string archive_string) 
        {
            byte game = 0;

            switch (archive_string.Substring(2, 2))
            {
                case "01":
                case "02":
                case "28":
                case "35":
                case "41":
                    game = 0;
                    break;
                case "06": 
                case "15": 
                case "10":
                case "26": 
                case "20":
                case "21":
                case "22":
                case "23":
                case "27":
                case "29":
                case "30":
                case "40":
                    game = 1;
                    break;



            }

            return game;
        }

    }
}
