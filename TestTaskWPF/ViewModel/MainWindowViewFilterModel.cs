using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestTaskWPF.DAO.DataAccessObject;
using TestTaskWPF.DAO.DataBaseSelectByFilter;
using TestTaskWPF.Models;

namespace TestTaskWPF.ViewModel
{
  partial  class MainWindowViewModel : ViewModelBase
    {
        //Фильтр не начатые
        private ICommand _chboxStartFilter;
        public ICommand ChboxStartFilter
        {
            get
            {
                if (_chboxStartFilter == null)
                    _chboxStartFilter = new RelayCommand(ChboxStartFilterClick);
                return _chboxStartFilter;
            }
            set
            {
                _createNode = value;
            }
        }
   
        void ChboxStartFilterClick(object param)
        {
            try
            {
                obj = new DataAccessObject(new SelectByNotStarted(taskNodeContext));
                ListTask = new ObservableCollection<TaskNode>(obj.ExecuteFilter() as List<TaskNode>);

                ChboxFinishChecked = false;
                ChboxProgressChecked = false;
            }
            catch { }
        }

        //Фильтр в работе
        private ICommand _checkBoxProgressFilter;
        public ICommand CheckBoxProgressFilter
        {
            get
            {
                if (_checkBoxProgressFilter == null)
                    _checkBoxProgressFilter = new RelayCommand(ChboxProgressFilterClick);
                return _checkBoxProgressFilter;
            }
            set
            {
                _checkBoxProgressFilter = value;
            }
        }
        void ChboxProgressFilterClick(object param)
        {
            try
            {
                obj = new DataAccessObject(new SelectByProgress(taskNodeContext));
                ListTask = new ObservableCollection<TaskNode>(obj.ExecuteFilter() as List<TaskNode>);

                ChboxStartChecked = false;
                ChboxFinishChecked = false;
            }
            catch { }
        }

        //Фильтр выполненые
        private ICommand _chboxFinishFilter;
        public ICommand ChboxFinishFilter
        {
            get
            {
                if (_chboxFinishFilter == null)
                    _chboxFinishFilter = new RelayCommand(ChboxFinishFilterClick);
                return _chboxFinishFilter;
            }
            set
            {
                _chboxFinishFilter = value;
            }
        }
        void ChboxFinishFilterClick(object param)
        {
            try
            {
                obj = new DataAccessObject(new SelectByFinished(taskNodeContext));
                ListTask = new ObservableCollection<TaskNode>(obj.ExecuteFilter() as List<TaskNode>);

                ChboxStartChecked = false;
                ChboxProgressChecked = false;
            }
            catch { }
        }


        //Привязка CheckBox.IsChecked для филтрации
        private bool _chboxStartChecked;

        public bool ChboxStartChecked
        {
            get { return _chboxStartChecked; }
            set
            {
                _chboxStartChecked = value;
                OnPropertyChanged();
            }
        }


        private bool _chboxProgressChecked;

        public bool ChboxProgressChecked
        {
            get { return _chboxProgressChecked; }
            set
            {
                _chboxProgressChecked = value;
                OnPropertyChanged();
            }
        }


        private bool _chboxFinishChecked;

        public bool ChboxFinishChecked
        {
            get { return _chboxFinishChecked; }
            set
            {
                _chboxFinishChecked = value;
                OnPropertyChanged();
            }
        }


        //фильтр по заголовку отрабатывает на событие KeyUp
        private ICommand _textCommand;
        public ICommand TextChange
        {
            get
            {
                if (_textCommand == null)
                    _textCommand = new RelayCommand(TextChangedCommandClick);
                return _textCommand;
            }
            set
            {
                _textCommand = value;
            }
        }
        void TextChangedCommandClick(object param)
        {
            try
            {
                string text = (param as TextBox).Text;
                obj = new DataAccessObject(new SelectByTitle(taskNodeContext, text));
                ListTask = new ObservableCollection<TaskNode>(obj.ExecuteFilter() as List<TaskNode>);

            }
            catch { }
             
        }


      

        private string _textBoxText;
        public string TextBoxText
        {
            get { return _textBoxText; }
            set
            {
                _textBoxText = value;       
                OnPropertyChanged();
            }
        }


        //Фильтр начало выполнения
        private ICommand _dateStartChanged;
        public ICommand DateStartChanged
        {
            get
            {
                if (_dateStartChanged == null)
                    _dateStartChanged = new RelayCommand(DateStartChangedClick);
                return _dateStartChanged;
            }
            set
            {
                _dateStartChanged = value;
            }
        }
        void DateStartChangedClick(object param)
        {
            try
            {
                var selectedDate = DateStart;
                obj = new DataAccessObject(new SelectByStartDate(taskNodeContext, (DateTime) selectedDate));
                ListTask = new ObservableCollection<TaskNode>(obj.ExecuteFilter() as List<TaskNode>);
            }
            catch { }

        }

        private DateTime? _dateStart=null ;
        public DateTime? DateStart
        {
            get { return _dateStart; }
            set
            {
                _dateStart = value;
                OnPropertyChanged();
            }
        }

        //Фильтр задача выполнена
        private ICommand _dateFinishChanged;
        public ICommand DateFinishChanged
        {
            get
            {
                if (_dateFinishChanged == null)
                    _dateFinishChanged = new RelayCommand(DateFinishChangedClick);
                return _dateFinishChanged;
            }
            set
            {
                _dateStartChanged = value;
            }
        }
        void DateFinishChangedClick(object param)
        {
            try
            {
                var selected = DateFinish;
                obj = new DataAccessObject(new SelectByFinishDate(taskNodeContext, (DateTime)selected));
                ListTask = new ObservableCollection<TaskNode>(obj.ExecuteFilter() as List<TaskNode>);
            }
            catch { }

        }

        private DateTime? _datFinish = null;
        public DateTime? DateFinish
        {
            get { return _datFinish; }
            set
            {
                _datFinish = value;
                OnPropertyChanged();
            }
        }
    }
}
