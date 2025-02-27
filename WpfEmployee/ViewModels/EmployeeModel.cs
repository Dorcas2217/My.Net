﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeModel : INotifyPropertyChanged
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

        private readonly Employee _employee;

        public EmployeeModel(Employee employee)
        {
            _employee = employee;
        }

        public Employee Employee => _employee;

        public String LastName
        {
            get { return _employee.LastName; }
            set
            {
                _employee.LastName = value;
                OnPropertyChanged("FullName");
            }
        }
        public String FirstName
        {
            get { return _employee.FirstName; }
            set
            {
                _employee.FirstName = value;
                OnPropertyChanged("FullName");

            }
        }
        public DateTime? BirthDate
        {
            get { return _employee.BirthDate; }
            set
            {
                _employee.BirthDate = value;
                OnPropertyChanged("DisplayBirthDate");
            }
        }
        public DateTime? HireDate
        {
            get { return _employee.HireDate; }
            set
            {
                _employee.HireDate = value;


            }
        }
        public string FullName => _employee.LastName + " " + _employee.FirstName;

        public string? Title  => _employee.Title;
        public String DisplayBirthDate
        {
            get
            {
                if (_employee.BirthDate.HasValue)
                {
                    return _employee.BirthDate.Value.ToShortDateString();
                }

                return "";
            }
        }

        public string TitleOfCourtesy
        {
            get { return _employee.TitleOfCourtesy; }
            set
            {
                _employee.TitleOfCourtesy = value;
            }
        }
    }
}
