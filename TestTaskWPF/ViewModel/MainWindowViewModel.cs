using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestTaskWPF.DAO.DataAccessObject;
using TestTaskWPF.DAO.DataBaseSelectByFilter;
using TestTaskWPF.DAO.DataBaseUtils;
using TestTaskWPF.Models;
using TestTaskWPF.View;

namespace TestTaskWPF.ViewModel
{
    partial  class MainWindowViewModel : ViewModelBase
    {
        CreateNodeWindow _createNodeWindow;

        TaskNodeContext taskNodeContext;

        DataAccessObject obj;

        //конструктор и загрузка элементов
        public MainWindowViewModel() {

            taskNodeContext = new TaskNodeContext();

            try
            {
                obj = new DataAccessObject(new SelectAllTask(taskNodeContext));
                ListTask = new ObservableCollection<TaskNode>(obj.ExecuteFilter() as List<TaskNode>);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }


        }

        //коллекция задач для отображения в ListBox
        ObservableCollection<TaskNode> _listTask;
        public ObservableCollection<TaskNode> ListTask
        {
            get
            {
                if(_listTask==null)
                {
                    _listTask = new ObservableCollection<TaskNode>();
                }
                return _listTask;
            }
            set
            {
                _listTask = value;
                OnPropertyChanged();
            }
        }



        //открыть окно для создания новой задачи
        private ICommand _createNode;
        public ICommand CreateNode
        {
            get
            {
                if (_createNode == null)
                    _createNode = new RelayCommand(CreateNodeClick);
                return _createNode;
            }
            set
            {
                _createNode = value;
            }
        }
        void CreateNodeClick(object param)
        {     
            _createNodeWindow = new CreateNodeWindow();
            _createNodeWindow.TaskPropertyChanged += _createNodeWindow_TaskPropertyChanged;
            _createNodeWindow.ShowDialog();
        }


        //добавление новой задачи
        private void _createNodeWindow_TaskPropertyChanged(object sender, EventArgs e)
        {
            TaskNode taskNode = _createNodeWindow.TaskNode;
            _createNodeWindow.Close();
            try
            {
                obj = new DataAccessObject(new AddNewTask(taskNodeContext, taskNode));
                obj.ExecuteUtils();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());

            }

            try {
                obj = new DataAccessObject(new SelectAllTask(taskNodeContext));
                ListTask = new ObservableCollection<TaskNode>(obj.ExecuteFilter() as List<TaskNode>);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        //установить значение выполнено
        private ICommand _chboxSetFinish;
        public ICommand ChboxSetFinish
        {
            get
            {
                if (_chboxSetFinish == null)
                    _chboxSetFinish = new RelayCommand(ChboxSetFinishClick);
                return _chboxSetFinish;
            }
            set
            {
                _chboxSetFinish = value;
            }
        }

        void ChboxSetFinishClick(object param)
        {
            try
            {
                TaskNode taskNode = (param as TaskNode);

                taskNode.IsFinish = true;
                taskNode.IsProgress = false;
                taskNode.IsStart = false;

                DateTime date = DateTime.Now;
                taskNode.DateFinish = date.Date;
                taskNode.Status = "Выполнена";


                obj = new DataAccessObject(new UpdateTaskNode(taskNodeContext, taskNode));
                obj.ExecuteUtils();

                obj = new DataAccessObject(new SelectAllTask(taskNodeContext));
                ListTask = new ObservableCollection<TaskNode>(obj.ExecuteFilter() as List<TaskNode>);               
            }
            catch { }
        }

    }
}
