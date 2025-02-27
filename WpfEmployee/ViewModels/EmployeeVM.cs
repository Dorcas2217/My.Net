﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private NorthwindContext context = new NorthwindContext();
        private List<EmployeeModel> _employeesList;
        private List<string> _listTitle;
        private EmployeeModel _employeeSelected;
        private DelegateCommand _addCommand;
        private DelegateCommand _saveCommand;

        public List<EmployeeModel> EmployeesList
        {
            get
            {
                return _employeesList = _employeesList ?? loadEmployees();
            }
        }

        private List<EmployeeModel> loadEmployees()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
            foreach (var item in context.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
            }
            return localCollection;
        }

        public List<string> ListTitle
        {
            get { return _listTitle = _listTitle ?? loadTitle(); }
        }

        private List<string> loadTitle()
        {
           return context.Employees.Select(x => x.TitleOfCourtesy).Distinct().ToList();
        }

        public EmployeeModel EmployeeSelected
        {
            get { return _employeeSelected; }
            set
            {
                _employeeSelected = value;
                OnPropertyChanged("EmployeeSelected");
            }
        }

        public DelegateCommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new DelegateCommand(SaveEmployee); }
        }

        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand = _addCommand ?? new DelegateCommand(AddEmployee);
            }

        }

        private void AddEmployee()
        {
            Employee EGlobal = new Employee();
            EmployeeModel EModel = new EmployeeModel(EGlobal);
            EmployeesList.Add(EModel);
            _employeeSelected = EModel;
        }

        private void SaveEmployee()
        {
            Employee verif = context.Employees.Where(e => e.EmployeeId == _employeeSelected.Employee.EmployeeId).SingleOrDefault();
            if (verif == null)
            {
                context.Employees.Add(_employeeSelected.Employee);
            }

            context.SaveChanges();
            MessageBox.Show("Enregistrement en base de données fait");
        }
    }
}


