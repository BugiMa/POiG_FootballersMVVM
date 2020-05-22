using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace FootballersMVVM.Model
{
    class Squad
    {
        public List<Footballer> SquadMembers { get; set; }

        public Squad()
        {
            SquadMembers = LoadSquad(); ;
        }
        
        public static List<Footballer> LoadSquad()
        {
            return FileOperations.LoadFromFile();
        }

        public void SaveSquad()
        {
            FileOperations.SaveToFile(SquadMembers);
        }

        public void Add(Footballer fballer)
        {
            SquadMembers.Add(fballer);
        }

        public void Edit(Footballer fballer, int index)
        {
            SquadMembers[index] = fballer;
        }

        public void Delete(int index)
        {
            SquadMembers.RemoveAt(index);
        }

        public bool AlreadyExist(Footballer fballer)
        {
            foreach(Footballer member in SquadMembers)
            {
                if (member.Name == fballer.Name && member.Surname == fballer.Surname && member.Age == fballer.Age && member.Weight == fballer.Weight)
                    return true;
            }
            return false;
        }

        public List<string> ListOfMembers()
        {
            List<string> squadToString = new List<string> ();
            foreach( Footballer member in SquadMembers)
            {
                squadToString.Add(member.ToString());
            }
            return squadToString;
        }
    }
}
