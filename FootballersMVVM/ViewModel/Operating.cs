using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FootballersMVVM.ViewModel
{
    using Model;
    using BaseClass;

    internal class Operating: ViewModelBase
    {
        public Squad squad = new Squad();
        public List<string> MemberList {get => squad.ListOfMembers();}

        #region User Interface

        public string NameTextBox { get; set; }
        public string SurnameTextBox { get; set; }
        public uint AgeSlider { get; set; } = 30;
        public uint WeightSlider { get; set; } = 75;
        
        public int Index { get; set; } = -1;
        public string Member { get; set; }

        #endregion

        #region Operations
        private ICommand _add = null;
        private ICommand _edit = null;
        private ICommand _delete = null;
        private ICommand _load = null;
        private ICommand _save = null;
        
        #region Adding new footballer operation
        public ICommand Add
        { 
            get
            {
                if (_add == null)
                {
                    _add = new RelayCommand(
                        arg => { squad.Add(new Footballer(NameTextBox, SurnameTextBox, AgeSlider, WeightSlider));
                                 onPropertyChanged(nameof(MemberList));
                        },
                        arg => (!squad.AlreadyExist(new Footballer(NameTextBox, SurnameTextBox, AgeSlider, WeightSlider)) &&
                                !string.IsNullOrEmpty(NameTextBox) &&
                                !string.IsNullOrEmpty(SurnameTextBox) &&
                                NameTextBox.All(Char.IsLetter) &&
                                SurnameTextBox.All(Char.IsLetter))
                                
                        );
                }
                return _add;
            }
        }
        
        #endregion

        #region Editing existing footballer operation
        public ICommand Edit
        {
            get
            {
                if (_edit == null)
                {
                    _edit = new RelayCommand(
                        arg => { squad.Edit(new Footballer(NameTextBox, SurnameTextBox, AgeSlider, WeightSlider), Index);
                                 onPropertyChanged(nameof(MemberList));
                        },
                        arg => (Index > -1 &&
                               !squad.AlreadyExist(new Footballer(NameTextBox, SurnameTextBox, AgeSlider, WeightSlider)) &&
                               !string.IsNullOrEmpty(NameTextBox) &&
                               !string.IsNullOrEmpty(SurnameTextBox) &&
                               NameTextBox.All(Char.IsLetter) &&
                               SurnameTextBox.All(Char.IsLetter))
                        );
                }
                return _edit;
            }
        }
        #endregion

        #region Deleting existiong footballer operation
        public ICommand Delete
        {
            get
            {
                if (_delete == null)
                {
                    _delete = new RelayCommand(
                        arg => { squad.Delete(Index);
                                 onPropertyChanged(nameof(MemberList));
                        },
                        arg => Index > -1 
                        );
                }
                return _delete;
            }
        }
        #endregion

        #region Load footballer operation
        public ICommand Load
        {
            get
            {
                if (_load == null)
                {
                    _load = new RelayCommand(
                        arg => { 
                            Footballer fballer = squad.SquadMembers[Index];
                            NameTextBox = fballer.Name;
                            SurnameTextBox = fballer.Surname;
                            AgeSlider = fballer.Age;
                            WeightSlider = fballer.Weight;
                            onPropertyChanged(nameof(NameTextBox), nameof(SurnameTextBox), nameof(AgeSlider), nameof(WeightSlider));
                        },
                        arg => Index > -1
                        );
                }
                return _load;
            }
        }
        #endregion

        #region Save footballer operation
        public ICommand Save
        {
            get
            {
                if (_save == null)
                {
                    _save = new RelayCommand(
                        arg => { squad.SaveSquad(); },
                        arg => true
                        );
                }
                return _save;
            }
        }
        #endregion

        #endregion
    }
}
