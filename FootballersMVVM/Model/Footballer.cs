using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace FootballersMVVM.Model
{
    public class Footballer
    {

        #region Prop
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public uint Weight { get; set; }
        #endregion

        #region constr
        public Footballer() {}

        public Footballer(string name, string surname, uint age, uint weight)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Weight = weight;
        }
        public Footballer(string Name, string Surname) : this(Name, Surname, 30, 75) { }
        #endregion
        
        #region methods

        public void Edit(Footballer fballer)
        {
            Name = fballer.Name.ToUpper();
            Surname = fballer.Surname.ToUpper();
            Age = fballer.Age;
            Weight = fballer.Weight;
        }

        public override string ToString()
        {
            return $"{Surname} {Name} lat: {Age} waga: {Weight} kg";
        }

        #endregion
    }
}
