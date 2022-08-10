using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DisplayedDocument : INotifyPropertyChanged
    {
        private int _year;

        public int Year { get => _year;
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }

        private int _january = 0;

        private int _february = 0;

        private int _march = 0;

        private int _april = 0;

        private int _may = 0;

        private int _june = 0;

        private int _july = 0;

        private int _august = 0;

        private int _september = 0;

        private int _october = 0;

        private int _november = 0;

        private int _december = 0;

        [DisplayName("Январь")]
        public int January { get => _january; set
            {
                _january = value;
                OnPropertyChanged("January");
            }
        }

        [DisplayName("Февраль")]
        public int February { get => _february; set
            {
                _february = value;
                OnPropertyChanged("February");
            }
        }

        [DisplayName("Март")]
        public int March { get => _march; set
            {
                _march = value;
                OnPropertyChanged("March");
            }
        }

        [DisplayName("Апрель")]
        public int April { get => _april; set
            {
                _april = value;
                OnPropertyChanged("April");
            }
        }

        [DisplayName("Май")]
        public int May { get => _may; set
            {
                _may = value;
                OnPropertyChanged("May");
            }
        }

        [DisplayName("Июнь")]
        public int June { get => _june; set
            {
                _june = value;
                OnPropertyChanged("June");
            }
        }

        [Display(Name = "Июль")]
        public int July { get => _july; set
            {
                _july = value;
                OnPropertyChanged("Июль");
            }
        } 

        [DisplayName("Август")]
        public int August { get => _august; set
            {
                _august = value;
                OnPropertyChanged("August");
            }
        }

        [DisplayName("Сентябрь")]
        public int September { get => _september; set
            {
                _september = value;
                OnPropertyChanged("September");
            }
        }

        [DisplayName("Октябрь")]
        public int October { get => _october; set
            {
                _october = value;
                OnPropertyChanged("October");
            }
        }

        [DisplayName("Ноябрь")]
        public int November { get => _november; set
            {
                _november = value;
                OnPropertyChanged("November");
            }
        }

        [DisplayName("Декабрь")]
        public int December { get => _december; set
            {
                _december = value;
                OnPropertyChanged("December");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string porp = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(porp));
        }

    }
}
